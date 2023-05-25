'   Program Name:   BMI Calculator
'   Purpose:        Calculate user's BMI based on height and weight
'   Developer:      Ethan King
'   Date:           4/25/2023
Public Class frmBMICalculator
    Private Sub frmBMICalculator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Display splash screen 1 second (edited in GitHub)
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub lstSystemSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSystemSelect.SelectedIndexChanged
        Dim intSystemSelect As Integer

        intSystemSelect = lstSystemSelect.SelectedIndex
        Select Case intSystemSelect
            Case 0
                lblHeight.Text = "Height (in)"
                lblWeight.Text = "Weight (lb)"
            Case 1
                lblHeight.Text = "Height (m)"
                lblWeight.Text = "Weight (kg)"
        End Select

        '   Enable text boxes and buttons
        txtHeight.Enabled = True
        txtWeight.Enabled = True
        btnCalculate.Enabled = True
        btnClear.Enabled = True
    End Sub

    Private Function fncValidateHeight() As Boolean
        '   Declare variables
        Dim decHeight As Integer
        Dim blnHeightValidityCheck As Boolean = False
        Dim strHeightMessage As String = "Please enter your height, above 0."
        Dim strMessageTitle As String = "Error"
        '   Test for errors
        Try
            decHeight = Convert.ToDecimal(txtHeight.Text)
            If decHeight >= 1 Then
                blnHeightValidityCheck = True

            Else
                MsgBox(strHeightMessage, , strMessageTitle)
                txtHeight.Focus()
                txtHeight.Clear()
            End If


        Catch ex As FormatException
            MsgBox(strHeightMessage, , strMessageTitle)
            txtHeight.Focus()
            txtHeight.Clear()
        Catch ex As OverflowException
            MsgBox(strHeightMessage, , strMessageTitle)
            txtHeight.Focus()
            txtHeight.Clear()
        Catch ex As SystemException
            MsgBox(strHeightMessage, , strMessageTitle)
            txtHeight.Focus()
            txtHeight.Clear()
        End Try

        Return blnHeightValidityCheck
    End Function

    Private Function fncValidateWeight() As Boolean
        '   Declare variables
        Dim decWeight As Decimal
        Dim blnWeightValidityCheck As Boolean = False
        Dim strWeightMessage As String = "Please enter your weight"
        Dim strMessageTitle As String = "Error"

        '   Test for errors
        Try
            decWeight = Convert.ToDecimal(txtWeight.Text)
            blnWeightValidityCheck = True

        Catch ex As FormatException
            MsgBox(strWeightMessage, , strMessageTitle)
            txtWeight.Clear()
        Catch ex As OverflowException
            MsgBox(strWeightMessage, , strMessageTitle)
            txtWeight.Clear()
        Catch ex As SystemException
            MsgBox(strWeightMessage, , strMessageTitle)
            txtWeight.Clear()
        End Try

        Return blnWeightValidityCheck
    End Function
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        '   Declare Variables
        Dim decHeight As Decimal
        Dim decWeight As Decimal
        Dim blnHeightValid As Boolean = False
        Dim blnWeightValid As Boolean = False
        Dim decFinalBMI As Decimal
        Dim intSystemSelect As Integer

        intSystemSelect = lstSystemSelect.SelectedIndex
        '   Are height and weight valid?
        blnHeightValid = fncValidateHeight()
        blnWeightValid = fncValidateWeight()

        If (blnHeightValid And blnWeightValid) Then
            decHeight = Convert.ToDecimal(txtHeight.Text)
            decWeight = Convert.ToDecimal(txtWeight.Text)

            '   Select which formula to use to calculate BMI
            Select Case intSystemSelect
                Case 0
                    '   Calculate BMI
                    decFinalBMI = ((decWeight / (decHeight * decHeight)) * 703)
                Case 1
                    '   Calculate BMI
                    decFinalBMI = (decWeight / (decHeight * decHeight))
            End Select
            '   Display BMI
            lblResult.Text = "BMI: " & decFinalBMI.ToString("N1")
            lblResult.Visible = True


        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        '   Clear out data
        txtHeight.Clear()
        txtWeight.Clear()
        lblResult.Text = ""

    End Sub
End Class
