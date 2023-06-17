Imports PhoneBook.Domain

Public Class ConsoleContactService
    Implements IContactService
    Public Sub ProcessAction(action As ContactAction) Implements IContactService.ProcessAction
        Select Case action
            Case ContactAction.Add
                AddContact()
            Case ContactAction.Search
                SearchContact()
            Case ContactAction.ListAll
                ListAllContacts()
            Case ContactAction.Delete
                DeleteContact()
            Case ContactAction.ExitApplication
                ExitApplication()
        End Select
    End Sub


    Public Sub SearchContact()
        Throw New NotImplementedException()
    End Sub

    Public Sub ListAllContacts()
        Throw New NotImplementedException()
    End Sub

    Public Sub DeleteContact()
        Console.Write("Enter the exact name of the contact to delete: ")
        Dim nameOfContactToDelete = Console.ReadLine()
        Dim contactRepository = New ContactRepository()
        Dim contactToDelete = contactRepository.SearchExact(nameOfContactToDelete)

        If contactToDelete Is Nothing Then
            Console.WriteLine("Contact not found.")
            Return
        End If

        contactRepository.Delete(contactToDelete.ContactId)

        Console.WriteLine("Contact deleted successfully.")
    End Sub

    Public Sub AddContact()
        Console.WriteLine("Enter first name:")
        Dim firstName = Console.ReadLine()
        Console.WriteLine("Enter last name:")
        Dim lastName = Console.ReadLine()
        Console.WriteLine("Enter phone number:")
        Dim phoneNumber = Console.ReadLine()
        Dim contact = New Contact With {
            .FirstName = firstName,
            .LastName = lastName,
            .PhoneNumber = phoneNumber,
            .DateCreated = DateTime.Now
        }

        Dim contactRepository = New ContactRepository()
        contactRepository.Create(contact)

        Console.WriteLine("Contact added successfully.")
    End Sub

    Public Sub ExitApplication()
        Environment.Exit(0)
    End Sub

End Class
