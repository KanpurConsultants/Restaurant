Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmTableStatusDisplay

    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Column1 As String = "Column1"
    Private Const Column2 As String = "Column2"
    Private Const Column3 As String = "Column3"
    Private Const Column4 As String = "Column4"
    Private Const Column5 As String = "Column5"

    ''============< Table Status Constants >==================================
    Public Const mTableStatus_Occupied As String = "Occupied"
    Public Const mTableStatus_Vacant As String = "Vacant"
    ''============< *************** >==================================h

    Dim mTotalFloor As Integer
    Dim mFloorNo As Integer

    Private Enum TableStauts
        Occupied
        PartiallyOccupied
        Vacant
        NonAllocatable
    End Enum

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()

        ''==============================================================================
        ''================< Table Charge Data Grid >====================================
        ''==============================================================================

        DGL1.DefaultCellStyle.SelectionBackColor = Color.Cyan
        DGL1.DefaultCellStyle.SelectionForeColor = Color.Black

        DGL1.BackgroundColor = Color.White
        DGL1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        With AgCL
            .AddAgTextColumn(DGL1, Column1, 70, 62, Column1, True, True)
            .AddAgTextColumn(DGL1, Column2, 70, 62, Column2, True, True)
            .AddAgTextColumn(DGL1, Column3, 70, 62, Column3, True, True)
            .AddAgTextColumn(DGL1, Column4, 70, 62, Column4, True, True)
            .AddAgTextColumn(DGL1, Column5, 70, 62, Column5, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.RowHeadersVisible = False
        DGL1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DGL1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        DGL1.RowTemplate.Height = 70
        DGL1.ColumnHeadersVisible = False
        DGL1.ContextMenuStrip = MnuMain
        DGL1.AllowUserToResizeColumns = False
        DGL1.AllowUserToResizeRows = False
        DGL1.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 650, 880, 0, 0)
            Call IniGrid()
            Call ProcFillTableStatus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Try
            Call ProcFillTableStatus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillTableStatus()
        Dim DtTemp As DataTable
        Dim bColumnIndex As Integer = 0, bRowIndex As Integer = -1, Remainder As Integer = 0

        Dim I As Integer
        Dim bCondStr$ = "", bCondStr1$ = ""
        Try
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            mQry = " Select H.Description From Ht_Table H "

            mQry = " Select T.Code, T.Description, " & _
                    " Case When V1.TableCode Is Not Null Then '" & mTableStatus_Occupied & "' Else '" & mTableStatus_Vacant & "' End As TableStatus " & _
                    " From Ht_Table T " & _
                    " LEFT JOIN " & _
                    "       (Select Distinct H.TableCode From SaleChallan H Where H.SaleInvoice Is Null) As V1 " & _
                    " On T.Code = V1.TableCode  "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Math.DivRem(I, 5, Remainder)
                        If Remainder = 0 Then DGL1.Rows.Add() : bColumnIndex = 0 : bRowIndex += 1
                        DGL1.Item(bColumnIndex, bRowIndex).Value = AgL.XNull(.Rows(I)("Description"))
                        DGL1.Item(bColumnIndex, bRowIndex).Tag = AgL.XNull(.Rows(I)("Code"))
                        DGL1.Item(bColumnIndex, bRowIndex).ToolTipText = AgL.XNull(.Rows(I)("TableStatus"))
                        If AgL.StrCmp(AgL.XNull(.Rows(I)("TableStatus")), mTableStatus_Vacant) Then
                            DGL1.Item(bColumnIndex, bRowIndex).Style.BackColor = TxtVacant.BackColor
                        ElseIf AgL.StrCmp(AgL.XNull(.Rows(I)("TableStatus")), mTableStatus_Occupied) Then
                            DGL1.Item(bColumnIndex, bRowIndex).Style.BackColor = TxtOccupied.BackColor
                        End If
                        bColumnIndex += 1
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MnuProductionOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuKOT.Click, MnuSaleBill.Click
        Dim FrmObj As Form = Nothing
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim MdiObj As New MDIMain
        Try


            Select Case sender.Name
                Case MnuKOT.Name
                    If AgL.StrCmp(DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).ToolTipText, mTableStatus_Occupied) Then
                        MsgBox("Table Is Already Occupied...!", MsgBoxStyle.Information) : Exit Sub
                    End If
                    StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, MdiObj.MnuKOTEntry.Name, MdiObj.MnuKOTEntry.Text, DTUP)
                    FrmObj = New FrmKOT(StrUserPermission, DTUP)
                    CType(FrmObj, FrmKOT).Table = DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).Tag
                    FrmObj.MdiParent = Me.MdiParent
                    FrmObj.Show()

                Case MnuSaleBill.Name
                    If AgL.StrCmp(DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).ToolTipText, mTableStatus_Vacant) Then
                        MsgBox("Table Is Vacant...!", MsgBoxStyle.Information) : Exit Sub
                    End If
                    StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, MdiObj.MnuSaleEntry.Name, MdiObj.MnuSaleEntry.Text, DTUP)
                    FrmObj = New FrmSaleInvoice(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSaleInvoice).Table = DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).Tag
                    FrmObj.MdiParent = Me.MdiParent
                    FrmObj.Show()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class