/************************
*   Имя: Бойко Виктория *
*   Группа: ПИ-221      *
*   Лабораторная 2      *
*   Дата: 19.02.23      *
*************************/
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DocumentsWorld
{
    class DocManager
    {
        private static readonly DocManager instance = new DocManager();
        private List<Document> documents = new List<Document>();

        private DocManager() { }

        public static DocManager Instance
        {
            get { return instance; }
        }

        public void AddDocument(Document doc)
        {
            documents.Add(doc);
        }

        public void RemoveDocument(Document doc)
        {
            documents.Remove(doc);
        }

        public void Menu()
        {
            Console.WriteLine("Выберите команду");
            Console.WriteLine("1 - Добавить документ");
            Console.WriteLine("2 - Удалить документ");
            Console.WriteLine("3 - Список документов");
            Console.WriteLine("4 - Выход");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddDocument();
                    break;
                case "2":
                    RemoveDocument();
                    break;
                case "3":
                    ListAllDocuments();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }

            Menu();
        }

        private void AddDocument()
        {
            Console.WriteLine("Введите имя документа:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите автора документа:");
            string author = Console.ReadLine();

            Console.WriteLine("Введите ключевые слова:");
            string[] keywords = Console.ReadLine().Split(',');

            Console.WriteLine("Введите тему документа:");
            string subject = Console.ReadLine();

            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine();

            Console.WriteLine("Выберите формат файла:");
            Console.WriteLine("1. MS Word");
            Console.WriteLine("2. PDF");
            Console.WriteLine("3. MS Excel");
            Console.WriteLine("4. TXT");
            Console.WriteLine("5. HTML");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    documents.Add(new MSWordDocument(name, author, keywords, subject, filePath));
                    break;
                case "2":
                    documents.Add(new PDFDocument(name, author, keywords, subject, filePath));
                    break;
                case "3":
                    documents.Add(new MSExcelDocument(name, author, keywords, subject, filePath));
                    break;
                case "4":
                    documents.Add(new TXTDocument(name, author, keywords, subject, filePath));
                    break;
                case "5":
                    documents.Add(new HTMLDocument(name, author, keywords, subject, filePath));
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        private void RemoveDocument()
        {
            Console.WriteLine("Введите имя документа который вы хотите удалить:");
            string name = Console.ReadLine();

            Document doc = documents.Find(d => d.Name == name);
            if (doc != null)
            {
                documents.Remove(doc);
                Console.WriteLine("Документ удалён.");
            }
            else
            {
                Console.WriteLine("Такой документ не найден.");
            }
        }

        private void ListAllDocuments()
        {
            Console.WriteLine("Все документы:");

            foreach (Document doc in documents)
            {
                Console.WriteLine(doc.GetInfo());
            }
        }
    }

    public abstract class Document
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string[] Keywords { get; set; }
        public string Subject { get; set; }
        public string FilePath { get; set; }

        public Document(string name, string author, string[] keywords, string subject, string filePath)
        {
            Name = name;
            Author = author;
            Keywords = keywords;
            Subject = subject;
            FilePath = filePath;
        }
        public abstract string GetInfo();
    }

    public class MSWordDocument : Document
    {
        public MSWordDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath)
        {
        }

        public override string GetInfo()
        {
            return $"MS Word Document: {Name}, by {Author}, Keywords: {string.Join(",", Keywords)}, Subject: {Subject}, File Path: {FilePath}";
        }
    }

    public class PDFDocument : Document
    {
        public PDFDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath)
        {
        }

        public override string GetInfo()
        {
            return $"PDF Document: {Name}, by {Author}, Keywords: {string.Join(",", Keywords)}, Subject: {Subject}, File Path: {FilePath}";
        }
    }

    public class MSExcelDocument : Document
    {
        public MSExcelDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath)
        {
        }

        public override string GetInfo()
        {
            return $"MS Excel Document: {Name}, by {Author}, Keywords: {string.Join(",", Keywords)}, Subject: {Subject}, File Path: {FilePath}";
        }
    }

    public class TXTDocument : Document
    {
        public TXTDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath)
        {
        }

        public override string GetInfo()
        {
            return $"TXT Document: {Name}, by {Author}, Keywords: {string.Join(",", Keywords)}, Subject: {Subject}, File Path: {FilePath}";
        }
    }

    public class HTMLDocument : Document
    {
        public HTMLDocument(string name, string author, string[] keywords, string subject, string filePath)
            : base(name, author, keywords, subject, filePath)
        {
        }

        public override string GetInfo()
        {
            return $"HTML Document: {Name}, by {Author}, Keywords: {string.Join(",", Keywords)}, Subject: {Subject}, File Path: {FilePath}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DocManager docManager = DocManager.Instance;
            docManager.Menu();
        }
    }
}
