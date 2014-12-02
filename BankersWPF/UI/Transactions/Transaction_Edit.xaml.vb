Public Class Transaction_Edit
    Private mJournal As Journal
    Public ReadOnly Property Journal() As Journal
        Get
            Return mJournal
        End Get
    End Property

    Private mMode As String = "Edit"

    Public Sub New(aId As Nullable(Of Int32), Optional aAccountCode As String = Nothing)
        InitializeComponent()
        If aId Is Nothing Then
            mMode = "New"
            mJournal = New Journal
            mJournal.AccountCode = aAccountCode
        Else
            Using db As New bankersEntities
                mJournal = db.Journals.Single(Function(j) j.Id = aId)
            End Using
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs) Handles btnSave.Click
        Using db As New bankersEntities
            db.Journals.Attach(Journal)
            db.Entry(Journal).State = IIf(mMode = "Edit", System.Data.Entity.EntityState.Modified, System.Data.Entity.EntityState.Added)
            db.SaveChanges()
        End Using
    End Sub
End Class
