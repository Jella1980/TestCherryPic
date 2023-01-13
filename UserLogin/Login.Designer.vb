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
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.rbtnIndia = New System.Windows.Forms.RadioButton()
        Me.rbtnNRI = New System.Windows.Forms.RadioButton()
        Me.txt_no_of_days = New System.Windows.Forms.TextBox()
        Me.lbl_Noofdays = New System.Windows.Forms.Label()
        Me.txt_Subscription_Plan = New System.Windows.Forms.TextBox()
        Me.txt_enddate = New System.Windows.Forms.TextBox()
        Me.txt_p_type = New System.Windows.Forms.TextBox()
        Me.lb_Subs_plan = New System.Windows.Forms.Label()
        Me.lbl_End_date = New System.Windows.Forms.Label()
        Me.lbl_ptype = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.Location = New System.Drawing.Point(66, 10)
        Me.lbl_Heading.Margin = New System.Windows.Forms.Padding(4, 1, 4, 1)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(386, 37)
        Me.lbl_Heading.TabIndex = 0
        Me.lbl_Heading.Text = "Welcome To Login page"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserName.Location = New System.Drawing.Point(14, 93)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(140, 30)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "Username"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.Location = New System.Drawing.Point(149, 90)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(150, 37)
        Me.txtUserName.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.SystemColors.Control
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(80, 170)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(124, 41)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login/Activate"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(14, 130)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(134, 30)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(149, 130)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(150, 37)
        Me.txtPassword.TabIndex = 3
        '
        'rbtnIndia
        '
        Me.rbtnIndia.AutoSize = True
        Me.rbtnIndia.Location = New System.Drawing.Point(71, 43)
        Me.rbtnIndia.Name = "rbtnIndia"
        Me.rbtnIndia.Size = New System.Drawing.Size(103, 34)
        Me.rbtnIndia.TabIndex = 10
        Me.rbtnIndia.Text = "India"
        Me.rbtnIndia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtnIndia.UseVisualStyleBackColor = True
        '
        'rbtnNRI
        '
        Me.rbtnNRI.AutoSize = True
        Me.rbtnNRI.Location = New System.Drawing.Point(193, 43)
        Me.rbtnNRI.Name = "rbtnNRI"
        Me.rbtnNRI.Size = New System.Drawing.Size(91, 34)
        Me.rbtnNRI.TabIndex = 11
        Me.rbtnNRI.Text = "NRI"
        Me.rbtnNRI.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.rbtnNRI.UseVisualStyleBackColor = True
        '
        'txt_no_of_days
        '
        Me.txt_no_of_days.Location = New System.Drawing.Point(211, 303)
        Me.txt_no_of_days.Name = "txt_no_of_days"
        Me.txt_no_of_days.ReadOnly = True
        Me.txt_no_of_days.Size = New System.Drawing.Size(145, 37)
        Me.txt_no_of_days.TabIndex = 48
        '
        'lbl_Noofdays
        '
        Me.lbl_Noofdays.AutoSize = True
        Me.lbl_Noofdays.Location = New System.Drawing.Point(17, 303)
        Me.lbl_Noofdays.Name = "lbl_Noofdays"
        Me.lbl_Noofdays.Size = New System.Drawing.Size(130, 30)
        Me.lbl_Noofdays.TabIndex = 47
        Me.lbl_Noofdays.Text = "Days Left"
        Me.lbl_Noofdays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_Subscription_Plan
        '
        Me.txt_Subscription_Plan.Location = New System.Drawing.Point(211, 331)
        Me.txt_Subscription_Plan.Name = "txt_Subscription_Plan"
        Me.txt_Subscription_Plan.ReadOnly = True
        Me.txt_Subscription_Plan.Size = New System.Drawing.Size(145, 37)
        Me.txt_Subscription_Plan.TabIndex = 46
        '
        'txt_enddate
        '
        Me.txt_enddate.Location = New System.Drawing.Point(211, 275)
        Me.txt_enddate.Name = "txt_enddate"
        Me.txt_enddate.ReadOnly = True
        Me.txt_enddate.Size = New System.Drawing.Size(145, 37)
        Me.txt_enddate.TabIndex = 45
        '
        'txt_p_type
        '
        Me.txt_p_type.Location = New System.Drawing.Point(211, 242)
        Me.txt_p_type.Name = "txt_p_type"
        Me.txt_p_type.ReadOnly = True
        Me.txt_p_type.Size = New System.Drawing.Size(145, 37)
        Me.txt_p_type.TabIndex = 41
        '
        'lb_Subs_plan
        '
        Me.lb_Subs_plan.AutoSize = True
        Me.lb_Subs_plan.Location = New System.Drawing.Point(17, 331)
        Me.lb_Subs_plan.Name = "lb_Subs_plan"
        Me.lb_Subs_plan.Size = New System.Drawing.Size(229, 30)
        Me.lb_Subs_plan.TabIndex = 40
        Me.lb_Subs_plan.Text = "Subscription Plan"
        Me.lb_Subs_plan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_End_date
        '
        Me.lbl_End_date.AutoSize = True
        Me.lbl_End_date.Location = New System.Drawing.Point(14, 275)
        Me.lbl_End_date.Name = "lbl_End_date"
        Me.lbl_End_date.Size = New System.Drawing.Size(323, 30)
        Me.lbl_End_date.TabIndex = 38
        Me.lbl_End_date.Text = "Last Date of Subscription"
        Me.lbl_End_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ptype
        '
        Me.lbl_ptype.AutoSize = True
        Me.lbl_ptype.Location = New System.Drawing.Point(17, 242)
        Me.lbl_ptype.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_ptype.Name = "lbl_ptype"
        Me.lbl_ptype.Size = New System.Drawing.Size(177, 30)
        Me.lbl_ptype.TabIndex = 35
        Me.lbl_ptype.Text = "Product Type"
        Me.lbl_ptype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 30.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(779, 502)
        Me.Controls.Add(Me.txt_no_of_days)
        Me.Controls.Add(Me.lbl_Noofdays)
        Me.Controls.Add(Me.txt_Subscription_Plan)
        Me.Controls.Add(Me.txt_enddate)
        Me.Controls.Add(Me.txt_p_type)
        Me.Controls.Add(Me.lb_Subs_plan)
        Me.Controls.Add(Me.lbl_End_date)
        Me.Controls.Add(Me.lbl_ptype)
        Me.Controls.Add(Me.rbtnNRI)
        Me.Controls.Add(Me.rbtnIndia)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Heading As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents rbtnNRI As RadioButton
    Friend WithEvents rbtnIndia As RadioButton
    Friend WithEvents txt_no_of_days As TextBox
    Friend WithEvents lbl_Noofdays As Label
    Friend WithEvents txt_Subscription_Plan As TextBox
    Friend WithEvents txt_enddate As TextBox
    Friend WithEvents txt_p_type As TextBox
    Friend WithEvents lb_Subs_plan As Label
    Friend WithEvents lbl_End_date As Label
    Friend WithEvents lbl_ptype As Label
End Class
