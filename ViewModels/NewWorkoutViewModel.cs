using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;
using System.Text.Json;
using WorkoutApp.Models;
using WorkoutApp.Services;
using WorkoutApp.Views;
using static System.Net.Mime.MediaTypeNames;

namespace WorkoutApp.ViewModels
{
    
    public partial class NewWorkoutViewModel : ObservableObject, IQueryAttributable
    {
        public ObservableCollection<Exercise> WorkoutExercises { get; set; } = new();
        public ObservableCollection<Exercise> ChooseExercises { get; set; } = new();




        public Exercise NewExercise { get; set; } = new Exercise();

        private readonly IListOfExercisesProvider listOfExercisesProvider;
        public NewWorkoutViewModel(IListOfExercisesProvider listOfExercisesProvider)
        {

            
            this.listOfExercisesProvider = listOfExercisesProvider;

            

             



        }

        async Task FillExercises(ObservableCollection<Exercise> exercisesCol)
        {
            
            exercisesCol.Clear();

             var exercisesList = await listOfExercisesProvider.GetListOfExercises();

            foreach (var exercise in exercisesList)
            {
                exercisesCol.Add(exercise);
            }

        }


        [RelayCommand]
        private void AddSetTest()
        {
            return;
        }


        [RelayCommand]
        public async Task SelectExercise(Exercise exercise)
        {
            if (exercise != null)
            {


                await Shell.Current.GoToAsync(nameof(ExercisePage),new Dictionary<string, object>
                {
                    {"passExercise",exercise }
                } );
            }


        }

        [RelayCommand]
        public async Task Finish()
        {
            Workout workout = new Workout(WorkoutExercises, ChooseExercises, DateTime.Now);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // форматирование с отступами
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // использование camelCase для свойств
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };

            string jsonString = JsonSerializer.Serialize(workout,options);
            string filename = $"{workout.Date.ToString("ddMMyyyy_HHmm")}.workout.json";


            File.WriteAllText(Path.Combine(FileSystem.AppDataDirectory, filename), jsonString);

            await Shell.Current.GoToAsync("..");

        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("deleteId", out object deleteId))
            {
                int id = int.Parse(deleteId.ToString());


                ChooseExercises.Remove(ChooseExercises.Where(exercise => exercise.Id == id).FirstOrDefault());
                

            }
            if (query.TryGetValue("addExercise", out object exercise))
            {
                Exercise ex = Exercise.UnescapeAndDeserialize(exercise);

                Exercise.AddOrUpdateExercise(ex, WorkoutExercises);

            }
            if (query.ContainsKey("newWorkout"))
            {
                Task.Run(() => FillExercises(ChooseExercises));
            }
            if (query.TryGetValue("workout", out object workout))
            {
                if(workout is Workout workout1)
                {
                    WorkoutExercises.Clear();
                    ChooseExercises.Clear();

                    foreach (var item in workout1.WorkoutExercises)
                    {
                        WorkoutExercises.Add(item);
                    }
                    foreach (var item in workout1.ChooseExercises)
                    {
                        ChooseExercises.Add(item);
                    }

                }
            }





        }
    }




}
