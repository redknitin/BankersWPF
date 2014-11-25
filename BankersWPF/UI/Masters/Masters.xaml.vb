Public Class Masters

    Private Sub btnBanks_Click(sender As Object, e As RoutedEventArgs) Handles btnBanks.Click
        Dim winBanks As New Banks
        winBanks.ShowDialog()
    End Sub

    Private Sub btnChequeBooks_Click(sender As Object, e As RoutedEventArgs) Handles btnChequeBooks.Click
        MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
    End Sub

    Private Sub btnAccounts_Click(sender As Object, e As RoutedEventArgs) Handles btnAccounts.Click
        Dim winAccounts As New Accounts
        winAccounts.ShowDialog()
        'MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
    End Sub
End Class
