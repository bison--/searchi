Imports System.IO

Public Class frmSearchi

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        cmdStart.Enabled = False

        dirSearch(txtPath.Text)

        cmdStart.Enabled = True
        MessageBox.Show("DONE")
    End Sub

    Sub dirSearch(ByVal sDir As String)
        Dim d As String
        Dim f As String

        Try
            For Each d In Directory.GetDirectories(sDir)
                For Each f In Directory.GetFiles(d, txtName.Text)
                    txtFound.AppendText(f & vbCrLf)
                Next
                DirSearch(d)
            Next
        Catch excpt As System.Exception
            Debug.WriteLine(excpt.Message)
        End Try
    End Sub
End Class
