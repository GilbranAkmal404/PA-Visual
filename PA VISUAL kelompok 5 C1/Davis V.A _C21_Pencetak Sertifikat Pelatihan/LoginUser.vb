Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class LoginUser
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        LoginUserorAdmin.Show()
        Me.Hide()
    End Sub

    Sub Clear()
        txtNIM.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        If txtNIM.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Data Belum Lengkap")
            txtPassword.Focus()
            Exit Sub
        Else
            Call koneksi()
            CMD = New MySqlCommand("SELECT * FROM tbakunmahasiswa WHERE nim='" & txtNIM.Text & "'", CONN)
            RD = CMD.ExecuteReader()

            If RD.HasRows Then
                RD.Close()
                MsgBox("NIM sudah terdaftar!", MsgBoxStyle.Information, "Pemberitahuan!")
            Else
                RD.Close()
                Dim Simpan As String = "INSERT INTO tbakunmahasiswa(nim, password) VALUES ('" & txtNIM.Text & "','" & txtPassword.Text & "')"
                CMD = New MySqlCommand(Simpan, CONN)
                CMD.ExecuteNonQuery()
                MsgBox("Berhasil Register!", MsgBoxStyle.Information, "Pemberitahuan!")
                Call Clear()
                txtNIM.Focus()
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtNIM.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Data Belum Lengkap")
            txtNIM.Focus()
            Exit Sub
        Else
            Call koneksi()
            CMD = New MySqlCommand("SELECT * FROM tbakunmahasiswa WHERE nim = '" & txtNIM.Text & "' AND password = '" & txtPassword.Text & "'", CONN)
            RD = CMD.ExecuteReader()
            RD.Read()

            If RD.HasRows Then
                Me.Visible = False
                FormMahasiswa.Show()
                FormMahasiswa.ToolStripStatusLabel1.Text = RD.GetString(0)
            Else
                RD.Close()
                MessageBox.Show("Periksa kembali NIM dan Password Anda!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtNIM.Focus()
                txtNIM.Text = ""
                txtPassword.Text = ""
            End If
        End If
    End Sub

    Private Sub LoginUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
