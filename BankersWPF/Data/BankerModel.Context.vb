﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class bankersEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=bankersEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Banks() As DbSet(Of Bank)
    Public Overridable Property Accounts() As DbSet(Of Account)
    Public Overridable Property ChequeBooks() As DbSet(Of ChequeBook)
    Public Overridable Property Cheques() As DbSet(Of Cheque)

End Class
