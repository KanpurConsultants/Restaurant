Imports System.Data.SqlClient
Public Class FrmAdjustBills
    Dim mQry As String = ""

    Public Const Col_SNo As String = "S.No"
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Public Const Col1Select As String = "Select"
    Public Const Col1SaleInvoiceNo As String = "Sale Invoice No"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Member Data Grid >====================================
        ''==============================================================================

        With AgCL
            .AddAgTextColumn(DGL1, Col_SNo, 65, 5, Col_SNo, True, True, False)
            .AddAgCheckColumn(DGL1, Col1Select, 70, Col1Select, True)
            .AddAgTextColumn(DGL1, Col1SaleInvoiceNo, 120, 20, Col1SaleInvoiceNo, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
        DGL1.AllowUserToAddRows = False
        DGL1.EnableHeadersVisualStyles = False
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.MultiSelect = True
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
            If e.KeyCode = Keys.Escape Then Me.Close()
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.GridDesign(DGL1)
            IniGrid()
            Ini_List()
            DispText()
            TxtFromDate.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try
            mQry = " Select H.DocId As Code, H.ReferenceNO As InvoiceNO From SaleInvoice H "
            DGL1.AgHelpDataSet(Col1SaleInvoiceNo) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BlankText()
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnCancel.Click
        Try
            Select Case sender.Name
                Case BtnOk.Name
                    FDeteteInvoice()
                    MsgBox("Operation Performed Successfully", MsgBoxStyle.Information)

                Case BtnCancel.Name
                    Me.Close()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer
        ' Dim I As Interaction
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcFillInvoice()
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0

        mQry = " Select H.DocId From SaleInvoice H Where H.V_Date Between '" & TxtFromDate.Text & "' And '" & TxtToDate.Text & "'"
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

        With DtTemp
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To .Rows.Count - 1
                    DGL1.Rows.Add()
                    DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                    DGL1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                    DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) = AgL.XNull(DtTemp.Rows(I)("DocId"))
                Next
            End If
        End With
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        ProcFillInvoice()
    End Sub

    Private Sub FDeteteInvoice()
        Dim I As Integer = 0
        Dim mTrans As Boolean = False
        Try
            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If AgL.StrCmp(.Item(Col1Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        mQry = "Delete From Ledger Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From Structure_Transline_Log Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From Structure_Transline Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From Structure_TransFooter_Log Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From Structure_TransFooter Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleInvoiceDetail_Log Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleInvoice_Log Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleInvoiceDetail Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleInvoice Where DocId = '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleChallanDetail_Log Where DocId In (Select SaleChallan From SaleInvoiceDetail Where DocId =  '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "') "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleChallanDetail Where DocId In (Select SaleChallan From SaleInvoiceDetail Where DocId =  '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "') "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleChallan_Log Where DocId In (Select SaleChallan From SaleInvoiceDetail Where DocId =  '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "') "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Delete From SaleChallan Where DocId In (Select SaleChallan From SaleInvoiceDetail Where DocId =  '" & DGL1.AgSelectedValue(Col1SaleInvoiceNo, I) & "') "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With
            AgL.ETrans.Commit()
            mTrans = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex
            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    Try
                        Call AgL.ProcSetCheckColumnCellValue(sender, DGL1.CurrentCell.ColumnIndex)
                    Catch ex As Exception
                    End Try
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        Dim mRowIndex As Integer = 0, mColumnIndex As Integer = 0
        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    If e.KeyCode = Keys.Space Then
                        Try
                            Call AgL.ProcSetCheckColumnCellValue(sender, DGL1.CurrentCell.ColumnIndex)
                        Catch ex As Exception
                        End Try
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class