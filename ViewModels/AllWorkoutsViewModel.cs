using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkoutApp.Models;
using WorkoutApp.Views;

namespace WorkoutApp.ViewModels
{
    public partial class AllWorkoutsViewModel
    {
        public ObservableCollection<Workout> Workouts { get; set; }

        public AllWorkoutsViewModel()
        {
            Workouts = new ObservableCollection<Workout>();

            string appDataPath = FileSystem.AppDataDirectory;

            

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // форматирование с отступами
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // использование camelCase для свойств
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            IEnumerable<Workout> workouts = Directory
                .EnumerateFiles(appDataPath, "*.workout.json")
                .Select(file => JsonSerializer.Deserialize<Workout>(File.ReadAllText(file),options))
                .OrderBy(workout => workout.Date);

            if (workouts.Any())
            {
                foreach (var workout in workouts)
                {
                    Workouts.Add(workout);
                }
            }

        }
        [RelayCommand]
        public async Task SelectWorkout(Workout workout)
        {
            if (workout != null)
            {



                await Shell.Current.GoToAsync(nameof(NewWorkoutPage), new Dictionary<string, object>
                {
                    {"workout",workout }
                    
                });
            }
        }
    }
}
