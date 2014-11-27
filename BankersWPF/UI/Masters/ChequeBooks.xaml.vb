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
    Public Sub Refresh()
        Using db As New bankersEntities
            Dim retval = db.ChequeBooks.Where(Function(c) c.AccountCode = DirectCast(cboAccount.SelectedItem, Account).Code).ToList()
            dgViewer.ItemsSource = retval
        End Using
    End Sub

    Private Sub btnNewChequeBook_Click(sender As Object, e As RoutedEventArgs) Handles btnNewChequeBook.Click
        Dim acCode As String = DirectCast(cboAccount.SelectedItem, Account).Code
        Dim wChqBookEdit As New Account_Edit(Nothing, acCode)
        wChqBookEdit.ShowDialog()
    End Sub

    Private Sub btnEditChequeBook_Click(sender As Object, e As RoutedEventArgs) Handles btnEditChequeBook.Click
        If dgViewer.SelectedItem Is Nothing Then
            MessageBox.Show("Select a cheque book")
            Return
        End If

        Dim chqBkId As Int32 = DirectCast(dgViewer.SelectedItem, ChequeBook).Id
        'MessageBox.Show(accountCode)
        Dim winChqBkEdit As New ChequeBook_Edit(chqBkId)
        winChqBkEdit.ShowDialog()
    End Sub

    Private Sub btnDeleteChequeBook_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteChequeBook.Click
        If dgViewer.SelectedItem Is Nothing Then
            MessageBox.Show("Select an cheque book")
            Return
        End If

        If MessageBoxResult.Yes = MessageBox.Show("Are you sure you want to delete?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) Then
            Dim selChequeBook = dgViewer.SelectedItem
            If Not selChequeBook Is Nothing Then
                Using db As New bankersEntities
                    db.ChequeBooks.Remove(db.ChequeBooks.Single(Function(c) c.Id = DirectCast(selChequeBook, ChequeBook).Id))
                    db.SaveChanges()
                End Using
                Refresh()
            End If
        End If
    End Sub
End Class
