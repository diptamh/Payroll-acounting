﻿Imports System.Data.OleDb
Public Class edtemplye
    Dim provider As String
    Dim dataFile As String
    Dim connstring As String
    Dim myconnection As OleDbConnection = New OleDbConnection
    Dim con As New OleDbConnection
    Dim dt As New DataTable()
    Private Sub REMOVEEMPLOYEE_Click(sender As Object, e As EventArgs) Handles REMOVEEMPLOYEE.Click
        GroupBox1.Visible = True
        GroupBox2.Visible = False
    End Sub

    Private Sub BACK_Click(sender As Object, e As EventArgs) Handles BACK.Click
        GroupBox1.Visible = False

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        Dim s As String
        s = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\vb_net.accdb"
        con.ConnectionString = s

        con.Open()
        Dim odc As New OleDbDataAdapter(New OleDbCommand("SELECT * FROM emp", con))

        odc.Fill(dt)
        For Each dr As DataRow In dt.Rows
            Idbox.Items.Add(dr(0))
        Next
        con.Close()
        odc.Dispose()
    End Sub

    Private Sub BACK2_Click(sender As Object, e As EventArgs) Handles BACK2.Click
        GroupBox2.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox2.Visible = True
        GroupBox1.Visible = False
    End Sub
    Private Sub PREV_Click(sender As Object, e As EventArgs) Handles PREV.Click
        Me.Hide()
        wlcmopearor.Show()

    End Sub

    Private Sub SAVE_Click(sender As Object, e As EventArgs) Handles SAVE.Click
        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
        dataFile = "C:\Users\DELL\Documents\vb_net.accdb"
        connstring = provider & dataFile
        myconnection.ConnectionString = connstring
        myconnection.Open()
        Dim str As String
        str = "Update [emp] set [empname]='" & TextBox2.Text & "',[branch]='" & ComboBox4.Text & "',[qualif]='" & ComboBox1.Text & "',[desig]='" & ComboBox2.Text & "',[gender]='" & ComboBox3.Text & "',[city]='" & TextBox6.Text & "',[ph]='" & MaskedTextBox1.Text & "',[mail]='" & TextBox7.Text & "',[add]='" & TextBox4.Text & "',[Basic]='" & TextBox3.Text & "' where [ID]= " & Idbox.Text & ""
        Dim cmd As OleDbCommand = New OleDbCommand(str, myconnection)
        MsgBox("Record Updated", vbInformation, "Upadate Successfull")
        Try
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            myconnection.Close()
            Idbox.Text = ""
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            MaskedTextBox1.Clear()
            TextBox6.Clear()
            TextBox4.Clear()
            ComboBox4.Text = ""
            TextBox7.Clear()
            ComboBox1.Text = ""
            ComboBox2.Text = ""
            ComboBox3.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Idbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Idbox.SelectedIndexChanged
        For Each dr As DataRow In dt.Rows
            If dr(0) = Idbox.Text Then
                TextBox2.Text = dr(1)
                ComboBox4.Text = dr(2)
                ComboBox1.Text = dr(3)
                ComboBox2.Text = dr(4)
                ComboBox3.Text = dr(5)
                TextBox6.Text = dr(6)
                MaskedTextBox1.Text = dr(7)
                TextBox7.Text = dr(8)
                TextBox4.Text = dr(9)
                TextBox3.Text = dr(10)
            End If
        Next
    End Sub

    Private Sub DELETE_Click(sender As Object, e As EventArgs) Handles DELETE.Click
        Dim con As OleDbConnection
        Dim com As OleDbCommand
        con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DELL\Documents\vb_net.accdb")
        com = New OleDbCommand("delete from emp where ID =@ID", con)
        con.Open()
        com.Parameters.AddWithValue("@ID", TextBox1.Text)
        com.ExecuteNonQuery()
        MsgBox("Record Deleted", vbInformation, "Delete Successfull")
        TextBox1.Text = ""
        con.Close()

    End Sub

End Class