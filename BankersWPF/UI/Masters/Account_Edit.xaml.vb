﻿Public Class Account_Edit
    Private mAccount As Account
    Public ReadOnly Property Account() As Account
        Get
            Return mAccount
        End Get
    End Property

    Private mMode As String = "Edit"

    Public Sub New(aAccountCode As String, Optional aBankCode As String = Nothing)
        InitializeComponent()
        If aAccountCode Is Nothing Then
            mMode = "New"
            mAccount = New Account
            mAccount.BankCode = aBankCode
        Else
            Using db As New bankersEntities
                mAccount = db.Accounts.Single(Function(a) a.Code = aAccountCode)
            End Using

            lblOpening.Visibility = Windows.Visibility.Hidden
            txtOpening.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtCode.Text) Or String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Code and name must be entered", "Invalid data", MessageBoxButton.OK, MessageBoxImage.Error)
            Return
        End If

        Using db As New bankersEntities
            db.Accounts.Attach(Account)
            db.Entry(Account).State = IIf(mMode = "Edit", System.Data.Entity.EntityState.Modified, System.Data.Entity.EntityState.Added)
            If mMode = "New" Then
                Dim j As New Journal
                j.AccountCode = Account.Code
                If Not String.IsNullOrWhiteSpace(txtOpening.Text) Then j.Amount = Decimal.Parse(txtOpening.Text) Else j.Amount = 0
                j.EntryType = "Opening"
                j.Comment = "Opening balance"
                j.OccurredOn = DateTime.Now
                db.Journals.Add(j)
            End If
            db.SaveChanges()
        End Using

        For Each win In Application.Current.Windows
            If TypeOf win Is Accounts Then
                DirectCast(win, Accounts).Refresh()
            End If
        Next

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
