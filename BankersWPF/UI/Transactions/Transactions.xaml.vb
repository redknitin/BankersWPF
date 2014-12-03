Public Class Transactions
    Public Sub cboBank_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cboBank.SelectedItem Is Nothing Or Not TypeOf cboBank.SelectedItem Is Bank Then
            cboAccount.ItemsSource = Nothing
            Return
        End If
        Dim edp As New EntityDataProvider
        cboAccount.ItemsSource = edp.GetAccounts(DirectCast(cboBank.SelectedItem, Bank).Code)
    End Sub
    Public Sub cboAccount_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cboAccount.SelectedItem Is Nothing Then
            dgViewer.ItemsSource = Nothing
            Return
        End If

        Using db As New bankersEntities
            Dim retval = db.Journals.Where(Function(j) j.AccountCode = DirectCast(cboAccount.SelectedItem, Account).Code).OrderByDescending(Function(j) j.OccurredOn).Take(10).ToList()
            dgViewer.ItemsSource = retval
        End Using
    End Sub

    Private Sub btnEditTransaction_Click(sender As Object, e As RoutedEventArgs) Handles btnEditTransaction.Click
        Dim transactionId As Int32 = DirectCast(dgViewer.SelectedItem, Journal).Id
        Dim winTrEdit As New Transaction_Edit(transactionId)
        winTrEdit.ShowDialog()
    End Sub

    Private Sub btnNewTransaction_Click(sender As Object, e As RoutedEventArgs) Handles btnNewTransaction.Click
        Dim accountCode As String = DirectCast(cboAccount.SelectedItem, Account).Code
        Dim winTrEdit As New Transaction_Edit(Nothing, accountCode)
        winTrEdit.ShowDialog()
    End Sub

    Private Sub btnDeleteTransaction_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteTransaction.Click
        If MessageBoxResult.Yes = MessageBox.Show("Are you sure you want to delete?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) Then
            Dim selTransaction = dgViewer.SelectedItem
            If Not selTransaction Is Nothing Then
                Using db As New bankersEntities
                    db.Journals.Remove(db.Journals.Single(Function(a) a.Id = DirectCast(selTransaction, Journal).Id))
                    db.SaveChanges()
                End Using
                'Refresh()
            End If
        End If
    End Sub
End Class
