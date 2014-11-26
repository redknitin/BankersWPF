Public Class ChequeBooks
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
            Dim retval = db.ChequeBooks.Where(Function(c) c.AccountCode = DirectCast(cboAccount.SelectedItem, Account).Code).ToList()
            dgViewer.ItemsSource = retval
        End Using
    End Sub
End Class
