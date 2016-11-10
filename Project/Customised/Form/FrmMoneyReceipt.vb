Public Class FrmMoneyReceipt

    Inherits TempPayment

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate.ClsMain.Temp_NCat.Receipt
        Me.TransType = TransactionType.Receipt
    End Sub


#Region "Designer Code"
    Private Sub InitializeComponent()
    End Sub
#End Region




    Private Sub FrmMoneyReceipt_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad

    End Sub

    Private Sub FrmMoneyReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 350, 885)
    End Sub
End Class
