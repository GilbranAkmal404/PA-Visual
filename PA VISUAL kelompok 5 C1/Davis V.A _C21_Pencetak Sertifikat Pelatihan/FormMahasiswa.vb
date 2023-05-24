Imports MySql.Data.MySqlClient
Public Class FormMahasiswa

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        LoginUserorAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click

    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnLihat_Click(sender As Object, e As EventArgs) Handles btnLihat.Click

    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If txtNim.Text = "" Or txtNama.Text = "" Or txtTempat.Text = "" Or txtProdi.Text = "" Then
            MsgBox("Data Belum Lengkap")
            txtNim.Focus()
            Exit Sub
        Else
            CMD = New MySqlCommand("Select * From tbmahasiswa where nim='" & txtNim.Text & "'", CONN)
            RD.Close()
            RD = CMD.ExecuteReader
            RD.Read()


            If Not RD.HasRows Then
                Dim Simpan As String = "insert into tbmahasiswa(nim,nama,prodi,jenis_kelamin,tempat,tanggal_lahir,tanggal_kelulusan)values ('" & txtNim.Text & "','" & txtNama.Text & "','" & txtProdi.Text & "','" & txtJenisKelamin.Text & "','" & txtTempat.Text & "','" & txtTanggalLahir.Text & "','" & txtTanggalKelulusan.Text & "')"
                CMD = New MySqlCommand(Simpan, CONN)
                RD.Close()
                CMD.ExecuteNonQuery()
                MsgBox("Simpan data sukses.....", MsgBoxStyle.Information, "Perhatian")
            End If
            txtNim.Focus()
        End If
    End Sub


    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnUbah_Click_1(sender As Object, e As EventArgs) Handles btnUbah.Click
        If txtNim.Text = "" Then
            MsgBox("ID Pembeli Belum diisi")
            txtNim.Focus()
        Else
            Dim Ubah As String = "Update tbmahasiswa set nim = '" & txtNim.Text & "', 
                                                    nama = '" & txtNama.Text & "', 
                                                    prodi = '" & txtProdi.Text & "',
                                                    jenis_kelamin = '" & txtJenisKelamin.Text & "',
                                                    tempat = '" & txtTempat.Text & "'
                                                    tanggal_lahir = '" & txtTanggalLahir.Text & "'
                                                    tanggal_kelulusan = '" & txtTanggalKelulusan.Text & "'
                                      where nim = '" & txtNim.Text & "'"
            CMD = New MySqlCommand(Ubah, CONN)
            RD.Close()
            CMD.ExecuteNonQuery()
            MessageBox.Show("Data Telah Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtNim.Focus()
        End If
    End Sub

    Private Sub Pnl_Input_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class