Imports System.Net
Imports System.Management
Imports IWshRuntimeLibrary
Imports LARAuto.ShellLinks


Public Class setupForm

    Private Sub setupForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        My.Settings.ProxyIP = txtIP.Text
        My.Settings.ProxyPort = txtPort.Text
        My.Settings.FEBoardLogin = txtLogin.Text
        My.Settings.FEBoardPass = txtPass.Text

        My.Settings.FirstLoad = False

        My.Settings.Save()
        End
    End Sub
    Private Sub CreateShortcut(ByVal args As String)
        Dim targetPath As String
        targetPath = My.Application.Info.DirectoryPath + "\larauto.exe"

        Link.Update(My.Application.Info.DirectoryPath, targetPath, "Run LarAuto", "", False)
        Link.Update(My.Application.Info.DirectoryPath, targetPath, "Run LarAuto", args, True)
    End Sub


    Private Function isSetup() As Boolean
        Try
            Dim args() As String = Environment.GetCommandLineArgs

            If args(1) = "-setup" Then
                Return True
            Else
                Return False

            End If

        Catch ex As Exception
            Return False
        End Try



    End Function
    Private Sub setupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim args() As String = Environment.GetCommandLineArgs


        If My.Settings.FirstLoad = True Or isSetup() Then




            'If checkProxy(txtIP.Text, txtPort.Text) Then
            '    lblCheckProxy.ForeColor = Drawing.Color.Green
            '    lblCheckProxy.Text = "Proxy OK"
            'Else
            '    lblCheckProxy.ForeColor = Drawing.Color.Red
            '    lblCheckProxy.Text = "Error"
            'End If
            'If checkLogin(txtLogin.Text, txtPass.Text) Then
            '    lblCheckLogin.ForeColor = Drawing.Color.Green
            '    lblCheckLogin.Text = "login OK"
            'Else
            '    lblCheckLogin.ForeColor = Drawing.Color.Red
            '    lblCheckLogin.Text = "Error"
            'End If
        Else

            larAuto.Main()
            Me.Close()


        End If

    End Sub


    Public Function checkProxy(ByVal ip As String, ByVal port As String) As Boolean
        Dim proxyObject
        If ip.Length > 0 Then
            proxyObject = New WebProxy(ip, CInt(port))
        Else
            proxyObject = New WebProxy()
        End If

        proxyObject.UseDefaultCredentials = True

        Dim fileAddress As String = String.Empty
        Dim filename As String = String.Empty
        Try
            Dim fileReader As New wccWebClient()
            'AddHandler fileReader.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf _DownloadFileCompleted)
            ' AddHandler fileReader.DownloadProgressChanged, New System.Net.DownloadProgressChangedEventHandler(AddressOf _DownloadProgressChanged)
            fileReader.Proxy = proxyObject
            fileReader.Headers.Add(HttpRequestHeader.KeepAlive, "999999999999")
            fileReader.Timeout = 10000
            fileAddress = "https://gateway.imservices.org.uk/sites/LARA/Pages/archive.aspx"
            Dim content As String = fileReader.DownloadString(fileAddress)

            Console.WriteLine("Checking Proxy....")

            Dim dateSearchString = Now().AddDays(-1).ToString("yyyyMMdd")



            If content.Contains("LARA_") Then
                Return True
            Else
                Return False
            End If

        Catch
            Return False
        End Try


    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If checkProxy(txtIP.Text, txtPort.Text) Then
            lblCheckProxy.ForeColor = Drawing.Color.Green
            lblCheckProxy.Text = "Proxy OK"
        Else
            lblCheckProxy.ForeColor = Drawing.Color.Red
            lblCheckProxy.Text = "Error"
        End If
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If checkLogin(txtLogin.Text, txtPass.Text) Then
            lblCheckLogin.ForeColor = Drawing.Color.Green
            lblCheckLogin.Text = "Login OK"
        Else
            lblCheckLogin.ForeColor = Drawing.Color.Red
            lblCheckLogin.Text = "Error"
        End If

    End Sub

    Public Function checkLogin(ByVal login As String, ByVal pass As String) As Boolean
        Dim proxyObject
        If txtIP.Text.Length > 0 Then
            proxyObject = New WebProxy(txtIP.Text, CInt(txtPort.Text))
        Else
            proxyObject = New WebProxy()
        End If

        proxyObject.UseDefaultCredentials = True

        Dim fileAddress As String = String.Empty
        Dim filename As String = String.Empty
        Try
            Dim fileReader As New wccWebClient()
            'AddHandler fileReader.DownloadFileCompleted, New AsyncCompletedEventHandler(AddressOf _DownloadFileCompleted)
            ' AddHandler fileReader.DownloadProgressChanged, New System.Net.DownloadProgressChangedEventHandler(AddressOf _DownloadProgressChanged)
            fileReader.Proxy = proxyObject
            fileReader.Timeout = 10000
            fileReader.Headers.Add(HttpRequestHeader.KeepAlive, "999999999999")
            fileAddress = "http://feboard.co.uk/larAuto.php?user=" + login + "&pass=" + pass
            Dim content As String = fileReader.DownloadString(fileAddress)

            Console.WriteLine("Checking Login details and lookup for updates")

            Dim dateSearchString = Now().AddDays(-1).ToString("yyyyMMdd")



            If content.Contains("1") Then
                Return True
            Else
                Return False
            End If

        Catch
            Return False
        End Try
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Select FolderBrowserDialog1.ShowDialog

            Case Windows.Forms.DialogResult.OK

                txtDownloadTo.Text = FolderBrowserDialog1.SelectedPath

        End Select

    End Sub

    Private Sub btnSaveShortcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveShortcut.Click
        Dim offset As String

        Select Case cbOffset.SelectedItem
            Case "Check for new files yesterday"
                offset = "-1"
            Case "Check for new files today"
                offset = "0"
        End Select

        Try
            Dim args As String = txtDownloadTo.Text + " " + offset.ToString
            CreateShortcut(args)
            MsgBox("Shortcut Created")
        Catch ex As Exception
            MsgBox("Unable to create shortcut")
        End Try
    
    End Sub

    Private Sub cbOffset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOffset.SelectedIndexChanged
        If Not cbOffset.SelectedItem = "Select..." And txtDownloadTo.Text.Length > 0 Then

            btnSaveShortcut.Enabled = True
        Else
            btnSaveShortcut.Enabled = False

        End If

    End Sub

    Private Sub txtDownloadTo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDownloadTo.KeyUp
        If Not cbOffset.SelectedItem = "Select..." And txtDownloadTo.Text.Length > 0 Then

            btnSaveShortcut.Enabled = True
        Else
            btnSaveShortcut.Enabled = False

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("iexplore http://feboard.co.uk/register")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        txtDownloadTo.Text = ".\LARA.mdb"
    End Sub
End Class