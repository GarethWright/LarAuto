Imports System.Windows.Forms
Imports System.Net
Imports System.ComponentModel
Imports Ionic.Zip
Imports System.IO
Imports Microsoft.Office.Interop.Access.Dao


Module larAuto

    Private Sub _DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' File download completed

        Console.WriteLine("Download completed")
    End Sub
    Private Sub _DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        ' Update progress bar
        Console.Write(".." + e.ProgressPercentage.ToString())
    End Sub

    Private Sub Extract(ByVal zipToUnpack As String, ByVal filename As String)
        Dim path As String = filename.Substring(filename.LastIndexOf("\") + 1)

        Dim UnpackDirectory As String = filename.Substring(0, filename.LastIndexOf("\") + 1)
        Using zip1 As ZipFile = ZipFile.Read(zipToUnpack)
            Dim e As ZipEntry
            ' here, we extract every entry, but we could extract conditionally,
            ' based on entry name, size, date, checkbox status, etc.   
            zip1.Item(0).FileName = filename.Substring(filename.LastIndexOf("\"))
            zip1.Save()

            For Each e In zip1


                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)


            Next
        End Using

    End Sub

    Public Class clsAccessMaint

        Function RepairDatabase(ByVal strSource As String, ByVal strDestination As String) As Boolean
            If File.Exists(strSource) = False Then
                Exit Function
            End If
            Try
                Dim acc As New Microsoft.Office.Interop.Access.Dao.DBEngine
                Console.WriteLine()
                Console.WriteLine("Compacting Database")
                acc.CompactDatabase(strSource, strDestination)
                My.Computer.FileSystem.DeleteFile(strSource)
                Console.WriteLine()
                Console.WriteLine("Replacing Old LARA")
                Dim strFileName As String = My.Computer.FileSystem.GetName(strSource)
                My.Computer.FileSystem.RenameFile(strDestination, strFileName)

            Catch ex As Exception

                Return False
            End Try
            Return True
        End Function
    End Class

    Sub Main()

        Dim s As New setupForm
        Console.BackgroundColor = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("Welcome to larAuto...Please wait while I check FEBoard for Updates")
        Console.WriteLine()
        If s.checkLogin(My.Settings.FEBoardLogin, My.Settings.FEBoardPass) Then

            
            Console.WriteLine("larAuto: Created by Gareth Wright.")
            Console.WriteLine()
            Console.WriteLine("Hello " + My.Settings.FEBoardLogin + ", thanks for using larAuto")
            Console.WriteLine("larAuto automatically checks for available Lara updates")
            Console.WriteLine()
            Console.WriteLine("LARA tends to be updated after 19:50")
            Console.WriteLine()
            Console.WriteLine("I'd suggest setting this to run as a job at 20:30")
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("Usage: larauto destinationFile dateOffset")
            Console.WriteLine()
            Console.WriteLine("eg. larauto k:\lara\laraLatest.mdb 0")
            Console.WriteLine()

            Dim args As String() = Environment.GetCommandLineArgs

            Dim destinationPath As String
            Try

                destinationPath = args(1)

            Catch ex As Exception

                Console.WriteLine("Usage: larauto destinationFile dateOffset")
                End
            End Try
            Dim dateOffset As Double
            Try
                dateOffset = args(2)
            Catch ex As Exception
                Console.WriteLine("Usage: larauto destinationFile dateOffset")
                End
            End Try
            args = Nothing
            Dim proxyObject
            If My.Settings.ProxyIP.Length > 0 Then
                proxyObject = New WebProxy(My.Settings.ProxyIP, CInt(My.Settings.ProxyPort))
            Else
                proxyObject = New WebProxy()
            End If

            proxyObject.UseDefaultCredentials = True


            Dim fileAddress As String = String.Empty
            Dim filename As String = String.Empty
            Try
                Dim fileReader As New WebClient()
                AddHandler fileReader.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf _DownloadFileCompleted)
                AddHandler fileReader.DownloadProgressChanged, New System.Net.DownloadProgressChangedEventHandler(AddressOf _DownloadProgressChanged)
                fileReader.Proxy = proxyObject
                fileReader.Headers.Add(HttpRequestHeader.KeepAlive, "999999999999")
                fileAddress = "https://gateway.imservices.org.uk/sites/LARA/Pages/LARADownload.aspx"
                Dim content As String = fileReader.DownloadString(fileAddress)

                Console.WriteLine("Looking for files on date:" + Now().AddDays(dateOffset).ToString)

                Dim dateSearchString = Now().AddDays(dateOffset).ToString("yyyyMMdd")



                If content.Contains("LARA_" + dateSearchString + "_1213_MDB") Then
                    Console.WriteLine()
                    Console.WriteLine("New file found...downloading...")
                    fileAddress = "https://gateway.imservices.org.uk/sites/LARA/Lists/LARAPubDBs/LARA_" + dateSearchString + "_1213_MDB.zip"

                    fileReader.DownloadFile(New Uri(fileAddress), destinationPath + ".zip")
                    Console.WriteLine()
                    Console.WriteLine("File downloaded to " + destinationPath + ".zip")


                    Console.Write("Extracting LARA MDB")
                    Extract(destinationPath + ".zip", destinationPath)
                    Dim acc As New clsAccessMaint
                    Dim tmpPath As String = destinationPath.Substring(0, destinationPath.LastIndexOf("\") + 1)
                    If File.Exists(tmpPath + "tmp.mdb") Then
                        File.Delete(tmpPath + "tmp.mdb")
                    End If
                    acc.RepairDatabase(destinationPath, tmpPath + "tmp.mdb")

                    Try
                        If Not File.Exists("\\puck\cisshared\lara downloads\LARA_" + dateSearchString + "_1213.mdb") Then
                            File.Copy(destinationPath, "\\puck\cisshared\lara downloads\LARA_" + dateSearchString + "_1213.mdb")
                        End If

                    Catch ex As Exception

                    End Try

                    Console.WriteLine()
                    Console.WriteLine("Washing hands....")
                    Try
                        File.Delete(destinationPath + ".zip")
                    Catch ex As Exception

                    End Try
                Else

                    Console.Write("Nothing new to download")
                End If
                Console.WriteLine("Done")
                End
            Catch ex As HttpListenerException
                Console.WriteLine("Error accessing " + fileAddress + " - " + ex.Message)
            Catch ex As Exception
                Console.WriteLine("Error accessing " + fileAddress + " - " + ex.Message)
            End Try


        Else
            Console.Write("Invalid FEBoard Credentials")
        End If


    End Sub

End Module
