using System;

namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
{
    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.

    // EN : The Singleton should always be a 'sealed' class to prevent class
    // inheritance through external classes and also through nested classes.
    public sealed class PusatDataSingleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private PusatDataSingleton()
        {
            DataTersimpan =new List<string>();
        }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static PusatDataSingleton _instance;

        public List<string> DataTersimpan { get; private set; }
        public string input { get; private set; }
        public int index { get; private set; }

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static PusatDataSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PusatDataSingleton();
            }
            return _instance;
        }

        
        public List<string>GetSemuaData()
        {
            return DataTersimpan;
        }
        public void PrintSemuaData()
        {
            for(int i = 0; i<DataTersimpan.Count; i++)
            {
                Console.WriteLine(DataTersimpan[i]);
            }
        }
        public void AddSebuahData(string input)
        {
            DataTersimpan.Add(input);
        }
        public void HapusSemuaData(int index)
        {
            DataTersimpan.RemoveAt(index);
        }
        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public void someBusinessLogic()
        {
            // ...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            PusatDataSingleton Data1 = PusatDataSingleton.GetInstance();
            PusatDataSingleton Data2 = PusatDataSingleton.GetInstance();

            Data1.AddSebuahData("Yesa Krisanto Sihombing");
            Data1.AddSebuahData("Hermawan Saputra");
            Data1.AddSebuahData("Arzaq Ajradika");
            Data1.AddSebuahData("Triani Putri Mumpuni");
            Data1.AddSebuahData("Dhafa Arrizki Gusman");

            Data2.PrintSemuaData();
            Console.WriteLine("Nama Anggota Kelompok 4: ");
            Data2.HapusSemuaData(0);
            Data1.PrintSemuaData();

            Console.WriteLine("Berikut Data Count : ");
            List<string>List1= Data1.GetSemuaData();
            List<string>List2 = Data2.GetSemuaData();
            Console.WriteLine("Data 1: "+List1.Count);
            Console.WriteLine("Data 2: "+List2.Count);
        }
    }
}
