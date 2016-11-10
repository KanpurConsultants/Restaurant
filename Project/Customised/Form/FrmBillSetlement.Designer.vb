<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBillSetlement
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblType = New System.Windows.Forms.Label
        Me.TxtType = New AgControls.AgTextBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtAccount = New AgControls.AgTextBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(564, 39)
        Me.Panel1.TabIndex = 713
        '
        'LblType
        '
        Me.LblType.AutoSize = True
        Me.LblType.BackColor = System.Drawing.Color.Transparent
        Me.LblType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblType.Location = New System.Drawing.Point(99, 60)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(35, 16)
        Me.LblType.TabIndex = 756
        Me.LblType.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.AgAllowUserToEnableMasterHelp = False
        Me.TxtType.AgMandatory = False
        Me.TxtType.AgMasterHelp = False
        Me.TxtType.AgNumberLeftPlaces = 0
        Me.TxtType.AgNumberNegetiveAllow = False
        Me.TxtType.AgNumberRightPlaces = 0
        Me.TxtType.AgPickFromLastValue = False
        Me.TxtType.AgRowFilter = ""
        Me.TxtType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtType.AgSelectedValue = Nothing
        Me.TxtType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtType.Location = New System.Drawing.Point(167, 59)
        Me.TxtType.MaxLength = 255
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(298, 18)
        Me.TxtType.TabIndex = 754
        '
        'BtnOk
        '
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(433, 161)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(55, 23)
        Me.BtnOk.TabIndex = 755
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 758
        Me.Label1.Text = "Account"
        '
        'TxtAccount
        '
        Me.TxtAccount.AgAllowUserToEnableMasterHelp = False
        Me.TxtAccount.AgMandatory = False
        Me.TxtAccount.AgMasterHelp = False
        Me.TxtAccount.AgNumberLeftPlaces = 0
        Me.TxtAccount.AgNumberNegetiveAllow = False
        Me.TxtAccount.AgNumberRightPlaces = 0
        Me.TxtAccount.AgPickFromLastValue = False
        Me.TxtAccount.AgRowFilter = ""
        Me.TxtAccount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAccount.AgSelectedValue = Nothing
        Me.TxtAccount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAccount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAccount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAccount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccount.Location = New System.Drawing.Point(167, 80)
        Me.TxtAccount.MaxLength = 255
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(298, 18)
        Me.TxtAccount.TabIndex = 757
        '
        'BtnCancel
        '
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(495, 161)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(63, 23)
        Me.BtnCancel.TabIndex = 759
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 4)
        Me.GroupBox1.TabIndex = 760
        Me.GroupBox1.TabStop = False
        '
        'FrmBillSetlement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 192)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAccount)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBillSetlement"
        Me.Text = "Table Status Display"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblType As System.Windows.Forms.Label
    Protected WithEvents TxtType As AgControls.AgTextBox
    Protected WithEvents BtnOk As System.Windows.Forms.Button
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtAccount As AgControls.AgTextBox
    Protected WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
