Public Class LoginAdmin
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        LoginUserorAdmin.Show()
        Me.Hide()
    End Sub
End Class