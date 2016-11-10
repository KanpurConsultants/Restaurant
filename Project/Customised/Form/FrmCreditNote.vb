Public Class FrmCreditNote
    Inherits TempPayment

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.CreditNote
        Me.TransType = TransactionType.CreditNote
    End Sub


#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(754, 61)
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(681, 77)
        Me.Label3.Visible = False
        '
        'TxtChqDate
        '
        Me.TxtChqDate.Location = New System.Drawing.Point(749, 10)
        Me.TxtChqDate.Visible = False
        '
        'LblChqDate
        '
        Me.LblChqDate.Location = New System.Drawing.Point(681, 12)
        Me.LblChqDate.Visible = False
        '
        'TxtChqNo
        '
        Me.TxtChqNo.Location = New System.Drawing.Point(749, 31)
        Me.TxtChqNo.Visible = False
        '
        'LblChqNo
        '
        Me.LblChqNo.Location = New System.Drawing.Point(681, 31)
        Me.LblChqNo.Visible = False
        '
        'TxtCashBank
        '
        Me.TxtCashBank.Location = New System.Drawing.Point(770, 54)
        Me.TxtCashBank.Visible = False
        '
        'LblCashBank
        '
        Me.LblCashBank.Location = New System.Drawing.Point(681, 56)
        Me.LblCashBank.Visible = False
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.Location = New System.Drawing.Point(303, 77)
        '
        'TxtSubCode
        '
        Me.TxtSubCode.Location = New System.Drawing.Point(319, 71)
        '
        'LblSUbCode
        '
        Me.LblSUbCode.Location = New System.Drawing.Point(200, 72)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(319, 131)
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(200, 132)
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.Location = New System.Drawing.Point(749, 116)
        Me.TxtNetAmount.Visible = False
        '
        'LblNetAmount
        '
        Me.LblNetAmount.Location = New System.Drawing.Point(678, 116)
        Me.LblNetAmount.Visible = False
        '
        'TxtPaidAmount
        '
        Me.TxtPaidAmount.Location = New System.Drawing.Point(533, 91)
        '
        'LblPaidAmount
        '
        Me.LblPaidAmount.Location = New System.Drawing.Point(425, 92)
        '
        'TxtCurrBalance
        '
        Me.TxtCurrBalance.Location = New System.Drawing.Point(319, 91)
        '
        'lblCurrBalance
        '
        Me.lblCurrBalance.Location = New System.Drawing.Point(200, 92)
        '
        'TxtDiscount
        '
        Me.TxtDiscount.Location = New System.Drawing.Point(749, 95)
        Me.TxtDiscount.Visible = False
        '
        'LblDiscount
        '
        Me.LblDiscount.Location = New System.Drawing.Point(679, 97)
        Me.LblDiscount.Visible = False
        '
        'TxtCashBankAc
        '
        Me.TxtCashBankAc.Location = New System.Drawing.Point(319, 111)
        '
        'LblCashBankAc
        '
        Me.LblCashBankAc.Location = New System.Drawing.Point(200, 112)
        Me.LblCashBankAc.Size = New System.Drawing.Size(98, 16)
        Me.LblCashBankAc.Text = "Adjustment A/c"
        '
        'LblPaidAmountReq
        '
        Me.LblPaidAmountReq.Location = New System.Drawing.Point(517, 98)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(425, 52)
        Me.LblV_No.Size = New System.Drawing.Size(63, 16)
        Me.LblV_No.Text = "Entry No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(533, 51)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(303, 57)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(200, 52)
        Me.LblV_Date.Size = New System.Drawing.Size(70, 16)
        Me.LblV_Date.Text = "Entry Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(517, 37)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(319, 51)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(425, 33)
        Me.LblV_Type.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Type.Text = "Entry Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(533, 31)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(303, 37)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(200, 32)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 31)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(485, 52)
        '
        'FrmCreditNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 317)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "DuesPayment_Log"
        Me.MainLineTableCsv = ""
        Me.MainTableName = "DuesPayment"
        Me.Name = "FrmCreditNote"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region




    Private Sub FrmMoneyReceipt_BaseEvent_Form_PreLoad()

    End Sub

    Private Sub FrmMoneyReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 350, 885)
    End Sub
End Class
