using System.Collections.ObjectModel;
using System.Text.Json;
using WorkoutApp.Models;

namespace WorkoutApp;

public partial class App : Application
{
   
    public App()
	{

		InitializeComponent();


        //var options = new JsonSerializerOptions
        //{
        //    WriteIndented = true, // форматирование с отступами
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // использование camelCase для свойств
        //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //};

        //string jsonString = JsonSerializer.Serialize(MyExercises, options);
        //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //string filePath = Path.Combine(desktopPath, "exercises.json");

        //File.WriteAllText(filePath, jsonString);

        
        MainPage = new AppShell();
	}
}
