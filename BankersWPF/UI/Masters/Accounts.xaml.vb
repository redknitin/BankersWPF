Public Class Accounts
    Private Sub cboBank_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cboBank.SelectedItem Is Nothing Then
            Return
        End If

        Dim bankCode As String = DirectCast(cboBank.SelectedItem, Bank).Code
        Using db As New bankersEntities
            dgViewer.ItemsSource = db.Accounts.Where(Function(a) a.BankCode = bankCode).ToList()
        End Using
    End Sub

    Private Sub btnEditAccount_Click(sender As Object, e As RoutedEventArgs) Handles btnEditAccount.Click
        If dgViewer.SelectedItem Is Nothing Then
            MessageBox.Show("Select an account")
            Return
        End If

        Dim accountCode As String = DirectCast(dgViewer.SelectedItem, Account).Code
        'MessageBox.Show(accountCode)
        Dim winAcEdit As New Account_Edit(accountCode)
        winAcEdit.ShowDialog()
    End Sub

    Public Sub Refresh()
        Dim bankCode As String = DirectCast(cboBank.SelectedItem, Bank).Code
        dgViewer.ItemsSource = New EntityDataProvider().GetAccounts(bankCode)
    End Sub

    Private Sub btnNewAccount_Click(sender As Object, e As RoutedEventArgs) Handles btnNewAccount.Click
        Dim bankCode As String = DirectCast(cboBank.SelectedItem, Bank).Code
        Dim wAccountEdit As New Account_Edit(Nothing, bankCode)
        wAccountEdit.ShowDialog()
    End Sub

    Private Sub btnDeleteAccount_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteAccount.Click
        If dgViewer.SelectedItem Is Nothing Then
            MessageBox.Show("Select an account")
            Return
        End If

        If MessageBoxResult.Yes = MessageBox.Show("Are you sure you want to delete?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) Then
            Dim selAccount = dgViewer.SelectedItem
            If Not selAccount Is Nothing Then
                Using db As New bankersEntities
                    db.Accounts.Remove(db.Accounts.Single(Function(a) a.Code = DirectCast(selAccount, Account).Code))
                    db.SaveChanges()
                End Using
                Refresh()
            End If
        End If
    End Sub
End Class
