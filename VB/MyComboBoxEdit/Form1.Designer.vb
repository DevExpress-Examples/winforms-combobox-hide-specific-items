Namespace MyComboBoxEdit

    Partial Class FormMain

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.comboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
            Me.indexesCheckedComboBox = New DevExpress.XtraEditors.CheckedComboBoxEdit()
            CType((Me.comboBoxEdit1.Properties), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.indexesCheckedComboBox.Properties), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' comboBoxEdit1
            ' 
            Me.comboBoxEdit1.Location = New System.Drawing.Point(12, 39)
            Me.comboBoxEdit1.Name = "comboBoxEdit1"
            Me.comboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.comboBoxEdit1.Properties.Items.AddRange(New Object() {"item 0", "item 1", "item 2", "item 3", "item 4", "item 5", "item 6", "item 7", "item 8", "item 9", "item 10"})
            Me.comboBoxEdit1.Size = New System.Drawing.Size(221, 20)
            Me.comboBoxEdit1.TabIndex = 0
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Location = New System.Drawing.Point(12, 20)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(93, 13)
            Me.labelControl1.TabIndex = 1
            Me.labelControl1.Text = "Test ComboBoxEdit"
            ' 
            ' labelControl2
            ' 
            Me.labelControl2.Location = New System.Drawing.Point(254, 20)
            Me.labelControl2.Name = "labelControl2"
            Me.labelControl2.Size = New System.Drawing.Size(61, 13)
            Me.labelControl2.TabIndex = 2
            Me.labelControl2.Text = "Hide indexes"
            ' 
            ' indexesCheckedComboBox
            ' 
            Me.indexesCheckedComboBox.Location = New System.Drawing.Point(254, 40)
            Me.indexesCheckedComboBox.Name = "indexesCheckedComboBox"
            Me.indexesCheckedComboBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.indexesCheckedComboBox.Size = New System.Drawing.Size(124, 20)
            Me.indexesCheckedComboBox.TabIndex = 5
            ' 
            ' FormMain
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(411, 92)
            Me.Controls.Add(Me.labelControl2)
            Me.Controls.Add(Me.labelControl1)
            Me.Controls.Add(Me.comboBoxEdit1)
            Me.Controls.Add(Me.indexesCheckedComboBox)
            Me.Name = "FormMain"
            Me.Text = "Main form"
            CType((Me.comboBoxEdit1.Properties), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.indexesCheckedComboBox.Properties), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

#End Region
        Private comboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit

        Private labelControl1 As DevExpress.XtraEditors.LabelControl

        Private labelControl2 As DevExpress.XtraEditors.LabelControl

        Private indexesCheckedComboBox As DevExpress.XtraEditors.CheckedComboBoxEdit
    End Class
End Namespace
