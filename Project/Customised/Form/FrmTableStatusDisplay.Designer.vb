<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTableStatusDisplay
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnRefresh = New System.Windows.Forms.LinkLabel
        Me.LblSelectedTable = New System.Windows.Forms.Label
        Me.TxtSelectedTable = New AgControls.AgTextBox
        Me.LblVacant = New System.Windows.Forms.Label
        Me.TxtVacant = New AgControls.AgTextBox
        Me.LblOccupied = New System.Windows.Forms.Label
        Me.TxtOccupied = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.MnuMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MnuKOT = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleBill = New System.Windows.Forms.ToolStripMenuItem
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnRefresh)
        Me.Panel1.Controls.Add(Me.LblSelectedTable)
        Me.Panel1.Controls.Add(Me.TxtSelectedTable)
        Me.Panel1.Controls.Add(Me.LblVacant)
        Me.Panel1.Controls.Add(Me.TxtVacant)
        Me.Panel1.Controls.Add(Me.LblOccupied)
        Me.Panel1.Controls.Add(Me.TxtOccupied)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(804, 39)
        Me.Panel1.TabIndex = 713
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRefresh.AutoSize = True
        Me.BtnRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.LinkColor = System.Drawing.Color.SteelBlue
        Me.BtnRefresh.Location = New System.Drawing.Point(734, 12)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(57, 13)
        Me.BtnRefresh.TabIndex = 722
        Me.BtnRefresh.TabStop = True
        Me.BtnRefresh.Text = "Refresh"
        '
        'LblSelectedTable
        '
        Me.LblSelectedTable.AutoSize = True
        Me.LblSelectedTable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectedTable.ForeColor = System.Drawing.Color.Blue
        Me.LblSelectedTable.Location = New System.Drawing.Point(299, 12)
        Me.LblSelectedTable.Name = "LblSelectedTable"
        Me.LblSelectedTable.Size = New System.Drawing.Size(111, 13)
        Me.LblSelectedTable.TabIndex = 721
        Me.LblSelectedTable.Text = ": Selected Table"
        '
        'TxtSelectedTable
        '
        Me.TxtSelectedTable.AgAllowUserToEnableMasterHelp = False
        Me.TxtSelectedTable.AgMandatory = True
        Me.TxtSelectedTable.AgMasterHelp = False
        Me.TxtSelectedTable.AgNumberLeftPlaces = 0
        Me.TxtSelectedTable.AgNumberNegetiveAllow = False
        Me.TxtSelectedTable.AgNumberRightPlaces = 0
        Me.TxtSelectedTable.AgPickFromLastValue = False
        Me.TxtSelectedTable.AgRowFilter = ""
        Me.TxtSelectedTable.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectedTable.AgSelectedValue = Nothing
        Me.TxtSelectedTable.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectedTable.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSelectedTable.BackColor = System.Drawing.Color.Cyan
        Me.TxtSelectedTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSelectedTable.Enabled = False
        Me.TxtSelectedTable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedTable.Location = New System.Drawing.Point(262, 4)
        Me.TxtSelectedTable.MaxLength = 50
        Me.TxtSelectedTable.Multiline = True
        Me.TxtSelectedTable.Name = "TxtSelectedTable"
        Me.TxtSelectedTable.ReadOnly = True
        Me.TxtSelectedTable.Size = New System.Drawing.Size(30, 29)
        Me.TxtSelectedTable.TabIndex = 720
        '
        'LblVacant
        '
        Me.LblVacant.AutoSize = True
        Me.LblVacant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVacant.ForeColor = System.Drawing.Color.Blue
        Me.LblVacant.Location = New System.Drawing.Point(181, 12)
        Me.LblVacant.Name = "LblVacant"
        Me.LblVacant.Size = New System.Drawing.Size(59, 13)
        Me.LblVacant.TabIndex = 718
        Me.LblVacant.Text = ": Vacant"
        '
        'TxtVacant
        '
        Me.TxtVacant.AgAllowUserToEnableMasterHelp = False
        Me.TxtVacant.AgMandatory = False
        Me.TxtVacant.AgMasterHelp = False
        Me.TxtVacant.AgNumberLeftPlaces = 0
        Me.TxtVacant.AgNumberNegetiveAllow = False
        Me.TxtVacant.AgNumberRightPlaces = 0
        Me.TxtVacant.AgPickFromLastValue = False
        Me.TxtVacant.AgRowFilter = ""
        Me.TxtVacant.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVacant.AgSelectedValue = Nothing
        Me.TxtVacant.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVacant.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVacant.BackColor = System.Drawing.Color.LightGreen
        Me.TxtVacant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVacant.Enabled = False
        Me.TxtVacant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVacant.Location = New System.Drawing.Point(145, 4)
        Me.TxtVacant.MaxLength = 50
        Me.TxtVacant.Multiline = True
        Me.TxtVacant.Name = "TxtVacant"
        Me.TxtVacant.ReadOnly = True
        Me.TxtVacant.Size = New System.Drawing.Size(30, 29)
        Me.TxtVacant.TabIndex = 9
        '
        'LblOccupied
        '
        Me.LblOccupied.AutoSize = True
        Me.LblOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOccupied.ForeColor = System.Drawing.Color.Blue
        Me.LblOccupied.Location = New System.Drawing.Point(43, 12)
        Me.LblOccupied.Name = "LblOccupied"
        Me.LblOccupied.Size = New System.Drawing.Size(74, 13)
        Me.LblOccupied.TabIndex = 716
        Me.LblOccupied.Text = ": Occupied"
        '
        'TxtOccupied
        '
        Me.TxtOccupied.AgAllowUserToEnableMasterHelp = False
        Me.TxtOccupied.AgMandatory = False
        Me.TxtOccupied.AgMasterHelp = False
        Me.TxtOccupied.AgNumberLeftPlaces = 0
        Me.TxtOccupied.AgNumberNegetiveAllow = False
        Me.TxtOccupied.AgNumberRightPlaces = 0
        Me.TxtOccupied.AgPickFromLastValue = False
        Me.TxtOccupied.AgRowFilter = ""
        Me.TxtOccupied.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOccupied.AgSelectedValue = Nothing
        Me.TxtOccupied.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOccupied.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOccupied.BackColor = System.Drawing.Color.Red
        Me.TxtOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOccupied.Enabled = False
        Me.TxtOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOccupied.Location = New System.Drawing.Point(8, 4)
        Me.TxtOccupied.MaxLength = 50
        Me.TxtOccupied.Multiline = True
        Me.TxtOccupied.Name = "TxtOccupied"
        Me.TxtOccupied.ReadOnly = True
        Me.TxtOccupied.Size = New System.Drawing.Size(30, 29)
        Me.TxtOccupied.TabIndex = 7
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 313)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(804, 20)
        Me.LinkLabel1.TabIndex = 742
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Right Click On The Table To Perform Further Operation"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuKOT, Me.MnuSaleBill})
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(121, 48)
        '
        'MnuKOT
        '
        Me.MnuKOT.Name = "MnuKOT"
        Me.MnuKOT.Size = New System.Drawing.Size(120, 22)
        Me.MnuKOT.Text = "K.O.T."
        '
        'MnuSaleBill
        '
        Me.MnuSaleBill.Name = "MnuSaleBill"
        Me.MnuSaleBill.Size = New System.Drawing.Size(120, 22)
        Me.MnuSaleBill.Text = "Sale Bill"
        '
        'Pnl1
        '
        Me.Pnl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl1.Location = New System.Drawing.Point(0, 39)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(804, 274)
        Me.Pnl1.TabIndex = 743
        '
        'FrmTableStatusDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 333)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTableStatusDisplay"
        Me.Text = "Table Status Display"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MnuMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtOccupied As AgControls.AgTextBox
    Friend WithEvents TxtVacant As AgControls.AgTextBox
    Friend WithEvents TxtSelectedTable As AgControls.AgTextBox
    Friend WithEvents LblSelectedTable As System.Windows.Forms.Label
    Friend WithEvents LblVacant As System.Windows.Forms.Label
    Friend WithEvents LblOccupied As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents MnuMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MnuSaleBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuKOT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BtnRefresh As System.Windows.Forms.LinkLabel
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
End Class
