Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class Form3
    Private Sub Form3_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtetme As DateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"))
        Dim prodtype As String = "T"
        Dim key As New AstroSubscribeDLL.AstroLicense
        Dim deviceid = key.DeviceID
        ' Getting serial Key  and creating License path in system 
        Dim sk As New AstroSubscribeDLL.TrialLicense
        Dim serialkey = sk.SerialKeySubscriptionTrial()

        Dim activeKey As New ActivationKey.ActivationKey()
        Dim currentDate As DateTime = Now()
        Dim Passdt As String = currentDate.ToString("ddMMyyyy")
        Dim ak As String = activeKey.CallActivationKey(prodtype, deviceid, serialkey, "A$trOWeb" + Passdt)

        Dim licpath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\AstroSubscribe"
        If Not System.IO.Directory.Exists(licpath) Then
            System.IO.Directory.CreateDirectory(licpath)
        End If
        If Not (IO.File.Exists(licpath + "license.lic")) Then
            Dim message As String = ak
            Using writer As New StreamWriter(licpath + "\license.lic")
                writer.WriteLine(message)
                writer.Close()
            End Using
        End If

        Dim myLib As New AstroSubscribeDLL.WriteYourClass 'Is the main functionality of this Test Application
        Dim result = myLib.numbersquare(10) 'numbersquare is the function accessible only through the astrosubscribedll
        MsgBox(String.Format("Result: {0}", result))

    End Sub
End Class