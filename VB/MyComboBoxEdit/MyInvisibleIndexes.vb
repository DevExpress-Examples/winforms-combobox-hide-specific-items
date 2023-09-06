Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraEditors

Namespace MyComboBoxEdit

    Friend Class MyInvisibleIndexes

        Private comboBox As ComboBoxEdit

        Private contentList As List(Of Integer)

        Private itemsChange As CollectionChangeEventHandler

        Private itemMeasure As MeasureItemEventHandler

        Default Public Property Item(ByVal index As Integer) As Integer
            Get
                Return contentList(index)
            End Get

            Set(ByVal value As Integer)
                contentList(index) = value
            End Set
        End Property

        Public Sub New(ByVal comboBox As ComboBoxEdit)
            itemsChange = Nothing
            itemMeasure = Nothing
            contentList = New List(Of Integer)()
            Me.comboBox = comboBox
            Init()
        End Sub

        Protected Overrides Sub Finalize()
            If comboBox IsNot Nothing Then
                Try
                    RemoveHandler comboBox.Properties.MeasureItem, itemMeasure
                    RemoveHandler comboBox.Properties.Items.CollectionChanged, itemsChange
                Catch
                End Try
            End If
        End Sub

        Private Sub Init()
            If comboBox IsNot Nothing Then
                If itemsChange Is Nothing Then
                    itemsChange = New CollectionChangeEventHandler(AddressOf OnItemsChanged)
                    AddHandler comboBox.Properties.Items.CollectionChanged, itemsChange
                End If

                If itemMeasure Is Nothing Then
                    itemMeasure = New MeasureItemEventHandler(AddressOf OnMeasureItem)
                    AddHandler comboBox.Properties.MeasureItem, itemMeasure
                End If
            End If
        End Sub

        Private Sub OnItemsChanged(ByVal sender As Object, ByVal e As CollectionChangeEventArgs)
            Dim combo As ComboBoxEdit = TryCast(sender, ComboBoxEdit)
            If combo Is Nothing Then Return
            Dim countItems As Integer = combo.Properties.Items.Count
            If countItems = 0 Then
                contentList.Clear()
                Return
            End If

            Dim ndx As Integer = 0
            While ndx < contentList.Count
                If contentList(ndx) >= countItems Then
                    contentList.RemoveAt(ndx)
                    Continue While
                End If

                ndx += 1
            End While
        End Sub

        Private Sub OnMeasureItem(ByVal sender As Object, ByVal e As MeasureItemEventArgs)
            If contentList.Contains(e.Index) Then
                e.ItemHeight = 0
                e.ItemWidth = 0
            End If
        End Sub

        Private Sub ClearPopup()
            Dim control As Control = TryCast(comboBox, DevExpress.Utils.Win.IPopupControl).PopupWindow
            If control IsNot Nothing Then
                control.Parent = Nothing
                control.Dispose()
            End If
        End Sub

        Public Function Add(ByVal value As Integer) As Integer
            Dim iResult As Integer = -1
            If comboBox Is Nothing OrElse contentList.Contains(value) Then Return iResult
            Try
                ClearPopup()
                contentList.Add(value)
                iResult = contentList.Count - 1
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
            contentList.Clear()
        End Sub

        Public Function Contains(ByVal value As Integer) As Boolean
            Return contentList.Contains(value)
        End Function

        Public Function IndexOf(ByVal value As Integer) As Integer
            Return contentList.IndexOf(value)
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return contentList.Count
            End Get
        End Property

        Public Sub Remove(ByVal value As Integer)
            contentList.Remove(value)
        End Sub
    End Class
End Namespace
