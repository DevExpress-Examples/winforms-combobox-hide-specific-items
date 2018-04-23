Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms





Namespace MyComboBoxEdit
	Partial Public Class FormMain
		Inherits Form
		Private invisibleIndexes As MyInvisibleIndexes

		Public Sub New()
			InitializeComponent()
			invisibleIndexes = New MyInvisibleIndexes(comboBoxEdit1)
		End Sub



		Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
			Dim s_array() As String = textEdit1.Text.Split(","c)
			invisibleIndexes.Clear()

			For i As Integer = 0 To s_array.Length - 1
				Try
					invisibleIndexes.Add(Integer.Parse(s_array(i)))
				Catch
				End Try
			Next i
		End Sub
	End Class
End Namespace