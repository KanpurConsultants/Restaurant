Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSaleOrder
    Inherits AgTemplate.TempTransaction
    Dim mQry$


    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1ItemCode As String = "Item Code"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1Outlet As String = "Outlet"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TxtIsHomeDelivery As AgControls.AgTextBox
    Protected WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtToPayAmount As AgControls.AgTextBox
    Protected WithEvents Label8 As System.Windows.Forms.Label
    Protected WithEvents TxtAccount As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtPaymentMode As AgControls.AgTextBox
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents TxtAdvance As AgControls.AgTextBox
    Protected Const Col1Amount As String = "Amount"

    Public Class HelpDataSet
        Public Shared SaleChallan As DataSet = Nothing
        Public Shared Table As DataSet = Nothing
        Public Shared Steward As DataSet = Nothing
        Public Shared KotNature As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared ItemCode As DataSet = Nothing
        Public Shared OutLet As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
    End Class

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.SaleOrder
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtPartyMobile = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPartyName = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDeliveryDate = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtDeliveryTime = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtIsHomeDelivery = New AgControls.AgTextBox
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel
        Me.TxtToPayAmount = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtAccount = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtPaymentMode = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtAdvance = New AgControls.AgTextBox
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
        Me.GroupBox2.Location = New System.Drawing.Point(758, 550)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(3, 19)
        Me.TxtStatus.Size = New System.Drawing.Size(142, 18)
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
        Me.TxtMoveToLog.Location = New System.Drawing.Point(29, 19)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(368, 581)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        Me.GBoxApprove.Text = "Approved By"
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtApproveBy.Size = New System.Drawing.Size(142, 18)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(231, 550)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 550)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 546)
        Me.GroupBox1.Size = New System.Drawing.Size(928, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(487, 550)
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
        Me.LblV_No.Location = New System.Drawing.Point(400, 113)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Voucher No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(508, 112)
        Me.TxtV_No.Size = New System.Drawing.Size(143, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(267, 41)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(166, 36)
        Me.LblV_Date.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(536, 21)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(286, 35)
        Me.TxtV_Date.Size = New System.Drawing.Size(166, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(462, 16)
        Me.LblV_Type.Size = New System.Drawing.Size(72, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Order Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(550, 15)
        Me.TxtV_Type.Size = New System.Drawing.Size(167, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(267, 21)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(166, 16)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(286, 15)
        Me.TxtSite_Code.Size = New System.Drawing.Size(166, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(460, 113)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, 19)
        Me.TabControl1.Size = New System.Drawing.Size(918, 89)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(910, 63)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(910, 41)
        Me.Topctrl1.TabIndex = 6
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
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(0, 248)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(902, 23)
        Me.Panel1.TabIndex = 694
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
        Me.Pnl1.Location = New System.Drawing.Point(1, 126)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(902, 122)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(643, 569)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(7, 16)
        Me.PnlCShowGrid2.TabIndex = 741
        Me.PnlCShowGrid2.Visible = False
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(682, 566)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(12, 16)
        Me.PnlCShowGrid.TabIndex = 740
        Me.PnlCShowGrid.Visible = False
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(536, 41)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(550, 35)
        Me.TxtReferenceNo.MaxLength = 0
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(167, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(462, 36)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(64, 16)
        Me.LblReferenceNo.TabIndex = 751
        Me.LblReferenceNo.Text = "Order No."
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
        Me.TxtRemarks.Location = New System.Drawing.Point(131, 398)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(339, 18)
        Me.TxtRemarks.TabIndex = 8
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.BackColor = System.Drawing.Color.Transparent
        Me.LblRemark.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(26, 399)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(53, 16)
        Me.LblRemark.TabIndex = 753
        Me.LblRemark.Text = "Remark"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(-1, 106)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(123, 20)
        Me.LinkLabel2.TabIndex = 742
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Item Detail"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(508, 132)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(143, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 5
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(400, 132)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 16)
        Me.Label27.TabIndex = 755
        Me.Label27.Text = "Sales Tax Group"
        Me.Label27.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(550, 271)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(353, 267)
        Me.PnlCalcGrid.TabIndex = 744
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(232, 139)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 757
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
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
        Me.TxtStructure.Location = New System.Drawing.Point(301, 138)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(72, 18)
        Me.TxtStructure.TabIndex = 756
        Me.TxtStructure.Text = "TxtStructure"
        Me.TxtStructure.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 298)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 759
        Me.Label1.Text = "Party Mobile"
        '
        'TxtPartyMobile
        '
        Me.TxtPartyMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtPartyMobile.AgMandatory = False
        Me.TxtPartyMobile.AgMasterHelp = False
        Me.TxtPartyMobile.AgNumberLeftPlaces = 0
        Me.TxtPartyMobile.AgNumberNegetiveAllow = False
        Me.TxtPartyMobile.AgNumberRightPlaces = 0
        Me.TxtPartyMobile.AgPickFromLastValue = False
        Me.TxtPartyMobile.AgRowFilter = ""
        Me.TxtPartyMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyMobile.AgSelectedValue = Nothing
        Me.TxtPartyMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyMobile.Location = New System.Drawing.Point(131, 298)
        Me.TxtPartyMobile.MaxLength = 255
        Me.TxtPartyMobile.Name = "TxtPartyMobile"
        Me.TxtPartyMobile.Size = New System.Drawing.Size(339, 18)
        Me.TxtPartyMobile.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 761
        Me.Label3.Text = "Party Name"
        '
        'TxtPartyName
        '
        Me.TxtPartyName.AgAllowUserToEnableMasterHelp = False
        Me.TxtPartyName.AgMandatory = False
        Me.TxtPartyName.AgMasterHelp = False
        Me.TxtPartyName.AgNumberLeftPlaces = 0
        Me.TxtPartyName.AgNumberNegetiveAllow = False
        Me.TxtPartyName.AgNumberRightPlaces = 0
        Me.TxtPartyName.AgPickFromLastValue = False
        Me.TxtPartyName.AgRowFilter = ""
        Me.TxtPartyName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyName.AgSelectedValue = Nothing
        Me.TxtPartyName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyName.Location = New System.Drawing.Point(131, 318)
        Me.TxtPartyName.MaxLength = 255
        Me.TxtPartyName.Name = "TxtPartyName"
        Me.TxtPartyName.Size = New System.Drawing.Size(339, 18)
        Me.TxtPartyName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 763
        Me.Label4.Text = "Address"
        '
        'TxtAdd1
        '
        Me.TxtAdd1.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd1.AgMandatory = False
        Me.TxtAdd1.AgMasterHelp = False
        Me.TxtAdd1.AgNumberLeftPlaces = 0
        Me.TxtAdd1.AgNumberNegetiveAllow = False
        Me.TxtAdd1.AgNumberRightPlaces = 0
        Me.TxtAdd1.AgPickFromLastValue = False
        Me.TxtAdd1.AgRowFilter = ""
        Me.TxtAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd1.AgSelectedValue = Nothing
        Me.TxtAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(131, 358)
        Me.TxtAdd1.MaxLength = 255
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(339, 18)
        Me.TxtAdd1.TabIndex = 4
        '
        'TxtAdd2
        '
        Me.TxtAdd2.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd2.AgMandatory = False
        Me.TxtAdd2.AgMasterHelp = False
        Me.TxtAdd2.AgNumberLeftPlaces = 0
        Me.TxtAdd2.AgNumberNegetiveAllow = False
        Me.TxtAdd2.AgNumberRightPlaces = 0
        Me.TxtAdd2.AgPickFromLastValue = False
        Me.TxtAdd2.AgRowFilter = ""
        Me.TxtAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd2.AgSelectedValue = Nothing
        Me.TxtAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(131, 378)
        Me.TxtAdd2.MaxLength = 255
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(339, 18)
        Me.TxtAdd2.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 280)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 759
        Me.Label5.Text = "Delivery Date"
        '
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtDeliveryDate.AgMandatory = False
        Me.TxtDeliveryDate.AgMasterHelp = False
        Me.TxtDeliveryDate.AgNumberLeftPlaces = 0
        Me.TxtDeliveryDate.AgNumberNegetiveAllow = False
        Me.TxtDeliveryDate.AgNumberRightPlaces = 0
        Me.TxtDeliveryDate.AgPickFromLastValue = False
        Me.TxtDeliveryDate.AgRowFilter = ""
        Me.TxtDeliveryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeliveryDate.AgSelectedValue = Nothing
        Me.TxtDeliveryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeliveryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeliveryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryDate.Location = New System.Drawing.Point(131, 278)
        Me.TxtDeliveryDate.MaxLength = 255
        Me.TxtDeliveryDate.Name = "TxtDeliveryDate"
        Me.TxtDeliveryDate.Size = New System.Drawing.Size(147, 18)
        Me.TxtDeliveryDate.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(312, 279)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 16)
        Me.Label6.TabIndex = 760
        Me.Label6.Text = "Time"
        '
        'TxtDeliveryTime
        '
        Me.TxtDeliveryTime.CustomFormat = ""
        Me.TxtDeliveryTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.TxtDeliveryTime.Location = New System.Drawing.Point(360, 275)
        Me.TxtDeliveryTime.Name = "TxtDeliveryTime"
        Me.TxtDeliveryTime.ShowUpDown = True
        Me.TxtDeliveryTime.Size = New System.Drawing.Size(111, 21)
        Me.TxtDeliveryTime.TabIndex = 764
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 765
        Me.Label7.Text = "Home Delivery ?"
        '
        'TxtIsHomeDelivery
        '
        Me.TxtIsHomeDelivery.AgAllowUserToEnableMasterHelp = False
        Me.TxtIsHomeDelivery.AgMandatory = False
        Me.TxtIsHomeDelivery.AgMasterHelp = False
        Me.TxtIsHomeDelivery.AgNumberLeftPlaces = 0
        Me.TxtIsHomeDelivery.AgNumberNegetiveAllow = False
        Me.TxtIsHomeDelivery.AgNumberRightPlaces = 0
        Me.TxtIsHomeDelivery.AgPickFromLastValue = False
        Me.TxtIsHomeDelivery.AgRowFilter = ""
        Me.TxtIsHomeDelivery.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsHomeDelivery.AgSelectedValue = Nothing
        Me.TxtIsHomeDelivery.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsHomeDelivery.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsHomeDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsHomeDelivery.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsHomeDelivery.Location = New System.Drawing.Point(131, 338)
        Me.TxtIsHomeDelivery.MaxLength = 255
        Me.TxtIsHomeDelivery.Name = "TxtIsHomeDelivery"
        Me.TxtIsHomeDelivery.Size = New System.Drawing.Size(339, 18)
        Me.TxtIsHomeDelivery.TabIndex = 764
        '
        'LinkLabel3
        '
        Me.LinkLabel3.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel3.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.White
        Me.LinkLabel3.Location = New System.Drawing.Point(230, 476)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(241, 20)
        Me.LinkLabel3.TabIndex = 771
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "To Pay Amount"
        Me.LinkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtToPayAmount
        '
        Me.TxtToPayAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtToPayAmount.AgMandatory = False
        Me.TxtToPayAmount.AgMasterHelp = False
        Me.TxtToPayAmount.AgNumberLeftPlaces = 8
        Me.TxtToPayAmount.AgNumberNegetiveAllow = False
        Me.TxtToPayAmount.AgNumberRightPlaces = 2
        Me.TxtToPayAmount.AgPickFromLastValue = False
        Me.TxtToPayAmount.AgRowFilter = ""
        Me.TxtToPayAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToPayAmount.AgSelectedValue = Nothing
        Me.TxtToPayAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToPayAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtToPayAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToPayAmount.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToPayAmount.Location = New System.Drawing.Point(231, 499)
        Me.TxtToPayAmount.MaxLength = 20
        Me.TxtToPayAmount.Name = "TxtToPayAmount"
        Me.TxtToPayAmount.Size = New System.Drawing.Size(240, 37)
        Me.TxtToPayAmount.TabIndex = 770
        Me.TxtToPayAmount.TabStop = False
        Me.TxtToPayAmount.Text = "88888888.88"
        Me.TxtToPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(275, 419)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 768
        Me.Label8.Text = "Payment Mode"
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
        Me.TxtAccount.Location = New System.Drawing.Point(131, 438)
        Me.TxtAccount.MaxLength = 20
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(339, 18)
        Me.TxtAccount.TabIndex = 767
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 440)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 769
        Me.Label9.Text = "Ledger Account"
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
        Me.TxtPaymentMode.Location = New System.Drawing.Point(379, 418)
        Me.TxtPaymentMode.MaxLength = 20
        Me.TxtPaymentMode.Name = "TxtPaymentMode"
        Me.TxtPaymentMode.Size = New System.Drawing.Size(91, 18)
        Me.TxtPaymentMode.TabIndex = 766
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 419)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 16)
        Me.Label10.TabIndex = 773
        Me.Label10.Text = "Advance"
        '
        'TxtAdvance
        '
        Me.TxtAdvance.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdvance.AgMandatory = False
        Me.TxtAdvance.AgMasterHelp = False
        Me.TxtAdvance.AgNumberLeftPlaces = 8
        Me.TxtAdvance.AgNumberNegetiveAllow = False
        Me.TxtAdvance.AgNumberRightPlaces = 2
        Me.TxtAdvance.AgPickFromLastValue = False
        Me.TxtAdvance.AgRowFilter = ""
        Me.TxtAdvance.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdvance.AgSelectedValue = Nothing
        Me.TxtAdvance.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdvance.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdvance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdvance.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdvance.Location = New System.Drawing.Point(131, 418)
        Me.TxtAdvance.MaxLength = 20
        Me.TxtAdvance.Name = "TxtAdvance"
        Me.TxtAdvance.Size = New System.Drawing.Size(138, 18)
        Me.TxtAdvance.TabIndex = 772
        '
        'FrmSaleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(910, 603)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtAdvance)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.TxtToPayAmount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtAccount)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtPaymentMode)
        Me.Controls.Add(Me.TxtDeliveryTime)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtIsHomeDelivery)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtDeliveryDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.TxtPartyName)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPartyMobile)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Name = "FrmSaleOrder"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.TxtPartyMobile, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.TxtPartyName, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.LblRemark, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtDeliveryDate, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtIsHomeDelivery, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtDeliveryTime, 0)
        Me.Controls.SetChildIndex(Me.TxtPaymentMode, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TxtAccount, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TxtToPayAmount, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel3, 0)
        Me.Controls.SetChildIndex(Me.TxtAdvance, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
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
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblRemark As System.Windows.Forms.Label
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtPartyMobile As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtPartyName As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents TxtAdd1 As AgControls.AgTextBox
    Protected WithEvents TxtAdd2 As AgControls.AgTextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtDeliveryDate As AgControls.AgTextBox
    Protected WithEvents TxtDeliveryTime As System.Windows.Forms.DateTimePicker
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleOrder"
        LogTableName = "SaleOrder_Log"
        MainLineTableCsv = "SaleOrderDetail"
        LogLineTableCsv = "SaleOrderDetail_LOG"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)

        AgCalcGrid1.AgLibVar = AgL
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From SaleOrder H " & _
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
               " From SaleOrder_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.UID as SearchCode, H.DocID, Vt.Description AS [Entry_Type], H.V_Date AS [Entry_Date], " & _
                         " H.V_No AS [Entry_No], H.ManualRefNo, H.TotalAmount  " & _
                         " FROM SaleOrder_Log H " & _
                         " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                         " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [Entry Type], " & _
                            " H.V_Date AS [Entry Date], H.V_No AS [Entry No], H.ManualRefNo  " & _
                            " FROM SaleOrder H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1ItemCode, 100, 0, Col1ItemCode, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 130, 0, Col1SalesTaxGroup, False, False)
            .AddAgTextColumn(Dgl1, Col1Outlet, 100, 0, Col1Outlet, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True

        AgCalcGrid1.Ini_Grid(TxtV_Date.Text)

        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        FrmKOT_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim DeliveryDateTime As String = ""

        mQry = "  Update SaleOrder " & _
                " SET  " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                " PartyDeliveryDate = " & AgL.Chk_Text(TxtDeliveryDate.Text) & ", " & _
                " PartyDeliveryTime = " & AgL.Chk_Text(TxtDeliveryTime.Value) & ", " & _
                " SaleToPartyMobile = " & AgL.Chk_Text(TxtPartyMobile.Text) & ", " & _
                " SaleToPartyName = " & AgL.Chk_Text(TxtPartyName.Text) & ", " & _
                " SaleToPartyAdd1 = " & AgL.Chk_Text(TxtAdd1.Text) & ", " & _
                " SaleToPartyAdd2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", " & _
                " IsHomeDelivery = " & IIf(AgL.StrCmp(TxtIsHomeDelivery.Text, "Yes"), 1, 0) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & " " & _
                " Where DocID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        AgCalcGrid1.Save_TransFooter(SearchCode, Conn, Cmd)

        mQry = "Delete From SaleOrderDetail Where DocID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "Insert Into SaleOrderDetail(DocId, Sr, Item, SalesTaxGroupItem, Outlet, Qty, Rate, Amount) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(SearchCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Outlet, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        mQry = "Select H.* " & _
                " From SaleOrder H " & _
                " Where H.DocID='" & SearchCode & "'"
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

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtDeliveryDate.Text = AgL.XNull(.Rows(0)("PartyDeliveryDate"))
                TxtPartyMobile.Text = AgL.XNull(.Rows(0)("SaleToPartyMobile"))
                TxtPartyName.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                TxtAdd1.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd1"))
                TxtAdd2.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd2"))
                TxtIsHomeDelivery.Text = IIf(AgL.VNull(.Rows(0)("IsHomeDelivery")) = 0, "No", "Yes")
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)


                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                mQry = "Select L.* " & _
                            " from SaleOrderDetail L " & _
                            " Where L.DocId = '" & SearchCode & "' " & _
                            " Order By L.Sr"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1ItemCode, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.AgSelectedValue(Col1Outlet, I) = AgL.XNull(.Rows(I)("Outlet"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                            Call AgCalcGrid1.MoveRec_TransLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                '-------------------------------------------------------------
            End If
        End With

        TxtToPayAmount.Text = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) - Val(TxtAdvance.Text)

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 631, 916, 0, 0)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    AgCalcGrid1.AgNCat = LblV_Type.Tag
                    IniGrid()

                Case TxtReferenceNo.Name
                    e.Cancel = FIsDuplicateReferenceNo()

                Case TxtPartyMobile.Name
                    If TxtPartyMobile.Text <> "" Then
                        Call FGetPartyName()
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "SaleOrder", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        AgCalcGrid1.AgNCat = LblV_Type.Tag
        IniGrid()

        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        TxtIsHomeDelivery.Text = "No"
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim bItemCode$ = ""
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1ItemCode
                    Dgl1.AgSelectedValue(Col1Item, mRowIndex) = Dgl1.AgSelectedValue(Col1ItemCode, mRowIndex)
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)

                Case Col1Item
                    Dgl1.AgSelectedValue(Col1ItemCode, mRowIndex) = Dgl1.AgSelectedValue(Col1Item, mRowIndex)
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1SalesTaxGroup, mRow).Value = ""
                Dgl1.Item(Col1Rate, mRow).Value = ""
                Dgl1.Item(Col1Outlet, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Tag, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                    Dgl1.AgSelectedValue(Col1Outlet, mRow) = AgL.XNull(DrTemp(0)("Outlet"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub


    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")

                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
        TxtToPayAmount.Text = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount)) - Val(TxtAdvance.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, "" & Dgl1.Columns(Col1Item).Index & "") Then passed = False : Exit Sub

        If FIsDuplicateReferenceNo() Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    If Val(.Item(Col1Rate, I).Value) = 0 Then
                        MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub TempSaleOrderCommon_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = " Select H.Code, H.Description From HT_Table H "
        HelpDataSet.Table = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Sg.SubCode as Code, Sg.DispName As Steward From SubGroup Sg "
        HelpDataSet.Steward = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description From KotNature H "
        HelpDataSet.KotNature = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description As Outlet From Outlet H "
        HelpDataSet.OutLet = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description As Item, H.Outlet, H.Rate, H.SalesTaxPostingGroup From Item H "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.ManualCode As ItemCode, H.Outlet, H.Rate, H.SalesTaxPostingGroup From Item H "
        HelpDataSet.ItemCode = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0)  FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function FIsDuplicateReferenceNo() As Boolean

        mQry = "Select Count(*) from SaleOrder H " & _
               " Where H.ManualRefNo = '" & TxtReferenceNo.Text & "' " & _
               " And H.DocID <> '" & TxtDocId.Text & "' " & _
               " And H.Site_Code ='" & TxtSite_Code.AgSelectedValue & "' " & _
               " And H.Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
               " And H.V_Type = '" & TxtV_Type.AgSelectedValue & "'  " & _
               " And IsNull(H.IsDeleted,0)=0  "

        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
            MsgBox("Reference No. already exists")
            FIsDuplicateReferenceNo = True
        End If
    End Function

    Private Sub FrmKOT_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dgl1.AgHelpDataSet(Col1Item) = HelpDataSet.Item
        Dgl1.AgHelpDataSet(Col1ItemCode) = HelpDataSet.ItemCode
        Dgl1.AgHelpDataSet(Col1Outlet) = HelpDataSet.OutLet
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
    End Sub

    Private Sub FGetPartyName()
        Dim DtTemp As DataTable = Nothing
        mQry = " Select H.SaleToPartyName, H.SaleToPartyAdd1, H.SaleToPartyAdd2 From SaleOrder H Where SaleToPartyMobile = '" & TxtPartyMobile.Text & "'"
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        With DtTemp
            If DtTemp.Rows.Count > 0 Then
                TxtPartyName.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                TxtAdd1.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd1"))
                TxtAdd2.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd2"))
            End If
        End With
    End Sub
End Class
