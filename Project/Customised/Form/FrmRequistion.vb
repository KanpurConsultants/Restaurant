Public Class FrmRequistion
    Inherits AgTemplate.TempTransaction
    Public mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Item"
    Protected Const Col1CurrentStock As String = "Current Stock"
    Protected Const Col1IndentQty As String = "Req Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalIndentMeasure As String = "Total Req Measure"
    Protected Const Col1OrdQty As String = "Order Qty"
    Protected Const Col1OrdMeasure As String = "Order Measure"
    Protected Const Col1PurchQty As String = "Purch Qty"
    Protected Const Col1PurchMeasure As String = "Purch Measure"
    Protected Const Col1RequireDate As String = "Require Date"

    Public Class HelpDataSet
        Public Shared Item As DataSet = Nothing
        Public Shared Indentor As DataSet = Nothing
        Public Shared Department As DataSet = Nothing
        Public Shared ProductionOrder As DataSet = Nothing
    End Class

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.CreditNote
    End Sub


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblIndentorReq = New System.Windows.Forms.Label
        Me.TxtIndentor = New AgControls.AgTextBox
        Me.LblIndentor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblManualRefNo = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(756, 525)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(596, 525)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 525)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 525)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 525)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 521)
        Me.GroupBox1.Size = New System.Drawing.Size(1010, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 525)
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
        Me.LblV_No.Location = New System.Drawing.Point(685, 121)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Voucher No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(771, 121)
        Me.TxtV_No.Size = New System.Drawing.Size(212, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(322, 44)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(209, 40)
        Me.LblV_Date.Size = New System.Drawing.Size(100, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Requistion Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(571, 24)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(338, 38)
        Me.TxtV_Date.Size = New System.Drawing.Size(122, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(466, 20)
        Me.LblV_Type.Size = New System.Drawing.Size(101, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Requistion Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(586, 18)
        Me.TxtV_Type.Size = New System.Drawing.Size(159, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(322, 24)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(209, 20)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(338, 18)
        Me.TxtSite_Code.Size = New System.Drawing.Size(122, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(20, 35)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, 18)
        Me.TabControl1.Size = New System.Drawing.Size(1001, 157)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.LblManualRefNo)
        Me.TP1.Controls.Add(Me.LblIndentorReq)
        Me.TP1.Controls.Add(Me.TxtIndentor)
        Me.TP1.Controls.Add(Me.LblIndentor)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(993, 131)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIndentor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIndentor, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIndentorReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(7, 488)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(976, 21)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(432, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 670
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(321, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 669
        Me.Label33.Text = "Total Measure :"
        Me.Label33.Visible = False
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(94, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 668
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(9, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 667
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(7, 181)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(976, 307)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(209, 80)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
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
        Me.TxtRemarks.Location = New System.Drawing.Point(338, 78)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(407, 18)
        Me.TxtRemarks.TabIndex = 6
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 159)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(195, 21)
        Me.LinkLabel1.TabIndex = 731
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Requistion For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblIndentorReq
        '
        Me.LblIndentorReq.AutoSize = True
        Me.LblIndentorReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIndentorReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIndentorReq.Location = New System.Drawing.Point(322, 66)
        Me.LblIndentorReq.Name = "LblIndentorReq"
        Me.LblIndentorReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIndentorReq.TabIndex = 732
        Me.LblIndentorReq.Text = "Ä"
        '
        'TxtIndentor
        '
        Me.TxtIndentor.AgAllowUserToEnableMasterHelp = False
        Me.TxtIndentor.AgMandatory = True
        Me.TxtIndentor.AgMasterHelp = False
        Me.TxtIndentor.AgNumberLeftPlaces = 8
        Me.TxtIndentor.AgNumberNegetiveAllow = False
        Me.TxtIndentor.AgNumberRightPlaces = 2
        Me.TxtIndentor.AgPickFromLastValue = False
        Me.TxtIndentor.AgRowFilter = ""
        Me.TxtIndentor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIndentor.AgSelectedValue = Nothing
        Me.TxtIndentor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIndentor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIndentor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIndentor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIndentor.Location = New System.Drawing.Point(338, 58)
        Me.TxtIndentor.MaxLength = 20
        Me.TxtIndentor.Name = "TxtIndentor"
        Me.TxtIndentor.Size = New System.Drawing.Size(407, 18)
        Me.TxtIndentor.TabIndex = 5
        '
        'LblIndentor
        '
        Me.LblIndentor.AutoSize = True
        Me.LblIndentor.BackColor = System.Drawing.Color.Transparent
        Me.LblIndentor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIndentor.Location = New System.Drawing.Point(209, 60)
        Me.LblIndentor.Name = "LblIndentor"
        Me.LblIndentor.Size = New System.Drawing.Size(60, 16)
        Me.LblIndentor.TabIndex = 731
        Me.LblIndentor.Text = "Order By"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(570, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 736
        Me.Label1.Text = "Ä"
        '
        'TxtManualRefNo
        '
        Me.TxtManualRefNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtManualRefNo.AgMandatory = True
        Me.TxtManualRefNo.AgMasterHelp = False
        Me.TxtManualRefNo.AgNumberLeftPlaces = 8
        Me.TxtManualRefNo.AgNumberNegetiveAllow = False
        Me.TxtManualRefNo.AgNumberRightPlaces = 2
        Me.TxtManualRefNo.AgPickFromLastValue = False
        Me.TxtManualRefNo.AgRowFilter = ""
        Me.TxtManualRefNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualRefNo.AgSelectedValue = Nothing
        Me.TxtManualRefNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualRefNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualRefNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualRefNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualRefNo.Location = New System.Drawing.Point(586, 38)
        Me.TxtManualRefNo.MaxLength = 50
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(159, 18)
        Me.TxtManualRefNo.TabIndex = 4
        '
        'LblManualRefNo
        '
        Me.LblManualRefNo.AutoSize = True
        Me.LblManualRefNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualRefNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualRefNo.Location = New System.Drawing.Point(466, 40)
        Me.LblManualRefNo.Name = "LblManualRefNo"
        Me.LblManualRefNo.Size = New System.Drawing.Size(93, 16)
        Me.LblManualRefNo.TabIndex = 735
        Me.LblManualRefNo.Text = "Manual Ref No"
        '
        'FrmRequistion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmRequistion"
        Me.Text = "Template Purchase Indent"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
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
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblIndentorReq As System.Windows.Forms.Label
    Protected WithEvents TxtIndentor As AgControls.AgTextBox
    Protected WithEvents LblIndentor As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblManualRefNo As System.Windows.Forms.Label
#End Region

    Private Sub TempPurchIndent_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = " UPDATE PurchOrder_Log SET PurchIndent = NULL WHERE PurchIndent = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " UPDATE PurchOrderdetail_Log SET PurchIndent = NULL WHERE PurchIndent = '" & mInternalCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "PurchIndent"
        LogTableName = "PurchIndent_Log"
        MainLineTableCsv = "PurchIndentDetail"
        LogLineTableCsv = "PurchIndentDetail_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                       " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "P.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select P.DocID As SearchCode " & _
            " From PurchIndent P " & _
            " Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By P.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "P.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select P.UID As SearchCode " & _
               " From PurchIndent_Log P " & _
               " Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type  " & _
               " Where P.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By P.EntryDate"



        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT P.DocID, Vt.Description AS [Entry Type], P.V_Date AS [Entry Date], " & _
        '                    " P.V_No AS [Entry No], Sg.DispName As Indentor, D.Description As Department " & _
        '                    " FROM PurchIndent P " & _
        '                    " LEFT JOIN Voucher_type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN Department D On P.Department = D.Code " & _
        '                    " LEFT JOIN SubGroup Sg On P.Indentor = Sg.SubCode " & _
        '                    " Where IsNull(P.IsDeleted,0) = 0   " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Indent Type], H.V_Prefix AS [Prefix], H.V_Date AS [Indent Date], H.V_No AS [Indent No], " & _
                            " H.Remarks, H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type],  " & _
                            " H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status,  " & _
                            " D.Div_Name AS Division, SM.Name AS [Site Name],DE.Description AS Department, SGI.DispName AS [Indentor Name], PO.ManualRefNo AS [Prod. ORDER No ] " & _
                            " FROM  PurchIndent H " & _
                            " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                            " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                            " LEFT JOIN Department DE ON DE.Code=H.Department  " & _
                            " LEFT JOIN SubGroup  SGI ON SGI.SubCode  = H.Indentor  " & _
                            " LEFT JOIN ProdOrder PO ON PO.DocID  = H.ProdOrder  " & _
                            " Where IsNull(H.IsDeleted,0) = 0   " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = " SELECT P.UID as SearchCode, P.DocId, Vt.Description AS [Entry Type], " & _
        '                    " P.V_Date AS [Entry Date], P.V_No AS [Entry No], Sg.DispName As  Indentor,  " & _
        '                    " D.Description As Department " & _
        '                    " FROM PurchIndent_Log P " & _
        '                    " LEFT JOIN Voucher_Type Vt ON P.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN Department D On P.Department = D.Code  " & _
        '                    " LEFT JOIN SubGroup Sg On P.Indentor = Sg.SubCode " & _
        '                    " Where P.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Indent Type], H.V_Prefix AS [Prefix], H.V_Date AS [Indent Date], H.V_No AS [Indent No], " & _
            " H.Remarks, H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type],  " & _
            " H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status,  " & _
            " D.Div_Name AS Division, SM.Name AS [Site Name],DE.Description AS Department, SGI.DispName AS [Indentor Name], PO.ManualRefNo AS [Prod. ORDER No ] " & _
            " FROM  PurchIndent_Log H " & _
            " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
            " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
            " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
            " LEFT JOIN Department DE ON DE.Code=H.Department  " & _
            " LEFT JOIN SubGroup  SGI ON SGI.SubCode  = H.Indentor  " & _
            " LEFT JOIN ProdOrder PO ON PO.DocID  = H.ProdOrder  " & _
            " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 250, 0, Col1Item, True, False)
            .AddAgNumberColumn(Dgl1, Col1CurrentStock, 100, 8, 4, False, Col1CurrentStock, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1IndentQty, 100, 8, 4, False, Col1IndentQty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 100, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, False, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 70, 0, Col1MeasureUnit, False, True)
            .AddAgNumberColumn(Dgl1, Col1TotalIndentMeasure, 120, 8, 4, False, Col1TotalIndentMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1OrdQty, 70, 8, 4, False, Col1OrdQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1OrdMeasure, 70, 8, 4, False, Col1OrdMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1PurchQty, 70, 8, 4, False, Col1PurchQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1PurchMeasure, 70, 8, 4, False, Col1PurchMeasure, False, True, True)
            .AddAgDateColumn(Dgl1, Col1RequireDate, 80, Col1RequireDate, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35


        'If AgL.PubDtEnviro.Rows.Count > 0 Then
        '    If AgL.VNull(AgL.PubDtEnviro.Rows(0)("IsLotNoApplicable")) <> 0 Then
        '        Dgl1.Columns(Col1CurrentStock).CellTemplate.Style.Font = New Font(Dgl1.DefaultCellStyle.Font.FontFamily, Dgl1.DefaultCellStyle.Font.Size, FontStyle.Underline)
        '        Dgl1.Columns(Col1CurrentStock).CellTemplate.Style.ForeColor = Color.Blue
        '    End If
        'End If

        Dgl1.AgSkipReadOnlyColumns = True
        'Ini_List()
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        mQry = "UPDATE PurchIndent_Log " & _
                " SET Indentor = " & AgL.Chk_Text(TxtIndentor.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From PurchIndentDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = "Insert Into PurchIndentDetail_Log(UID, DocId, Sr, Item, CurrentStock, IndentQty, " & _
                            " Unit, Rate, MeasurePerPcs, MeasureUnit, TotalIndentMeasure, OrdQty,  " & _
                            " OrdMeasure, PurchQty, PurchMeasure,RequireDate) " & _
                            " Values(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & Val(Dgl1.Item(Col1CurrentStock, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1IndentQty, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ",  " & _
                            " " & Val(Dgl1.Item(Col1TotalIndentMeasure, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1OrdQty, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1OrdMeasure, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1PurchQty, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1PurchMeasure, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1RequireDate, I).Value) & " )"

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select P.* " & _
                " From PurchIndent P " & _
                " Where P.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select P.* " & _
                " From PurchIndent_Log P " & _
                " Where P.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtIndentor.AgSelectedValue = AgL.XNull(.Rows(0)("Indentor"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")
                LblTotalMeasure.Text = Format(AgL.VNull(.Rows(0)("TotalMeasure")), "0.000")

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from PurchIndentDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from PurchIndentDetail_Log where UID = '" & SearchCode & "' Order By Sr"
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
                            Dgl1.Item(Col1CurrentStock, I).Value = Format(AgL.VNull(.Rows(I)("CurrentStock")), "0.000")
                            Dgl1.Item(Col1IndentQty, I).Value = AgL.VNull(.Rows(I)("IndentQty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.000")
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalIndentMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalIndentMeasure")), "0.000")
                            Dgl1.Item(Col1OrdQty, I).Value = AgL.VNull(.Rows(I)("OrdQty"))
                            Dgl1.Item(Col1OrdMeasure, I).Value = AgL.VNull(.Rows(I)("OrdMeasure"))
                            Dgl1.Item(Col1PurchQty, I).Value = AgL.VNull(.Rows(I)("PurchQty"))
                            Dgl1.Item(Col1PurchMeasure, I).Value = AgL.VNull(.Rows(I)("PurchMeasure"))
                            Dgl1.Item(Col1RequireDate, I).Value = AgL.XNull(.Rows(I)("RequireDate"))

                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmProductionOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 594, 998)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dgl1.AgHelpDataSet(Col1Item, 8) = HelpDataSet.Item
        TxtIndentor.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Indentor
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    'Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0  " & _
                    '        " And " & ClsMain.RetDivFilterStr & "  " & _
                    '        " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0  " & _
                            " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalIndentMeasure, I).Value = Format(Val(Dgl1.Item(Col1IndentQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1IndentQty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalIndentMeasure, I).Value)
            End If
        Next
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.000")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        'If AgL.RequiredField(TxtIndentor, LblIndentor.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1IndentQty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1IndentQty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Date.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtV_Date.Name

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
                Case TxtIndentor.Name
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.Item(Col1CurrentStock, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("Measure"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                    Dgl1.Item(Col1CurrentStock, mRow).Value = AgTemplate.ClsMain.FunRetStock(Dgl1.AgSelectedValue(Col1Item, mRow), mInternalCode, , , , , TxtV_Date.Text)
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
                    Dgl1.Item(Col1RequireDate, mRowIndex).Value = TxtV_Date.Text
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try

            Dim bRData As String
            '// Check for relational data in Purchase Quotation
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo From PurchQuotationDetail  L LEFT JOIN PurchQuotation H ON L.DocId = H.DocID WHERE L.PurchIndent  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Quotation " & bRData & " created against Indent No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

            '// Check for relational data in Purchase Order
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo From PurchOrderDetail  L LEFT JOIN PurchOrder H ON L.DocId = H.DocID WHERE L.PurchIndent  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Order " & bRData & " created against Indent No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If


        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function


    Private Sub TempPurchIndent_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempPurchIndent_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub Dgl1_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseMove
        Try
            If AgL.PubDtEnviro.Rows.Count > 0 Then
                If AgL.VNull(AgL.PubDtEnviro.Rows(0)("IsLotNoApplicable")) = 0 Then Exit Sub
            End If

            Select Case Dgl1.Columns(e.ColumnIndex).Name
                Case Col1CurrentStock
                    Dgl1.Cursor = Cursors.Hand

                Case Else
                    Dgl1.Cursor = Cursors.Default
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TempPurchIndent_BaseFunction_Create() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT H.Code, H.Description, H.Unit, H.ItemType, H.SalesTaxPostingGroup , " & _
                " IsNull(H.IsDeleted ,0) AS IsDeleted, H.Div_Code, " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, H.Measure, MeasureUnit " & _
                " FROM Item H"
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT E.SubCode AS Code, S.DispName AS [Employee Name], IsNull(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status   " & _
               " FROM Employee E " & _
               " LEFT JOIN Subgroup S ON E.SubCode = S.SubCode  "
        HelpDataSet.Indentor = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select H.Code As Code, H.Description As Department,  " & _
                " H.Div_Code,  " & _
                " IsNull(H.IsDeleted,0) as IsDeleted,  " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status   " & _
                " From Department H "
        HelpDataSet.Department = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.DocID As Code , H.ManualRefNo AS [Manual Order No], H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS [Prod. Order], " & _
                " H.V_Date  AS [Prod. Order Date], H.DueDate AS [Due Date], So.V_Type + '-' + Convert(NVARCHAR,So.V_No) AS [Sale Order No], " & _
                " H.Div_Code, IsNull(H.IsDeleted,0) AS IsDeleted , " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, H.MoveToLog    " & _
                " FROM ProdOrder H " & _
                " LEFT JOIN SaleOrder So ON H.SaleOrder = So.DocID "
        HelpDataSet.ProductionOrder = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
End Class
