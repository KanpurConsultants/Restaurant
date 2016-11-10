Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmKOT
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1ItemCode As String = "Item Code"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1OutLet As String = "OutLet"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected WithEvents LblKOTNature As System.Windows.Forms.Label
    Protected WithEvents TxtKOTNature As AgControls.AgTextBox

    Dim mTable$ = ""

    Public Class HelpDataSet
        Public Shared Table As DataSet = Nothing
        Public Shared Steward As DataSet = Nothing
        Public Shared KotNature As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared ItemCode As DataSet = Nothing
        Public Shared OutLet As DataSet = Nothing
    End Class

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.KOT
    End Sub

    Public Property Table() As String
        Get
            Table = mTable
        End Get
        Set(ByVal value As String)
            mTable = value
        End Set
    End Property

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.LblTableReq = New System.Windows.Forms.Label
        Me.TxtTable = New AgControls.AgTextBox
        Me.LblTable = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.TxtSteward = New AgControls.AgTextBox
        Me.LblSteward = New System.Windows.Forms.Label
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblRemarks = New System.Windows.Forms.Label
        Me.LblKOTNature = New System.Windows.Forms.Label
        Me.TxtKOTNature = New AgControls.AgTextBox
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
        Me.GroupBox2.Location = New System.Drawing.Point(758, 436)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 462)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(368, 462)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(231, 436)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 436)
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
        Me.GroupBox1.Location = New System.Drawing.Point(-6, 433)
        Me.GroupBox1.Size = New System.Drawing.Size(928, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(487, 436)
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
        Me.LblV_No.Location = New System.Drawing.Point(119, 130)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Voucher No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(227, 129)
        Me.TxtV_No.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(508, 20)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(425, 15)
        Me.LblV_Date.Size = New System.Drawing.Size(65, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "KOT Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(428, 109)
        Me.LblV_TypeReq.Tag = ""
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(527, 14)
        Me.TxtV_Date.Size = New System.Drawing.Size(143, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(397, 105)
        Me.LblV_Type.Size = New System.Drawing.Size(88, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Voucher Type"
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(505, 104)
        Me.TxtV_Type.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(258, 20)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(157, 15)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(277, 14)
        Me.TxtSite_Code.Size = New System.Drawing.Size(132, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(179, 130)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, 19)
        Me.TabControl1.Size = New System.Drawing.Size(915, 125)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblKOTNature)
        Me.TP1.Controls.Add(Me.TxtSteward)
        Me.TP1.Controls.Add(Me.LblRemarks)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.TxtKOTNature)
        Me.TP1.Controls.Add(Me.LblSteward)
        Me.TP1.Controls.Add(Me.LblTableReq)
        Me.TP1.Controls.Add(Me.TxtTable)
        Me.TP1.Controls.Add(Me.LblTable)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(907, 99)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTableReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSteward, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtKOTNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSteward, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblKOTNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(910, 41)
        Me.Topctrl1.TabIndex = 2
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
        'LblTableReq
        '
        Me.LblTableReq.AutoSize = True
        Me.LblTableReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTableReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTableReq.Location = New System.Drawing.Point(508, 40)
        Me.LblTableReq.Name = "LblTableReq"
        Me.LblTableReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTableReq.TabIndex = 694
        Me.LblTableReq.Text = "Ä"
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
        Me.TxtTable.Location = New System.Drawing.Point(527, 34)
        Me.TxtTable.MaxLength = 0
        Me.TxtTable.Name = "TxtTable"
        Me.TxtTable.Size = New System.Drawing.Size(143, 18)
        Me.TxtTable.TabIndex = 4
        '
        'LblTable
        '
        Me.LblTable.AutoSize = True
        Me.LblTable.BackColor = System.Drawing.Color.Transparent
        Me.LblTable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTable.Location = New System.Drawing.Point(425, 35)
        Me.LblTable.Name = "LblTable"
        Me.LblTable.Size = New System.Drawing.Size(39, 16)
        Me.LblTable.TabIndex = 693
        Me.LblTable.Text = "Table"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 395)
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
        Me.Pnl1.Location = New System.Drawing.Point(4, 166)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(902, 229)
        Me.Pnl1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 145)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(109, 20)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Item Details"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(502, 588)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(7, 16)
        Me.PnlCShowGrid2.TabIndex = 741
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(523, 588)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(12, 16)
        Me.PnlCShowGrid.TabIndex = 740
        '
        'TxtSteward
        '
        Me.TxtSteward.AgAllowUserToEnableMasterHelp = False
        Me.TxtSteward.AgMandatory = True
        Me.TxtSteward.AgMasterHelp = False
        Me.TxtSteward.AgNumberLeftPlaces = 8
        Me.TxtSteward.AgNumberNegetiveAllow = False
        Me.TxtSteward.AgNumberRightPlaces = 2
        Me.TxtSteward.AgPickFromLastValue = False
        Me.TxtSteward.AgRowFilter = ""
        Me.TxtSteward.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSteward.AgSelectedValue = Nothing
        Me.TxtSteward.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSteward.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSteward.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSteward.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSteward.Location = New System.Drawing.Point(277, 54)
        Me.TxtSteward.MaxLength = 100
        Me.TxtSteward.Name = "TxtSteward"
        Me.TxtSteward.Size = New System.Drawing.Size(393, 18)
        Me.TxtSteward.TabIndex = 6
        '
        'LblSteward
        '
        Me.LblSteward.AutoSize = True
        Me.LblSteward.BackColor = System.Drawing.Color.Transparent
        Me.LblSteward.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSteward.Location = New System.Drawing.Point(157, 55)
        Me.LblSteward.Name = "LblSteward"
        Me.LblSteward.Size = New System.Drawing.Size(55, 16)
        Me.LblSteward.TabIndex = 738
        Me.LblSteward.Text = "Steward"
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(258, 40)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(277, 34)
        Me.TxtReferenceNo.MaxLength = 0
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(132, 18)
        Me.TxtReferenceNo.TabIndex = 3
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(157, 35)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(58, 16)
        Me.LblReferenceNo.TabIndex = 751
        Me.LblReferenceNo.Text = "KOT No."
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
        Me.TxtRemarks.Location = New System.Drawing.Point(277, 74)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(393, 18)
        Me.TxtRemarks.TabIndex = 7
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.LblRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(157, 75)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(60, 16)
        Me.LblRemarks.TabIndex = 755
        Me.LblRemarks.Text = "Remarks"
        '
        'LblKOTNature
        '
        Me.LblKOTNature.AutoSize = True
        Me.LblKOTNature.BackColor = System.Drawing.Color.Transparent
        Me.LblKOTNature.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKOTNature.Location = New System.Drawing.Point(626, 102)
        Me.LblKOTNature.Name = "LblKOTNature"
        Me.LblKOTNature.Size = New System.Drawing.Size(76, 16)
        Me.LblKOTNature.TabIndex = 754
        Me.LblKOTNature.Text = "KOT Nature"
        Me.LblKOTNature.Visible = False
        '
        'TxtKOTNature
        '
        Me.TxtKOTNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtKOTNature.AgMandatory = True
        Me.TxtKOTNature.AgMasterHelp = False
        Me.TxtKOTNature.AgNumberLeftPlaces = 8
        Me.TxtKOTNature.AgNumberNegetiveAllow = False
        Me.TxtKOTNature.AgNumberRightPlaces = 2
        Me.TxtKOTNature.AgPickFromLastValue = False
        Me.TxtKOTNature.AgRowFilter = ""
        Me.TxtKOTNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKOTNature.AgSelectedValue = Nothing
        Me.TxtKOTNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKOTNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtKOTNature.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKOTNature.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKOTNature.Location = New System.Drawing.Point(735, 101)
        Me.TxtKOTNature.MaxLength = 100
        Me.TxtKOTNature.Name = "TxtKOTNature"
        Me.TxtKOTNature.Size = New System.Drawing.Size(151, 18)
        Me.TxtKOTNature.TabIndex = 5
        Me.TxtKOTNature.Visible = False
        '
        'FrmKOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(910, 484)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmKOT"
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
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
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
    Protected WithEvents LblTable As System.Windows.Forms.Label
    Public WithEvents TxtTable As AgControls.AgTextBox
    Protected WithEvents LblTableReq As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtSteward As AgControls.AgTextBox
    Protected WithEvents LblSteward As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblRemarks As System.Windows.Forms.Label
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleChallan"
        LogTableName = "SaleChallan_Log"
        MainLineTableCsv = "SaleChallanDetail"
        LogLineTableCsv = "SaleChallanDetail_LOG"

        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From SaleChallan H " & _
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
               " From SaleChallan_Log H " & _
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
                         " H.V_No AS [Entry_No], H.ReferenceNo, H.TotalAmount  " & _
                         " FROM SaleChallan_Log H " & _
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
                            " H.V_Date AS [Entry Date], H.V_No AS [Entry No], H.ReferenceNo  " & _
                            " FROM SaleChallan H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1ItemCode, 150, 0, Col1ItemCode, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 250, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1OutLet, 170, 0, Col1OutLet, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = Pnl1.Anchor

        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "  Update SaleChallan_Log " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " TableCode = " & AgL.Chk_Text(TxtTable.AgSelectedValue) & ", " & _
                " Steward = " & AgL.Chk_Text(TxtSteward.AgSelectedValue) & ", " & _
                " KotNature = " & AgL.Chk_Text(TxtKOTNature.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From SaleChallanDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "Insert Into SaleChallanDetail_Log( UID, DocId, Sr, Item, Outlet, Qty, Rate, Amount) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1OutLet, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From SaleChallan H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From SaleChallan_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtTable.AgSelectedValue = AgL.XNull(.Rows(0)("TableCode"))
                TxtSteward.AgSelectedValue = AgL.XNull(.Rows(0)("Steward"))
                TxtKOTNature.AgSelectedValue = AgL.XNull(.Rows(0)("KOTNature"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select L.* " & _
                            " from SaleChallanDetail L " & _
                            " Where L.DocId = '" & SearchCode & "' " & _
                            " Order By L.Sr"
                Else
                    mQry = "Select L.* " & _
                            " from SaleChallanDetail_log L " & _
                            " Where L.UID = '" & SearchCode & "' " & _
                            " Order By L.Sr"
                End If
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
                            Dgl1.AgSelectedValue(Col1OutLet, I) = AgL.XNull(.Rows(I)("Outlet"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        Next I
                    End If
                End With
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 512, 916, 0, 0)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        If mTable <> "" Then
            Topctrl1.FButtonClick(0)
            TxtTable.AgSelectedValue = mTable
        End If
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtReferenceNo.Validating, TxtTable.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtReferenceNo.Name
                    e.Cancel = FIsDuplicateReferenceNo()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "SaleChallan", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max) 'TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
        TxtTable.Focus()
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.AgSelectedValue(Col1OutLet, mRow) = ""
                Dgl1.Item(Col1Rate, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.AgSelectedValue(Col1OutLet, mRow) = AgL.XNull(DrTemp(0)("OutLet"))
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
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
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtTable, LblTable.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtSteward, LblSteward.Text) Then passed = False : Exit Sub

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

    Private Sub TempSaleChallanCommon_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = " Select H.Code, H.Description From HT_Table H "
        HelpDataSet.Table = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Sg.SubCode as Code, Sg.DispName As Steward From SubGroup Sg "
        HelpDataSet.Steward = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description From KotNature H "
        HelpDataSet.KotNature = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description As Outlet From Outlet H "
        HelpDataSet.OutLet = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.Description As Item, H.Outlet, H.Rate From Item H "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select H.Code, H.ManualCode As ItemCode, H.Outlet, H.Rate From Item H "
        HelpDataSet.ItemCode = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT Max(H.ReferenceNo) AS VNo FROM SaleInvoiceDetail L LEFT JOIN SaleInvoice H ON L.DocId = H.DocID WHERE L.SaleChallan  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0)=0 Group By H.DocID ) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Sale Invoice " & bRData & " created against KOT No. " & TxtReferenceNo.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If



        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in FrmKot")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub TempSaleChallanCommon_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempSaleChallanCommon_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Function FIsDuplicateReferenceNo() As Boolean

        mQry = "Select Count(*) from SaleChallan H " & _
               " Where H.ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
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
        TxtTable.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Table
        TxtSteward.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Steward
        TxtKOTNature.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.KotNature
        Dgl1.AgHelpDataSet(Col1Item) = HelpDataSet.Item
        Dgl1.AgHelpDataSet(Col1ItemCode) = HelpDataSet.ItemCode
        Dgl1.AgHelpDataSet(Col1OutLet) = HelpDataSet.OutLet
    End Sub

    Private Sub FrmPurchaseEntry_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Dim bStructJoin As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "KOT"
            RepName = "Ht_KOT_Print" : RepTitle = "KOT"
            bCondstr = " WHERE H.DocID = '" & mInternalCode & "'"

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.SaleToParty, " & _
                        " H.SaleToPartyName, H.SaleToPartyAddress, H.SaleToPartyCity, H.SaleToPartyMobile, H.ShipToParty, H.ShipToPartyName,  " & _
                        " H.ShipToPartyAddress, H.ShipToPartyCity, H.ShipToPartyMobile, H.PurchOrder, H.Currency, H.GateEntryNo, H.TruckNo,  " & _
                        " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.Transporter, H.Transport, H.Godown, H.Remarks,  " & _
                        " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy,  " & _
                        " H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Ht_Table, H.Steward, H.KOTNature,  " & _
                        " H.SaleInvoice, H.TableCode, H.Vendor, H.SaleOrder, H.DeliveryOrder, H.Vehicle, H.VehicleDescription, H.Driver,  " & _
                        " H.DriverName, H.DriverContactNo, H.LrNo, H.LrDate, H.PrivateMark, H.PortOfLoading, H.DestinationPort,  " & _
                        " H.FinalPlaceOfDelivery, H.PreCarriageBy, H.PlaceOfPreCarriage, H.ShipmentThrough, " & _
                        " L.DocId, L.Sr, L.V_Date, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, L.Unit, L.MeasurePerPcs,  " & _
                        " L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,  " & _
                        " L.QcQty, L.QcMeasure, L.LotNo, L.Remark, L.UID, L.Outlet, L.SaleOrder, L.DeliveryOrder,  " & _
                        " L.Specification, L.BaleNo, L.JobReceiveDocId, Sg.DispName AS StewardName, T.Description AS TableDesc, I.Description AS ItemDesc  " & _
                        " FROM SaleChallan H  " & _
                        " LEFT JOIN SaleChallanDetail L ON H.DocID = L.DocId " & _
                        " LEFT JOIN SubGroup Sg ON H.Steward = Sg.SubCode " & _
                        " LEFT JOIN HT_Table T ON H.TableCode = T.Code " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " " & bCondstr & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(mQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class
