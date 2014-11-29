Class MainWindow 

    Private Sub btnTransactions_Click(sender As Object, e As RoutedEventArgs) Handles btnTransactions.Click
        Dim winTrans As New Transactions
        winTrans.ShowDialog()
    End Sub

    Private Sub btnMasters_Click(sender As Object, e As RoutedEventArgs) Handles btnMasters.Click
        Dim winMasters As New Masters
        winMasters.ShowDialog()
    End Sub

    Private Sub btnReports_Click(sender As Object, e As RoutedEventArgs) Handles btnReports.Click
        MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As RoutedEventArgs) Handles btnQuit.Click
        Environment.Exit(0)
    End Sub
End Class
