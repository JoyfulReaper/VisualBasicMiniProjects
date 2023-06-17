Imports Microsoft.Data.SqlClient
Imports PhoneBook.Domain

Public Class ContactRepository
    Function CreateContact(contact As Contact) As Integer
        Using connection As New SqlConnection(GetConnectionString())
            Dim command As New SqlCommand("INSERT INTO Contacts (FirstName, LastName, PhoneNumber) VALUES (@FirstName, @LastName, @PhoneNumber); SELECT SCOPE_IDENTITY();", connection)
            command.Parameters.AddWithValue("@FirstName", contact.FirstName)
            command.Parameters.AddWithValue("@LastName", contact.LastName)
            command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber)
            connection.Open()

            Dim result = command.ExecuteScalar()
            Return Convert.ToInt32(result)
        End Using
    End Function
End Class
