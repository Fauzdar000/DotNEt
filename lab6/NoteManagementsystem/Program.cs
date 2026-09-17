using System;
using System.IO;

class NoteManagerApp
{
    // Path of the NotesApp folder
    static string noteDirectory = @"D:\NotesApp";

    // 1. SetupNoteDirectory()
    static void SetupNoteDirectory()
    {
        // Create directory if it does not exist
        if (!Directory.Exists(noteDirectory))
        {
            Directory.CreateDirectory(noteDirectory);
            Console.WriteLine("NotesApp folder created successfully.");
        }
        else
        {
            Console.WriteLine("NotesApp folder already exists.");
        }
    }

    // 2. CreateNote()
    static void CreateNote(string title, string content)
    {
        string filePath = Path.Combine(noteDirectory, title + ".txt");

        // Check if file already exists
        if (File.Exists(filePath))
        {
            Console.Write("Note already exists. Do you want to overwrite it? (y/n): ");
            string answer = Console.ReadLine();

            if (answer?.ToLower() != "y")
            {
                Console.WriteLine("Note was not overwritten.");
                return;
            }
        }

        File.WriteAllText(filePath, content);
        Console.WriteLine("Note created successfully.");
    }

    // 3. ReadNote()
    static void ReadNote(string title)
    {
        string filePath = Path.Combine(noteDirectory, title + ".txt");

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);

            Console.WriteLine("\n--- Note Content ---");
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Note not found.");
        }
    }

    // 4. ListAllNotes()
    static void ListAllNotes()
    {
        string[] files = Directory.GetFiles(noteDirectory, "*.txt");

        if (files.Length == 0)
        {
            Console.WriteLine("No notes found.");
            return;
        }

        Console.WriteLine("\n--- All Notes ---");

        foreach (string file in files)
        {
            // Get file name without extension
            string title = Path.GetFileNameWithoutExtension(file);
            Console.WriteLine(title);
        }
    }

    // 5. CopyNote()
    static void CopyNote(string originalTitle, string copyTitle)
    {
        string originalPath =
            Path.Combine(noteDirectory, originalTitle + ".txt");

        string copyPath =
            Path.Combine(noteDirectory, copyTitle + ".txt");

        if (!File.Exists(originalPath))
        {
            Console.WriteLine("Original note not found.");
            return;
        }

        if (File.Exists(copyPath))
        {
            Console.Write("Copy already exists. Overwrite? (y/n): ");
            string answer = Console.ReadLine();

            if (answer?.ToLower() != "y")
            {
                Console.WriteLine("Copy operation cancelled.");
                return;
            }

            File.Copy(originalPath, copyPath, true);
        }
        else
        {
            File.Copy(originalPath, copyPath);
        }

        Console.WriteLine("Note copied successfully.");
    }

    // 6. MoveNote()
    static void MoveNote(string oldTitle, string newTitle)
    {
        string oldPath =
            Path.Combine(noteDirectory, oldTitle + ".txt");

        string newPath =
            Path.Combine(noteDirectory, newTitle + ".txt");

        if (!File.Exists(oldPath))
        {
            Console.WriteLine("Note not found.");
            return;
        }

        if (File.Exists(newPath))
        {
            Console.WriteLine("A note with the new title already exists.");
            return;
        }

        File.Move(oldPath, newPath);

        Console.WriteLine("Note moved/renamed successfully.");
    }

    // 7. DeleteNote()
    static void DeleteNote(string title)
    {
        string filePath =
            Path.Combine(noteDirectory, title + ".txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Note not found.");
            return;
        }

        // Ask for confirmation
        Console.Write("Are you sure you want to delete this note? (y/n): ");
        string answer = Console.ReadLine();

        if (answer?.ToLower() == "y")
        {
            File.Delete(filePath);
            Console.WriteLine("Note deleted successfully.");
        }
        else
        {
            Console.WriteLine("Delete operation cancelled.");
        }
    }

    // 8. ReadNoteLineByLine()
    static void ReadNoteLineByLine(string title)
    {
        string filePath =
            Path.Combine(noteDirectory, title + ".txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Note not found.");
            return;
        }

        Console.WriteLine("\n--- Note Line by Line ---");

        int lineNumber = 1;

        // File.ReadLines reads the file line by line
        foreach (string line in File.ReadLines(filePath))
        {
            Console.WriteLine(lineNumber + ". " + line);
            lineNumber++;
        }
    }


    // Main method
    static void Main()
    {
        // Setup directory first
        SetupNoteDirectory();

        while (true)
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("       NOTE MANAGER APP");
            Console.WriteLine("============================");

            Console.WriteLine("1. Create Note");
            Console.WriteLine("2. Read Note");
            Console.WriteLine("3. List All Notes");
            Console.WriteLine("4. Copy Note");
            Console.WriteLine("5. Move/Rename Note");
            Console.WriteLine("6. Delete Note");
            Console.WriteLine("7. Read Note Line by Line");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter note title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter note content: ");
                    string content = Console.ReadLine();

                    CreateNote(title, content);
                    break;

                case "2":
                    Console.Write("Enter note title: ");
                    title = Console.ReadLine();

                    ReadNote(title);
                    break;

                case "3":
                    ListAllNotes();
                    break;

                case "4":
                    Console.Write("Enter original note title: ");
                    string originalTitle = Console.ReadLine();

                    Console.Write("Enter copy title: ");
                    string copyTitle = Console.ReadLine();

                    CopyNote(originalTitle, copyTitle);
                    break;

                case "5":
                    Console.Write("Enter old note title: ");
                    string oldTitle = Console.ReadLine();

                    Console.Write("Enter new note title: ");
                    string newTitle = Console.ReadLine();

                    MoveNote(oldTitle, newTitle);
                    break;

                case "6":
                    Console.Write("Enter note title to delete: ");
                    title = Console.ReadLine();

                    DeleteNote(title);
                    break;

                case "7":
                    Console.Write("Enter note title: ");
                    title = Console.ReadLine();

                    ReadNoteLineByLine(title);
                    break;

                case "8":
                    Console.WriteLine("Exiting Note Manager App...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}