Imports System.Security.Cryptography
Imports System.Text

Public Class MainForm
    Private ReadOnly digits() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9}
    Dim seen = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0}

    Private Function IsFinished() As Boolean

        For i As Byte = 0 To 8
            If seen(i) = 0 Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim sb As StringBuilder
        Dim rngByte(1) As Byte

        seen = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0}
        Using csprng = New RNGCryptoServiceProvider
            sb = New StringBuilder

            While Not IsFinished()
                csprng.GetBytes(rngByte)
                rngByte(0) = 1 + rngByte(0) Mod 9

                If seen(rngByte(0) - 1) = 0 Then
                    seen(rngByte(0) - 1) = 1
                    sb.Append(rngByte(0).ToString)
                End If

            End While

            txtPin.Text = sb.ToString
        End Using
    End Sub
End Class
