Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmBillSetlement
    Dim mQry$ = ""

    Private Sub IniList()
        Try
            mQry = " Select 'Cash' As Code, 'Cash' As Type " & _
                    " UNION ALL " & _
                    " Select 'Credit' As Code, 'Credit' As Type " & _
                    " UNION ALL " & _
                    " Select 'Bill To Company' As Code, 'Bill To Company' As Type "
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class