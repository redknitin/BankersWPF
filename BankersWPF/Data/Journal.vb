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

Partial Public Class Journal
    Public Property Id As Integer
    Public Property AccountCode As String
    Public Property Amount As Decimal
    Public Property OccurredOn As Date
    Public Property Comment As String
    Public Property EntryType As String

    Public Overridable Property Account As Account

End Class
