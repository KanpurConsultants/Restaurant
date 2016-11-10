Imports CrystalDecisions.CrystalReports.Engine
Public Class TempSaleInvoice
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1SaleChallan As String = "Challan No"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Specification As String = "Specification"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1DocQty As String = "Doc Qty"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalDocMeasure As String = "Total Doc Measure"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"

    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Select As String = "Select"
    Protected Const Col2SaleChallan As String = "Challan No"
    Protected Const Col2SaleChallanDate As String = "Challan Date"
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtCurrency As AgControls.AgTextBox
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyCity As AgControls.AgTextBox
    Protected WithEvents TxtSaleToPartyAddress As AgControls.AgTextBox
    Protected WithEvents LblSaleToPartyNameReq As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyName As AgControls.AgTextBox
    Protected WithEvents LblSaleToPartyName As System.Windows.Forms.Label
    Protected WithEvents LblSaleToPartyMobile As System.Windows.Forms.Label
    Protected WithEvents LblSaleToPartyCity As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyMobile As AgControls.AgTextBox
    Protected WithEvents TxtSubGroupMasterType As AgControls.AgTextBox
    Protected WithEvents TxtSubgroupNature As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Class HelpDataSet
        Public Shared SaleToParty As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared SaleChallan As DataSet = Nothing
    End Class

    Dim mChallanTypeStr$ = ""
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


    Public Property ChallanTypeStr() As String
        Get
            ChallanTypeStr = mChallanTypeStr
        End Get
        Set(ByVal value As String)
            mChallanTypeStr = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.LblSaleToPartyReq = New System.Windows.Forms.Label
        Me.TxtSaleToParty = New AgControls.AgTextBox
        Me.LblSaleToParty = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtBillingType = New AgControls.AgTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblChallans = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.BtnImportDetails = New System.Windows.Forms.Button
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.LblSaleToPartyNameReq = New System.Windows.Forms.Label
        Me.TxtSaleToPartyName = New AgControls.AgTextBox
        Me.LblSaleToPartyName = New System.Windows.Forms.Label
        Me.TxtSaleToPartyAddress = New AgControls.AgTextBox
        Me.TxtSaleToPartyCity = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyMobile = New AgControls.AgTextBox
        Me.LblSaleToPartyCity = New System.Windows.Forms.Label
        Me.LblSaleToPartyMobile = New System.Windows.Forms.Label
        Me.TxtSubgroupNature = New AgControls.AgTextBox
        Me.TxtSubGroupMasterType = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(830, 581)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 581)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 581)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(289, 581)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 581)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 577)
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(562, 581)
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
        Me.LblV_No.Location = New System.Drawing.Point(233, 29)
        Me.LblV_No.Size = New System.Drawing.Size(71, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Invoice No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(341, 28)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(7, 29)
        Me.LblV_Date.Size = New System.Drawing.Size(78, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Invoice Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(311, 14)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 28)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 10)
        Me.LblV_Type.Size = New System.Drawing.Size(79, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Invoice Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(341, 8)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 14)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(7, 9)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 8)
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
        Me.LblPrefix.Location = New System.Drawing.Point(293, 29)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 20)
        Me.TabControl1.Size = New System.Drawing.Size(1000, 198)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblGodown)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.TxtSubGroupMasterType)
        Me.TP1.Controls.Add(Me.TxtSubgroupNature)
        Me.TP1.Controls.Add(Me.LblSaleToPartyMobile)
        Me.TP1.Controls.Add(Me.LblSaleToPartyCity)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyMobile)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyCity)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyAddress)
        Me.TP1.Controls.Add(Me.LblSaleToPartyNameReq)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyName)
        Me.TP1.Controls.Add(Me.LblSaleToPartyName)
        Me.TP1.Controls.Add(Me.LblSaleToPartyReq)
        Me.TP1.Controls.Add(Me.TxtSaleToParty)
        Me.TP1.Controls.Add(Me.LblSaleToParty)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Controls.Add(Me.Pnl2)
        Me.TP1.Controls.Add(Me.LblChallans)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.Label32)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.LblCurrency)
        Me.TP1.Controls.Add(Me.TxtCurrency)
        Me.TP1.Controls.Add(Me.TxtBillingType)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(992, 172)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblChallans, 0)
        Me.TP1.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToPartyReq, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToPartyName, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToPartyNameReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleToPartyMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubgroupNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubGroupMasterType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1012, 41)
        Me.Topctrl1.TabIndex = 2
        '
        'Dgl1
        '
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
        'LblSaleToPartyReq
        '
        Me.LblSaleToPartyReq.AutoSize = True
        Me.LblSaleToPartyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSaleToPartyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSaleToPartyReq.Location = New System.Drawing.Point(111, 75)
        Me.LblSaleToPartyReq.Name = "LblSaleToPartyReq"
        Me.LblSaleToPartyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSaleToPartyReq.TabIndex = 694
        Me.LblSaleToPartyReq.Text = "Ä"
        '
        'TxtSaleToParty
        '
        Me.TxtSaleToParty.AgMandatory = True
        Me.TxtSaleToParty.AgMasterHelp = False
        Me.TxtSaleToParty.AgNumberLeftPlaces = 8
        Me.TxtSaleToParty.AgNumberNegetiveAllow = False
        Me.TxtSaleToParty.AgNumberRightPlaces = 2
        Me.TxtSaleToParty.AgPickFromLastValue = False
        Me.TxtSaleToParty.AgRowFilter = ""
        Me.TxtSaleToParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToParty.AgSelectedValue = Nothing
        Me.TxtSaleToParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToParty.Location = New System.Drawing.Point(127, 68)
        Me.TxtSaleToParty.MaxLength = 0
        Me.TxtSaleToParty.Name = "TxtSaleToParty"
        Me.TxtSaleToParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToParty.TabIndex = 4
        '
        'LblSaleToParty
        '
        Me.LblSaleToParty.AutoSize = True
        Me.LblSaleToParty.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleToParty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleToParty.Location = New System.Drawing.Point(7, 68)
        Me.LblSaleToParty.Name = "LblSaleToParty"
        Me.LblSaleToParty.Size = New System.Drawing.Size(87, 16)
        Me.LblSaleToParty.TabIndex = 693
        Me.LblSaleToParty.Text = "Sale To Party"
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
        Me.Panel1.Location = New System.Drawing.Point(4, 413)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(865, 3)
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
        Me.Label33.Location = New System.Drawing.Point(754, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
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
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
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
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 243)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(1000, 170)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(849, 442)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(155, 135)
        Me.PnlCalcGrid.TabIndex = 694
        '
        'TxtStructure
        '
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
        Me.TxtStructure.Location = New System.Drawing.Point(617, 46)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(72, 18)
        Me.TxtStructure.TabIndex = 15
        Me.TxtStructure.Text = "TxtStructure"
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(508, 49)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(617, 86)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(72, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 14
        Me.TxtSalesTaxGroupParty.Text = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(510, 88)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
        Me.Label27.Visible = False
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
        Me.TxtRemarks.Location = New System.Drawing.Point(127, 148)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 12
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(7, 148)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtBillingType
        '
        Me.TxtBillingType.AgMandatory = False
        Me.TxtBillingType.AgMasterHelp = False
        Me.TxtBillingType.AgNumberLeftPlaces = 0
        Me.TxtBillingType.AgNumberNegetiveAllow = False
        Me.TxtBillingType.AgNumberRightPlaces = 0
        Me.TxtBillingType.AgPickFromLastValue = False
        Me.TxtBillingType.AgRowFilter = ""
        Me.TxtBillingType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBillingType.AgSelectedValue = Nothing
        Me.TxtBillingType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBillingType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBillingType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBillingType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillingType.Location = New System.Drawing.Point(617, 66)
        Me.TxtBillingType.MaxLength = 20
        Me.TxtBillingType.Name = "TxtBillingType"
        Me.TxtBillingType.Size = New System.Drawing.Size(72, 18)
        Me.TxtBillingType.TabIndex = 13
        Me.TxtBillingType.Text = "TxtBillingType"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(510, 68)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 16)
        Me.Label32.TabIndex = 727
        Me.Label32.Text = "Billing On"
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl2.Location = New System.Drawing.Point(706, 28)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(283, 138)
        Me.Pnl2.TabIndex = 695
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(889, 4)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 23)
        Me.BtnFill.TabIndex = 696
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblChallans
        '
        Me.LblChallans.AutoSize = True
        Me.LblChallans.BackColor = System.Drawing.Color.Transparent
        Me.LblChallans.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChallans.Location = New System.Drawing.Point(703, 7)
        Me.LblChallans.Name = "LblChallans"
        Me.LblChallans.Size = New System.Drawing.Size(71, 16)
        Me.LblChallans.TabIndex = 736
        Me.LblChallans.Text = "Challans :"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 220)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Sale Invoice For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImportDetails
        '
        Me.BtnImportDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportDetails.Location = New System.Drawing.Point(16, 548)
        Me.BtnImportDetails.Name = "BtnImportDetails"
        Me.BtnImportDetails.Size = New System.Drawing.Size(98, 23)
        Me.BtnImportDetails.TabIndex = 737
        Me.BtnImportDetails.Text = "Import Details"
        Me.BtnImportDetails.UseVisualStyleBackColor = True
        Me.BtnImportDetails.Visible = False
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(502, 441)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 140)
        Me.PnlCShowGrid2.TabIndex = 741
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(683, 441)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(151, 140)
        Me.PnlCShowGrid.TabIndex = 740
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AgMandatory = False
        Me.TxtCurrency.AgMasterHelp = False
        Me.TxtCurrency.AgNumberLeftPlaces = 8
        Me.TxtCurrency.AgNumberNegetiveAllow = False
        Me.TxtCurrency.AgNumberRightPlaces = 2
        Me.TxtCurrency.AgPickFromLastValue = False
        Me.TxtCurrency.AgRowFilter = ""
        Me.TxtCurrency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrency.AgSelectedValue = Nothing
        Me.TxtCurrency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrency.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrency.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrency.Location = New System.Drawing.Point(617, 26)
        Me.TxtCurrency.MaxLength = 20
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(72, 18)
        Me.TxtCurrency.TabIndex = 10
        Me.TxtCurrency.Text = "TxtCurrency"
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(508, 29)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(60, 16)
        Me.LblCurrency.TabIndex = 735
        Me.LblCurrency.Text = "Currency"
        '
        'LblSaleToPartyNameReq
        '
        Me.LblSaleToPartyNameReq.AutoSize = True
        Me.LblSaleToPartyNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSaleToPartyNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSaleToPartyNameReq.Location = New System.Drawing.Point(111, 95)
        Me.LblSaleToPartyNameReq.Name = "LblSaleToPartyNameReq"
        Me.LblSaleToPartyNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSaleToPartyNameReq.TabIndex = 739
        Me.LblSaleToPartyNameReq.Text = "Ä"
        '
        'TxtSaleToPartyName
        '
        Me.TxtSaleToPartyName.AgMandatory = True
        Me.TxtSaleToPartyName.AgMasterHelp = False
        Me.TxtSaleToPartyName.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyName.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyName.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyName.AgPickFromLastValue = False
        Me.TxtSaleToPartyName.AgRowFilter = ""
        Me.TxtSaleToPartyName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyName.AgSelectedValue = Nothing
        Me.TxtSaleToPartyName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyName.Location = New System.Drawing.Point(127, 88)
        Me.TxtSaleToPartyName.MaxLength = 100
        Me.TxtSaleToPartyName.Name = "TxtSaleToPartyName"
        Me.TxtSaleToPartyName.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyName.TabIndex = 737
        '
        'LblSaleToPartyName
        '
        Me.LblSaleToPartyName.AutoSize = True
        Me.LblSaleToPartyName.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleToPartyName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleToPartyName.Location = New System.Drawing.Point(7, 88)
        Me.LblSaleToPartyName.Name = "LblSaleToPartyName"
        Me.LblSaleToPartyName.Size = New System.Drawing.Size(77, 16)
        Me.LblSaleToPartyName.TabIndex = 738
        Me.LblSaleToPartyName.Text = "Party Name"
        '
        'TxtSaleToPartyAddress
        '
        Me.TxtSaleToPartyAddress.AgMandatory = False
        Me.TxtSaleToPartyAddress.AgMasterHelp = False
        Me.TxtSaleToPartyAddress.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyAddress.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyAddress.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyAddress.AgPickFromLastValue = False
        Me.TxtSaleToPartyAddress.AgRowFilter = ""
        Me.TxtSaleToPartyAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyAddress.AgSelectedValue = Nothing
        Me.TxtSaleToPartyAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyAddress.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyAddress.Location = New System.Drawing.Point(127, 108)
        Me.TxtSaleToPartyAddress.MaxLength = 255
        Me.TxtSaleToPartyAddress.Name = "TxtSaleToPartyAddress"
        Me.TxtSaleToPartyAddress.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyAddress.TabIndex = 740
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.AgMandatory = False
        Me.TxtSaleToPartyCity.AgMasterHelp = False
        Me.TxtSaleToPartyCity.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyCity.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyCity.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyCity.AgPickFromLastValue = False
        Me.TxtSaleToPartyCity.AgRowFilter = ""
        Me.TxtSaleToPartyCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyCity.AgSelectedValue = Nothing
        Me.TxtSaleToPartyCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(127, 128)
        Me.TxtSaleToPartyCity.MaxLength = 0
        Me.TxtSaleToPartyCity.Name = "TxtSaleToPartyCity"
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(148, 18)
        Me.TxtSaleToPartyCity.TabIndex = 741
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 742
        Me.Label5.Text = "Address"
        '
        'TxtSaleToPartyMobile
        '
        Me.TxtSaleToPartyMobile.AgMandatory = False
        Me.TxtSaleToPartyMobile.AgMasterHelp = False
        Me.TxtSaleToPartyMobile.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyMobile.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyMobile.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyMobile.AgPickFromLastValue = False
        Me.TxtSaleToPartyMobile.AgRowFilter = ""
        Me.TxtSaleToPartyMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyMobile.AgSelectedValue = Nothing
        Me.TxtSaleToPartyMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyMobile.Location = New System.Drawing.Point(384, 128)
        Me.TxtSaleToPartyMobile.MaxLength = 35
        Me.TxtSaleToPartyMobile.Name = "TxtSaleToPartyMobile"
        Me.TxtSaleToPartyMobile.Size = New System.Drawing.Size(120, 18)
        Me.TxtSaleToPartyMobile.TabIndex = 743
        '
        'LblSaleToPartyCity
        '
        Me.LblSaleToPartyCity.AutoSize = True
        Me.LblSaleToPartyCity.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleToPartyCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleToPartyCity.Location = New System.Drawing.Point(7, 128)
        Me.LblSaleToPartyCity.Name = "LblSaleToPartyCity"
        Me.LblSaleToPartyCity.Size = New System.Drawing.Size(31, 16)
        Me.LblSaleToPartyCity.TabIndex = 744
        Me.LblSaleToPartyCity.Text = "City"
        '
        'LblSaleToPartyMobile
        '
        Me.LblSaleToPartyMobile.AutoSize = True
        Me.LblSaleToPartyMobile.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleToPartyMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleToPartyMobile.Location = New System.Drawing.Point(281, 129)
        Me.LblSaleToPartyMobile.Name = "LblSaleToPartyMobile"
        Me.LblSaleToPartyMobile.Size = New System.Drawing.Size(46, 16)
        Me.LblSaleToPartyMobile.TabIndex = 745
        Me.LblSaleToPartyMobile.Text = "Mobile"
        '
        'TxtSubgroupNature
        '
        Me.TxtSubgroupNature.AgMandatory = False
        Me.TxtSubgroupNature.AgMasterHelp = False
        Me.TxtSubgroupNature.AgNumberLeftPlaces = 0
        Me.TxtSubgroupNature.AgNumberNegetiveAllow = False
        Me.TxtSubgroupNature.AgNumberRightPlaces = 0
        Me.TxtSubgroupNature.AgPickFromLastValue = False
        Me.TxtSubgroupNature.AgRowFilter = ""
        Me.TxtSubgroupNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubgroupNature.AgSelectedValue = Nothing
        Me.TxtSubgroupNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubgroupNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubgroupNature.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubgroupNature.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubgroupNature.Location = New System.Drawing.Point(513, 107)
        Me.TxtSubgroupNature.MaxLength = 20
        Me.TxtSubgroupNature.Name = "TxtSubgroupNature"
        Me.TxtSubgroupNature.Size = New System.Drawing.Size(176, 18)
        Me.TxtSubgroupNature.TabIndex = 746
        Me.TxtSubgroupNature.Text = "TxtSubgroupNature"
        Me.TxtSubgroupNature.Visible = False
        '
        'TxtSubGroupMasterType
        '
        Me.TxtSubGroupMasterType.AgMandatory = False
        Me.TxtSubGroupMasterType.AgMasterHelp = False
        Me.TxtSubGroupMasterType.AgNumberLeftPlaces = 0
        Me.TxtSubGroupMasterType.AgNumberNegetiveAllow = False
        Me.TxtSubGroupMasterType.AgNumberRightPlaces = 0
        Me.TxtSubGroupMasterType.AgPickFromLastValue = False
        Me.TxtSubGroupMasterType.AgRowFilter = ""
        Me.TxtSubGroupMasterType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubGroupMasterType.AgSelectedValue = Nothing
        Me.TxtSubGroupMasterType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubGroupMasterType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubGroupMasterType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubGroupMasterType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubGroupMasterType.Location = New System.Drawing.Point(513, 128)
        Me.TxtSubGroupMasterType.MaxLength = 20
        Me.TxtSubGroupMasterType.Name = "TxtSubGroupMasterType"
        Me.TxtSubGroupMasterType.Size = New System.Drawing.Size(176, 18)
        Me.TxtSubGroupMasterType.TabIndex = 747
        Me.TxtSubGroupMasterType.Text = "TxtSubGroupMasterType"
        Me.TxtSubGroupMasterType.Visible = False
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(508, 9)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 749
        Me.LblGodown.Text = "Godown"
        '
        'TxtGodown
        '
        Me.TxtGodown.AgMandatory = False
        Me.TxtGodown.AgMasterHelp = False
        Me.TxtGodown.AgNumberLeftPlaces = 8
        Me.TxtGodown.AgNumberNegetiveAllow = False
        Me.TxtGodown.AgNumberRightPlaces = 2
        Me.TxtGodown.AgPickFromLastValue = False
        Me.TxtGodown.AgRowFilter = ""
        Me.TxtGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGodown.AgSelectedValue = Nothing
        Me.TxtGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGodown.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGodown.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGodown.Location = New System.Drawing.Point(617, 6)
        Me.TxtGodown.MaxLength = 20
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(72, 18)
        Me.TxtGodown.TabIndex = 748
        Me.TxtGodown.Text = "TxtGodown"
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(111, 55)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 752
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtReferenceNo
        '
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(127, 48)
        Me.TxtReferenceNo.MaxLength = 0
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(377, 18)
        Me.TxtReferenceNo.TabIndex = 750
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(7, 48)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 751
        Me.LblReferenceNo.Text = "Reference No."
        '
        'TempSaleInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1012, 622)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.BtnImportDetails)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempSaleInvoice"
        Me.Text = "Template Goods Receive"
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
        Me.Controls.SetChildIndex(Me.BtnImportDetails, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
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

    End Sub
    Protected WithEvents LblSaleToParty As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToParty As AgControls.AgTextBox
    Protected WithEvents LblSaleToPartyReq As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtBillingType As AgControls.AgTextBox
    Protected WithEvents Label32 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LblChallans As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents BtnImportDetails As System.Windows.Forms.Button
#End Region

    Private Sub TempSaleInvoice_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "Delete from Stock Where DocID = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        For I = 0 To Dgl1.Rows.Count - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO dbo.Stock"
                mQry += "("
                mQry += "DocId,"
                mQry += "V_Type,"
                mQry += "RecId,"
                mQry += "V_SNo,"
                mQry += "V_Date,"
                mQry += "PtyChallanNo,"
                mQry += "PtyBillNo,"
                mQry += "PartyCode,"
                mQry += "ItemCode,"
                mQry += "RecQty,"
                mQry += "IssueQty,"
                mQry += "LandedRate,"
                mQry += "LandedValue,"
                mQry += "OtherAdjustment,"
                mQry += "FIFOValue,"
                mQry += "AverageValue,"
                mQry += "CostCenter,"
                mQry += "Department,"
                mQry += "Godown,"
                mQry += "OwnYN,"
                mQry += "EType_IR,"
                mQry += "Remark,"
                mQry += "Site_Code,"
                mQry += "Specification"
                mQry += ")"
                mQry += "VALUES"
                mQry += "("
                mQry += "" & AgL.Chk_Text(TxtDocId.Text) & ","
                mQry += "" & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ","
                mQry += "" & AgL.Chk_Text(TxtV_No.Text) & ","
                mQry += "" & mSr & ","
                mQry += "" & AgL.Chk_Text(TxtV_Date.Text) & ","
                mQry += "" & AgL.Chk_Text("") & ","
                mQry += "" & AgL.Chk_Text("") & ","
                mQry += "" & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & ","
                mQry += "" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ","
                mQry += "" & IIf(mTransactionType = TransactionType.SalesReturn, Val(Dgl1.Item(Col1Qty, I).Value), 0) & ","
                mQry += "" & IIf(mTransactionType = TransactionType.SalesInvoice, Val(Dgl1.Item(Col1Qty, I).Value), 0) & ","
                mQry += "" & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.LANDEDVALUE, I, AgStructure.AgCalcGrid.LineColumnType.Amount)) / Val(Dgl1.Item(Col1Qty, I).Value) & ","
                mQry += "" & Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.LANDEDVALUE, I, AgStructure.AgCalcGrid.LineColumnType.Amount)) & ","
                mQry += "0,"
                mQry += "0,"
                mQry += "0,"
                mQry += "Null," 'CostCenter
                mQry += "Null," 'Department
                mQry += "" & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ","
                mQry += "'Y',"
                mQry += "'R',"
                mQry += "Null," 'Remark
                mQry += "" & AgL.Chk_Text(AgL.PubSiteCode) & ","
                mQry += "" & AgL.Chk_Text(Dgl1.Item(Col1Specification, I).Value) & ""
                mQry += ")"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next
        AgCalcGrid1.AgPostingPartyAc = TxtSaleToParty.AgSelectedValue

        If mTransactionType = TransactionType.SalesInvoice Then
            ClsMain.PostStructureToAccounts(AgCalcGrid1, "Being Goods Sold", TxtDocId.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, TxtV_Type.AgSelectedValue, LblPrefix.Text, Val(TxtV_No.Text), TxtReferenceNo.Text, TxtV_Date.Text, Conn, Cmd)
        Else
            ClsMain.PostStructureToAccounts(AgCalcGrid1, "Being Goods Returned", TxtDocId.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, TxtV_Type.AgSelectedValue, LblPrefix.Text, Val(TxtV_No.Text), TxtReferenceNo.Text, TxtV_Date.Text, Conn, Cmd)
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
        AgL.GridDesign(Dgl2)
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
            .AddAgTextColumn(Dgl1, Col1SaleChallan, 120, 0, Col1SaleChallan, True, True)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1Specification, 150, 255, Col1Specification, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 130, 0, Col1SalesTaxGroup, False, False)
            .AddAgNumberColumn(Dgl1, Col1DocQty, 80, 8, 4, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 4, False, Col1Qty, True, False, True)
            '.AddAgNumberColumn(Dgl1, Col1PrevQty, 50, 8, 3, False, Col1PrevQty, False, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 70, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 50, 0, Col1MeasureUnit, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocMeasure, 70, 8, 4, False, Col1TotalDocMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 70, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            '.AddAgTextColumn(Dgl1, Col1PrevItem, 200, 0, Col1PrevItem, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = Pnl1.Anchor

        Dgl1.ColumnHeadersHeight = 35

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgCheckColumn(Dgl2, Col2Select, 50, Col2Select, True)
            .AddAgTextColumn(Dgl2, Col2SaleChallan, 100, 0, Col2SaleChallan, True, True)
            .AddAgDateColumn(Dgl2, Col2SaleChallanDate, 100, Col2SaleChallanDate, True, True)
        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.Anchor = Pnl2.Anchor
        Dgl2.ColumnHeadersHeight = 25
        Dgl2.AllowUserToAddRows = False

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
        Dgl2.AgSkipReadOnlyColumns = True

        FrmSaleOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer


        mQry = "  Update SaleInvoice_Log " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SaleToParty = " & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & ", " & _
                " SaleToPartyName = " & AgL.Chk_Text(TxtSaleToPartyName.Text) & ", " & _
                " SaleToPartyAddress = " & AgL.Chk_Text(TxtSaleToPartyAddress.Text) & ", " & _
                " SaleToPartyCity = " & AgL.Chk_Text(TxtSaleToPartyCity.AgSelectedValue) & ", " & _
                " SaleToPartyMobile = " & AgL.Chk_Text(TxtSaleToPartyMobile.Text) & ", " & _
                " Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.Text) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " BillingType = " & AgL.Chk_Text(TxtBillingType.AgSelectedValue) & ", " & _
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
                mQry = "Insert Into SaleInvoiceDetail_Log( UID, DocId, Sr, SaleChallan, Item, Specification, SalesTaxGroupItem, " & _
                        " DocQty, Qty, Unit, MeasurePerPcs, MeasureUnit, TotalDocMeasure, " & _
                        " TotalMeasure, Rate, Amount) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SaleChallan, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Specification, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1DocQty, I).Value) & ", " & _
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
                TxtSaleToParty.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToParty"))
                TxtSaleToPartyName.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                TxtSaleToPartyAddress.Text = AgL.XNull(.Rows(0)("SaleToPartyAddress"))
                TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToPartyCity"))
                TxtSaleToPartyMobile.Text = AgL.XNull(.Rows(0)("SaleToPartyMobile"))
                TxtSubGroupMasterType.Text = AgL.XNull(.Rows(0)("MasterType"))
                TxtSubgroupNature.Text = AgL.XNull(.Rows(0)("Nature"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtBillingType.AgSelectedValue = AgL.XNull(.Rows(0)("BillingType"))

                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)




                '-------------------------------------------------------------
                'Line Records are showing Challan No
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select Distinct Id.SaleChallan, C.V_Date As SaleChallanDate " & _
                            " from SaleInvoiceDetail Id " & _
                            " LEFT JOIN SaleChallan C On Id.SaleChallan = C.DocId " & _
                            " where Id.DocId = '" & SearchCode & "' "
                Else
                    mQry = "Select Distinct Id.SaleChallan, C.V_Date As SaleChallanDate " & _
                            " from SaleInvoiceDetail_Log Id " & _
                            " LEFT JOIN SaleChallan C On Id.SaleChallan = C.DocId " & _
                            " where Id.UID = '" & SearchCode & "' "
                End If
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            If AgL.XNull(.Rows(I)("SaleChallan")) <> "" Then
                                Dgl2.Rows.Add()
                                Dgl2.Item(Col2Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                                Dgl2.AgSelectedValue(Col2SaleChallan, I) = AgL.XNull(.Rows(I)("SaleChallan"))
                                Dgl2.Item(Col2SaleChallanDate, I).Value = AgL.XNull(.Rows(I)("SaleChallanDate"))
                            End If
                        Next I
                    End If
                End With

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
                            Dgl1.AgSelectedValue(Col1SaleChallan, I) = AgL.XNull(.Rows(I)("SaleChallan"))
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Specification, I).Value = AgL.XNull(.Rows(I)("Specification"))
                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("DocQty"))
                            'Dgl1.Item(Col1PrevQty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.000")
                            Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.000")
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            'Dgl1.Item(Col1PrevItem, I).Value = AgL.XNull(.Rows(I)("Item"))

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
        Topctrl1.ChangeAgGridState(Dgl2, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtSaleToParty.Validating, TxtSalesTaxGroupParty.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    AgCalcGrid1.AgNCat = LblV_Type.Tag
                    IniGrid()

                Case TxtSaleToParty.Name
                    If TxtV_Date.Text <> "" And TxtSaleToParty.Text <> "" Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtSaleToPartyName.Text = AgL.XNull(DrTemp(0)("Name"))
                        TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                        TxtSaleToPartyMobile.Text = AgL.XNull(DrTemp(0)("Mobile"))
                        TxtSaleToPartyAddress.Text = AgL.XNull(DrTemp(0)("Add1"))
                        If AgL.XNull(DrTemp(0)("Add2")) <> "" And AgL.XNull(DrTemp(0)("Add1")) <> "" Then
                            TxtSaleToPartyAddress.Text += vbCrLf + AgL.XNull(DrTemp(0)("Add2"))
                        Else
                            TxtSaleToPartyAddress.Text += AgL.XNull(DrTemp(0)("Add2"))
                        End If
                        TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                        TxtSubgroupNature.Text = AgL.XNull(DrTemp(0)("Nature"))
                        TxtSubGroupMasterType.Text = AgL.XNull(DrTemp(0)("MasterType"))
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then Call ProcFillPendingChallans(TxtSaleToParty.AgSelectedValue, TxtV_Date.Text)

                        FEnablePartyDetail()
                        If AgL.StrCmp(TxtSubgroupNature.Text, "Cash") Then TxtSaleToPartyName.Focus()

                    End If

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtReferenceNo.Name
                    e.Cancel = FIsDuplicateReferenceNo()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FEnablePartyDetail()
        If AgL.StrCmp(TxtSubgroupNature.Text, "Cash") And Not AgL.StrCmp(Topctrl1.Mode, "Browse") Then
            TxtSaleToPartyName.Enabled = True
            TxtSaleToPartyAddress.Enabled = True
            TxtSaleToPartyCity.Enabled = True
            TxtSaleToPartyMobile.Enabled = True
        Else
            TxtSaleToPartyName.Enabled = False
            TxtSaleToPartyAddress.Enabled = False
            TxtSaleToPartyCity.Enabled = False
            TxtSaleToPartyMobile.Enabled = False
        End If
    End Sub
    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "SaleInvoice", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        AgCalcGrid1.AgNCat = LblV_Type.Tag
        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSaleToParty.AgHelpDataSet(6, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SaleToParty
        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Currency
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        TxtBillingType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.BillingType
        Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item
        Dgl2.AgHelpDataSet(Col2SaleChallan, 8) = HelpDataSet.SaleChallan
        Dgl1.AgHelpDataSet(Col1SaleChallan, 8) = HelpDataSet.SaleChallan
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
                Dgl1.Item(Col1DocQty, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("MeasurePerPcs"))
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
                    'Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(DrTemp(0)("PendingQty")) + Dgl1.Item(Col1PrevQty, mRow).Value
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If

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
                Case Col1Qty
                    Dgl1.Item(Col1DocQty, mRowIndex).Value = Val(Dgl1.Item(Col1Qty, mRowIndex).Value)

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
                Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.000")

                If AgL.StrCmp(TxtBillingType.Text, "Qty") Or TxtBillingType.Text = "" Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                Else
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                End If

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
        If AgL.RequiredField(TxtSaleToParty, LblSaleToParty.Text) Then passed = False : Exit Sub
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

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRemarks.Enter, TxtSalesTaxGroupParty.Enter, TxtSite_Code.Enter, TxtSaleToParty.Enter, TxtStructure.Enter, TxtBillingType.Enter, TxtCurrency.Enter
        Try
            Select Case sender.name
                Case TxtCurrency.Name
                    sender.AgRowFilter = " IsDeleted = 0 "

                Case TxtSaleToParty.Name
                    'sender.AgRowFilter = " IsDeleted = 0 And Status = '" & ClsMain.EntryStatus.Active & "' And " & ClsMain.RetDivFilterStr & " "
                    sender.AgRowFilter = " IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " (IsDeleted = 0 And Status <= '" & AgTemplate.ClsMain.EntryStatus.Active & "' And PendingQty  > 0 Or Code = '" & Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) & "') "
        End Select
    End Sub

    Private Sub ProcFillPendingChallans(ByVal bSaleToParty As String, ByVal bV_Date As String)
        Dim DtTemp As DataTable = Nothing
        Dim bConStr$ = ""
        Dim I As Integer = 0
        Try
            If mChallanTypeStr <> "" Then
                bConStr = " And Vt.NCat In (" & mChallanTypeStr & ")"
            Else
                bConStr = " And 1=1 "
            End If

            mQry = "SELECT Cd.DocId As ChallanNo, Max(C.V_Date) As SaleChallanDate " & _
                    " FROM SaleChallanDetail Cd " & _
                    " LEFT JOIN SaleChallan C On C.DocId = Cd.DocId  " & _
                    " LEFT JOIN Voucher_Type Vt On C.V_Type = Vt.V_Type " & _
                    " WHERE C.SaleToParty = '" & bSaleToParty & "'  " & _
                    " And C.V_Date <= '" & bV_Date & "' " & bConStr & _
                    " GROUP BY Cd.DocId " & _
                    " HAVING IsNull(Sum(Cd.InvoicedQty), 0) = 0 "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl2.RowCount = 1
                Dgl2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl2.Rows.Add()
                        Dgl2.Item(Col2Select, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        Dgl2.AgSelectedValue(Col2SaleChallan, I) = AgL.XNull(.Rows(I)("ChallanNo"))
                        Dgl2.Item(Col2SaleChallanDate, I).Value = AgL.XNull(.Rows(I)("SaleChallanDate"))
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub ProcFillItems(ByVal bChallanNoStr As String)
        Dim I As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Try
            If bChallanNoStr = "" Then Exit Sub
            mQry = "SELECT Cd.DocId As SaleChallan, Cd.Sr, Cd.Item, Cd.SalesTaxGroupItem, Cd.DocQty, Cd.Qty, Cd.Unit, " & _
                        " Cd.MeasurePerPcs, Cd.MeasureUnit, Cd.TotalDocMeasure, Cd.TotalMeasure, " & _
                        " CASE WHEN  IsNull(Od.Rate,0) = 0 THEN IsNull(Cd.Rate,0) ELSE IsNull(Od.Rate,0) END AS Rate " & _
                        " FROM SaleChallanDetail Cd " & _
                        " LEFT JOIN SaleChallan C On Cd.DocId = C.DocId " & _
                        " LEFT JOIN SaleOrderDetail Od On C.SaleOrder = Od.DocId " & _
                        "                               And Cd.Item = Od.Item " & _
                        " WHERE Cd.DocId In (" & bChallanNoStr & ") "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1SaleChallan, I) = AgL.XNull(.Rows(I)("SaleChallan"))
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("DocQty"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.000")
                        Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.000")
                        Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                        'Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                        AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("SaleChallan")), Dgl1, I, AgL.VNull(.Rows(I)("Sr")))
                    Next I
                End If
            End With
            AgCalcGrid1.Calculation(True)
            Calculation()
            If Dgl1.Item(Col1SaleChallan, 0).Value <> "" Then Dgl1.Columns(Col1Item).ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0
        Dim bChallanStr$ = ""
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        With Dgl2
            If .Rows.Count > 0 Then
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2SaleChallan, I).Value <> "" And AgL.StrCmp(.Item(Col2Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        If bChallanStr = "" Then
                            bChallanStr = "'" & .AgSelectedValue(Col2SaleChallan, I) & "'"
                        Else
                            bChallanStr &= "," & "'" & .AgSelectedValue(Col2SaleChallan, I) & "'"
                        End If
                    End If
                Next
                Call ProcFillItems(bChallanStr)
            End If
        End With
    End Sub

    Private Sub TempSaleInvoice_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If Dgl1.Item(Col1SaleChallan, 0).Value <> "" Then Dgl1.Columns(Col1Item).ReadOnly = True
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            BtnFill.Enabled = True
        Else
            BtnFill.Enabled = False
        End If
        FEnablePartyDetail()
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
                   " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 1 As PendingQty, I.Status " & _
                   " FROM Item I"
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.DocID AS Code, C.V_Type + '-' + Convert(NVARCHAR, C.V_No) AS SaleOrderNo, " & _
                " C.MoveToLog,  IsNull(C.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM SaleChallan C "
        HelpDataSet.SaleChallan = AgL.FillData(mQry, AgL.GCn)
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
End Class
