Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPurchaseEntry
    Inherits TempPurchInvoiceCommon
    Dim mQry$

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice
    End Sub


#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
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
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(206, 437)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(387, 437)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(73, 213)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(7, 215)
        Me.LblCurrency.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(491, 15)
        '
        'TxtVendorCity
        '
        Me.TxtVendorCity.Location = New System.Drawing.Point(595, 34)
        Me.TxtVendorCity.TabIndex = 7
        '
        'TxtVendorAddress
        '
        Me.TxtVendorAddress.Location = New System.Drawing.Point(595, 14)
        Me.TxtVendorAddress.TabIndex = 6
        '
        'LblVendorNameReq
        '
        Me.LblVendorNameReq.Location = New System.Drawing.Point(111, 81)
        '
        'TxtVendorName
        '
        Me.TxtVendorName.Location = New System.Drawing.Point(127, 74)
        Me.TxtVendorName.Size = New System.Drawing.Size(358, 18)
        Me.TxtVendorName.TabIndex = 5
        '
        'LblVendorName
        '
        Me.LblVendorName.Location = New System.Drawing.Point(7, 74)
        '
        'LblVendorMobile
        '
        Me.LblVendorMobile.Location = New System.Drawing.Point(749, 35)
        '
        'LblVendorCity
        '
        Me.LblVendorCity.Location = New System.Drawing.Point(491, 34)
        '
        'TxtVendorMobile
        '
        Me.TxtVendorMobile.Location = New System.Drawing.Point(852, 34)
        Me.TxtVendorMobile.TabIndex = 8
        '
        'TxtSubGroupMasterType
        '
        Me.TxtSubGroupMasterType.Location = New System.Drawing.Point(695, 215)
        Me.TxtSubGroupMasterType.Size = New System.Drawing.Size(68, 18)
        '
        'TxtSubgroupNature
        '
        Me.TxtSubgroupNature.Location = New System.Drawing.Point(629, 214)
        Me.TxtSubgroupNature.Size = New System.Drawing.Size(60, 18)
        '
        'LblGodown
        '
        Me.LblGodown.Location = New System.Drawing.Point(492, 96)
        Me.LblGodown.Visible = False
        '
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(551, 94)
        Me.TxtGodown.Visible = False
        '
        'LblVendor
        '
        Me.LblVendor.Location = New System.Drawing.Point(7, 54)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(127, 54)
        Me.TxtVendor.Size = New System.Drawing.Size(358, 18)
        '
        'LblVendorReq
        '
        Me.LblVendorReq.Location = New System.Drawing.Point(111, 61)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 182)
        Me.Pnl1.Size = New System.Drawing.Size(1000, 231)
        Me.Pnl1.TabIndex = 12
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(633, 442)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(370, 135)
        Me.PnlCalcGrid.TabIndex = 13
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(218, 214)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(151, 213)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(551, 213)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(440, 213)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(595, 74)
        Me.TxtRemarks.TabIndex = 11
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(491, 74)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(362, 213)
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(296, 213)
        Me.Label32.Visible = False
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(852, 54)
        Me.TxtVendorDocDate.TabIndex = 10
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(749, 55)
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(595, 54)
        Me.TxtVendorDocNo.TabIndex = 9
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.Location = New System.Drawing.Point(491, 54)
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pnl2.Location = New System.Drawing.Point(771, 214)
        Me.Pnl2.Size = New System.Drawing.Size(57, 17)
        Me.Pnl2.Visible = False
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(888, 181)
        Me.BtnFill.Visible = False
        '
        'LblChallans
        '
        Me.LblChallans.Location = New System.Drawing.Point(834, 214)
        Me.LblChallans.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 161)
        '
        'TxtDocId
        '
        Me.TxtDocId.Location = New System.Drawing.Point(932, 210)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(233, 35)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(341, 34)
        Me.TxtV_No.Size = New System.Drawing.Size(144, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 40)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(7, 35)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(311, 20)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 34)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 16)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(341, 14)
        Me.TxtV_Type.Size = New System.Drawing.Size(144, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 20)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(7, 15)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 14)
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(885, 212)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(293, 35)
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(1010, 141)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(1002, 115)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 1000
        '
        'FrmPurchaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1012, 622)
        Me.LogLineTableCsv = "PurchInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchInvoice_Log"
        Me.MainLineTableCsv = "PurchInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchInvoice"
        Me.Name = "FrmPurchaseEntry"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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

    Private Sub FrmPurchaseEntry_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Dim bStructJoin As String = ""

        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Purchase Invoice"
                RepName = "SD_PurchInvoice_Print" : RepTitle = "Purchase Invoice"
                bTableName = "PurchInvoice" : bSecTableName = "PurchInvoiceDetail L ON L.DocID =H.DocID"
                bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

                bStructJoin = " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, FrmType) & ") As SF On H.DocId = SF.DocId " & _
                               " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, FrmType) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr "

            ElseIf FrmType = ClsMain.EntryPointType.Log Then
                AgL.PubReportTitle = "Purchase Invoice"
                RepName = "SD_PurchInvoice_Print" : RepTitle = "Purchase Invoice"
                bTableName = "PurchInvoice_Log" : bSecTableName = "PurchInvoiceDetail_Log  L ON L.UID =H.UID "
                bCondstr = "WHERE H.UID='" & mSearchCode & "'"

                bStructJoin = " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, FrmType) & ") As SF On H.UID = SF.UId " & _
                                " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, FrmType) & ") As SL On L.UID = SL.UID And L.Sr = Sl.TSr "

            End If

            mQry = " SELECT  H.DocID, H.V_Type + ' - ' +convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.PurchChallan, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " H.EntryBy, H.EntryDate,  " & _
                    " SG.Add1, SG.Add2, SG.EMail, SG.Mobile," & _
                    " H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.UID, " & _
                    " L.PurchChallan, L.Item, L.Specification, L.SalesTaxGroupItem, L.DocQty, L.Qty,SM.Name AS SiteName,SG.DispName AS VenderName,C.CityName , " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, " & _
                    " PC.V_Type AS PCV_Type,PC.V_No AS PCV_No,PC.ReferenceNo AS PCVoucherNo,I.Description AS ItemDesc,SF.*, SL.* " & _
                    " FROM " & bTableName & " H " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " " & bStructJoin & " " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN PurchChallan PC ON PC.DocID=L.PurchChallan  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
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


    Private Sub FrmPurchaseEntry_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        Dgl2.Visible = False
    End Sub

    Private Sub FrmPurchaseEntry_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).Width = 240
        Dgl1.Columns(Col1Specification).Width = 240
        Dgl1.Columns(Col1Qty).Width = 100
        Dgl1.Columns(Col1Unit).Width = 80
        Dgl1.Columns(Col1Rate).Width = 100
        Dgl1.Columns(Col1Amount).Width = 110
        Dgl1.Columns(Col1PurchChallan).Visible = False
        Dgl1.Columns(Col1DocQty).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalDocMeasure).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
    End Sub


    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRemarks.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtRemarks.Name
                    Dgl1.CurrentCell = Dgl1(Dgl1.Columns(Col1Item).Index, 0)
                    Dgl1.Focus()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
End Class
