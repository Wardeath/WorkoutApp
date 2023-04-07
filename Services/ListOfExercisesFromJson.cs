

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkoutApp.Models;

namespace WorkoutApp.Services
{
    public class ListOfExercisesFromJson : IListOfExercisesProvider
    {
        List<Exercise> exerciseList;
        public async Task<List<Exercise>> GetListOfExercises()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("exercises.json");
           
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // форматирование с отступами
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // использование camelCase для свойств
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            exerciseList = JsonSerializer.Deserialize<List<Exercise>>(contents, options);
            
            return exerciseList;


        }
    }
}
