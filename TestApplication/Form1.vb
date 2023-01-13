Imports System
Imports System.ComponentModel
Imports System.Environment
Imports System.IO
Imports AstroSubscribeDLL
'Imports astrocustomerapp

Public Class Form1
    ' Private LicPath As String = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "AstroSubscribe", "license.lic")


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myLib As New AstroSubscribeDLL.WriteYourClass 'Is the main functionality of this Test Application
        Dim result = myLib.numbersquare(Me.NumericUpDown1.Value) 'numbersquare is the function accessible only through the astrosubscribedll
        MsgBox(String.Format("Result: {0}", result))

    End Sub

    Private Sub btnExpirty_Click(sender As Object, e As EventArgs) Handles btnExpirty.Click

        ''MsgBox("The Product ID is " & My.Settings.productID & " The remaining days are " & My.Settings.RemainingDays)
        'Dim fulllicense = New AstroSubscribeDLL.FullLicense
        'Dim subscriptionLicense = New AstroSubscribeDLL.SubscriptionLicense
        'Dim trialLicense = New AstroSubscribeDLL.TrialLicense
        'If Login.devicenumber = 1 Then

        '    If fulllicense.IsValid() Then
        '        MsgBox("Astro Diamond Full is active")
        '        My.Settings.productID = "F"
        '    ElseIf subscriptionLicense.IsValid() Then
        '        subscriptionLicense.Update()
        '        MsgBox("The Product ID is " & subscriptionLicense.ProductID & " The remaining days are " & subscriptionLicense.RemainingDays)
        '        My.Settings.productID = subscriptionLicense.ProductID
        '        My.Settings.RemainingDays = subscriptionLicense.RemainingDays
        '        My.Settings.SubscriptionPeriod = subscriptionLicense.SubscriptionPeriod
        '    ElseIf trialLicense.IsValid() Then
        '        trialLicense.Update()
        '        MsgBox("Astro Trial is active")
        '        My.Settings.productID = "T"
        '        My.Settings.RemainingDays = trialLicense.RemainingDays
        '    End If
        'ElseIf Login.devicenumber = 2 Then
        '    If fulllicense.IsValid() Then
        '        MsgBox("Astro Diamond Full is active")
        '        My.Settings.productID = "F"
        '    ElseIf subscriptionLicense.IsValid() Then
        '        subscriptionLicense.Update()
        '        MsgBox("The Product ID is " & subscriptionLicense.ProductID & " The remaining days are " & subscriptionLicense.RemainingDays)
        '        My.Settings.productID = subscriptionLicense.ProductID
        '        My.Settings.RemainingDays = subscriptionLicense.RemainingDays
        '        My.Settings.SubscriptionPeriod = subscriptionLicense.SubscriptionPeriod
        '    ElseIf trialLicense.IsValid() Then
        '        trialLicense.Update()
        '        MsgBox("Astro Trial is active")
        '        My.Settings.productID = "T"
        '        My.Settings.RemainingDays = trialLicense.RemainingDays
        '    End If
        'End If
    End Sub

    Private Sub btnOpenActivation_Click(sender As Object, e As EventArgs) Handles btnOpenActivation.Click
        Dim newActivationForm As New AstroSubscribeDLL.FormActivation()
        newActivationForm.ShowDialog()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.productID = "D" Then
            DiamondToolStripMenuItem.Enabled = True
            PEARLToolStripMenuItem.Enabled = False
            TrialToolStripMenuItem.Enabled = False

        ElseIf My.Settings.productID = "P" Then
            PEARLToolStripMenuItem.Enabled = True
            DiamondToolStripMenuItem.Enabled = False
            TrialToolStripMenuItem.Enabled = False
        Else
            TrialToolStripMenuItem.Enabled = True
            PEARLToolStripMenuItem.Enabled = False
            DiamondToolStripMenuItem.Enabled = False
        End If

        lblusernme.Text = "Welcome " + Login.customername
        lblname.Text = Login.computer_name
        lbldttime.Text = Now().ToString("dd/MM/yyyy hh:mm tt")

    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://astrouser.com/subscription-password/?task=change")
        Application.Exit()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub btnSunriseTime_Click(sender As Object, e As EventArgs) Handles btnSunriseTime.Click
        Dim acal As New astrocal
        Dim sunrise As String = (acal.FindSunRiseTime(-79, 18.5, 5, 10, 2022, 5.5)).ToString
        MsgBox("Sunrise at: " + sunrise)

    End Sub

    Private Sub btnListboxes_Click(sender As Object, e As EventArgs) Handles btnListboxes.Click
        Dim current As New astrocal
        Dim af As New astrofn

        Dim i As Integer


        '  current.kphousecal(3, 5, 1982, 6.11666667, 5.5, -83.45, 17.75, 2100)
        Dim lst As Double = (Now.Hour + Now.Minute / 60 + Now.Second / 3600)
        ' lst = dtpHM.Value.Hour + (dtpHM.Value.Minute) / 60 + (dtpHM.Value.Second) / 3600
        ' TEST for Karan  Dim lst As Double = (11 + 6 / 60 + Now.Second / 3600)

        ' current.housecal(Now.Day, Now.Month, Now.Year, lst, 5.5, -78.48944444, 17.40777778)
        'Abhisekh patodia chart for bhavamadhya and bhavarambha settings, passing optional parameter
        current.housecal(7, 3, 1984, 5.5, 5.5, -88.4, 22.566666666666666, False)
        'current.housecal(chart_day, chart_mon, chart_year, chart_ist, 5.5, -78.48333, 17.4) ''place longitude and lat is for Hyderabad
        '' current.kphousecal(25, 2, 1997, 2.45, 5.5, -79.15, 21.15, 24)
        '' Debug.Print(" ----")
        ''MsgBox("chart of Allen Woody")
        '   lstHouses.Items.Clear()
        For i = 1 To 12

            lstHouses.Items.Add(af.Roman(i) & " : " & current.degOfLong(current.housevalue(i)) & " : " & current.minOfLong(current.housevalue(i)))
            lstHouses.Items.Add(af.Roman(i) & " : " & af.Double2DMS(current.housevalue(i, 4))) '' Check for Mother's housevalues relation 4 is mother
            lstHouses.Items.Add(af.Roman(i) & " : " & af.Double2DMS(current.housevalue(i)))

            lstHouses.Items.Add("")
            Debug.Print(i & "  " & current.degOfLong(current.housevalue(i)) & " : " & current.minOfLong(current.housevalue(i)))
        Next i

        '' OK ?
        ''''yes
        'Calculating planetary position
        '' current.planetcal(25, 2, 1997, 2.45, 5.5, -79.15, 21.15)'''


        ''
        ''current.planetcal(18, 4, 1992, 22.6, 5.5, -79.75, 17.9666)
        '' current.planetcal(1, 12, 1935, 22.91666, -5.0, 73.96666, 40.78333)
        '   current.planetcal(3, 5, 1982, 6.11666667, 5.5, -83.45, 17.75)
        current.planetcal(Now.Day, Now.Month, Now.Year, lst, 5.5, af.DMS2Double(-78, 29, 23), af.DMS2Double(17, 24, 28))

        'Caluclation for Abhisekh patodia from Manju patodias book of computer astrology
        '  current.planetcal(7, 3, 1984, 5.5, 5.5, -88.4, 22.566666666666666) 'Abhishekh patodia test case

        'current.planetcal(chart_day, chart_mon, chart_year, chart_ist, 5.5, -78.48333, 17.4)
        '' current.planetcal(Now.Day, Now.Month, Now.Year, (Now.Hour + Now.Minute / 60), 5.5, -78.48333, 17.4)
        ''Debug.Print(" ----")
        ' lstPlanets.Items.Clear()
        For i = 1 To 12
            If current.planetretro(i) Then
                lstPlanets.Items.Add(af.planet_Name(i) & ":   " & current.degOfLong(current.planetvalue(i)) & " : " & current.minOfLong(current.planetvalue(i)) & " -R ")
                lstPlanets.Items.Add(af.planet_Name(i) & ":   " & af.Double2DMS(current.planetvalue(i)))
            Else
                lstPlanets.Items.Add(af.planet_Name(i) & ":   " & current.degOfLong(current.planetvalue(i)) & " : " & current.minOfLong(current.planetvalue(i)))
                '  lstPlanets.Items.Add(af.planet_Name(i) & ":   " & af.Double2DMS(current.planetvalue(i)))

            End If

            lstPlanets.Items.Add("")

            Debug.Print(i & " " & current.degOfLong(current.planetvalue(i)) & " : " & current.minOfLong(current.planetvalue(i)))

        Next i
        ''   MsgBox(" check the values in output window")

        ''Fortuna calculation 
        Dim fortuna As Double

        '   current.FindSunRiseTime(-78.48333, 17.4, chart_day, chart_mon, chart_year, 5.5)

        '   current.FindSunSetTime(-78.48333, 17.4, chart_day, chart_mon, chart_year, 5.5)
        'fortuna = current.FortunaValue(current.ist, current.srt, current.sst, current.planetvalue(1), current.planetvalue(2), current.chart_lagna)
        Dim srt = current.FindSunRiseTime(-83.45, 17.75, 3, 5, 1982, 5.5)
        Dim sst = current.FindSunSetTime(-83.45, 17.75, 3, 5, 1982, 5.5)
        fortuna = current.FortunaValue(6.1166667, srt, sst, current.planetvalue(1), current.planetvalue(2), current.housevalue(1))
        '  lstPlanets.Items.Add("Fortuna : " & af.Double2DMS(fortuna))
        '' MsgBox("Value of Fortuna is -->" & fortuna)
    End Sub

    Private Sub HelpDeskToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpDeskToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://astrouser.com/helpdesk/")
    End Sub
End Class
