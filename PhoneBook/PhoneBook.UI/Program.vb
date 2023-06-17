Option Strict On

Imports System
Imports PhoneBook.Application
Imports PhoneBook.Domain

Module Program
    Sub Main(args As String())
        Dim menuService = New MenuService
        menuService.PrintHeader()
        menuService.PrintMenu()
    End Sub
End Module
