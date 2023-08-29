namespace LibrarySystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            LibrarySystem librarySystem = new LibrarySystem();
            librarySystem.AddBook("The Catcher in the Rye", "J.D. Salinger", "9780316769174");
            Console.WriteLine(librarySystem.GetAvailableBooksCount());

            //Pastel Assert --> https://learn.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert?view=visualstudiosdk-2022
        }
    }
}