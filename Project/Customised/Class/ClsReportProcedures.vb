Public Class ClsReportProcedures

#Region "Danger Zone"
    Dim StrArr1() As String = Nothing, StrArr2() As String = Nothing, StrArr3() As String = Nothing, StrArr4() As String = Nothing, StrArr5() As String = Nothing

    Dim mGRepFormName As String = ""
    Dim WithEvents ObjRFG As AgLibrary.RepFormGlobal

    Public Property GRepFormName() As String
        Get
            GRepFormName = mGRepFormName
        End Get
        Set(ByVal value As String)
            mGRepFormName = value
        End Set
    End Property

#End Region

#Region "Common Reports Constant"
    Private Const CityList As String = "CityList"
    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
#End Region

#Region "Reports Constant"
    Private Const SaleReport As String = "SaleReport"
    Private Const ItemWiseSaleReport As String = "ItemWiseSaleReport"
    Private Const KOTReport As String = "KOTReport"
    Private Const SaleOrderReport As String = "SaleOrderReport"
    Private Const PurchaseReport As String = "PurchaseReport"
    Private Const PurchaseReturnReport As String = "PurchaseReturnReport"
    Private Const CashierSummary As String = "CashierSummary"
    Private Const TaxSummary As String = "TaxSummary"
#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpItemQry$ = "Select Convert(BIT,0) As [Select],Code, Description As [Item] From Item "
    Dim mHelpVendorQry$ = " Select Convert(BIT,0) As [Select], H.SubCode As Code, Sg.DispName AS Vendor FROM Vendor H LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode "
    Dim mHelpTableQry$ = "Select Convert(BIT,0) As [Select],H.Code, H.Description AS [Table] FROM HT_Table H "
    Dim mHelpPaymentModeQry$ = "Select Convert(BIT,0) As [Select],'" & ClsMain.PaymentMode.Cash & "' As Code, '" & ClsMain.PaymentMode.Cash & "' As Description " & _
                                " UNION ALL " & _
                                " Select Convert(BIT,0) As [Select],'" & ClsMain.PaymentMode.Credit & "' As Code, '" & ClsMain.PaymentMode.Credit & "' As Description "
    Dim mHelpOutletQry$ = "Select Convert(BIT,0) As [Select],H.Code, H.Description AS [Table] FROM Outlet H "
    Dim mHelpStewardQry$ = "Select Convert(BIT,0) As [Select], Sg.SubCode AS Code, Sg.DispName AS Steward FROM SubGroup Sg  "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case KOTReport
                    StrArr2 = New String() {"Summary", "Detail"}
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpStewardQry, "Steward")
                    ObjRFG.CreateHelpGrid(mHelpTableQry, "Table")
                    ObjRFG.CreateHelpGrid(mHelpOutletQry, "Outlet")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case SaleReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpTableQry, "Table")
                    ObjRFG.CreateHelpGrid(mHelpPaymentModeQry, "Payment Mode")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case ItemWiseSaleReport
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpOutletQry, "Outlet")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case CashierSummary
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case TaxSummary
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case SaleOrderReport
                    StrArr2 = New String() {"Summary", "Detail"}
                    ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

                Case PurchaseReport, PurchaseReturnReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case SaleReport
                ProcSaleReport()

            Case ItemWiseSaleReport
                ProcItemWiseSaleReport()

            Case KOTReport
                ProcKOTRegister()

            Case PurchaseReport
                ProcPurchaseInvoiceReport("Purchase Invoice", "Item ", AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice)

            Case PurchaseReturnReport
                ProcPurchaseInvoiceReport("Purchase Return", "Item ", ClsMain.Temp_NCat.PurchaseReturn)

            Case SaleOrderReport
                ProcSaleOrderReport("Sale Order Report", AgTemplate.ClsMain.Temp_NCat.SaleOrder)

            Case CashierSummary
                ProcCashierSummary()

            Case TaxSummary
                ProcTaxSummary()
        End Select
    End Sub

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

#Region "Kot Register"
    Private Sub ProcKOTRegister()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_KOTReport" : RepTitle = "K.O.T. Report"


            Dim mCondStr$ = ""
            mCondStr = " Where 1=1 "
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Steward", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.TableCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Outlet", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 4)


            mQry = " SELECT H.DocID , H.V_Type      , H.V_Prefix      , H.V_Date      , H.V_No      , H.Div_Code      , H.Site_Code      , H.ReferenceNo " & _
                        " , H.Godown      , H.Vendor      , H.SaleToParty      , H.SaleToPartyName      , H.SaleToPartyAddress      , H.SaleToPartyCity " & _
                        " , H.SaleToPartyMobile      , H.ShipToParty " & _
                        " , H.ShipToPartyName      , H.ShipToPartyAddress      , H.ShipToPartyCity      , H.ShipToPartyMobile " & _
                        " , H.SaleOrder      , H.Currency      , H.SalesTaxGroupParty      , H.Structure " & _
                        " , H.BillingType      , H.Form      , H.FormNo      , H.Transporter      , H.Vehicle      , H.VehicleDescription " & _
                        " , H.Driver      , H.DriverName      , H.DriverContactNo      , H.LrNo      , H.LrDate      , H.PrivateMark " & _
                        " , H.PortOfLoading      , H.DestinationPort      , H.FinalPlaceOfDelivery      , H.PreCarriageBy " & _
                        " , H.PlaceOfPreCarriage      , H.ShipmentThrough      , H.Remarks " & _
                        " , H.TotalQty      , H.TotalMeasure      , H.TotalAmount      , H.EntryBy      , H.EntryDate      , H.EntryType " & _
                        " , H.EntryStatus      , H.ApproveBy      , H.ApproveDate      , H.MoveToLog      , H.MoveToLogDate      , H.IsDeleted " & _
                        " , H.Status      , H.UID      , " & _
                        " L.DocId, L.Sr, L.SaleOrder " & _
                        " , L. Item       , L. Specification       , L. SalesTaxGroupItem       , L. DocQty       , L. Qty       , L. Unit  " & _
                        " , L. MeasurePerPcs       , L. MeasureUnit       , L. TotalDocMeasure       , L. TotalMeasure  " & _
                        " , L. Rate       , L. Amount       , L. LotNo       , L. UID       " & _
                        " , Sg.DispName As DistributerName, Sg.ManualCode As DistributerManualCode, " & _
                        " Sm.Name As SiteName, Sg1.DispName As StewardName, Kn.Description As KotNatureDesc, " & _
                        " I.Description As ItemDesc, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                        " O.Description As OutletDesc    " & _
                        " FROM SaleChallan H " & _
                        " LEFT JOIN SaleChallanDetail L On H.DocID = L.DocId " & _
                        " LEFT JOIN SubGroup Sg On H.SaleToParty = Sg.SubCode " & _
                        " LEFT JOIN SubGroup Sg1 On H.Steward = Sg1.SubCode " & _
                        " LEFT JOIN SiteMast Sm On H.Site_Code = Sm.Code " & _
                        " LEFT JOIN KOTNature Kn On H.KOTNature = Kn.Code " & _
                        " LEFT JOIN Item I On L.Item = I.Code " & _
                        " LEFT JOIN Outlet O On L.Outlet = O.Code " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Report"
    Private Sub ProcSaleReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_SaleReport" : RepTitle = "Sale Report"


            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.TableCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.PaymentMode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.SaleToParty, " & _
                        " H.SaleToPartyName, H.SaleToPartyAddress, H.SaleToPartyCity, H.SaleToPartyMobile, H.ShipToParty, H.ShipToPartyName,  " & _
                        " H.ShipToPartyAddress, H.ShipToPartyCity, H.ShipToPartyMobile, H.SaleOrder, H.SaleChallan, H.Currency,  " & _
                        " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.ReferenceDocId, H.Remarks, H.TotalQty,  " & _
                        " H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate,  " & _
                        " H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.TableCode, H.PaymentMode, H.PostingAc, H.Godown, H.Vendor,  " & _
                        " H.SaleToPartyTinNo, H.SaleToPartyCstNo, H.Transporter, H.Vehicle, H.VehicleDescription, H.Driver, H.DriverName,  " & _
                        " H.DriverContactNo, H.LrNo, H.LrDate, H.PrivateMark, H.PortOfLoading, H.DestinationPort, H.FinalPlaceOfDelivery,  " & _
                        " H.PreCarriageBy, H.PlaceOfPreCarriage, H.ShipmentThrough, H.CreditDays,  " & _
                        " H.Gross_Amount, H.Discount_Pre_Tax_Per, H.Discount_Pre_Tax, H.Other_Additions_Pre_Tax_Per, H.Other_Additions_Pre_Tax,  " & _
                        " H.Sales_Tax_Taxable_Amt, H.Vat_Per, H.Vat, H.Sat_Per, H.Sat, H.Discount_Per, H.Discount, H.Other_Charges_Per,  " & _
                        " H.Other_Charges, H.Round_Off, H.Net_Amount, H.Landed_Value, T.Description AS TableDesc " & _
                        " FROM SaleInvoice H  " & _
                        " LEFT JOIN HT_Table T ON H.TableCode = T.Code " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Invoice Report"
    Private Sub ProcPurchaseInvoiceReport(ByVal ReportTitle As String, ByVal bItemTitle As String, ByVal bNCat As String)
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            bTableName = "PurchInvoice" : bSecTableName = "PurchInvoiceDetail L ON L.DocID =H.DocID"
            RepName = "Ht_PurchInvoiceReport" : RepTitle = "" & bItemTitle & ReportTitle

            Dim mCondStr$ = ""
            mCondStr = " where 1=1 "
            mCondStr = mCondStr & " AND Vt.NCat =" & AgL.Chk_Text(bNCat) & ""
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mOrderBy = "ORDER BY H.V_Date"

            If ObjRFG.GetWhereCondition("H.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)


            mQry = " SELECT  H.DocID, H.V_Type + ' - ' +convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.PurchChallan, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " H.EntryBy, H.EntryDate,  " & _
                    " H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.UID, " & _
                    " L.PurchChallan, L.Item, L.SalesTaxGroupItem, L.DocQty, L.Qty,SM.Name AS SiteName,SG.DispName AS VenderName,SG.DispName AS VendorDispName,C.CityName , " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, " & _
                    " PC.V_Type AS PCV_Type,PC.V_No AS PCV_No,PC.ReferenceNo AS PCVoucherNo,I.Description AS ItemDesc,SF.*, SL.* , " & _
                    " " & IIf(AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Modify Date"), "H.EntryDate", "H.V_No") & " AS SortOn," & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType , '" & bItemTitle & "' AS ItemTitle " & _
                    " FROM " & bTableName & " H " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, bNCat) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, bNCat) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN PurchChallan PC ON PC.DocID=L.PurchChallan  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Order Report"
    Private Sub ProcSaleOrderReport(ByVal ReportTitle As String, ByVal NCat As String)
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_SaleOrderReport" : RepTitle = ReportTitle

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & NCat & "' "

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)


            mQry = " SELECT H.DocID      , H.V_Type      , H.V_Prefix      , H.V_Date      , H.V_No      , H.Div_Code      , H.Site_Code      , H.SaleToParty " & _
                    " , H.SaleToPartyName      , H.SaleToPartyAdd1      , H.SaleToPartyAdd2      , H.SaleToPartyCity      , H.SaleToPartyCityName " & _
                    " , H.SaleToPartyState      , H.SaleToPartyCountry      , H.ShipToParty      , H.ShipToPartyName      , H.ShipToPartyAdd1 " & _
                    " , H.ShipToPartyAdd2      , H.ShipToPartyCity      , H.ShipToPartyCityName      , H.ShipToPartyState " & _
                    " , H.ShipToPartyCountry      , H.Currency      , H.SalesTaxGroupParty      , H.Structure      , H.BillingType      , H.PartyOrderNo " & _
                    " , H.PartyOrderDate      , H.PartyDeliveryDate      , H.PartyOrderCancelDate      , H.DestinationPort      , H.FinalPlaceOfDelivery " & _
                    " , H.TermsAndConditions      , H.Remarks      , H.TotalQty      , H.TotalMeasure      , H.StockTotalMeasure      , H.TotalAmount " & _
                    " , H.EntryBy     , H.EntryDate      , H.EntryType      , H.EntryStatus      , H.ApproveBy      , H.ApproveDate      , H.MoveToLog " & _
                    " , H.MoveToLogDate      , H.IsDeleted      , H.Status      , H.UID      , H.PreCarriageBy      , H.PlaceOfReceipt      , H.ShipmentThrough " & _
                    " , H.BankAcNoBuyer      , H.BankNameBuyer      , H.BankAddressBuyer      , H.PriceMode      , H.Agent      , H.ManualRefNo " & _
                    " , H.SaleToPartyMobile      , H.IsDoorDelivery      , H.IsHomeDelivery      , H.PartyDeliveryTime, " & _
                    "             L.DocId, L.Sr, L.Item, L.PartySKU, L.PartyUPC, L.SalesTaxGroupItem " & _
                    " , L.Qty      , L.Unit      , L.MeasurePerPcs      , L.MeasureUnit      , L.TotalMeasure      , L.StockMeasurePerPcs " & _
                    " , L.StockTotalMeasure      , L.Rate      , L.Amount      , L.ShippedQty      , L.ShippedMeasure " & _
                    " , L.ProdOrdQty      , L.ProdOrdMeasure      , L.ProdPlanQty      , L.ProdPlanMeasure      , L.PurchQty " & _
                    " , L.PurchMeasure      , L.ProdIssQty      , L.ProdIssMeasure      , L.ProdRecQty      , L.ProdRecMeasure " & _
                    " , L.UID      , L.Vendor      , L.Specification      , L.Priority      , L.DeliveryOrderQty      ,  " & _
                    " L.DeliveryOrderMeasure      , L.outlet, I.Description As ItemDesc, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, SF.*, SL.*    " & _
                    " FROM SaleOrder H  " & _
                    " LEFT JOIN SaleOrderDetail L On H.DocID = L.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, AgTemplate.ClsMain.Temp_NCat.SaleOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, AgTemplate.ClsMain.Temp_NCat.SaleOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I On L.Item = I.Code "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Sale Invoice Report"
    Private Sub ProcItemWiseSaleReport()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_ItemWiseSaleReport" : RepTitle = "Item Wise Sale Report"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Outlet", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)


            mQry = " SELECT L.DocId, L.Sr, L.SaleOrder, L.SaleOrderSr, L.SaleChallan, L.SaleChallanSr, L.Item, I.ManualCode AS ItemManualCode, L.SalesTaxGroupItem, L.DocQty, " & _
                        " L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.ReferenceDocId,  " & _
                        " L.LotNo, L.UID, L.Specification, L.Outlet, L.Gross_Amount, L.Discount_Pre_Tax_Per, L.Discount_Pre_Tax,  " & _
                        " L.Other_Additions_Pre_Tax_Per, L.Other_Additions_Pre_Tax, L.Sales_Tax_Taxable_Amt, L.Vat_Per, L.Vat, L.Sat_Per, L.Sat,  " & _
                        " L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges, L.Round_Off, L.Net_Amount, L.Landed_Value, " & _
                        " I.Description AS ItemDesc, O.Description AS OutletDesc " & _
                        " FROM SaleInvoiceDetail L " & _
                        " LEFT JOIN SaleInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN OutLet O ON L.Outlet = O.Code " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Cashier Summary"
    Private Sub ProcCashierSummary()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_CashierSummary" : RepTitle = "Cashier Summary"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)


            mQry = " SELECT H.V_Date, H.ReferenceNo AS BillNo, H.Net_Amount, H.Remarks, " & _
                        " CASE WHEN H.PaymentMode = 'Cash' THEN H.Net_Amount ELSE 0 END AS Cash, " & _
                        " CASE WHEN H.PaymentMode = 'Cheque' THEN H.Net_Amount ELSE 0 END AS Cheque, " & _
                        " CASE WHEN H.PaymentMode = 'Complementary' THEN H.Net_Amount ELSE 0 END AS Complementary, " & _
                        " CASE WHEN H.PaymentMode = 'Credit Card' THEN H.Net_Amount ELSE 0 END AS CreditCard, " & _
                        " H.EntryBy " & _
                        " FROM SaleInvoice H  " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Tax Summary"
    Private Sub ProcTaxSummary()
        Try
            Call ObjRFG.FillGridString()

            RepName = "Ht_TaxSummary" : RepTitle = "Tax Summary"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1"

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)

            mQry = " SELECT H.V_Date, Sum(H.Net_Amount) AS NetAmt, Sum(H.Vat) AS VatAmt, Sum(H.Sat) AS SatAmt " & _
                    " FROM SaleInvoice H " & mCondStr & _
                    " GROUP BY H.V_Date   "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
End Class
