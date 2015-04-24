Imports System.IO

Public Class frmSearchi
    Dim searchFor As String = ""
    Dim errorsString As String = ""

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        cmdStart.Enabled = False

        errorsString = ""
        searchFor = txtName.Text
        dirSearch(txtPath.Text)

        cmdStart.Enabled = True

        MessageBox.Show("DONE", "FIN", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If errorsString <> "" Then
            MessageBox.Show(errorsString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub dirSearch(ByVal sDir As String)
        Dim d As String
        Dim f As String

        Try
            For Each d In Directory.GetDirectories(sDir)
                For Each f In Directory.GetFiles(d, searchFor)
                    txtFound.AppendText(f & vbCrLf)
                Next
                DirSearch(d)
            Next
        Catch ex As System.Exception
            errorsString &= ex.Message & "'" & sDir & "'" & vbCrLf
        End Try
    End Sub
End Class
