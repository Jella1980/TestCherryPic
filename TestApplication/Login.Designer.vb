<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lblMobileNo = New System.Windows.Forms.Label()
        Me.txtmobile = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtccode = New System.Windows.Forms.TextBox()
        Me.lblor = New System.Windows.Forms.Label()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.lbl_datetime = New System.Windows.Forms.Label()
        Me.lnkClearAll = New System.Windows.Forms.LinkLabel()
        Me.btnTopUp = New System.Windows.Forms.Button()
        Me.btnAddDevice = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.license_lnk = New System.Windows.Forms.LinkLabel()
        Me.helpdesk = New System.Windows.Forms.LinkLabel()
        Me.New_Register = New System.Windows.Forms.LinkLabel()
        Me.ForgotPasswd = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.computername = New System.Windows.Forms.Label()
        Me.version_timer = New System.Windows.Forms.Timer(Me.components)
        Me.latest_ver = New System.Windows.Forms.Label()
        Me.Panel_inst = New System.Windows.Forms.Panel()
        Me.Wb_AstroInst = New System.Windows.Forms.WebBrowser()
        Me.btn_hide_pwd = New System.Windows.Forms.Button()
        Me.btn_show_pwd = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel_inst.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Location = New System.Drawing.Point(6, 4)
        Me.lbl_Heading.Margin = New System.Windows.Forms.Padding(4, 1, 4, 1)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(105, 26)
        Me.lbl_Heading.TabIndex = 0
        Me.lbl_Heading.Text = "Welcome"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMobileNo
        '
        Me.lblMobileNo.BackColor = System.Drawing.Color.Transparent
        Me.lblMobileNo.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMobileNo.ForeColor = System.Drawing.Color.White
        Me.lblMobileNo.Location = New System.Drawing.Point(21, 19)
        Me.lblMobileNo.Name = "lblMobileNo"
        Me.lblMobileNo.Size = New System.Drawing.Size(83, 26)
        Me.lblMobileNo.TabIndex = 3
        Me.lblMobileNo.Text = "Mobile No"
        '
        'txtmobile
        '
        Me.txtmobile.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobile.Location = New System.Drawing.Point(147, 19)
        Me.txtmobile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(97, 26)
        Me.txtmobile.TabIndex = 5
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLogin.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(389, 127)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(124, 33)
        Me.btnLogin.TabIndex = 11
        Me.btnLogin.Text = "Login/Activate"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.White
        Me.lblPassword.Location = New System.Drawing.Point(21, 70)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(69, 20)
        Me.lblPassword.TabIndex = 9
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(110, 64)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(403, 26)
        Me.txtPassword.TabIndex = 10
        '
        'txtccode
        '
        Me.txtccode.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtccode.Location = New System.Drawing.Point(110, 19)
        Me.txtccode.Name = "txtccode"
        Me.txtccode.ReadOnly = True
        Me.txtccode.Size = New System.Drawing.Size(31, 26)
        Me.txtccode.TabIndex = 4
        Me.txtccode.Text = "+91"
        '
        'lblor
        '
        Me.lblor.AutoSize = True
        Me.lblor.BackColor = System.Drawing.Color.Transparent
        Me.lblor.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblor.Location = New System.Drawing.Point(246, 22)
        Me.lblor.Name = "lblor"
        Me.lblor.Size = New System.Drawing.Size(28, 20)
        Me.lblor.TabIndex = 6
        Me.lblor.Text = "OR"
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.ForeColor = System.Drawing.Color.White
        Me.lblemail.Location = New System.Drawing.Point(276, 22)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(45, 20)
        Me.lblemail.TabIndex = 7
        Me.lblemail.Text = "Email"
        '
        'txtemail
        '
        Me.txtemail.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail.Location = New System.Drawing.Point(329, 19)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(185, 26)
        Me.txtemail.TabIndex = 8
        '
        'lbl_datetime
        '
        Me.lbl_datetime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_datetime.AutoSize = True
        Me.lbl_datetime.BackColor = System.Drawing.Color.Transparent
        Me.lbl_datetime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_datetime.ForeColor = System.Drawing.Color.Gold
        Me.lbl_datetime.Location = New System.Drawing.Point(784, 38)
        Me.lbl_datetime.Name = "lbl_datetime"
        Me.lbl_datetime.Size = New System.Drawing.Size(91, 19)
        Me.lbl_datetime.TabIndex = 2
        Me.lbl_datetime.Text = "lbl_datetime"
        Me.lbl_datetime.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lnkClearAll
        '
        Me.lnkClearAll.AutoSize = True
        Me.lnkClearAll.BackColor = System.Drawing.Color.Transparent
        Me.lnkClearAll.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkClearAll.LinkColor = System.Drawing.Color.White
        Me.lnkClearAll.Location = New System.Drawing.Point(255, 93)
        Me.lnkClearAll.Name = "lnkClearAll"
        Me.lnkClearAll.Size = New System.Drawing.Size(66, 18)
        Me.lnkClearAll.TabIndex = 16
        Me.lnkClearAll.TabStop = True
        Me.lnkClearAll.Text = "Clear All"
        '
        'btnTopUp
        '
        Me.btnTopUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTopUp.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTopUp.ForeColor = System.Drawing.Color.White
        Me.btnTopUp.Location = New System.Drawing.Point(250, 127)
        Me.btnTopUp.Name = "btnTopUp"
        Me.btnTopUp.Size = New System.Drawing.Size(121, 33)
        Me.btnTopUp.TabIndex = 12
        Me.btnTopUp.Text = "TopUp-Renew"
        Me.btnTopUp.UseVisualStyleBackColor = False
        '
        'btnAddDevice
        '
        Me.btnAddDevice.BackColor = System.Drawing.Color.DarkCyan
        Me.btnAddDevice.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDevice.ForeColor = System.Drawing.Color.White
        Me.btnAddDevice.Location = New System.Drawing.Point(110, 127)
        Me.btnAddDevice.Name = "btnAddDevice"
        Me.btnAddDevice.Size = New System.Drawing.Size(104, 33)
        Me.btnAddDevice.TabIndex = 14
        Me.btnAddDevice.Text = "Add Device"
        Me.btnAddDevice.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btn_show_pwd)
        Me.Panel1.Controls.Add(Me.btn_hide_pwd)
        Me.Panel1.Controls.Add(Me.license_lnk)
        Me.Panel1.Controls.Add(Me.helpdesk)
        Me.Panel1.Controls.Add(Me.New_Register)
        Me.Panel1.Controls.Add(Me.ForgotPasswd)
        Me.Panel1.Controls.Add(Me.txtmobile)
        Me.Panel1.Controls.Add(Me.lblMobileNo)
        Me.Panel1.Controls.Add(Me.lblPassword)
        Me.Panel1.Controls.Add(Me.btnAddDevice)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.btnTopUp)
        Me.Panel1.Controls.Add(Me.txtccode)
        Me.Panel1.Controls.Add(Me.btnLogin)
        Me.Panel1.Controls.Add(Me.lblor)
        Me.Panel1.Controls.Add(Me.lblemail)
        Me.Panel1.Controls.Add(Me.lnkClearAll)
        Me.Panel1.Controls.Add(Me.txtemail)
        Me.Panel1.Location = New System.Drawing.Point(368, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 168)
        Me.Panel1.TabIndex = 18
        '
        'license_lnk
        '
        Me.license_lnk.AutoSize = True
        Me.license_lnk.BackColor = System.Drawing.Color.Transparent
        Me.license_lnk.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.license_lnk.LinkArea = New System.Windows.Forms.LinkArea(0, 100)
        Me.license_lnk.LinkColor = System.Drawing.Color.White
        Me.license_lnk.Location = New System.Drawing.Point(531, 70)
        Me.license_lnk.Name = "license_lnk"
        Me.license_lnk.Size = New System.Drawing.Size(122, 23)
        Me.license_lnk.TabIndex = 22
        Me.license_lnk.TabStop = True
        Me.license_lnk.Text = "ASTRO-License"
        Me.license_lnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.license_lnk.UseCompatibleTextRendering = True
        '
        'helpdesk
        '
        Me.helpdesk.AutoSize = True
        Me.helpdesk.BackColor = System.Drawing.Color.Transparent
        Me.helpdesk.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.helpdesk.LinkColor = System.Drawing.Color.White
        Me.helpdesk.Location = New System.Drawing.Point(111, 93)
        Me.helpdesk.Name = "helpdesk"
        Me.helpdesk.Size = New System.Drawing.Size(81, 18)
        Me.helpdesk.TabIndex = 18
        Me.helpdesk.TabStop = True
        Me.helpdesk.Text = "Help Desk"
        '
        'New_Register
        '
        Me.New_Register.AutoSize = True
        Me.New_Register.BackColor = System.Drawing.Color.Transparent
        Me.New_Register.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.New_Register.LinkArea = New System.Windows.Forms.LinkArea(0, 100)
        Me.New_Register.LinkColor = System.Drawing.Color.White
        Me.New_Register.Location = New System.Drawing.Point(531, 19)
        Me.New_Register.Name = "New_Register"
        Me.New_Register.Size = New System.Drawing.Size(132, 23)
        Me.New_Register.TabIndex = 21
        Me.New_Register.TabStop = True
        Me.New_Register.Text = "New Registration"
        Me.New_Register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.New_Register.UseCompatibleTextRendering = True
        '
        'ForgotPasswd
        '
        Me.ForgotPasswd.AutoSize = True
        Me.ForgotPasswd.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForgotPasswd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ForgotPasswd.LinkColor = System.Drawing.Color.White
        Me.ForgotPasswd.Location = New System.Drawing.Point(389, 94)
        Me.ForgotPasswd.Name = "ForgotPasswd"
        Me.ForgotPasswd.Size = New System.Drawing.Size(128, 18)
        Me.ForgotPasswd.TabIndex = 17
        Me.ForgotPasswd.TabStop = True
        Me.ForgotPasswd.Text = "Forgot Password"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lbl_Heading)
        Me.Panel2.Controls.Add(Me.computername)
        Me.Panel2.Location = New System.Drawing.Point(258, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(835, 33)
        Me.Panel2.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(460, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 22)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Computer Name :"
        '
        'computername
        '
        Me.computername.AutoSize = True
        Me.computername.BackColor = System.Drawing.Color.Transparent
        Me.computername.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.computername.ForeColor = System.Drawing.Color.White
        Me.computername.Location = New System.Drawing.Point(613, 3)
        Me.computername.Name = "computername"
        Me.computername.Size = New System.Drawing.Size(54, 22)
        Me.computername.TabIndex = 3
        Me.computername.Text = "name"
        '
        'version_timer
        '
        Me.version_timer.Enabled = True
        Me.version_timer.Interval = 400
        '
        'latest_ver
        '
        Me.latest_ver.AutoSize = True
        Me.latest_ver.BackColor = System.Drawing.Color.Transparent
        Me.latest_ver.Cursor = System.Windows.Forms.Cursors.Hand
        Me.latest_ver.Font = New System.Drawing.Font("Times New Roman", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.latest_ver.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.latest_ver.Location = New System.Drawing.Point(34, 113)
        Me.latest_ver.Name = "latest_ver"
        Me.latest_ver.Size = New System.Drawing.Size(0, 24)
        Me.latest_ver.TabIndex = 20
        '
        'Panel_inst
        '
        Me.Panel_inst.BackColor = System.Drawing.Color.Transparent
        Me.Panel_inst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_inst.Controls.Add(Me.Wb_AstroInst)
        Me.Panel_inst.Location = New System.Drawing.Point(366, 250)
        Me.Panel_inst.Name = "Panel_inst"
        Me.Panel_inst.Size = New System.Drawing.Size(673, 380)
        Me.Panel_inst.TabIndex = 22
        '
        'Wb_AstroInst
        '
        Me.Wb_AstroInst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Wb_AstroInst.Location = New System.Drawing.Point(0, 0)
        Me.Wb_AstroInst.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Wb_AstroInst.Name = "Wb_AstroInst"
        Me.Wb_AstroInst.Size = New System.Drawing.Size(669, 376)
        Me.Wb_AstroInst.TabIndex = 0
        '
        'btn_hide_pwd
        '
        Me.btn_hide_pwd.BackColor = System.Drawing.Color.White
        Me.btn_hide_pwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hide_pwd.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btn_hide_pwd.Image = CType(resources.GetObject("btn_hide_pwd.Image"), System.Drawing.Image)
        Me.btn_hide_pwd.Location = New System.Drawing.Point(483, 64)
        Me.btn_hide_pwd.Name = "btn_hide_pwd"
        Me.btn_hide_pwd.Size = New System.Drawing.Size(30, 26)
        Me.btn_hide_pwd.TabIndex = 23
        Me.btn_hide_pwd.UseVisualStyleBackColor = False
        '
        'btn_show_pwd
        '
        Me.btn_show_pwd.BackColor = System.Drawing.Color.White
        Me.btn_show_pwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_show_pwd.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btn_show_pwd.Image = CType(resources.GetObject("btn_show_pwd.Image"), System.Drawing.Image)
        Me.btn_show_pwd.Location = New System.Drawing.Point(483, 64)
        Me.btn_show_pwd.Name = "btn_show_pwd"
        Me.btn_show_pwd.Size = New System.Drawing.Size(30, 26)
        Me.btn_show_pwd.TabIndex = 24
        Me.btn_show_pwd.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1048, 641)
        Me.Controls.Add(Me.Panel_inst)
        Me.Controls.Add(Me.latest_ver)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_datetime)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel_inst.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Heading As Label

    Friend WithEvents lblMobileNo As Label
    Friend WithEvents txtmobile As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtccode As TextBox
    Friend WithEvents lblor As Label
    Friend WithEvents lblemail As Label
    Friend WithEvents txtemail As TextBox
    Friend WithEvents lbl_datetime As Label
    Friend WithEvents lnkClearAll As LinkLabel
    Friend WithEvents btnTopUp As Button
    Friend WithEvents btnAddDevice As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ForgotPasswd As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents computername As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents helpdesk As LinkLabel
    Friend WithEvents version_timer As Timer
    Friend WithEvents latest_ver As Label
    Friend WithEvents New_Register As LinkLabel
    Friend WithEvents Panel_inst As Panel
    Friend WithEvents Wb_AstroInst As WebBrowser
    Friend WithEvents license_lnk As LinkLabel
    Friend WithEvents btn_show_pwd As Button
    Friend WithEvents btn_hide_pwd As Button
End Class
