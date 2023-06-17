Imports PhoneBook.Domain

Public Interface IContactRepository
    Sub Delete(contactId As Integer)
    Function Create(contact As Contact) As Integer
    Function Fetch(contactId As Integer) As Contact
    Function FetchAll() As List(Of Contact)
    Function Search(name As String) As List(Of Contact)
    Function SearchExact(name As String) As Contact
End Interface
