'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class ChequeBook
    Public Property Id As Integer
    Public Property ChequeBookNo As String
    Public Property AccountCode As String
    Public Property StartChequeNo As Nullable(Of Integer)
    Public Property EndChequeNo As Nullable(Of Integer)
    Public Property LastChequeNo As Nullable(Of Integer)

    Public Overridable Property Account As Account
    Public Overridable Property Cheques As ICollection(Of Cheque) = New HashSet(Of Cheque)

End Class
