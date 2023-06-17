Option Strict On

Imports Microsoft.Data.SqlClient
Imports PhoneBook.Domain

Public Class ContactRepository
    Function Create(contact As Contact) As Integer

        Dim existingContactWithSameName = SearchExact(contact.FullName)
        If existingContactWithSameName IsNot Nothing Then
            Throw New ContactExistException("Contact with same name already exists")
        End If

        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("INSERT INTO Contacts (FirstName, LastName, PhoneNumber) VALUES (@FirstName, @LastName, @PhoneNumber); SELECT SCOPE_IDENTITY();", connection)
            command.Parameters.AddWithValue("@FirstName", contact.FirstName)
            command.Parameters.AddWithValue("@LastName", contact.LastName)
            command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber)
            connection.Open()

            Dim result = Convert.ToInt32(command.ExecuteScalar())
            contact.ContactId = result
            Return result
        End Using
    End Function

    Function Fetch(contactId As Integer) As Contact
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("SELECT * FROM Contacts WHERE ContactId = @ContactId AND DateDeleted IS NULL", connection)
            command.Parameters.AddWithValue("@ContactId", contactId)
            connection.Open()

            Dim reader = command.ExecuteReader()
            If reader.Read() Then
                Return New Contact With {
                    .ContactId = reader.GetInt32(0),
                    .FirstName = reader.GetString(1),
                    .LastName = reader.GetString(2),
                    .PhoneNumber = reader.GetString(3),
                    .DateCreated = reader.GetDateTime(4)
                }
            End If
        End Using
        Return Nothing
    End Function

    Function Search(name As String) As List(Of Contact)
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("SELECT * FROM Contacts WHERE FirstName LIKE @Name OR LastName LIKE @Name OR FullName LIKE @Name AND DateDeleted IS NULL", connection)
            command.Parameters.AddWithValue("@Name", $"%{name}%")
            connection.Open()

            Dim reader = command.ExecuteReader()
            Dim contacts = New List(Of Contact)
            While reader.Read()
                contacts.Add(New Contact With {
                    .ContactId = reader.GetInt32(0),
                    .FirstName = reader.GetString(1),
                    .LastName = reader.GetString(2),
                    .PhoneNumber = reader.GetString(3),
                    .DateCreated = reader.GetDateTime(4)
                })
            End While
            Return contacts
        End Using
    End Function

    Sub Delete(contactId As Integer)
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("UPDATE Contacts SET DateDeleted = @DateDeleted WHERE ContactId = @ContactId", connection)
            command.Parameters.AddWithValue("@DateDeleted", DateTime.Now)
            command.Parameters.AddWithValue("@ContactId", contactId)
            connection.Open()

            command.ExecuteNonQuery()
        End Using
    End Sub

    Function SearchExact(name As String) As Contact
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("SELECT * FROM Contacts WHERE FullName = @Name AND DateDeleted IS NULL", connection)
            command.Parameters.AddWithValue("@Name", $"%{name}%")
            connection.Open()

            Dim reader = command.ExecuteReader()
            Dim contacts = New List(Of Contact)
            While reader.Read()
                contacts.Add(New Contact With {
                    .ContactId = reader.GetInt32(0),
                    .FirstName = reader.GetString(1),
                    .LastName = reader.GetString(2),
                    .PhoneNumber = reader.GetString(3),
                    .DateCreated = reader.GetDateTime(4)
                })
            End While
            Return contacts.SingleOrDefault()
        End Using
    End Function
End Class
