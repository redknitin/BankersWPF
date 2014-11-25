Public Class Banks
    Private Sub btnEditBank_Click(sender As Object, e As RoutedEventArgs) Handles btnEditBank.Click
        Dim selBank = dgViewer.SelectedItem
        Dim bankCode = DirectCast(selBank, Bank).Code
        'System.Diagnostics.Debug.WriteLine(selBank.ToString())
        Dim wBankEdit As New Bank_Edit(bankCode)
        wBankEdit.ShowDialog()
    End Sub

    Private Sub btnDeleteBank_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteBank.Click
        MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
    End Sub

    Private Sub btnNewBank_Click(sender As Object, e As RoutedEventArgs) Handles btnNewBank.Click
        MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
    End Sub

    Public Sub Refresh()
        'Dim tmpSrc = dgViewer.ItemsSource
        'dgViewer.ItemsSource = Nothing
        'dgViewer.ItemsSource = tmpSrc

        'Dim tmpCtx = dgViewer.DataContext
        'dgViewer.DataContext = Nothing
        'dgViewer.DataContext = tmpCtx

        'dgViewer.GetBindingExpression(DataGrid.ItemsSourceProperty).UpdateTarget()
        'BindingOperations.GetBindingExpressionBase(dgViewer, dgViewer.DataContext).UpdateTarget()

        dgViewer.ItemsSource = New EntityDataProvider().GetBanks()

        'dgViewer.Items.Refresh()
    End Sub
End Class
