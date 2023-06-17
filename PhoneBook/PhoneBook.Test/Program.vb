Option Strict On

Imports System
Imports PhoneBook.Application
Imports PhoneBook.Domain

Module Program
    Sub Main(args As String())
        Dim repo = New ContactRepository()
        ''repo.Create(New Contact With {.FirstName = "Kyle", .LastName = "Smith", .PhoneNumber = "123456789"})
        Dim res = repo.Fetch(1)
    End Sub
End Module
