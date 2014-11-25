Public Class Bank_Edit
    Private mBank As Bank
    Public ReadOnly Property Bank() As Bank
        Get
            Return mBank
        End Get
    End Property

    Private mMode As String = "Edit"

    Public Sub New(aCode As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Dim bankModelProvider = DirectCast(Me.FindResource("BankModel"), ObjectDataProvider)
        'bankModelProvider.MethodParameters.Clear()
        'bankModelProvider.MethodParameters.Add(aCode)

        If aCode Is Nothing Then
            mMode = "New"
            mBank = New Bank
        Else
            Using db As New bankersEntities
                mBank = db.Banks.Single(Function(b) b.Code.Equals(aCode))
            End Using
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        Using db As New bankersEntities
            db.Banks.Attach(Bank)
            'db.Entry(Bank).Property(Function(b) b.Code).IsModified = True
            db.Entry(Bank).State = IIf(mMode.Equals("Edit"), System.Data.Entity.EntityState.Modified, System.Data.Entity.EntityState.Added)
            db.SaveChanges()
        End Using

        For Each win In Application.Current.Windows
            If TypeOf win Is Banks Then
                DirectCast(win, Banks).Refresh()
            End If
        Next

        Me.Close()
    End Sub
End Class
