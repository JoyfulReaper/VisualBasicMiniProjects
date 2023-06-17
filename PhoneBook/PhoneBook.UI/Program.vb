Option Strict On

Imports System
Imports PhoneBook.Application
Imports PhoneBook.Domain

Module Program
    Sub Main(args As String())
        Dim menuService = New MenuService
        Dim contactService = New ConsoleContactService

        menuService.PrintHeader()
        Do
            menuService.PrintMenu()
            Dim action = menuService.GetAction()
            contactService.ProcessAction(action)
        Loop

    End Sub
End Module
