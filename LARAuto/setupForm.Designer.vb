<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setupForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.lblCheckProxy = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lblCheckLogin = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnSaveShortcut = New System.Windows.Forms.Button()
        Me.cbOffset = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDownloadTo = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.txtIP)
        Me.GroupBox1.Controls.Add(Me.lblCheckProxy)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 139)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proxy"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(98, 98)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Check Proxy"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Proxy Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Proxy IP"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(225, 55)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(53, 20)
        Me.txtPort.TabIndex = 2
        Me.txtPort.Text = Global.LARAuto.My.MySettings.Default.ProxyPort
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(6, 55)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(213, 20)
        Me.txtIP.TabIndex = 1
        Me.txtIP.Text = Global.LARAuto.My.MySettings.Default.ProxyIP
        '
        'lblCheckProxy
        '
        Me.lblCheckProxy.AutoSize = True
        Me.lblCheckProxy.ForeColor = System.Drawing.Color.Green
        Me.lblCheckProxy.Location = New System.Drawing.Point(225, 103)
        Me.lblCheckProxy.Name = "lblCheckProxy"
        Me.lblCheckProxy.Size = New System.Drawing.Size(0, 13)
        Me.lblCheckProxy.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.lblCheckLogin)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.txtPass)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtLogin)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(359, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(290, 139)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FEBoard Login"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(238, 16)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 5
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Register"
        '
        'lblCheckLogin
        '
        Me.lblCheckLogin.AutoSize = True
        Me.lblCheckLogin.ForeColor = System.Drawing.Color.Green
        Me.lblCheckLogin.Location = New System.Drawing.Point(228, 108)
        Me.lblCheckLogin.Name = "lblCheckLogin"
        Me.lblCheckLogin.Size = New System.Drawing.Size(0, 13)
        Me.lblCheckLogin.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(88, 103)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Check login"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPass
        '
        Me.txtPass.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LARAuto.My.MySettings.Default, "FEBoardPass", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtPass.Location = New System.Drawing.Point(159, 55)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(111, 20)
        Me.txtPass.TabIndex = 8
        Me.txtPass.Text = Global.LARAuto.My.MySettings.Default.FEBoardPass
        Me.txtPass.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Password"
        '
        'txtLogin
        '
        Me.txtLogin.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.LARAuto.My.MySettings.Default, "FEBoardLogin", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtLogin.Location = New System.Drawing.Point(10, 55)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(111, 20)
        Me.txtLogin.TabIndex = 6
        Me.txtLogin.Text = Global.LARAuto.My.MySettings.Default.FEBoardLogin
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Login"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.btnSaveShortcut)
        Me.GroupBox3.Controls.Add(Me.cbOffset)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.btnBrowse)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtDownloadTo)
        Me.GroupBox3.Location = New System.Drawing.Point(30, 246)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(619, 155)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Create Shortcut"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(88, 70)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Use larAuto Folder"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnSaveShortcut
        '
        Me.btnSaveShortcut.Enabled = False
        Me.btnSaveShortcut.Location = New System.Drawing.Point(417, 111)
        Me.btnSaveShortcut.Name = "btnSaveShortcut"
        Me.btnSaveShortcut.Size = New System.Drawing.Size(121, 23)
        Me.btnSaveShortcut.TabIndex = 5
        Me.btnSaveShortcut.Text = "Save Shortcut"
        Me.btnSaveShortcut.UseVisualStyleBackColor = True
        '
        'cbOffset
        '
        Me.cbOffset.FormattingEnabled = True
        Me.cbOffset.Items.AddRange(New Object() {"Check for new files yesterday", "Check for new files today"})
        Me.cbOffset.Location = New System.Drawing.Point(339, 43)
        Me.cbOffset.Name = "cbOffset"
        Me.cbOffset.Size = New System.Drawing.Size(260, 21)
        Me.cbOffset.TabIndex = 4
        Me.cbOffset.Text = "Select..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(336, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Date Offset"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(7, 70)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(318, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Download to:  (Use browse or type path. Defaults to larauto folder)"
        '
        'txtDownloadTo
        '
        Me.txtDownloadTo.Location = New System.Drawing.Point(7, 43)
        Me.txtDownloadTo.Name = "txtDownloadTo"
        Me.txtDownloadTo.Size = New System.Drawing.Size(292, 20)
        Me.txtDownloadTo.TabIndex = 0
        Me.txtDownloadTo.Text = ".\LARA.mdb"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LARAuto.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(256, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(414, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'setupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 439)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "setupForm"
        Me.Text = "Setup LarAuto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCheckProxy As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCheckLogin As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDownloadTo As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cbOffset As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSaveShortcut As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
