' =====================================================================
'
' ShellLink - Using WSH to program shell links
'
' by Jim Hollenhorst, jwtk@ultrapico.com
' Copyright Ultrapico, April 2003
' http://www.ultrapico.com
'
' =====================================================================
Imports System.Windows.Forms
Imports System.IO
Imports IWshRuntimeLibrary

Namespace ShellLinks
    ''' <summary>
    ''' Summary description for Link.
    ''' </summary>
    Public Class Link
        ''' <summary>
        ''' Check to see if a shortcut exists in a given directory with a specified file name
        ''' </summary>
        ''' <param name="DirectoryPath">The directory in which to look</param>
        ''' <param name="LinkPathName">The name of the shortcut (without the .lnk extension) or the full path to a file of the same name</param>
        ''' <returns>Returns true if the link exists</returns>
        Public Shared Function Exists(ByVal DirectoryPath As String, ByVal LinkPathName As String) As Boolean
            ' Get some file and directory information
            Dim SpecialDir As New DirectoryInfo(DirectoryPath)
            ' First get the filename for the original file and create a new file
            ' name for a link in the Startup directory
            '
            Dim originalfile As New FileInfo(LinkPathName)
            Dim NewFileName As String = SpecialDir.FullName & "\" & originalfile.Name & ".lnk"
            Dim linkfile As New FileInfo(NewFileName)
            Return linkfile.Exists
        End Function

        'Check to see if a shell link exists to the given path in the specified special folder
        ' return true if it exists
        Public Shared Function Exists(ByVal folder As Environment.SpecialFolder, ByVal LinkPathName As String) As Boolean
            Return Link.Exists(Environment.GetFolderPath(folder), LinkPathName)
        End Function


        ' boolean variable "install" determines whether the link should be there or not.
        ' Update the folder by creating or deleting the link as required.

        ''' <summary>
        ''' Update the specified folder by creating or deleting a Shell Link if necessary
        ''' </summary>
        ''' <param name="DirectoryPath">The full path of the directory in which the link will reside</param>
        ''' <param name="TargetPathName">The path name of the target file for the link</param>
        ''' <param name="LinkPathName">The file name for the link itself or, if a path name the directory information will be ignored.</param>
        ''' <param name="Create">If true, create the link, otherwise delete it</param>
        Public Shared Sub Update(ByVal DirectoryPath As String, ByVal TargetPathName As String, ByVal LinkPathName As String, ByVal args As String, ByVal Create As Boolean)
            ' Get some file and directory information
            Dim SpecialDir As New DirectoryInfo(DirectoryPath)
            ' First get the filename for the original file and create a new file
            ' name for a link in the Startup directory
            '
            Dim OriginalFile As New FileInfo(LinkPathName)
            Dim NewFileName As String = SpecialDir.FullName & "\" & OriginalFile.Name & ".lnk"
            Dim LinkFile As New FileInfo(NewFileName)

            If Create Then
                ' If the link doesn't exist, create it
                If LinkFile.Exists Then
                    Return
                End If
                ' We're all done if it already exists
                'Place a shortcut to the file in the special folder 
                Try
                    ' Create a shortcut in the special folder for the file
                    ' Making use of the Windows Scripting Host
                    Dim shell As New WshShell()
                    Dim link As IWshShortcut = DirectCast(shell.CreateShortcut(LinkFile.FullName), IWshShortcut)
                    link.TargetPath = TargetPathName
                    link.Arguments = args
                    link.Save()
                Catch
                    MessageBox.Show("Unable to create link in special directory: " & NewFileName, "Shell Link Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            Else
                ' otherwise delete it from the startup directory
                If Not LinkFile.Exists Then
                    Return
                End If
                ' It doesn't exist so we are done!
                Try
                    LinkFile.Delete()
                Catch
                    MessageBox.Show("Error deleting link in special directory: " & NewFileName, "Shell Link Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try
            End If
        End Sub

    End Class
End Namespace
