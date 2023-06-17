Imports System
Imports PhoneBook.Application
Imports PhoneBook.Domain

Module Program
    Sub Main(args As String())
        Dim repo = New ContactRepository()
        repo.CreateContact(New Contact With {.FirstName = "Kyle", .LastName = "Smith", .PhoneNumber = "123456789"})
    End Sub
End Module
