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
End Class
