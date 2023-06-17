Option Strict On

Imports System
Imports PhoneBook.Domain

Module Program
    Sub Main(args As String())
        Dim contact As New Contact With {
                .FirstName = "Kyle",
                .LastName = "Smith",
                .PhoneNumber = "1234567890"
            }

        Console.WriteLine($"FirstName: {contact.FirstName}")
    End Sub
End Module
