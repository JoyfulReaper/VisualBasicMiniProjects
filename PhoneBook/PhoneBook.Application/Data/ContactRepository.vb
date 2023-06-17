Option Strict On

Imports Microsoft.Data.SqlClient
Imports PhoneBook.Domain

Public Class ContactRepository
    Function Create(contact As Contact) As Integer
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
            Dim command As New SqlCommand("SELECT * FROM Contacts WHERE ContactId = @ContactId", connection)
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
End Class
