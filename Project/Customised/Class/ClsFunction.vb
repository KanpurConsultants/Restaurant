Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True)
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuSchemeMaster.Name
                    FrmObj = New FrmNCat(StrUserPermission, DTUP)

                Case MDI.MnuPurchaseReturnEntry.Name
                    FrmObj = New FrmPurchaseReturnEntry(StrUserPermission, DTUP)

                Case MDI.MnuPurchaseEntry.Name
                    FrmObj = New FrmPurchaseEntry(StrUserPermission, DTUP)

                Case MDI.MnuSaleWithoutKOTEntry.Name
                    FrmObj = New FrmSaleWithoutKOT(StrUserPermission, DTUP)

                Case MDI.MnuOutletMaster.Name
                    FrmObj = New FrmOutlet(StrUserPermission, DTUP)

                Case MDI.MnuAdjjustBills.Name
                    FrmObj = New FrmAdjustBills()

                Case MDI.MnuConsumptionEntry.Name
                    FrmObj = New FrmConsumptionEntry(StrUserPermission, DTUP)

                Case MDI.MnuRequistionEntry.Name
                    FrmObj = New FrmRequistion(StrUserPermission, DTUP)

                Case MDI.MnuSaleOrderEntry.Name
                    FrmObj = New FrmSaleOrder(StrUserPermission, DTUP)

                Case MDI.MnuEnivrnmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuMenuItemItemMaster.Name
                    FrmObj = New FrmMenuItem(StrUserPermission, DTUP)

                Case MDI.MnuMenuItemCateogryMaster.Name
                    FrmObj = New FrmMenuItemCategory(StrUserPermission, DTUP)

                Case MDI.MnuMenuItemGroupMaster.Name
                    FrmObj = New FrmMenuItemGroup(StrUserPermission, DTUP)

                Case MDI.MnuKOTNatureMaster.Name
                    FrmObj = New FrmKOTNature(StrUserPermission, DTUP)

                Case MDI.MnuKOTEntry.Name
                    FrmObj = New FrmKOT(StrUserPermission, DTUP)
                    CType(FrmObj, FrmKOT).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuTableStatusDisplay.Name
                    FrmObj = New FrmTableStatusDisplay(StrUserPermission, DTUP)

                Case MDI.MnuTableMaster.Name
                    FrmObj = New FrmTableMaster(StrUserPermission, DTUP)

                Case MDI.MnuStewardMaster.Name
                    FrmObj = New FrmSteward(StrUserPermission, DTUP)

                Case MDI.MnuRawMaterialMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)

                Case MDI.MnuRawMaterialGroupItemGroupMaster.Name
                    FrmObj = New FrmItemGroup(StrUserPermission, DTUP)

                Case MDI.MnuRawMaterialCategoryItemCategoryMaster.Name
                    FrmObj = New FrmItemCategory(StrUserPermission, DTUP)

                Case MDI.MnuSaleEntry.Name
                    FrmObj = New FrmSaleInvoice(StrUserPermission, DTUP)

                Case Else
                    FrmObj = Nothing
            End Select
        Else
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)
            CRepProc.GRepFormName = Replace(Replace(StrSenderText, "&", ""), " ", "")
            CRepProc.Ini_Grid()
            FrmObj = ObjRepFormGlobal
        End If
        If FrmObj IsNot Nothing Then
            FrmObj.Text = StrSenderText
        End If
        Return FrmObj
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

