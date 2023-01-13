Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Net.WebRequestMethods
Imports System.Net
Imports System.Web
Imports System.Net.Http.HttpClient

Imports System.IO.File
Imports System.IO
Public Class Login

    Public type As String
    Public p_id As String
    Public uid As String
    Public db_device_id As String
    Public db_serial_Key As String
    Public db_activationKey As String
    Public activ_Key As String
    Public deviceid As String
    Public serialkey, days As String
    Public prod_type As String
    Public end_date As String
    Public Subs_plan As String
    Public activate_key As String

    Dim filename As String = Application.StartupPath & "\test_" + Date.Now.ToString("ddMMyyyy") + ".log"
    Public sw As StreamWriter = AppendText(filename)
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        rbtnIndia.Checked = True
        'user - 9985646458 ; pwd =  sudha@123
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)        ' Getting Connection from Appconfig

        ' Genrating Device ID from astrolicense
        Dim key As New AstroSubscribeDLL.AstroLicense
        deviceid = key.DeviceID
        sw.WriteLine(Now() & " " & "DeviceID:" + deviceid)

        ' Getting serial Key  and creating License path in system 
        Dim sk As New AstroSubscribeDLL.TrialLicense
        serialkey = sk.SerialKeySubscriptionTrial()
        sw.WriteLine(Now() & " " & "SerialKey:" + serialkey)
        Dim day As New AstroSubscribeDLL.SubscriptionLicense
        Dim remaindays = day.RemainingDays
        Try
            ' We are checking the username as user entered  correct mobile number  and email format.
            ' We are also checking the username password  entered correctly or not.
            If UserValid() = True Then
                sw.WriteLine(Now() & " " & "Username: " + txtUserName.Text + " and Password: " + txtPassword.Text)
                conn.Open()
                Dim rd As MySqlDataReader
                rd = GetUserDetails()

                '' Data Reading from Database
                If (rd.Read()) Then

                    If (rd(4).ToString() = txtUserName.Text And rd(5).ToString() = txtPassword.Text) Then
                        If (rd(0).ToString() <> "") Then
                            uid = rd(0).ToString.Trim()                   ' getting user id from db
                            db_device_id = rd(1).ToString.Trim()          ' getting Device Id from db
                            db_serial_Key = rd(2).ToString.Trim()         ' getting serial key from db
                            db_activationKey = rd(3).ToString.Trim()      ' gettin Activation key from db
                            end_date = rd(6).ToString.Trim()              ' getting End Date from db
                            prod_type = rd(7).ToString.Trim()             ' getting Product type from db
                            Subs_plan = rd(8).ToString.Trim()             ' getting Subcription Plan from db
                            conn.Close()

                        End If

                        ' Deviceid ,serialkey and ActivationKey  checking with database. If its matches  login will be successfull.
                        If (deviceid <> "" And serialkey <> "") Then
                            days = RemainingDays()
                            If days <= 0 Then
                                Dim buttons As MessageBoxButtons = MessageBoxButtons.OK
                                Dim result As DialogResult = MessageBox.Show("Your Subscription as been ended.Please Renewal. ", "Subscription", buttons)
                                System.Diagnostics.Process.Start("http://www.astrouser.com")
                                Me.Show()
                            ElseIf days <= 7 Then
                                MsgBox("Login Sucessfully", MsgBoxStyle.OkOnly, "Done")
                                'Me.Hide()
                                Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
                                Dim result As DialogResult = MessageBox.Show("Your subscription Product ( " & prod_type & " ) will end in " & end_date & " (" & days & ") days. For Renew Click Yes button.", "Subscription", buttons)

                                If result = DialogResult.Yes Then
                                    'Me.Hide()
                                    System.Diagnostics.Process.Start("http://www.astrouser.com")
                                ElseIf result = DialogResult.No Then
                                    txt_p_type.Text = prod_type
                                    txt_enddate.Text = end_date
                                    txt_no_of_days.Text = days
                                    txt_Subscription_Plan.Text = Subs_plan
                                    If db_activationKey = "" Then
                                        activate_key = GetActivationKey()
                                        Activation()
                                    Else
                                        MessageBox.Show("Your Account is Already Activated.")
                                    End If

                                    'Me.Hide()
                                    'Home.Show()
                                End If
                            Else
                                MsgBox("Login Sucessfully", MsgBoxStyle.OkOnly, "Done")
                                txt_p_type.Text = prod_type
                                txt_enddate.Text = end_date
                                txt_no_of_days.Text = days
                                txt_Subscription_Plan.Text = Subs_plan
                                If db_activationKey = "" Then
                                    activate_key = GetActivationKey()
                                    Activation()
                                Else
                                    MessageBox.Show("Your Account is Already Activated.")

                                End If

                                'Me.Hide()
                                'Home.Show()
                            End If
                        Else
                            MsgBox("Please login with registerd device")
                            Me.Show()
                        End If
                    Else
                        MsgBox("Please enter the correct username/Password")
                        Me.Show()
                    End If
                Else
                    'If username and password is not there in database. User will get alert message for register.
                    Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
                    Dim result As DialogResult = MessageBox.Show("Username is not Registerd with our database.Please click Yes for Register", "Register", buttons)

                    If result = DialogResult.Yes Then
                        Me.Hide()
                        System.Diagnostics.Process.Start("http://www.astrouser.com")
                    ElseIf result = DialogResult.No And days <= 0 Then
                        Me.Show()
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox("Error Loading Database", MsgBoxStyle.Critical, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' ' Getting the user details from database based on the Username
    ''' </summary>
    ''' <returns>MySql DataReader</returns>
    Public Function GetUserDetails()
        Try
            Dim username, password As String
            username = txtUserName.Text
            password = txtPassword.Text
            Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
            conn.Open()

            '' MySQL Commands
            Dim mySelectQuery As String = "Select A.uid,B.device_id,B.serialization_key,B.activation_key,A.username,A.password,B.end_date,B.subscription_type,B.subscription_plan from tester_astro.wp_subscription_users A inner join tester_astro.wp_subscription_model B On B.subscription_id=  A.uid
            where username = '" + username + "' or password = '" + password + "'"
            Dim myCommand As New MySqlCommand(mySelectQuery, conn)

            Return myCommand.ExecuteReader()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try
    End Function

    Public Function RemainingDays() As String
#Region "REMAINING DAYS"
        Dim subs_enddt As Date = end_date.ToString()
        Dim current_date As Date = DateTime.Now.ToString("yyyy/M/dd")
        Dim daydiff As TimeSpan = subs_enddt.Subtract(current_date)
        days = Convert.ToInt32(daydiff.Days)
#End Region
        sw.WriteLine(Now() & " " & "End date:" + subs_enddt + " and Days: " + days + " and Product Type: " + prod_type)
        Return days
    End Function

    Public Function UserValid() As Boolean
        If rbtnIndia.Checked = True Then     ' For Indain need to enter only  10 digit mobile number

            If IsNumeric(txtUserName.Text) Then
                If (txtUserName.Text.Length = 10) Then

                    Dim PhoneNumber As String = "^[6789]\d{9}$"  'It Allows only Indian Mobile number starting with 6789
                    Dim ChekPhone As New Regex(PhoneNumber)
                    Dim PhoneValid As Boolean
                    PhoneValid = ChekPhone.IsMatch(txtUserName.Text)
                    If (PhoneValid = False) Then
                        MessageBox.Show(" Please enter valid mobile number")
                        Return False
                    Else
                        Return True
                    End If
                Else
                    MsgBox("Please enter the 10 digit mobile number")
                    Return False
                End If
            Else
                MsgBox("Please enter the 10 digit mobile number")
                Return False
            End If
        Else
            If rbtnNRI.Checked = True Then      ' For NRI  need to enter only email Id with gmail or yahoo or rediffmail domains only
                If Not (Regex.IsMatch(txtUserName.Text, "^([a-zA-Z0-9._%+-]{1,50})+(@gmail|@GMAIL|@YAHOO|@yahoo|@rediffmail|@REDDIFFMAIL)+(\.)+(com|COM)$")) Then
                    MessageBox.Show("Please enter valid Email")
                    Return False
                Else
                    Return True
                End If
            End If
        End If
    End Function


    ''' <summary>
    ''' 'This Update the User details in database. If deviceid, activation key serial Key is null.
    ''' </summary>
    ''' <returns></returns>
    Public Function UpdateUserData()
        Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
        If ((db_activationKey = "" And db_device_id = "" And db_serial_Key = "")) Then
            Dim command As New MySqlCommand
            Dim update As String = "update tester_astro.wp_subscription_model SET serialization_key= '" & serialkey & "',activation_key= '" & activate_key & "', device_id='" & deviceid & "' where serialization_key is not Null and activation_key is not Null and device_id is not Null and  subscription_id=" & uid
            command.Connection = conn
            command.CommandText = update
            conn.Open() ''DB connection Open
            command.ExecuteNonQuery()
            conn.Close() '' Closing Database.
            db_device_id = deviceid
            db_serial_Key = serialkey
            db_activationKey = activ_Key
        End If
    End Function

    Public Function Activation()
        Dim locdeviceid As String = deviceid
        Dim locserialkey As String = serialkey
        If (deviceid = locdeviceid And serialkey = locserialkey) Then
            If Filegeneration() = True Then
                UpdateUserData()
                'Me.Hide()
                MsgBox("Successfully Activated.Please restart the application.")
            Else
                MsgBox("Please try again")
            End If
        Else

            MessageBox.Show("Please enter the correct DeviceID and Serial Key")
        End If
        sw.WriteLine(Now() & "" & "ActivationKey: " & GetActivationKey())
        sw.Close()
    End Function
    ''' <summary>
    ''' 
    ''' 'It will pass the device id and serial key to generate the Activation Key from the web services.
    ''' Right Click on Project then select Add ==> Service References ==>Click on Advanced ==> Click on Add Web References ==> 
    ''' Enter the  your service url in urltextbox click on Arrow button. Then Rename the webservice name to ActivationKey
    ''' then Click on Add Refereneces
    ''' </summary>
    ''' <returns>It return the ActivationKey in String format</returns>

    Public Function GetActivationKey() As String
        Dim activeKey As New ActivationKey.ActivationKey()
        Dim Passdt As String = DateTime.Now.ToString("ddMMyyyy")
        Return activeKey.CallActivationKey(prod_type, deviceid, serialkey, "A$trOWeb" + Passdt)

    End Function
#Region "File Creation"
    Public Function Filegeneration() As Boolean
        Try
            Dim licpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\AstroSubscribe"
            If Not System.IO.Directory.Exists(licpath) Then
                System.IO.Directory.CreateDirectory(licpath)
            End If
            If Not (IO.File.Exists(licpath + "license.lic")) Then
                Dim message As String = activate_key
                Using writer As New StreamWriter(licpath + "\license.lic")
                    writer.WriteLine(message)
                    writer.Close()
                End Using
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
#End Region

End Class
