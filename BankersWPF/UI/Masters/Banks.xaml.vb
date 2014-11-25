Public Class Banks
    Private Sub btnEditBank_Click(sender As Object, e As RoutedEventArgs) Handles btnEditBank.Click
        Dim selBank = dgViewer.SelectedItem

        If selBank Is Nothing Then
            MessageBox.Show("You must select an item to edit")
            Return
        End If

        Dim bankCode = DirectCast(selBank, Bank).Code
        'System.Diagnostics.Debug.WriteLine(selBank.ToString())
        Dim wBankEdit As New Bank_Edit(bankCode)
        wBankEdit.ShowDialog()
    End Sub

    Private Sub btnDeleteBank_Click(sender As Object, e As RoutedEventArgs) Handles btnDeleteBank.Click
        If dgViewer.SelectedItem Is Nothing Then
            MessageBox.Show("Select a bank")
            Return
        End If

        If MessageBoxResult.Yes = MessageBox.Show("Are you sure you want to delete?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) Then
            Dim selBank = dgViewer.SelectedItem
            If Not selBank Is Nothing Then
                Using db As New bankersEntities
                    db.Banks.Remove(db.Banks.Single(Function(x) x.Code = DirectCast(selBank, Bank).Code))
                    db.SaveChanges()
                    dgViewer.ItemsSource = New EntityDataProvider().GetBanks()
                End Using
            End If
        End If
    End Sub

    Private Sub btnNewBank_Click(sender As Object, e As RoutedEventArgs) Handles btnNewBank.Click
        'MessageBox.Show("Not implemented", "Under Construction", MessageBoxButton.OK, MessageBoxImage.Exclamation)
        Dim wBankEdit As New Bank_Edit(Nothing)
        wBankEdit.ShowDialog()
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
