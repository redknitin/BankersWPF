Public Class ChequeBook_Edit
    Private mChequeBook As ChequeBook
    Public ReadOnly Property ChequeBook() As ChequeBook
        Get
            Return mChequeBook
        End Get
    End Property

    Private mMode As String = "Edit"

    Public Sub New(aChequeBookId As Nullable(Of Int32), Optional aAccountCode As String = Nothing)
        InitializeComponent()
        If aChequeBookId Is Nothing Then
            mMode = "New"
            mChequeBook = New ChequeBook()
            mChequeBook.AccountCode = aAccountCode
        Else
            Using db As New bankersEntities
                mChequeBook = db.ChequeBooks.Single(Function(c) c.Id = aChequeBookId)
            End Using
        End If
    End Sub

    Public Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        Using db As New bankersEntities
            db.ChequeBooks.Attach(mChequeBook)
            db.Entry(mChequeBook).State = IIf(mMode = "Edit", System.Data.Entity.EntityState.Modified, System.Data.Entity.EntityState.Added)
            db.SaveChanges()
        End Using

        For Each win In Application.Current.Windows
            If TypeOf win Is ChequeBooks Then
                DirectCast(win, ChequeBooks).Refresh()
            End If
        Next

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As RoutedEventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
