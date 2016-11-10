Imports CrystalDecisions.CrystalReports.Engine
Public Class TempPayment
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)



    Dim DtDuesPaymentEnviro As DataTable
    Dim mTransactionType As TransactionType = TransactionType.Payment
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents Label3 As System.Windows.Forms.Label

    Dim mReferenceNCat$ = ""

    Public Property ReferenceNCat() As String
        Get
            ReferenceNCat = mReferenceNCat
        End Get
        Set(ByVal value As String)
            mReferenceNCat = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Enum TransactionType
        Receipt = 0
        Payment = 1
        CreditNote = 2
        DebitNote = 3
    End Enum

    Public Property TransType() As TransactionType
        Get
            Return mTransactionType
        End Get
        Set(ByVal value As TransactionType)
            mTransactionType = value            
        End Set
    End Property


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.TxtChqDate = New AgControls.AgTextBox
        Me.LblChqDate = New System.Windows.Forms.Label
        Me.TxtChqNo = New AgControls.AgTextBox
        Me.LblChqNo = New System.Windows.Forms.Label
        Me.TxtCashBank = New AgControls.AgTextBox
        Me.LblCashBank = New System.Windows.Forms.Label
        Me.LblSubCodeReq = New System.Windows.Forms.Label
        Me.TxtSubCode = New AgControls.AgTextBox
        Me.LblSUbCode = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtNetAmount = New AgControls.AgTextBox
        Me.LblNetAmount = New System.Windows.Forms.Label
        Me.TxtPaidAmount = New AgControls.AgTextBox
        Me.LblPaidAmount = New System.Windows.Forms.Label
        Me.TxtCurrBalance = New AgControls.AgTextBox
        Me.lblCurrBalance = New System.Windows.Forms.Label
        Me.TxtDiscount = New AgControls.AgTextBox
        Me.LblDiscount = New System.Windows.Forms.Label
        Me.TxtCashBankAc = New AgControls.AgTextBox
        Me.LblCashBankAc = New System.Windows.Forms.Label
        Me.LblPaidAmountReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
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
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(723, 276)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 276)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 19)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 276)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(241, 276)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 276)
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 272)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(496, 276)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(425, 31)
        Me.LblV_No.Size = New System.Drawing.Size(84, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Payment No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(533, 30)
        Me.TxtV_No.Size = New System.Drawing.Size(123, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(303, 36)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(200, 31)
        Me.LblV_Date.Size = New System.Drawing.Size(91, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Payment Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(517, 16)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(319, 30)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(425, 12)
        Me.LblV_Type.Size = New System.Drawing.Size(92, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Payment Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(533, 10)
        Me.TxtV_Type.Size = New System.Drawing.Size(123, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(303, 16)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(200, 11)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 10)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(485, 31)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 41)
        Me.TabControl1.Size = New System.Drawing.Size(886, 237)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.LblPaidAmountReq)
        Me.TP1.Controls.Add(Me.TxtCashBankAc)
        Me.TP1.Controls.Add(Me.LblCashBankAc)
        Me.TP1.Controls.Add(Me.TxtDiscount)
        Me.TP1.Controls.Add(Me.LblDiscount)
        Me.TP1.Controls.Add(Me.TxtNetAmount)
        Me.TP1.Controls.Add(Me.LblNetAmount)
        Me.TP1.Controls.Add(Me.TxtPaidAmount)
        Me.TP1.Controls.Add(Me.LblPaidAmount)
        Me.TP1.Controls.Add(Me.TxtCurrBalance)
        Me.TP1.Controls.Add(Me.lblCurrBalance)
        Me.TP1.Controls.Add(Me.TxtChqDate)
        Me.TP1.Controls.Add(Me.LblChqDate)
        Me.TP1.Controls.Add(Me.TxtChqNo)
        Me.TP1.Controls.Add(Me.LblChqNo)
        Me.TP1.Controls.Add(Me.TxtCashBank)
        Me.TP1.Controls.Add(Me.LblCashBank)
        Me.TP1.Controls.Add(Me.LblSubCodeReq)
        Me.TP1.Controls.Add(Me.TxtSubCode)
        Me.TP1.Controls.Add(Me.LblSUbCode)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(878, 211)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSUbCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubCode, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubCodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCashBank, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCashBank, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblChqNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtChqNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblChqDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtChqDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.lblCurrBalance, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrBalance, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPaidAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPaidAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblNetAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtNetAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDiscount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDiscount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCashBankAc, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCashBankAc, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPaidAmountReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        Me.Topctrl1.TabIndex = 1
        '
        'TxtChqDate
        '
        Me.TxtChqDate.AgMandatory = False
        Me.TxtChqDate.AgMasterHelp = False
        Me.TxtChqDate.AgNumberLeftPlaces = 8
        Me.TxtChqDate.AgNumberNegetiveAllow = False
        Me.TxtChqDate.AgNumberRightPlaces = 2
        Me.TxtChqDate.AgPickFromLastValue = False
        Me.TxtChqDate.AgRowFilter = ""
        Me.TxtChqDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChqDate.AgSelectedValue = Nothing
        Me.TxtChqDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChqDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtChqDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChqDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChqDate.Location = New System.Drawing.Point(533, 150)
        Me.TxtChqDate.MaxLength = 20
        Me.TxtChqDate.Name = "TxtChqDate"
        Me.TxtChqDate.Size = New System.Drawing.Size(123, 18)
        Me.TxtChqDate.TabIndex = 11
        '
        'LblChqDate
        '
        Me.LblChqDate.AutoSize = True
        Me.LblChqDate.BackColor = System.Drawing.Color.Transparent
        Me.LblChqDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChqDate.Location = New System.Drawing.Point(425, 151)
        Me.LblChqDate.Name = "LblChqDate"
        Me.LblChqDate.Size = New System.Drawing.Size(62, 16)
        Me.LblChqDate.TabIndex = 749
        Me.LblChqDate.Text = "Chq Date"
        '
        'TxtChqNo
        '
        Me.TxtChqNo.AgMandatory = False
        Me.TxtChqNo.AgMasterHelp = False
        Me.TxtChqNo.AgNumberLeftPlaces = 8
        Me.TxtChqNo.AgNumberNegetiveAllow = False
        Me.TxtChqNo.AgNumberRightPlaces = 2
        Me.TxtChqNo.AgPickFromLastValue = False
        Me.TxtChqNo.AgRowFilter = ""
        Me.TxtChqNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChqNo.AgSelectedValue = Nothing
        Me.TxtChqNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChqNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtChqNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChqNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChqNo.Location = New System.Drawing.Point(319, 150)
        Me.TxtChqNo.MaxLength = 20
        Me.TxtChqNo.Name = "TxtChqNo"
        Me.TxtChqNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtChqNo.TabIndex = 10
        '
        'LblChqNo
        '
        Me.LblChqNo.AutoSize = True
        Me.LblChqNo.BackColor = System.Drawing.Color.Transparent
        Me.LblChqNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChqNo.Location = New System.Drawing.Point(200, 151)
        Me.LblChqNo.Name = "LblChqNo"
        Me.LblChqNo.Size = New System.Drawing.Size(51, 16)
        Me.LblChqNo.TabIndex = 748
        Me.LblChqNo.Text = "Chq No"
        '
        'TxtCashBank
        '
        Me.TxtCashBank.AgMandatory = True
        Me.TxtCashBank.AgMasterHelp = False
        Me.TxtCashBank.AgNumberLeftPlaces = 8
        Me.TxtCashBank.AgNumberNegetiveAllow = False
        Me.TxtCashBank.AgNumberRightPlaces = 2
        Me.TxtCashBank.AgPickFromLastValue = False
        Me.TxtCashBank.AgRowFilter = ""
        Me.TxtCashBank.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCashBank.AgSelectedValue = Nothing
        Me.TxtCashBank.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCashBank.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCashBank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCashBank.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCashBank.Location = New System.Drawing.Point(319, 110)
        Me.TxtCashBank.MaxLength = 20
        Me.TxtCashBank.Name = "TxtCashBank"
        Me.TxtCashBank.Size = New System.Drawing.Size(100, 18)
        Me.TxtCashBank.TabIndex = 8
        '
        'LblCashBank
        '
        Me.LblCashBank.AutoSize = True
        Me.LblCashBank.BackColor = System.Drawing.Color.Transparent
        Me.LblCashBank.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCashBank.Location = New System.Drawing.Point(200, 110)
        Me.LblCashBank.Name = "LblCashBank"
        Me.LblCashBank.Size = New System.Drawing.Size(72, 16)
        Me.LblCashBank.TabIndex = 747
        Me.LblCashBank.Text = "Cash/Bank"
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.AutoSize = True
        Me.LblSubCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubCodeReq.Location = New System.Drawing.Point(303, 56)
        Me.LblSubCodeReq.Name = "LblSubCodeReq"
        Me.LblSubCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubCodeReq.TabIndex = 746
        Me.LblSubCodeReq.Text = "Ä"
        '
        'TxtSubCode
        '
        Me.TxtSubCode.AgMandatory = True
        Me.TxtSubCode.AgMasterHelp = False
        Me.TxtSubCode.AgNumberLeftPlaces = 8
        Me.TxtSubCode.AgNumberNegetiveAllow = False
        Me.TxtSubCode.AgNumberRightPlaces = 2
        Me.TxtSubCode.AgPickFromLastValue = False
        Me.TxtSubCode.AgRowFilter = ""
        Me.TxtSubCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubCode.AgSelectedValue = Nothing
        Me.TxtSubCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubCode.Location = New System.Drawing.Point(319, 50)
        Me.TxtSubCode.MaxLength = 20
        Me.TxtSubCode.Name = "TxtSubCode"
        Me.TxtSubCode.Size = New System.Drawing.Size(337, 18)
        Me.TxtSubCode.TabIndex = 3
        '
        'LblSUbCode
        '
        Me.LblSUbCode.AutoSize = True
        Me.LblSUbCode.BackColor = System.Drawing.Color.Transparent
        Me.LblSUbCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSUbCode.Location = New System.Drawing.Point(200, 51)
        Me.LblSUbCode.Name = "LblSUbCode"
        Me.LblSUbCode.Size = New System.Drawing.Size(39, 16)
        Me.LblSUbCode.TabIndex = 745
        Me.LblSUbCode.Text = "Party"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(319, 170)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(337, 18)
        Me.TxtRemarks.TabIndex = 12
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(200, 171)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 744
        Me.Label30.Text = "Remarks"
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.AgMandatory = False
        Me.TxtNetAmount.AgMasterHelp = False
        Me.TxtNetAmount.AgNumberLeftPlaces = 8
        Me.TxtNetAmount.AgNumberNegetiveAllow = False
        Me.TxtNetAmount.AgNumberRightPlaces = 2
        Me.TxtNetAmount.AgPickFromLastValue = False
        Me.TxtNetAmount.AgRowFilter = ""
        Me.TxtNetAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNetAmount.AgSelectedValue = Nothing
        Me.TxtNetAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNetAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNetAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmount.Location = New System.Drawing.Point(533, 90)
        Me.TxtNetAmount.MaxLength = 20
        Me.TxtNetAmount.Name = "TxtNetAmount"
        Me.TxtNetAmount.Size = New System.Drawing.Size(123, 18)
        Me.TxtNetAmount.TabIndex = 7
        Me.TxtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblNetAmount
        '
        Me.LblNetAmount.AutoSize = True
        Me.LblNetAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNetAmount.Location = New System.Drawing.Point(425, 90)
        Me.LblNetAmount.Name = "LblNetAmount"
        Me.LblNetAmount.Size = New System.Drawing.Size(77, 16)
        Me.LblNetAmount.TabIndex = 755
        Me.LblNetAmount.Text = "Net Amount"
        '
        'TxtPaidAmount
        '
        Me.TxtPaidAmount.AgMandatory = True
        Me.TxtPaidAmount.AgMasterHelp = False
        Me.TxtPaidAmount.AgNumberLeftPlaces = 8
        Me.TxtPaidAmount.AgNumberNegetiveAllow = False
        Me.TxtPaidAmount.AgNumberRightPlaces = 2
        Me.TxtPaidAmount.AgPickFromLastValue = False
        Me.TxtPaidAmount.AgRowFilter = ""
        Me.TxtPaidAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPaidAmount.AgSelectedValue = Nothing
        Me.TxtPaidAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPaidAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPaidAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPaidAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaidAmount.Location = New System.Drawing.Point(533, 70)
        Me.TxtPaidAmount.MaxLength = 20
        Me.TxtPaidAmount.Name = "TxtPaidAmount"
        Me.TxtPaidAmount.Size = New System.Drawing.Size(123, 18)
        Me.TxtPaidAmount.TabIndex = 5
        Me.TxtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblPaidAmount
        '
        Me.LblPaidAmount.AutoSize = True
        Me.LblPaidAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblPaidAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaidAmount.Location = New System.Drawing.Point(425, 71)
        Me.LblPaidAmount.Name = "LblPaidAmount"
        Me.LblPaidAmount.Size = New System.Drawing.Size(83, 16)
        Me.LblPaidAmount.TabIndex = 754
        Me.LblPaidAmount.Text = "Paid Amount"
        '
        'TxtCurrBalance
        '
        Me.TxtCurrBalance.AgMandatory = False
        Me.TxtCurrBalance.AgMasterHelp = False
        Me.TxtCurrBalance.AgNumberLeftPlaces = 8
        Me.TxtCurrBalance.AgNumberNegetiveAllow = False
        Me.TxtCurrBalance.AgNumberRightPlaces = 2
        Me.TxtCurrBalance.AgPickFromLastValue = False
        Me.TxtCurrBalance.AgRowFilter = ""
        Me.TxtCurrBalance.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrBalance.AgSelectedValue = Nothing
        Me.TxtCurrBalance.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrBalance.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtCurrBalance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrBalance.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrBalance.Location = New System.Drawing.Point(319, 70)
        Me.TxtCurrBalance.MaxLength = 20
        Me.TxtCurrBalance.Name = "TxtCurrBalance"
        Me.TxtCurrBalance.Size = New System.Drawing.Size(100, 18)
        Me.TxtCurrBalance.TabIndex = 4
        Me.TxtCurrBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCurrBalance
        '
        Me.lblCurrBalance.AutoSize = True
        Me.lblCurrBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrBalance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrBalance.Location = New System.Drawing.Point(200, 71)
        Me.lblCurrBalance.Name = "lblCurrBalance"
        Me.lblCurrBalance.Size = New System.Drawing.Size(83, 16)
        Me.lblCurrBalance.TabIndex = 753
        Me.lblCurrBalance.Text = "Curr Balance"
        '
        'TxtDiscount
        '
        Me.TxtDiscount.AgMandatory = False
        Me.TxtDiscount.AgMasterHelp = False
        Me.TxtDiscount.AgNumberLeftPlaces = 8
        Me.TxtDiscount.AgNumberNegetiveAllow = False
        Me.TxtDiscount.AgNumberRightPlaces = 2
        Me.TxtDiscount.AgPickFromLastValue = False
        Me.TxtDiscount.AgRowFilter = ""
        Me.TxtDiscount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDiscount.AgSelectedValue = Nothing
        Me.TxtDiscount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDiscount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiscount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscount.Location = New System.Drawing.Point(319, 90)
        Me.TxtDiscount.MaxLength = 20
        Me.TxtDiscount.Name = "TxtDiscount"
        Me.TxtDiscount.Size = New System.Drawing.Size(100, 18)
        Me.TxtDiscount.TabIndex = 6
        Me.TxtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDiscount
        '
        Me.LblDiscount.AutoSize = True
        Me.LblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.LblDiscount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscount.Location = New System.Drawing.Point(200, 91)
        Me.LblDiscount.Name = "LblDiscount"
        Me.LblDiscount.Size = New System.Drawing.Size(59, 16)
        Me.LblDiscount.TabIndex = 757
        Me.LblDiscount.Text = "Discount"
        '
        'TxtCashBankAc
        '
        Me.TxtCashBankAc.AgMandatory = False
        Me.TxtCashBankAc.AgMasterHelp = False
        Me.TxtCashBankAc.AgNumberLeftPlaces = 8
        Me.TxtCashBankAc.AgNumberNegetiveAllow = False
        Me.TxtCashBankAc.AgNumberRightPlaces = 2
        Me.TxtCashBankAc.AgPickFromLastValue = False
        Me.TxtCashBankAc.AgRowFilter = ""
        Me.TxtCashBankAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCashBankAc.AgSelectedValue = Nothing
        Me.TxtCashBankAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCashBankAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCashBankAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCashBankAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCashBankAc.Location = New System.Drawing.Point(319, 130)
        Me.TxtCashBankAc.MaxLength = 20
        Me.TxtCashBankAc.Name = "TxtCashBankAc"
        Me.TxtCashBankAc.Size = New System.Drawing.Size(337, 18)
        Me.TxtCashBankAc.TabIndex = 9
        '
        'LblCashBankAc
        '
        Me.LblCashBankAc.AutoSize = True
        Me.LblCashBankAc.BackColor = System.Drawing.Color.Transparent
        Me.LblCashBankAc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCashBankAc.Location = New System.Drawing.Point(200, 131)
        Me.LblCashBankAc.Name = "LblCashBankAc"
        Me.LblCashBankAc.Size = New System.Drawing.Size(62, 16)
        Me.LblCashBankAc.TabIndex = 759
        Me.LblCashBankAc.Text = "Bank A/c"
        '
        'LblPaidAmountReq
        '
        Me.LblPaidAmountReq.AutoSize = True
        Me.LblPaidAmountReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPaidAmountReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPaidAmountReq.Location = New System.Drawing.Point(517, 77)
        Me.LblPaidAmountReq.Name = "LblPaidAmountReq"
        Me.LblPaidAmountReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPaidAmountReq.TabIndex = 761
        Me.LblPaidAmountReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(303, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 762
        Me.Label1.Text = "Ä"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(425, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 763
        Me.Label3.Text = "'C' - Cash / 'B' - Bank"
        '
        'TempPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(879, 317)
        Me.Name = "TempPayment"
        Me.Text = "Template Goods Receive"
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
    Protected WithEvents TxtChqDate As AgControls.AgTextBox
    Protected WithEvents LblChqDate As System.Windows.Forms.Label
    Protected WithEvents TxtChqNo As AgControls.AgTextBox
    Protected WithEvents LblChqNo As System.Windows.Forms.Label
    Protected WithEvents TxtCashBank As AgControls.AgTextBox
    Protected WithEvents LblCashBank As System.Windows.Forms.Label
    Protected WithEvents LblSubCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtSubCode As AgControls.AgTextBox
    Protected WithEvents LblSUbCode As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtNetAmount As AgControls.AgTextBox
    Protected WithEvents LblNetAmount As System.Windows.Forms.Label
    Protected WithEvents TxtPaidAmount As AgControls.AgTextBox
    Protected WithEvents LblPaidAmount As System.Windows.Forms.Label
    Protected WithEvents TxtCurrBalance As AgControls.AgTextBox
    Protected WithEvents lblCurrBalance As System.Windows.Forms.Label
    Protected WithEvents TxtDiscount As AgControls.AgTextBox
    Protected WithEvents LblDiscount As System.Windows.Forms.Label
    Protected WithEvents TxtCashBankAc As AgControls.AgTextBox
    Protected WithEvents LblCashBankAc As System.Windows.Forms.Label
    Protected WithEvents LblPaidAmountReq As System.Windows.Forms.Label
#End Region

    Private Sub FrmBillEntry_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim mContraText As String = "", mCashBankAc As String, mNarration$


        If Me.TransType = TransactionType.CreditNote Or Me.TransType = TransactionType.DebitNote Then

            mCashBankAc = TxtCashBankAc.AgSelectedValue
        ElseIf AgL.StrCmp(TxtCashBank.Text, "Bank") Then
            mCashBankAc = TxtCashBankAc.AgSelectedValue
        Else
            mCashBankAc = AgL.XNull(DtDuesPaymentEnviro.Rows(0)("CashAc"))
        End If


        mNarration = TxtRemarks.Text
        If TxtChqNo.Text <> "" Then mNarration += mNarration + " CHQ No." + TxtChqNo.Text
        If TxtChqDate.Text <> "" Then mNarration += mNarration + " CHQ Date." + TxtChqDate.Text

        mQry = "Delete from Ledger Where DocID ='" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)



        ClsMain.FPrepareContraText(True, mContraText, TxtSubCode.AgSelectedValue, TxtNetAmount.Text, IIf(Me.TransType = TransactionType.Payment, "Dr", "Cr"))
        If Val(TxtDiscount.Text) > 0 Then
            mContraText += vbCrLf
            ClsMain.FPrepareContraText(False, mContraText, AgL.XNull(DtDuesPaymentEnviro.Rows(0)("DiscountAc")), TxtDiscount.Text, IIf(Me.TransType = TransactionType.Payment, "Cr", "Dr"))
        End If
        mQry = "Insert Into Ledger(DocId,RecId,V_SNo,V_Date,SubCode,ContraSub,AmtDr,AmtCr," & _
                                     "Narration,V_Type,V_No,V_Prefix,Site_Code,Chq_No,Chq_Date,TDSCategory,TDSOnAmt,TDSDesc,TDSPer,TDS_Of_V_SNo,System_Generated,FormulaString,ContraText) Values " & _
                                     "('" & mInternalCode & "','" & TxtV_No.Text & "', 1 ," & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(mCashBankAc) & "," & AgL.Chk_Text("") & ", " & _
                                     "" & IIf(Not Me.TransType = TransactionType.Payment, Val(TxtPaidAmount.Text), 0) & "," & IIf(Me.TransType = TransactionType.Payment, Val(TxtPaidAmount.Text), 0) & ", " & _
                                     "" & AgL.Chk_Text(TxtRemarks.Text) & ",'" & TxtV_Type.AgSelectedValue & "','" & Val(TxtV_No.Text) & "','" & LblPrefix.Text & "'," & _
                                     "'" & TxtSite_Code.AgSelectedValue & "','" & AgL.Chk_Text(TxtChqNo.Text) & "'," & _
                                     "" & AgL.ConvertDate(TxtChqDate.Text) & "," & AgL.Chk_Text("") & "," & _
                                     "" & Val("") & "," & AgL.Chk_Text("") & "," & Val("") & "," & 0 & ",'Y','" & "" & "','" & mContraText & "')"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If Val(TxtDiscount.Text) > 0 Then
            ClsMain.FPrepareContraText(True, mContraText, TxtSubCode.AgSelectedValue, TxtNetAmount.Text, IIf(Me.TransType = TransactionType.Payment, "Dr", "Cr"))
            If Val(TxtPaidAmount.Text) > 0 Then
                mContraText += vbCrLf
                ClsMain.FPrepareContraText(False, mContraText, mCashBankAc, TxtPaidAmount.Text, IIf(Me.TransType = TransactionType.Payment, "Cr", "Dr"))
            End If
            mQry = "Insert Into Ledger(DocId,RecId,V_SNo,V_Date,SubCode,ContraSub,AmtDr,AmtCr," & _
                                         "Narration,V_Type,V_No,V_Prefix,Site_Code,Chq_No,Chq_Date,TDSCategory,TDSOnAmt,TDSDesc,TDSPer,TDS_Of_V_SNo,System_Generated,FormulaString,ContraText) Values " & _
                                         "('" & mInternalCode & "','" & TxtV_No.Text & "', 2 ," & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(AgL.XNull(DtDuesPaymentEnviro.Rows(0)("DiscountAc"))) & "," & AgL.Chk_Text("") & ", " & _
                                         "" & IIf(Not Me.TransType = TransactionType.Payment, Val(TxtDiscount.Text), 0) & "," & IIf(Me.TransType = TransactionType.Payment, Val(TxtDiscount.Text), 0) & ", " & _
                                         "" & AgL.Chk_Text(TxtRemarks.Text) & ",'" & TxtV_Type.AgSelectedValue & "','" & Val(TxtV_No.Text) & "','" & LblPrefix.Text & "'," & _
                                         "'" & TxtSite_Code.AgSelectedValue & "','" & AgL.Chk_Text("") & "'," & _
                                         "" & AgL.ConvertDate("") & "," & AgL.Chk_Text("") & "," & _
                                         "" & Val("") & "," & AgL.Chk_Text("") & "," & Val("") & "," & 0 & ",'Y','" & "" & "','" & mContraText & "')"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        ClsMain.FPrepareContraText(True, mContraText, mCashBankAc, TxtPaidAmount.Text, IIf(Me.TransType = TransactionType.Payment, "Cr", "Dr"))
        If Val(TxtDiscount.Text) > 0 Then
            mContraText += vbCrLf
            ClsMain.FPrepareContraText(False, mContraText, AgL.XNull(DtDuesPaymentEnviro.Rows(0)("DiscountAc")), TxtDiscount.Text, IIf(Me.TransType = TransactionType.Payment, "Cr", "Dr"))
        End If
        mQry = "Insert Into Ledger(DocId,RecId,V_SNo,V_Date,SubCode,ContraSub,AmtDr,AmtCr," & _
                                     "Narration,V_Type,V_No,V_Prefix,Site_Code,Chq_No,Chq_Date,TDSCategory,TDSOnAmt,TDSDesc,TDSPer,TDS_Of_V_SNo,System_Generated,FormulaString,ContraText) Values " & _
                                     "('" & mInternalCode & "','" & TxtV_No.Text & "', 3 ," & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & "," & AgL.Chk_Text("") & ", " & _
                                     "" & IIf(Me.TransType = TransactionType.Payment, Val(TxtNetAmount.Text), 0) & "," & IIf(Not Me.TransType = TransactionType.Payment, Val(TxtNetAmount.Text), 0) & ", " & _
                                     "" & AgL.Chk_Text(TxtRemarks.Text) & ",'" & TxtV_Type.AgSelectedValue & "','" & Val(TxtV_No.Text) & "','" & LblPrefix.Text & "'," & _
                                     "'" & TxtSite_Code.AgSelectedValue & "','" & AgL.Chk_Text("") & "'," & _
                                     "" & AgL.ConvertDate("") & "," & AgL.Chk_Text("") & "," & _
                                     "" & Val("") & "," & AgL.Chk_Text("") & "," & Val("") & "," & 0 & ",'Y','" & "" & "','" & mContraText & "')"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "DuesPayment"
        LogTableName = "DuesPayment_Log"
        MainLineTableCsv = ""
        LogLineTableCsv = ""

    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From DuesPayment H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0 And IsNull(H.TransactionType,'Payment')='" & IIf(mTransactionType = TransactionType.Payment, "Payment", "Receipt") & "'  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select H.UID As SearchCode, H.DocID " & _
               " From DuesPayment_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "'  And IsNull(H.TransactionType,'Payment')='" & IIf(mTransactionType = TransactionType.Payment, "Payment", "Receipt") & "'   " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"


        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Payment Type], H.V_Date AS [Date], H.V_No AS [Payment No], " & _
            " H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], H.PartyCity AS [Party City],  " & _
            " H.PaidAmount AS [Paid Amount], H.Discount, H.NetAmount AS [Net Amount], H.CashBank AS [Cash/Bank],  " & _
            " H.CashBankAc AS [Cash/Bank A/c], H.ChqNo AS [Cheque No], H.ChqDate AS [Cheque Date], H.Remark,   " & _
            " H.Status, H.TDSPer AS [TDS %], H.TDSAmt AS [TDS Amount], " & _
            " D.Div_Name AS Division, SM.Name AS [Site Name]  " & _
            " FROM  DuesPayment_Log H " & _
            " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
            " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
            " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"



        AgL.PubFindQry = " SELECT H.DocId AS SearchCode, H.V_Type AS [Payment Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [Payment No], " & _
                            " H.TransactionType AS [TRANSACTION Type], H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], H.PartyCity AS [Party City],  " & _
                            " H.CurrBalance AS [Currunt Balance], H.PaidAmount AS [Paid Amount], H.Discount, H.NetAmount AS [Net Amount], H.CashBank AS [Cash/Bank],  " & _
                            " H.CashBankAc AS [Cash/Bank A/c], H.ChqNo AS [Cheque No], H.ChqDate AS [Cheque Date], H.Remark, H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date],  " & _
                            " H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                            " H.MoveToLogDate AS [Move To Log Date], H.Status, H.TDSPer AS [TDS %], H.TDSAmt AS [TDS Amount], " & _
                            " D.Div_Name AS Division, SM.Name AS [Site Name]  " & _
                            " FROM  DuesPayment H " & _
                            " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                            " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                            " Where 1=1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub


    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans


        mQry = " Update DuesPayment_Log " & _
                " SET  " & _
                " TransactionType = " & AgL.Chk_Text(IIf(TransType = TransactionType.Payment, "Payment", "Receipt")) & ", " & _
                " SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                " CurrBalance = " & Val(TxtCurrBalance.Text) & ", " & _
                " PaidAmount = " & Val(TxtPaidAmount.Text) & ", " & _
                " Discount = " & Val(TxtDiscount.Text) & ", " & _
                " NetAmount = " & Val(TxtNetAmount.Text) & ", " & _
                " CashBank = " & AgL.Chk_Text(TxtCashBank.Text) & ", " & _
                " CashBankAc = " & AgL.Chk_Text(TxtCashBankAc.AgSelectedValue) & ", " & _
                " ChqNo = " & AgL.Chk_Text(TxtChqNo.Text) & ", " & _
                " ChqDate = " & AgL.Chk_Text(TxtChqDate.Text) & ", " & _
                " Remark = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From DuesPayment H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From DuesPayment_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                TxtCurrBalance.Text = Format(AgL.VNull(.Rows(0)("CurrBalance")), "0.00")
                TxtPaidAmount.Text = Format(AgL.VNull(.Rows(0)("PaidAmount")), "0.00")
                TxtDiscount.Text = Format(AgL.VNull(.Rows(0)("Discount")), "0.00")
                TxtNetAmount.Text = Format(AgL.VNull(.Rows(0)("NetAmount")), "0.00")
                TxtCashBank.Text = AgL.XNull(.Rows(0)("CashBank"))
                TxtCashBankAc.AgSelectedValue = AgL.XNull(.Rows(0)("CashBankAc"))
                TxtChqNo.Text = AgL.XNull(.Rows(0)("ChqNo"))
                TxtChqDate.Text = AgL.XNull(.Rows(0)("ChqDate"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remark"))

                FFillEnviro(TxtV_Type.AgSelectedValue)
            End If
        End With

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT Sg.SubCode AS Code, Sg.DispName AS Name " & _
                " FROM SubGroup Sg  Order By Sg.DispName"
        TxtSubCode.AgHelpDataSet(, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = " SELECT Sg.SubCode AS Code , Sg.DispName AS Name, Sg.Nature " & _
                " FROM SubGroup Sg " & _
                " WHERE Sg.Nature IN ('Bank', 'Direct', 'Indirect')"
        TxtCashBankAc.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        TxtNetAmount.Text = 0
        TxtNetAmount.Text = Val(TxtPaidAmount.Text) + Val(TxtDiscount.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtSubCode, LblSUbCode.Text) Then passed = False : Exit Sub

    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
    End Sub

    Public Function FGetLedgerBalance(ByVal StrSubCode As String, ByVal V_Date As String, ByVal Site_Code As String) As Double
        Dim DblRtn As Double
        Dim DTTemp As DataTable

        Try
            DTTemp = AgL.FillData("Select (IsNull(Sum(LG.AmtDr),0)-IsNull(Sum(LG.AmtCr),0)) As Balance From Ledger LG Where LG.SubCode='" & StrSubCode & "' And LG.Site_Code='" & Site_Code & "' And LG.V_Date <= '" & V_Date & "' ", AgL.GCn).Tables(0)
            DblRtn = DTTemp.Rows(0).Item("Balance")
            DTTemp.Dispose()
        Catch ex As Exception
            DblRtn = 0
        End Try
        DTTemp = Nothing
        FGetLedgerBalance = DblRtn
    End Function

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSubCode.Validating, TxtCashBankAc.Validating, TxtChqDate.Validating, TxtChqNo.Validating, TxtCurrBalance.Validating, TxtDiscount.Validating, TxtDocId.Validating, TxtPaidAmount.Validating
        Dim DrTemp As DataRow() = Nothing
        Dim bConStr$ = ""
        Try
            Select Case sender.NAME
                Case TxtSubCode.Name
                    If sender.Text <> "" Then
                        TxtCurrBalance.Text = FGetLedgerBalance(sender.tag, TxtV_Date.Text, TxtSite_Code.AgSelectedValue)
                    End If


                Case TxtCashBankAc.Name
                    If sender.Text <> "" Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select(" Code = '" & TxtSubCode.AgSelectedValue & "' ")
                        If DrTemp.Length > 0 Then
                            TxtCashBank.Text = AgL.XNull(DrTemp(0)("Nature"))
                        Else
                            TxtCashBank.Text = ""
                        End If
                    End If
            End Select
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCashBank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCashBank.KeyDown
        Try
            If e.KeyCode = Keys.C Then
                TxtCashBank.Text = "Cash"
                TxtCashBankAc.AgSelectedValue = ""
            ElseIf e.KeyCode = Keys.B Then
                TxtCashBank.Text = "Bank"
                TxtCashBankAc.AgSelectedValue = AgL.XNull(DtDuesPaymentEnviro.Rows(0)("BankAc"))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TempPayment_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtCashBank.ReadOnly = True
        TxtCurrBalance.Enabled = False
    End Sub

    Private Sub TxtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSubCode.Validating, TxtV_Type.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.Name
                Case TxtSubCode.Name
                Case TxtV_Type.Name
                    FFillEnviro(TxtV_Type.AgSelectedValue)
            End Select
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempPayment_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        FFillEnviro(TxtV_Type.AgSelectedValue)
        If Me.TransType = TransactionType.DebitNote Then TxtCashBankAc.AgSelectedValue = AgL.XNull(DtDuesPaymentEnviro.Rows(0)("DebitNoteAc"))
        If Me.TransType = TransactionType.CreditNote Then TxtCashBankAc.AgSelectedValue = AgL.XNull(DtDuesPaymentEnviro.Rows(0)("CreditNoteAc"))
    End Sub

    Private Sub FFillEnviro(ByVal V_Type As String)
        mQry = "Select * from DuesPaymentEnviro Where V_Type = '" & V_Type & "'"
        DtDuesPaymentEnviro = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        If DtDuesPaymentEnviro.Rows.Count = 0 Then
            MsgBox("Please set environment settings of " & TxtV_Type.Text)
        End If
    End Sub

    Private Sub Topctrl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Topctrl1.Load

    End Sub
End Class
