Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO.File
Imports System.IO
Imports System
Imports System.Net
Imports System.Reflection

Public Class Login
    'variables getting  values from the database on server
    Public uid As String 'Unique key for comparing tables users, model and model2
    Public db_device_id As String
    Public db_serial_Key As String
    Public db_activationKey As String
    Public dbdays As Integer
    Public Subs_plan As String
    Public customername As String
    Public computer_name As String
    'Local variables
    Public deviceid As String  'local deviceId 
    Public serialkey As String 'local serial Key
    Public prod_type As String 'P , D or T'
    Public devicenumber As Integer
    Public remainingdays As Integer
    Public end_date As Date
    Public end_date2 As Date
    Public strtdt As Date
    Public strdt2 As Date
    Public email2 As String
    Public edate As Date
    Public Const trialperiod As Integer = 30
    Public activate_key As String 'key received from server as activationkey

    Dim filename As String = Application.StartupPath & "\User_Log_Details" + Date.Now.ToString("ddMMyyyy") + ".log"
    Public sw As StreamWriter = AppendText(filename)
    Private passcode As String = "A$trOWeb2023$$" + Now.ToString("ddMMyyyy")  'a key to confirm the authenticaiton of calling source to astrowebservice (activaitonkey.asmx) file on the server
    'Private Passdt As String = Now.ToString("ddMMyyyy") 'This is added to passcode to pass a unique key to the astrowebservice
    Dim astrowebservice As New ActivationKey.ActivationKey  'namespace.servicepage
    Public tlicense As New AstroSubscribeDLL.TrialLicense
    Public slicense As New AstroSubscribeDLL.SubscriptionLicense
    Public updatedlink, version As String
    ''Public tick As Integer = 0 

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Try
            Me.CenterToScreen()

            'Saving the Login Details for next time
            If My.Settings.RememberMe = True Then
                txtmobile.Text = My.Settings.MobileNo
                txtemail.Text = My.Settings.EmailID
                '  txtPassword.Text = My.Settings.Password
                customername = My.Settings.CustomerName
                computer_name = My.Settings.ComputerName
                lbl_Heading.Text = "Welcome " + customername
                computername.Text = computer_name
            End If

            If My.Settings.productID = "T" Then
                btnAddDevice.Enabled = False
            Else
                btnAddDevice.Enabled = True
            End If

            lbl_datetime.Text = Now().ToString("dd/MM/yyyy hh:mm tt")
            txtPassword.Select()

            ' removed older version check
            ' removed  Astro Subscription Instructions  from rich textbox

            ' Astro Subscription Instructions reading from the HTML Page

            Dim assmbly As Assembly = Assembly.GetExecutingAssembly()
            Dim astro_sub_inst_rd As New StreamReader(assmbly.GetManifestResourceStream("TestApplication.Astro_Subscription_Inst.html"))
            Wb_AstroInst.DocumentText = astro_sub_inst_rd.ReadToEnd()

            ''Version display
            VersionCheck()


        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Saving the Login Details for next time
        'If (String.IsNullOrWhiteSpace(txtmobile.Text)) Or (String.IsNullOrWhiteSpace(txtemail.Text) And String.IsNullOrWhiteSpace(txtPassword.Text)) Then
        '  MessageBox.Show("You cannot leave the Mobile No / Email ID or  Password blank.", "Required Fields", MessageBoxButtons.OK)
        ' Else
        'Check for a valid login
        ' Dim fname As String = Application.StartupPath & "\User_Log_Details" + Date.Now.ToString("ddMMyyyy") + ".txt"
        Using sw

            My.Settings.MobileNo = txtmobile.Text
            My.Settings.EmailID = txtemail.Text.ToLower()
            ' My.Settings.Password = txtPassword.Text
            My.Settings.RememberMe = True

            ' Genrating Local Device ID from astrolicense
            Dim lic As New AstroSubscribeDLL.AstroLicense
            deviceid = lic.DeviceID   ''Local device ID  stored in the lic file
            sw.WriteLine(Now() & " " & "DeviceID:" + deviceid)

            Try
                If UserFormatValid() = True Then ' We are checking the username as user entered  correct mobile number  and email format.
                    sw.WriteLine(Now() & " " & "Mobile No: " + txtmobile.Text + "  or  Email ID: " + txtemail.Text + " and Password: " + txtPassword.Text)

                    Dim rdUserdtls As MySqlDataReader
                    rdUserdtls = GetUserDetails() 'get all details for this username and password combination such as the subcription_period, end_date etc. 
                    If (rdUserdtls.Read()) Then 'user details are in the db and fetched from three tables

                        uid = rdUserdtls(0) 'Getting the uid of the subscriber
                        customername = rdUserdtls(5)
                        My.Settings.CustomerName = customername

                        ' computer_name = rdUserdtls(13).ToString.Trim()
                        'My.Settings.Computer = computer_name
                        prod_type = rdUserdtls(8).ToString.Trim() 'product_type is subscription_type which will be available only in model table 
                        My.Settings.productID = prod_type
                        email2 = rdUserdtls(2).ToString.Trim()
                        If prod_type = "T" Then
                            strtdt = rdUserdtls(11).ToString.Trim()
                            end_date = strtdt.AddDays(trialperiod).ToString("yyyy-MM-dd hh:mm:ss")
                        Else
                            end_date = rdUserdtls(9).ToString.Trim() 'For the first Device End date
                            If email2 <> "" Then   'No second emailID means user not subscribed for the second device 
                                end_date2 = rdUserdtls(10)
                                '         computer_name = rdUserdtls(14).ToString.Trim()
                                '        My.Settings.ComputerName = computer_name
                            End If
                        End If

                        My.Settings.Save()
                        My.Settings.Reload()


                        'Registration of the device 1 Or device 2
                        If rdUserdtls(6).ToString.Trim = "" Then ''rdUserdtls(6)  is deviceid of first device
                            FirstTimeAccess(1)

                        End If
                        If deviceid <> rdUserdtls(6).ToString.Trim() Then  'Meand check only for the second device or other device id , not the first one
                            If end_date2 > Now.Date().ToString Then 'Means the user has subscribed for the second device
                                If rdUserdtls(7).ToString.Trim = "" Then 'rdUserdtls(7) is deviceid of second device 
                                    FirstTimeAccess(2) 'Generate and update keys in localdb and server model2 table

                                End If
                            End If
                            'Else
                            '   MsgBox("This computer is used. Please install in another computer")
                        End If

                        '//***  Device Number is allocated here based on comparision of local deviceid with db_device id 1 and db_device_id 2
                        If deviceid = rdUserdtls(6).ToString.Trim() Then 'matching deviceid from table model or B then user logged in with first device
                            devicenumber = 1
                            db_device_id = rdUserdtls(6).ToString.Trim()
                            computer_name = rdUserdtls(13).ToString.Trim()
                            My.Settings.ComputerName = computer_name
                            edate = end_date    'End date for device1
                        ElseIf deviceid = rdUserdtls(7).ToString.Trim() Then 'matching deviceid from table model2 or C then user logged in with second device. It handles deviceid 2 as Null case also
                            devicenumber = 2
                            db_device_id = rdUserdtls(7).ToString.Trim()
                            computer_name = rdUserdtls(14).ToString.Trim()
                            My.Settings.ComputerName = computer_name
                            edate = end_date2   'End date for device2
                        Else
                            MsgBox("Please Login with the authorized computer. This device is not subscribed")
                            Application.Exit()
                            End
                        End If
                        ' Which computer  user is login
                        My.Settings.Save()
                        My.Settings.Reload()

                    Else
                        MsgBox("Please check and enter the correct Mobile Number/Email ID & Password.")
                        'Me.Show()
                        txtPassword.Text = ""
                        txtmobile.Text = ""
                        txtemail.Text = ""
                        Exit Sub
                    End If

                End If  'for userformatvalid

                Dim rdDevicedtls As MySqlDataReader
                rdDevicedtls = GetDeviceDetails()  'get device details such as serial key, , activation key, end date, subs_type, subs_plan, and start date

                If rdDevicedtls.Read() Then ' user device details from table.
                    db_serial_Key = rdDevicedtls(0).ToString.Trim()
                    db_activationKey = rdDevicedtls(1).ToString.Trim()
                    Subs_plan = rdDevicedtls(4).ToString.Trim()
                    'My.Settings.SubscriptionPeriod = Subs_plan
                End If
                sw.WriteLine(Now() & " " & "db_SerialKey: " + db_serial_Key & " and " & "db_ActivationKey: " + db_activationKey)
                '//at this stage user is using the first device or second is known  through devicenumber which is a local public variable.
                'Keys(serial and activaiton) already exists in db. User wants to user the software already registered or he wants to Renew/Upgrade the license
                If (db_device_id <> "" And db_serial_Key <> "") Then
                    dbdays = dbRemainingDays() 'remaining days of license as per database. It is based on end_date in the DB
                    'remainingdays are extracted below from the license file i.e. local remaining days
                    If slicense.IsValid() Then
                        remainingdays = slicense.RemainingDays
                    ElseIf tlicense.IsValid() Then
                        remainingdays = tlicense.RemainingDays
                    End If

                    'My.Settings.RemainingDays = remainingdays

                    'Trial is not given for the second device
                    If (devicenumber = 2) And (prod_type = "T") Then 'Trial is not allowed for second device
                        MsgBox("Trial License is given only for the First Device. Please Register for Pearl or Diamond for the Second Device")
                        System.Diagnostics.Process.Start("https://astrouser.com/product-subscription/")
                        Me.Hide()
                        Application.Exit()
                        End
                    End If

                    'If the remaining days for any product T or P or D for the first device or  P or D for the second device  are less than zero then Renewal required. 
                    If remainingdays < 0 Then
                        MsgBox("Subscription is expired.Please renew your account")
                        System.Diagnostics.Process.Start("https://astrouser.com/product-subscription/")
                        Me.Hide()
                        Application.Exit()
                        End
                    End If

                    Dim productname As String
                    If My.Settings.productID = "T" Then
                        productname = "Trial"
                    ElseIf My.Settings.productID = "P" Then
                        productname = "Pearl"
                    ElseIf My.Settings.productID = "D" Then
                        productname = "Diamond"
                    Else
                        productname = "Nothing"
                    End If


                    '/* The Logic for Renewal of subscription or TOPUP for either of the devices is in the below code */
                    If (dbdays > remainingdays And remainingdays >= 0) Then   ''Case for Renewal or Upgrade as dbdays are more means the customer has topped up more months 
                        'in the same product or he has upgraded his product
                        Dim tlic As New AstroSubscribeDLL.SubscriptionLicense
                        serialkey = tlic.SerialKeySubscriptionTrial()  'New GUID/Trial key generated through internal generate() function
                        sw.WriteLine(Now() & " " & "Topup_SerialKey:" + serialkey)

                        'ActivationKey.asmx    'callActivationkey is a function written inside the web service
                        If prod_type = "P" Or prod_type = "D" Then 'User shoudl not be allowed to renew with Trial license after exhausting his trial period.
                            activate_key = astrowebservice.CallActivationKey(prod_type, deviceid, serialkey, passcode)
                            sw.WriteLine(Now() & " " & " Topup_ActivationKey: " + activate_key)

                        Else
                            MsgBox("Trial License cannot be renewed. Please subscribe for Pearl or Diamond")
                            System.Diagnostics.Process.Start("https://astrouser.com/product-subscription/")
                            Me.Hide()
                            Application.Exit()
                            End
                        End If

                        ' edate  declare device1 end date or device2 end date

                        ActivateLicense(activate_key, dbdays, prod_type, edate) 'Activate license and put activation key in the licese.lic file
                        'devicenumber is either 1 or 2 accordingly the model or model2 table is updated with new keys

                        UpdateUserData()
                        Application.Exit()
                        End
                    Else

                        'Valid user license and user is not topping up.  He is just loggin into his account for the regular use.  We have to check for license expiry and warn if less than 7 days are left for expiry of license. 
                        'Warnings for renewal given 
                        If dbdays < 0 Then
                            MessageBox.Show("Your Subscription Product (ASTRO-" & productname & ") has ended." & vbCrLf & "To continue using the  application, please renew/upgrade your subscription.", "Subscription Top-up")
                            System.Diagnostics.Process.Start("https://astrouser.com/renewal-subscription")
                            Me.Hide()
                        ElseIf dbdays <= 7 Then

                            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
                            Dim result As DialogResult = MessageBox.Show("Your subscription Product ( ASTRO-" & productname & ") will end on " & edate.ToString("dd/MM/yyyy") & ". For Renew/Upgrade, Click Yes button.", "Subscription Top-up", buttons)

                            If result = DialogResult.Yes Then
                                Me.Hide()
                                System.Diagnostics.Process.Start("https://astrouser.com/renewal-subscription")
                            ElseIf result = DialogResult.No Then 'Keys not NULL and the subscription is less than seven days but user wants to continue
                                MsgBox("Login Successful" & vbCrLf & "Product: ASTRO-" & productname & vbCrLf & "Remaining Subscription Days:" & remainingdays, MsgBoxStyle.OkOnly, "Subscription Validity")
                                Me.Update()
                                Me.Hide()
                                Form1.Show()
                            End If
                        Else
                            MsgBox("Login Successful" & vbCrLf & "Product: ASTRO-" & productname & vbCrLf & "Remaining Subscription Days:" & remainingdays, MsgBoxStyle.OkOnly, "AstroLogin")
                            Me.Hide()
                            Form1.Show()
                        End If
                    End If
                End If

            Catch ex As Exception
                sw.WriteLine(Now() & " " & "Expection Error: " + ex.Message)
                ' MsgBox("Error Loading Database", MsgBoxStyle.Critical, ex.Message)
                MsgBox("Database Connection Error. Check Internet connectivity and Try Again.")
            End Try
            sw.Close()
        End Using
        'End If
    End Sub

    Public Function UserFormatValid() As Boolean 'Checking mobile number format and email format to the Regex and country valid number format
        Dim mobile, email As String
        mobile = Trim(txtmobile.Text)
        email = Trim(txtemail.Text)


        ' For Indain need to enter only  10 digit mobile number
        Try
            If IsNumeric(txtmobile.Text) Then
                ' If (txtmobile.Text.Length = 10) Then

                Dim PhoneNumber As String = "^[6789]\d{9}$"  'It Allows only Indian Mobile number starting with 6789
                ' ^     #Match the beginning of the string
                '[6789] #Match a 6, 7, 8 Or 9
                '\d    #Match a digit (0-9 And anything else that Is a "digit" in the regex engine)
                '{9}   #Repeat the previous "\d" 9 times (9 digits)
                '$     #Match the end of the string
                Dim ChekPhone As New Regex(PhoneNumber)
                '        Dim PhoneValid As Boolean
                ' PhoneValid = ChekPhone.IsMatch(txtmobile.Text)
                If (ChekPhone.IsMatch(txtmobile.Text) = False) Then
                    MessageBox.Show(" Please enter valid mobile number")
                    Return False
                Else
                    Return True
                End If
                'Else
                '    MsgBox("Please enter the 10 digit mobile number")
                '    Return False
                'End If
            Else
                ' For NRI  need to enter only email Id with gmail or yahoo or rediffmail domains only
                If Not (Regex.IsMatch(txtemail.Text, "^([a-zA-Z0-9._%+-]{1,50})+(@gmail|@GMAIL|@YAHOO|@yahoo|@rediffmail|@REDDIFFMAIL)+(\.)+(com|COM)$")) Then
                    MessageBox.Show("Please enter valid Email")
                    Return False
                Else
                    Return True
                End If
            End If
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function
    Public Function GetUserDetails() 'get deviceId, serialkey, activationkey, username, password, end date, subs type, subs_plan in months, from two tables in the DB on innerjoin of uid from both tables to match
        Try
            Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
            Dim mobile, emailid, password As String
            mobile = Trim(txtmobile.Text)
            emailid = Trim(txtemail.Text)
            password = Trim(txtPassword.Text)
            Dim mySelectQuery As String
            Dim myCommand As New MySqlCommand
            conn.Open()

            '' MySQL Commands
            If emailid <> "" Then
                mySelectQuery =
                "Select A.uid,A.customer_email,A.customer_email2,A.customer_mobile,A.password, A.customer_name,
                B.device_id,C.device_id,B.subscription_type,B.end_date,C.end_date,B.start_date,C.start_date,B.computer_name,C.computer_name    
                   from astro_subscription.wp_subscription_users A
                inner join astro_subscription.wp_subscription_model B On B.uid=  A.uid 
                left join  astro_subscription.wp_subscription_model2 C on C.uid= A.uid
                where (A.customer_email= '" + emailid + "' or A.customer_email2= '" + emailid + "') and A.password = '" + password + "'"
            Else
                'User to check with mobile number is valid user or not.
                mySelectQuery =
                "Select A.uid,A.customer_email,A.customer_email2,A.customer_mobile,A.password, A.customer_name,
                B.device_id,C.device_id,B.subscription_type,B.end_date,C.end_date,B.start_date,C.start_date,B.computer_name,C.computer_name    
                from astro_subscription.wp_subscription_users A
                inner join astro_subscription.wp_subscription_model B On B.uid=  A.uid 
                left join  astro_subscription.wp_subscription_model2 C on C.uid= A.uid
                where (A.customer_mobile='" + mobile + "') and A.password = '" + password + "'"
            End If
            'Where condition is required to get a single row from the db which belong to the customer

            myCommand.CommandText = mySelectQuery
            myCommand.Connection = conn
            Return myCommand.ExecuteReader()
            conn.Close()
        Catch ex As Exception
            sw.WriteLine(Now() & " " & "User Details: " + ex.Message)
            MsgBox(MsgBoxStyle.Critical, ex.Message)

        End Try
        sw.Close()
    End Function
    Public Function GetDeviceDetails() 'get deviceId, serialkey, activationkey, username, password, end date, subs type, subs_plan in months, from two tables in the DB on innerjoin of uid from both tables to match
        Try

            Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
            Dim mydeviceQuerry As String
            Dim myCommand As New MySqlCommand
            conn.Open()

            '' MySQL Commands
            If devicenumber = 2 Then 'customer is a multi-device user and coming from a second device. 
                mydeviceQuerry = "Select serialization_key,activation_key,end_date,subscription_type,subscription_plan,start_date
                                  from astro_subscription.wp_subscription_model2 where uid = '" + uid + "'"
            Else
                mydeviceQuerry = "Select serialization_key,activation_key,end_date,subscription_type,subscription_plan,start_date
                                  from astro_subscription.wp_subscription_model where uid = '" + uid + "'"
            End If


            myCommand.CommandText = mydeviceQuerry
            myCommand.Connection = conn
            Return myCommand.ExecuteReader()
            conn.Close()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
            sw.WriteLine(Now() & " " & "Device Error: " + ex.Message)
        End Try
        sw.Close()
    End Function
    Public Function dbRemainingDays() As String 'Derived from the end_date obtained from the DB
        Try
            Dim subs_enddt As Date
            If devicenumber = 2 Then
                subs_enddt = end_date2
            Else
                subs_enddt = end_date
            End If

            Dim current_date As Date = DateTime.Now.ToString("yyyy/M/dd")
            Dim daydiff As TimeSpan = subs_enddt.Subtract(current_date)
            Dim days As String = Convert.ToInt32(daydiff.Days)
            sw.WriteLine(Now() & " " & "End date:" + subs_enddt + " and Days: " + days + " and Product Type: " + prod_type)
            Return days
            sw.Close()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function

    Public Function FirstTimeAccess(Dno As Integer) ' This function generates the license file and updates serial and activation keys for the device under consideration in database. Dno is device number passed on as a parameter.
        'The same code is useful for checking for both the devices
        Try
            devicenumber = Dno
            Dim edate As Date
            If devicenumber = 1 Then
                edate = end_date

            ElseIf devicenumber = 2 Then
                edate = end_date2
            End If
            If prod_type = "P" Or prod_type = "D" Then
                Dim subs As New AstroSubscribeDLL.SubscriptionLicense
                serialkey = subs.SerialKeySubscriptionTrial()  'First time GUID key generated through internal generate() function.

            ElseIf prod_type = "T" Then
                Dim subs As New AstroSubscribeDLL.TrialLicense
                serialkey = subs.SerialKeySubscriptionTrial()
            End If
            'First time GUID key generated through internal generate() function.
            sw.WriteLine(Now() & " " & "Firsttime_SerialKey:" + serialkey)
            dbdays = dbRemainingDays() 'remaining days of license as per database. It is based on end_date in the DB
            'callActivationkey is a function written inside the web service  via ActivationKey.asmx  
            activate_key = astrowebservice.CallActivationKey(prod_type, deviceid, serialkey, passcode)
            ''sw.WriteLine(Now() & " " & "Firsttime_ActivationKey:" + activate_key)
            ActivateLicense(activate_key, dbdays, prod_type, edate) 'Activate license and put activation key in the licese.lic file

            UpdateUserData()  'updates serial key and activation key in the model table of the database
            Application.Exit()
            End
            sw.Close()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function
    Public Function UpdateUserData()
        Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
        '  If ((db_activationKey = "" Or db_serial_Key IsNot DBNull.Value)) Then
        Try
            Dim command As New MySqlCommand
            Dim update As String
            If devicenumber = 2 Then
                update = "update astro_subscription.wp_subscription_model2 SET serialization_key= '" & serialkey & "',activation_key= '" & activate_key & "', device_id='" & deviceid & "', modified_date='" & Now().ToString("yyyy-MM-dd hh:mm:ss") & "' where serialization_key is not Null and activation_key is not Null and device_id is not Null and  uid='" & uid & "'"
            Else
                update = "update astro_subscription.wp_subscription_model SET serialization_key= '" & serialkey & "',activation_key= '" & activate_key & "', device_id='" & deviceid & "' , modified_date='" & Now().ToString("yyyy-MM-dd hh:mm:ss") & "' where serialization_key is not Null and activation_key is not Null and device_id is not Null and  uid='" & uid & "'"

            End If
            command.Connection = conn
            command.CommandText = update

            conn.Open() ''DB connection Open
            command.ExecuteNonQuery()
            If prod_type = "T" Then  ''Update the end_date in the database which is not available as user does not subscribe
                Dim enddate_update As String
                If devicenumber = 2 Then
                    enddate_update = "update astro_subscription.wp_subscription_model2 Set end_date= '" & end_date.ToString("yyyy-MM-dd hh:mm:ss") & "', modified_date='" & Now().ToString("yyyy-MM-dd hh:mm:ss") & "' where uid='" & uid & "'"
                Else
                    enddate_update = "update astro_subscription.wp_subscription_model Set end_date= '" & end_date.ToString("yyyy-MM-dd hh:mm:ss") & "', modified_date='" & Now().ToString("yyyy-MM-dd hh:mm:ss") & "' where uid='" & uid & "'"
                End If

                command.CommandText = enddate_update
                command.ExecuteNonQuery()
            End If
            conn.Close() '' Closing Database.
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function

    Public Function ActivateLicense(serverkey As String, balancedays As Integer, product As String, lastdate As Date)
        Try
            If product = "P" Or product = "D" Then
                Dim sublicense As New AstroSubscribeDLL.SubscriptionLicense
                If sublicense.Activate(serverkey, balancedays) Then
                    MsgBox(" Astro License activated till " + lastdate.ToString("dd/MM/yyyy") + " Please restart the application.", MessageBoxButtons.OK)
                End If

            ElseIf product = "T" Then
                Dim tlicense As New AstroSubscribeDLL.TrialLicense
                If tlicense.Activate(serverkey, trialperiod) Then
                    MsgBox(" Astro Trial License activated till " + lastdate.ToString("dd/MM/yyyy") + " Please restart the application.")
                End If
            Else
                MsgBox("Product Type is Incorrect!")
            End If

            sw.WriteLine(Now() & " " & "ActivationKey: " & activate_key)
            sw.Close()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function

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
            ''MsgBox(" Astro License activated till " + lastdate + "Please restart the application.")
            sw.WriteLine(Now() & " " & "File Generation Error: " + ex.Message)
        End Try
        sw.Close()
    End Function

    Private Sub btnTopUp_click(sender As Object, e As EventArgs) Handles btnTopUp.Click
        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult = MessageBox.Show("Do you want to Top-Up/Renew Subscription? Please click yes", "Renew", buttons)

        If result = DialogResult.Yes Then
            Me.Hide()
            System.Diagnostics.Process.Start("https://astrouser.com/renewal-subscription")
        ElseIf result = DialogResult.No Then
            Me.Show()
        End If

    End Sub
    Private Sub btnAddDevice_Click(sender As Object, e As EventArgs) Handles btnAddDevice.Click
        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult = MessageBox.Show("Do you want Add Second Device? Please click yes", "Add-Device", buttons)

        If result = DialogResult.Yes Then
            Me.Hide()
            System.Diagnostics.Process.Start("https://astrouser.com/renewal-subscription")
        ElseIf result = DialogResult.No Then
            Me.Show()
        End If
    End Sub
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnLogin_Click(Me, New EventArgs())
        End If
    End Sub
    Private Sub txtmobile_TextChanged(sender As Object, e As EventArgs) Handles txtmobile.TextChanged
        txtemail.Enabled = False
        ''MsgBox(" Astro Trial License activated till " + lastdate + " Please restart the application.")
    End Sub
    Private Sub txtemail_TextChanged(sender As Object, e As EventArgs) Handles txtemail.TextChanged
        txtmobile.Enabled = False
    End Sub

    ' Link Labels Start
    Private Sub ForgotPasswd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ForgotPasswd.LinkClicked
        System.Diagnostics.Process.Start("https://astrouser.com/subscription-password/?task=forgot")
    End Sub
    Private Sub helpdesk_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles helpdesk.LinkClicked
        System.Diagnostics.Process.Start("https://astrouser.com/helpdesk/")
    End Sub
    Private Sub lnkClearAll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkClearAll.LinkClicked
        txtemail.Text = String.Empty
        txtmobile.Text = String.Empty
        txtPassword.Text = String.Empty
        txtemail.Enabled = True
        txtmobile.Enabled = True
    End Sub
    Private Sub New_Register_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles New_Register.LinkClicked
        System.Diagnostics.Process.Start("https://astrouser.com/product-subscription/")
    End Sub
    Private Sub license_lnk_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles license_lnk.LinkClicked
        Dim licfilepath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\ASTROLICENSE.txt"
        If System.IO.File.Exists(licfilepath) = True Then
            Process.Start(licfilepath)
        Else
            MsgBox("File Does Not Exist")
        End If
    End Sub

    'Link Labels End

    Public Function GetVersion() 'get the latestversion from db
        Try
            Dim conn = New MySqlConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
            Dim mySelectQuery As String
            Dim myCommand As New MySqlCommand
            Dim currdate As Date = Now().ToString("yyyy-MM-dd")
            conn.Open()
            '' MySQL Commands
            mySelectQuery = "select version,file_link from astro_subscription.wp_versions where is_active='Y' order by id desc LIMIT 1 ;"

            myCommand.CommandText = mySelectQuery
            myCommand.Connection = conn
            Return myCommand.ExecuteReader()
            conn.Close()
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try

    End Function
    Private Sub latest_ver_Click(sender As Object, e As EventArgs) Handles latest_ver.Click

        System.Diagnostics.Process.Start(updatedlink) ' Automatically downloads the latest version
        Try

            Dim userRoot As String = Path.Combine(System.Environment.GetEnvironmentVariable("USERPROFILE"), "Downloads")
            Dim files = New DirectoryInfo(userRoot).GetFiles("*.exe*")
            Dim latestfile As String = ""
            Dim lastModified As DateTime = DateTime.MinValue
            Dim updateinstall As Process = New Process()
            'check the  latest downloaded file 
            For Each file As FileInfo In files
                If file.LastWriteTime > lastModified Then
                    lastModified = file.LastWriteTime
                    latestfile = file.Name
                End If
            Next

            'installation starts
            updateinstall.StartInfo.FileName = userRoot + "\" + latestfile
            updateinstall.Start()
            Application.Exit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub version_timer_Tick(sender As Object, e As EventArgs) Handles version_timer.Tick
        If latest_ver.Visible = True Then
            latest_ver.Visible = False
        Else
            latest_ver.Visible = True
        End If
        'removed the 30 time blink
    End Sub
    Public Function VersionCheck()
        Try
            Dim rdversion As MySqlDataReader
            rdversion = GetVersion()
            Dim presentVersion = ConfigurationManager.AppSettings("VersionCheck").ToString()

            If rdversion.Read() Then
                version = rdversion(0).ToString.Trim
                updatedlink = rdversion(1).ToString.Trim()
            End If
            If (presentVersion <> version) Then
                latest_ver.Text = "Click here to Download and install the " & vbCrLf & "latest Ver " & version
            End If
        Catch ex As Exception
            MsgBox(MsgBoxStyle.Critical, ex.Message)
        End Try
    End Function

    Private Sub btn_show_pwd_Click(sender As Object, e As EventArgs) Handles btn_show_pwd.Click
        If txtPassword.PasswordChar = "*" Then
            btn_hide_pwd.BringToFront()
            txtPassword.PasswordChar = vbNullChar
        End If
    End Sub

    Private Sub btn_hide_pwd_Click(sender As Object, e As EventArgs) Handles btn_hide_pwd.Click
        If txtPassword.PasswordChar = vbNullChar Then
            btn_show_pwd.BringToFront()
            txtPassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtmobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmobile.KeyPress
        If txtmobile.Text.Length >= 10 Then
            If e.KeyChar <> ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        If (String.IsNullOrEmpty(txtmobile.Text) And String.IsNullOrWhiteSpace(txtemail.Text)) Then
            MessageBox.Show("Mobile No. and Email ID both are blank. Enter any one. ", "Login Requirements", MessageBoxButtons.OK)
            txtemail.Enabled = True
            txtmobile.Enabled = True
        End If
    End Sub
End Class

