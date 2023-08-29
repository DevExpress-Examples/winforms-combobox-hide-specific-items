Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace MyComboBoxEdit

    Public Partial Class FormMain
        Inherits Form

        Private _comboBoxHideItemsHelper As ComboBoxHideItemsHelper

        Public Sub New()
            InitializeComponent()
            AddHandler indexesCheckedComboBox.EditValueChanged, AddressOf indexesCheckedComboBox_EditValueChanged
            indexesCheckedComboBox.Properties.EditValueType = DevExpress.XtraEditors.Repository.EditValueTypeCollection.List
            _comboBoxHideItemsHelper = New ComboBoxHideItemsHelper(comboBoxEdit1)
            PopulateIndexes()
        End Sub

        Private Sub PopulateIndexes()
            For i As Integer = 0 To comboBoxEdit1.Properties.Items.Count - 1
                indexesCheckedComboBox.Properties.Items.Add(i, comboBoxEdit1.Properties.Items(i).ToString(), If(i < 2, CheckState.Checked, CheckState.Unchecked), True)
            Next
        End Sub

        Private Sub indexesCheckedComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            _comboBoxHideItemsHelper.Clear()
            Dim checkedItems = TryCast(indexesCheckedComboBox.Properties.GetCheckedItems(), List(Of Object))
            For Each item In checkedItems
                _comboBoxHideItemsHelper.Add(CInt(item))
            Next

            Return
        End Sub

        Protected Overrides Sub OnHandleDestroyed(ByVal e As EventArgs)
            MyBase.OnHandleDestroyed(e)
            _comboBoxHideItemsHelper.Dispose()
            RemoveHandler indexesCheckedComboBox.EditValueChanged, AddressOf indexesCheckedComboBox_EditValueChanged
        End Sub
    End Class
End Namespace
