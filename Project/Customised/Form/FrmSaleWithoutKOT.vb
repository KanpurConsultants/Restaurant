Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSaleWithoutKOT
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Specification As String = "Specification"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1Outlet As String = "Outlet"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalDocMeasure As String = "Total Doc Measure"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"

    Private Const PaymentMode_Cash As String = "Cash"
    Private Const PaymentMode_Credit As String = "Credit"
    Private Const PaymentMode_Complementary As String = "Complementary"

    Public Class HelpDataSet
        Public Shared SaleToParty As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared SaleChallan As DataSet = Nothing
        Public Shared Table As DataSet = Nothing
        Public Shared PaymentMode As DataSet = Nothing
        Public Shared PositingAc As DataSet = Nothing
        Public Shared OutLet As DataSet = Nothing
    End Class

    Dim mChallanTypeStr$ = ""
    Protected WithEvents TxtAccount As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtPaymentMode As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Dim mTransactionType As TransactionType = TransactionType.SalesInvoice

    Enum TransactionType
        SalesInvoice = 0
        SalesReturn = 1
    End Enum

    Public Property TransType() As TransactionType
        Get
            Return mTransactionType
        End Get
        Set(ByVal value As TransactionType)
            mTransactionType = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.SaleWithoutKOT
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtTable = New AgControls.AgTextBox
        Me.LblTable = New System.Windows.Forms.Label
        Me.TxtStructure = New AgControls.AgTextBox
        Me.TxtAccount = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPaymentMode = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(709, 535)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 535)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 535)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(279, 535)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 535)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 531)
        Me.GroupBox1.Size = New System.Drawing.Size(937, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(484, 535)
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
        Me.LblV_No.Location = New System.Drawing.Point(437, 29)
        Me.LblV_No.Size = New System.Drawing.Size(71, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Invoice No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(545, 28)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(315, 34)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(211, 29)
        Me.LblV_Date.Size = New System.Drawing.Size(78, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Invoice Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(515, 14)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(331, 28)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(437, 10)
        Me.LblV_Type.Size = New System.Drawing.Size(78, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Invoice Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(545, 8)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(315, 14)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(211, 9)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(331, 8)
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
        Me.LblPrefix.Location = New System.Drawing.Point(497, 29)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 20)
        Me.TabControl1.Size = New System.Drawing.Size(927, 140)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.TxtTable)
        Me.TP1.Controls.Add(Me.LblTable)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(919, 114)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(919, 41)
        Me.Topctrl1.TabIndex = 4
        '
        'Dgl1
        '
        Me.Dgl1.AgAllowFind = True
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(11, 369)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(898, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(735, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 666
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(624, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        Me.Label33.Visible = False
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(97, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(465, 4)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 662
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(12, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(72, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(361, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(100, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(11, 188)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(898, 180)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(551, 398)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(358, 135)
        Me.PnlCalcGrid.TabIndex = 694
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 8
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 2
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(331, 68)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 6
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(211, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtRemarks.Location = New System.Drawing.Point(331, 88)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(211, 89)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 167)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Sale Invoice For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(63, 511)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 32)
        Me.PnlCShowGrid2.TabIndex = 741
        Me.PnlCShowGrid2.Visible = False
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(244, 511)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(151, 32)
        Me.PnlCShowGrid.TabIndex = 740
        Me.PnlCShowGrid.Visible = False
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(315, 55)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 752
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtReferenceNo.AgMandatory = True
        Me.TxtReferenceNo.AgMasterHelp = False
        Me.TxtReferenceNo.AgNumberLeftPlaces = 8
        Me.TxtReferenceNo.AgNumberNegetiveAllow = False
        Me.TxtReferenceNo.AgNumberRightPlaces = 2
        Me.TxtReferenceNo.AgPickFromLastValue = False
        Me.TxtReferenceNo.AgRowFilter = ""
        Me.TxtReferenceNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReferenceNo.AgSelectedValue = Nothing
        Me.TxtReferenceNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReferenceNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReferenceNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferenceNo.Location = New System.Drawing.Point(331, 48)
        Me.TxtReferenceNo.MaxLength = 0
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(211, 49)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 751
        Me.LblReferenceNo.Text = "Reference No."
        '
        'TxtTable
        '
        Me.TxtTable.AgAllowUserToEnableMasterHelp = False
        Me.TxtTable.AgMandatory = True
        Me.TxtTable.AgMasterHelp = False
        Me.TxtTable.AgNumberLeftPlaces = 8
        Me.TxtTable.AgNumberNegetiveAllow = False
        Me.TxtTable.AgNumberRightPlaces = 2
        Me.TxtTable.AgPickFromLastValue = False
        Me.TxtTable.AgRowFilter = ""
        Me.TxtTable.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTable.AgSelectedValue = Nothing
        Me.TxtTable.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTable.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTable.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTable.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTable.Location = New System.Drawing.Point(545, 48)
        Me.TxtTable.MaxLength = 0
        Me.TxtTable.Name = "TxtTable"
        Me.TxtTable.Size = New System.Drawing.Size(163, 18)
        Me.TxtTable.TabIndex = 5
        '
        'LblTable
        '
        Me.LblTable.AutoSize = True
        Me.LblTable.BackColor = System.Drawing.Color.Transparent
        Me.LblTable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTable.Location = New System.Drawing.Point(437, 49)
        Me.LblTable.Name = "LblTable"
        Me.LblTable.Size = New System.Drawing.Size(38, 16)
        Me.LblTable.TabIndex = 754
        Me.LblTable.Text = "Table"
        '
        'TxtStructure
        '
        Me.TxtStructure.AgAllowUserToEnableMasterHelp = False
        Me.TxtStructure.AgMandatory = False
        Me.TxtStructure.AgMasterHelp = False
        Me.TxtStructure.AgNumberLeftPlaces = 8
        Me.TxtStructure.AgNumberNegetiveAllow = False
        Me.TxtStructure.AgNumberRightPlaces = 2
        Me.TxtStructure.AgPickFromLastValue = False
        Me.TxtStructure.AgRowFilter = ""
        Me.TxtStructure.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStructure.AgSelectedValue = Nothing
        Me.TxtStructure.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStructure.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStructure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStructure.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStructure.Location = New System.Drawing.Point(738, 219)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(72, 18)
        Me.TxtStructure.TabIndex = 757
        Me.TxtStructure.Visible = False
        '
        'TxtAccount
        '
        Me.TxtAccount.AgAllowUserToEnableMasterHelp = False
        Me.TxtAccount.AgMandatory = False
        Me.TxtAccount.AgMasterHelp = False
        Me.TxtAccount.AgNumberLeftPlaces = 8
        Me.TxtAccount.AgNumberNegetiveAllow = False
        Me.TxtAccount.AgNumberRightPlaces = 2
        Me.TxtAccount.AgPickFromLastValue = False
        Me.TxtAccount.AgRowFilter = ""
        Me.TxtAccount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAccount.AgSelectedValue = Nothing
        Me.TxtAccount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAccount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAccount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAccount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccount.Location = New System.Drawing.Point(108, 423)
        Me.TxtAccount.MaxLength = 20
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(377, 18)
        Me.TxtAccount.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 423)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 765
        Me.Label3.Text = "Account"
        '
        'TxtPaymentMode
        '
        Me.TxtPaymentMode.AgAllowUserToEnableMasterHelp = False
        Me.TxtPaymentMode.AgMandatory = False
        Me.TxtPaymentMode.AgMasterHelp = False
        Me.TxtPaymentMode.AgNumberLeftPlaces = 8
        Me.TxtPaymentMode.AgNumberNegetiveAllow = False
        Me.TxtPaymentMode.AgNumberRightPlaces = 2
        Me.TxtPaymentMode.AgPickFromLastValue = False
        Me.TxtPaymentMode.AgRowFilter = ""
        Me.TxtPaymentMode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPaymentMode.AgSelectedValue = Nothing
        Me.TxtPaymentMode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPaymentMode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPaymentMode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPaymentMode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaymentMode.Location = New System.Drawing.Point(108, 403)
        Me.TxtPaymentMode.MaxLength = 20
        Me.TxtPaymentMode.Name = "TxtPaymentMode"
        Me.TxtPaymentMode.Size = New System.Drawing.Size(377, 18)
        Me.TxtPaymentMode.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 403)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 763
        Me.Label1.Text = "Payment Mode"
        '
        'FrmSaleWithoutKOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(919, 576)
        Me.Controls.Add(Me.TxtAccount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPaymentMode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmSaleWithoutKOT"
        Me.Text = "Sale Invoice Without KOT"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtPaymentMode, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtAccount, 0)
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
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtTable As AgControls.AgTextBox
    Protected WithEvents LblTable As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
#End Region

    Private Sub TempSaleInvoice_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        If Not AgL.StrCmp(TxtPaymentMode.Text, PaymentMode_Complementary) Then
            AccountPosting()
        End If
    End Sub

    Private Sub TempSaleInvoiceCommon_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = "Delete from Stock Where DocID = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete from Ledger Where DocID = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleInvoice"
        LogTableName = "SaleInvoice_Log"
        MainLineTableCsv = "SaleInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "SaleInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)
        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False


        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From SaleInvoice H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode, DocId " & _
               " From SaleInvoice_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.UID as SearchCode, H.DocID, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], " & _
                         " H.V_No AS [Entry No], H.ReferenceNo, Sg.DispName As SaleToPartyName, H.TotalAmount  " & _
                         " FROM SaleInvoice_Log H " & _
                         " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                         " LEFT JOIN SubGroup Sg On H.SaleToParty = Sg.SubCode " & _
                         " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [Entry Type], " & _
                            " H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
                            " H.ReferenceNo, Sg.DispName As SaleToPartyName,  " & _
                            " H.SaleToPartyDocNo AS [SaleToParty Doc No], H.SaleToPartyDocDate AS [SaleToParty Doc Date] " & _
                            " FROM SaleInvoice H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg On H.SaleToParty = Sg.SubCode " & _
                            " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1Specification, 150, 255, Col1Specification, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 130, 0, Col1SalesTaxGroup, False, False)
            .AddAgTextColumn(Dgl1, Col1Outlet, 100, 0, Col1Outlet, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 70, 8, 4, False, Col1MeasurePerPcs, False, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 50, 0, Col1MeasureUnit, False, True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocMeasure, 70, 8, 4, False, Col1TotalDocMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 70, 8, 4, False, Col1TotalMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = Pnl1.Anchor

        Dgl1.ColumnHeadersHeight = 35

        AgCalcGrid1.Ini_Grid(mSearchCode)

        AgCalcGrid1.AgFixedRows = 6
        AgCShowGrid1.AgIsFixedRows = True
        AgCShowGrid1.AgParentCalcGrid = AgCalcGrid1
        AgCShowGrid2.AgParentCalcGrid = AgCalcGrid1
        If AgCalcGrid1.RowCount > 0 Then
            AgCShowGrid1.Ini_Grid()
            AgCShowGrid2.Ini_Grid()
        End If



        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        Dgl1.AgSkipReadOnlyColumns = True

        FrmSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "  Update SaleInvoice_Log " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.Text) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " TableCode = " & AgL.Chk_Text(TxtTable.AgSelectedValue) & ", " & _
                " PaymentMode = " & AgL.Chk_Text(TxtPaymentMode.Text) & ", " & _
                " PostingAc = " & AgL.Chk_Text(TxtAccount.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From SaleInvoiceDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "Insert Into SaleInvoiceDetail_Log( UID, DocId, Sr, Item, Specification, SalesTaxGroupItem, Outlet, " & _
                        " Qty, Unit, MeasurePerPcs, MeasureUnit, TotalDocMeasure, " & _
                        " TotalMeasure, Rate, Amount) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Specification, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Outlet, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.*, Sg.MasterType, Sg.Nature " & _
                " From SaleInvoice H " & _
                " Left Join Subgroup Sg On H.SaleToParty = Sg.SubCode " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.*, Sg.MasterType, Sg.Nature " & _
                " From SaleInvoice_Log H " & _
                " Left Join Subgroup Sg On H.SaleToParty = Sg.SubCode " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtTable.AgSelectedValue = AgL.XNull(.Rows(0)("TableCode"))
                TxtPaymentMode.Text = AgL.XNull(.Rows(0)("PaymentMode"))
                TxtAccount.AgSelectedValue = AgL.XNull(.Rows(0)("PostingAc"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)


                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from SaleInvoiceDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from SaleInvoiceDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If


                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Specification, I).Value = AgL.XNull(.Rows(I)("Specification"))
                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.AgSelectedValue(Col1Outlet, I) = AgL.XNull(.Rows(I)("Outlet"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.000")
                            Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.000")
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                AgCShowGrid1.MoveRec_FromCalcGrid()
                AgCShowGrid2.MoveRec_FromCalcGrid()
                'Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
        AgL.WinSetting(Me, 604, 925, 0, 0)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtSalesTaxGroupParty.Validating, TxtReferenceNo.Validating, TxtPaymentMode.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    AgCalcGrid1.AgNCat = LblV_Type.Tag
                    IniGrid()

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtReferenceNo.Name
                    e.Cancel = FIsDuplicateReferenceNo()

                Case TxtPaymentMode.Name
                    Select Case TxtPaymentMode.Text
                        Case PaymentMode_Cash
                            TxtAccount.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("CashAc"))
                        Case PaymentMode_Credit
                            TxtAccount.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("PostingAc"))
                        Case Else
                            TxtAccount.AgSelectedValue = ""
                    End Select
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        AgCalcGrid1.AgNCat = LblV_Type.Tag
        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item
        TxtPaymentMode.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PaymentMode
        TxtAccount.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PositingAc
        TxtTable.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Table
        Dgl1.AgHelpDataSet(Col1Outlet) = HelpDataSet.OutLet
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1SalesTaxGroup, mRow).Value = ""
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = ""
                Dgl1.Item(Col1Rate, mRow).Value = ""
                Dgl1.Item(Col1Outlet, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("MeasurePerPcs"))
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                    Dgl1.AgSelectedValue(Col1Outlet, mRow) = AgL.XNull(DrTemp(0)("Outlet"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalMeasure.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.000")
                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.0000")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If FIsDuplicateReferenceNo() Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    'If Val(.Item(Col1Rate, I).Value) = 0 Then
                    '    MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                    '    .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                    '    passed = False : Exit Sub
                    'End If
                End If
            Next
        End With

    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRemarks.Enter, TxtSalesTaxGroupParty.Enter, TxtSite_Code.Enter
        Try
            Select Case sender.name
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " (IsDeleted = 0 And Status <= '" & AgTemplate.ClsMain.EntryStatus.Active & "' And PendingQty  > 0 Or Code = '" & Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) & "') "
        End Select
    End Sub

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub TempSaleInvoiceCommon_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT Sg.SubCode As Code, Sg.DispName AS [Name], C.CityName, Sg.Add1, Sg.Add2, Sg.CityCode, Sg.Mobile , Sg.Currency, Sg.SalesTaxPostingGroup, " & _
                " Sg.SalesTaxPostingGroup, Sg.MasterType, Sg.Nature, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted,  " & _
                " IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, Sg.Div_Code " & _
                " FROM SubGroup Sg  " & _
                " LEFT JOIN City C ON Sg.CityCode = C.CityCode  "
        HelpDataSet.SaleToParty = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted " & _
                " FROM Currency " & _
                " ORDER BY Code "
        HelpDataSet.Currency = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0)  FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Qty' AS Code, 'Qty' AS Name " & _
                " Union ALL " & _
                " SELECT 'Measure' AS Code, 'Measure' AS Name"
        HelpDataSet.BillingType = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                   " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                   " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 1 As PendingQty, I.Status, I.Outlet " & _
                   " FROM Item I"
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.DocID AS Code, C.V_Type + '-' + Convert(NVARCHAR, C.V_No) AS SaleOrderNo, " & _
                " C.MoveToLog,  IsNull(C.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM SaleChallan C "
        HelpDataSet.SaleChallan = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select '" & PaymentMode_Cash & "' As Code, '" & PaymentMode_Cash & "' As Description " & _
                " UNION ALL " & _
                " Select '" & PaymentMode_Credit & "' As Code, '" & PaymentMode_Credit & "' As Description  " & _
                " UNION ALL " & _
                " Select '" & PaymentMode_Complementary & "' As Code, '" & PaymentMode_Complementary & "' As Description  "
        HelpDataSet.PaymentMode = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Sg.SubCode As Code, Sg.DispName As Name From SubGroup Sg  "
        HelpDataSet.PositingAc = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description From HT_Table H "
        HelpDataSet.Table = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description As Outlet From Outlet H "
        HelpDataSet.OutLet = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try

            'mQry = " DECLARE @Temp NVARCHAR(Max); "
            'mQry += " SET @Temp=''; "
            'mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM DuesPaymentDetail   L LEFT JOIN DuesPayment  H ON L.DocId = H.DocID WHERE L.ReferenceDocID  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0)=0) AS X  "
            'mQry += " SELECT @Temp as RelationalData "
            'bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            'If bRData.Trim <> "" Then
            '    MsgBox(" Payment / Debit Note " & bRData & " created against Invoice No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
            '    FGetRelationalData = True
            '    Exit Function
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub TempSaleInvoiceCommon_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempSaleInvoiceCommon_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Function FIsDuplicateReferenceNo() As Boolean

        mQry = "Select Count(*) from SaleInvoice H " & _
               "Where H.ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
               "And H.DocID <> '" & TxtDocId.Text & "' " & _
               "And H.Site_Code ='" & TxtSite_Code.AgSelectedValue & "' " & _
               "And H.Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
               "And H.V_Type = '" & TxtV_Type.AgSelectedValue & "'  " & _
               "And IsNull(H.IsDeleted,0)=0  "

        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
            MsgBox("Reference No. already exists")
            FIsDuplicateReferenceNo = True
        End If
    End Function

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec
        Dim I As Integer, J As Integer = 0
        Dim DsTemp As DataSet = Nothing
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mNetAmount As Double, mRoundOff As Double = 0
        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        mNetAmount = 0
        mCommonNarr = ""
        mCommonNarr = ""
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        ReDim Preserve LedgAry(I)
        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = TxtAccount.AgSelectedValue
        LedgAry(I).ContraSub = AgL.XNull(AgL.PubDtEnviro.Rows(0)("SaleAc"))
        LedgAry(I).AmtCr = 0
        LedgAry(I).AmtDr = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)
        LedgAry(I).Narration = mNarr

        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = AgL.XNull(AgL.PubDtEnviro.Rows(0)("SaleAc"))
        LedgAry(I).ContraSub = TxtAccount.AgSelectedValue
        LedgAry(I).AmtCr = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        LedgAry(I).AmtDr = 0
        LedgAry(I).Narration = mNarr

        If AgL.PubManageOfflineData Then
            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GcnSite, AgL.ECmdSite, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.GcnSite_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            Else
            End If
        End If

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mInternalCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If
        GcnRead.Close()
        GcnRead.Dispose()
    End Function
End Class
