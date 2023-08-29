Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Popup
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace MyComboBoxEdit

    Friend Class ComboBoxHideItemsHelper
        Implements IDisposable

        Private _comboBox As ComboBoxEdit

        Private _hiddenIndexes As List(Of Integer)

        Public ReadOnly Property Owner As ComboBoxEdit
            Get
                Return _comboBox
            End Get
        End Property

        Public ReadOnly Property HiddenIndexes As List(Of Integer)
            Get
                Return _hiddenIndexes
            End Get
        End Property

        Private _itemMeasure As MeasureItemEventHandler

        Public Sub New(ByVal comboBox As ComboBoxEdit)
            _itemMeasure = Nothing
            _hiddenIndexes = New List(Of Integer)()
            _comboBox = comboBox
            Init()
        End Sub

        Private Sub Init()
            If _comboBox IsNot Nothing Then
                If _itemMeasure Is Nothing Then
                    _itemMeasure = New MeasureItemEventHandler(AddressOf OnMeasureItem)
                    AddHandler _comboBox.Properties.MeasureItem, _itemMeasure
                End If
            End If
        End Sub

        Private Sub OnMeasureItem(ByVal sender As Object, ByVal e As MeasureItemEventArgs)
            If _hiddenIndexes.Contains(e.Index) Then
                e.ItemHeight = 0
                e.ItemWidth = 0
            End If
        End Sub

        Private Sub RefreshPopup()
            Dim popupForm As ComboBoxPopupListBoxForm = _comboBox.GetPopupEditForm()
            If popupForm IsNot Nothing Then
                popupForm.Parent = Nothing
                popupForm.Dispose()
            End If
        End Sub

        Public Function Add(ByVal value As Integer) As Integer
            Dim iResult As Integer = -1
            If _comboBox Is Nothing OrElse _hiddenIndexes.Contains(value) Then Return iResult
            Try
                RefreshPopup()
                _hiddenIndexes.Add(value)
                iResult = _hiddenIndexes.Count - 1
            Catch
            End Try

            Return iResult
        End Function

        Public Sub AddRange(ByVal indexes As Integer())
            If indexes Is Nothing Then Return
            For i As Integer = 0 To indexes.Length - 1
                Add(indexes(i))
            Next
        End Sub

        Public Sub Clear()
            _hiddenIndexes.Clear()
            RefreshPopup()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If _comboBox IsNot Nothing Then
                Try
                    RemoveHandler _comboBox.Properties.MeasureItem, _itemMeasure
                    _comboBox = Nothing
                    _hiddenIndexes.Clear()
                    _hiddenIndexes = Nothing
                Catch
                End Try
            End If
        End Sub
    End Class
End Namespace
