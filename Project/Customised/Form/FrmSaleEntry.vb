
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSaleEntry
    Inherits TempSaleInvoice

    Dim mQry$

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.SaleInvoice
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
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(163, 437)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(348, 437)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(72, 189)
        Me.TxtCurrency.Size = New System.Drawing.Size(36, 18)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(6, 191)
        Me.LblCurrency.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(533, 16)
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(600, 35)
        Me.TxtSaleToPartyCity.TabIndex = 7
        '
        'TxtSaleToPartyAddress
        '
        Me.TxtSaleToPartyAddress.Location = New System.Drawing.Point(600, 15)
        Me.TxtSaleToPartyAddress.TabIndex = 6
        '
        'LblSaleToPartyNameReq
        '
        Me.LblSaleToPartyNameReq.Location = New System.Drawing.Point(112, 81)
        '
        'TxtSaleToPartyName
        '
        Me.TxtSaleToPartyName.Location = New System.Drawing.Point(128, 74)
        Me.TxtSaleToPartyName.TabIndex = 5
        '
        'LblSaleToPartyName
        '
        Me.LblSaleToPartyName.Location = New System.Drawing.Point(8, 74)
        '
        'LblSaleToPartyMobile
        '
        Me.LblSaleToPartyMobile.Location = New System.Drawing.Point(754, 36)
        '
        'LblSaleToPartyCity
        '
        Me.LblSaleToPartyCity.Location = New System.Drawing.Point(533, 35)
        '
        'TxtSaleToPartyMobile
        '
        Me.TxtSaleToPartyMobile.Location = New System.Drawing.Point(857, 35)
        Me.TxtSaleToPartyMobile.TabIndex = 8
        '
        'TxtSubGroupMasterType
        '
        Me.TxtSubGroupMasterType.Location = New System.Drawing.Point(546, 189)
        Me.TxtSubGroupMasterType.Size = New System.Drawing.Size(45, 18)
        '
        'TxtSubgroupNature
        '
        Me.TxtSubgroupNature.Location = New System.Drawing.Point(481, 189)
        Me.TxtSubgroupNature.Size = New System.Drawing.Size(59, 18)
        '
        'LblGodown
        '
        Me.LblGodown.Location = New System.Drawing.Point(589, 91)
        Me.LblGodown.Visible = False
        '
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(650, 89)
        Me.TxtGodown.Visible = False
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(312, 41)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(342, 34)
        Me.TxtReferenceNo.Size = New System.Drawing.Size(163, 18)
        Me.TxtReferenceNo.TabIndex = 3
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(235, 34)
        Me.LblReferenceNo.Size = New System.Drawing.Size(71, 16)
        Me.LblReferenceNo.Text = "Invoice No."
        '
        'LblSaleToParty
        '
        Me.LblSaleToParty.Location = New System.Drawing.Point(8, 54)
        '
        'TxtSaleToParty
        '
        Me.TxtSaleToParty.Location = New System.Drawing.Point(128, 54)
        '
        'LblSaleToPartyReq
        '
        Me.LblSaleToPartyReq.Location = New System.Drawing.Point(112, 61)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 181)
        Me.Pnl1.Size = New System.Drawing.Size(1000, 232)
        Me.Pnl1.TabIndex = 10
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(633, 442)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(370, 135)
        Me.PnlCalcGrid.TabIndex = 11
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(181, 189)
        Me.TxtStructure.Size = New System.Drawing.Size(31, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(114, 191)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(432, 188)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(43, 18)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(327, 190)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(600, 55)
        Me.TxtRemarks.TabIndex = 9
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(533, 55)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(283, 190)
        Me.TxtBillingType.Size = New System.Drawing.Size(38, 18)
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(218, 190)
        Me.Label32.Visible = False
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pnl2.Location = New System.Drawing.Point(674, 188)
        Me.Pnl2.Size = New System.Drawing.Size(71, 22)
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(755, 186)
        '
        'LblChallans
        '
        Me.LblChallans.Location = New System.Drawing.Point(597, 188)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(1, 158)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(729, 90)
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(837, 89)
        Me.TxtV_No.Size = New System.Drawing.Size(57, 18)
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(112, 40)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(8, 35)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(312, 20)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(128, 34)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(234, 16)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(342, 14)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(112, 20)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(8, 15)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(128, 14)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(789, 90)
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(1010, 139)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(1002, 113)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 1000
        '
        'FrmSaleEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1012, 622)
        Me.LogLineTableCsv = "SaleInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "SaleInvoice_Log"
        Me.MainLineTableCsv = "SaleInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "SaleInvoice"
        Me.Name = "FrmSaleEntry"
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
                AgL.PubReportTitle = "Sale Invoice"
                RepName = "SD_SaleInvoice_Print" : RepTitle = "Sale Invoice"
                bTableName = "SaleInvoice" : bSecTableName = "SaleInvoiceDetail L ON L.DocID =H.DocID"
                bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

                bStructJoin = " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, AgTemplate.ClsMain.Temp_NCat.SaleInvoice, FrmType) & ") As SF On H.DocId = SF.DocId " & _
                               " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, AgTemplate.ClsMain.Temp_NCat.SaleInvoice, FrmType) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr "

            ElseIf FrmType = ClsMain.EntryPointType.Log Then
                AgL.PubReportTitle = "Sale Invoice"
                RepName = "SD_SaleInvoice_Print" : RepTitle = "Sale Invoice"
                bTableName = "SaleInvoice_Log" : bSecTableName = "SaleInvoiceDetail_Log  L ON L.UID =H.UID "
                bCondstr = "WHERE H.UID='" & mSearchCode & "'"

                bStructJoin = " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, AgTemplate.ClsMain.Temp_NCat.SaleInvoice, FrmType) & ") As SF On H.UID = SF.UId " & _
                                " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, AgTemplate.ClsMain.Temp_NCat.SaleInvoice, FrmType) & ") As SL On L.UID = SL.UID And L.Sr = Sl.TSr "

            End If

            mQry = " SELECT  H.DocID, H.V_Type + ' - ' +convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.SaleToParty, H.SaleChallan, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " H.EntryBy, H.EntryDate,  " & _
                    " H.SaleToPartyAddress, H.SaleToPartyMobile," & _
                    " H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.UID, " & _
                    " L.SaleChallan, L.Item, L.Specification, L.SalesTaxGroupItem, L.DocQty, L.Qty,SM.Name AS SiteName,H.SaleToPartyName AS SaleToPartyName,C.CityName , " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, " & _
                    " PC.V_Type AS PCV_Type,PC.V_No AS PCV_No,PC.ReferenceNo AS PCVoucherNo,I.Description AS ItemDesc,SF.*, SL.* " & _
                    " FROM " & bTableName & " H " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " " & bStructJoin & " " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.SaleToParty  " & _
                    " LEFT JOIN City C ON C.CityCode =H.SaleToPartyCity  " & _
                    " LEFT JOIN SaleChallan PC ON PC.DocID=L.SaleChallan  " & _
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
        Dgl1.Columns(Col1SaleChallan).Visible = False
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
End Class
