Option Strict On

Public Class MenuService
    Public Sub PrintHeader()
        Console.WriteLine("Welcome to the Phone Book")
        Console.WriteLine("Programming Challenge For Programming Friends Discord Server")
        Console.WriteLine("========================")
    End Sub

    Public Sub PrintMenu()
        Console.WriteLine()
        Console.WriteLine("1. Add a contact")
        Console.WriteLine("2. Search for a contact")
        Console.WriteLine("3. List all contacts")
        Console.WriteLine("4. Delete a contact")
        Console.WriteLine("5. Exit")
    End Sub

    Public Function GetAction() As ContactAction
        Dim action As ContactAction
        Console.Write("Enter your choice: ")
        Dim input = Console.ReadLine()
        If Not [Enum].TryParse(input, action) Then
            Console.WriteLine("Invalid input. Please try again.")
            Return GetAction()
        End If
        Return action
    End Function
End Class
