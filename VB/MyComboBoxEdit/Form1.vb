Imports System
Imports System.Windows.Forms

Namespace MyComboBoxEdit

    Public Partial Class FormMain
        Inherits Form

        Private invisibleIndexes As MyInvisibleIndexes

        Public Sub New()
            InitializeComponent()
            invisibleIndexes = New MyInvisibleIndexes(comboBoxEdit1)
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim s_array As String() = textEdit1.Text.Split(","c)
            invisibleIndexes.Clear()
            For i As Integer = 0 To s_array.Length - 1
                Try
                    invisibleIndexes.Add(Integer.Parse(s_array(i)))
                Catch
                End Try
            Next
        End Sub
    End Class
End Namespace
