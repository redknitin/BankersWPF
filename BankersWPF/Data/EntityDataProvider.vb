Imports System.Data

Public Class EntityDataProvider
    'Public Function GetBanks() As DataTable
    '    Dim dt As New DataTable

    '    dt.Columns.Add("Code") : dt.Columns.Add("Name")

    '    dt.Rows.Add({"SCB-DXB", "Standard Chartered Bank, Dubai"})
    '    dt.Rows.Add({"SBH-HYD", "State Bank of Hyderabad, Hyderabad"})
    '    dt.Rows.Add({"CAN-HYD", "Canara Bank, Hyderabad"})

    '    Return dt
    'End Function

    Public Function GetBanks() As List(Of Bank)
        Using db As New bankersEntities
            Return db.Banks.ToList()
        End Using
    End Function

    Public Function GetBank(aCode As String) As Bank
        Using db As New bankersEntities
            Return db.Banks.SingleOrDefault(Function(b) b.Code.Equals(aCode))
        End Using
    End Function

    Public Function GetAccounts(aBankCode As String) As List(Of Account)
        If aBankCode Is Nothing Then Return Nothing
        Using db As New bankersEntities
            Return db.Accounts.Where(Function(a) a.BankCode.Equals(aBankCode)).ToList()
        End Using
    End Function

    Public Function GetAccount(aAccountCode As String) As Account
        Throw New NotImplementedException()
    End Function

    Public Function GetChequeBooks(aAccountCode As String) As List(Of ChequeBook)
        Throw New NotImplementedException()
    End Function

    Public Function GetChequeBook(aChequeBookCode As String) As ChequeBook
        Throw New NotImplementedException()
    End Function

    Public Function GetCheques(aChequeBookCode As String) As List(Of Cheque)
        Throw New NotImplementedException()
    End Function

    Public Function GetCheque(aChequeNo As String) As Cheque
        Throw New NotImplementedException()
    End Function
End Class
