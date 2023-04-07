using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using WorkoutApp.Models;
using WorkoutApp.Services;

namespace WorkoutApp.ViewModels
{
    [QueryProperty(nameof(MyExercise), "passExercise")]
    public partial class ExerciseViewModel : ObservableObject
    {
        [ObservableProperty]
        public Exercise myExercise;

        [ObservableProperty]
        public bool isAddButtonVisible = true;

   






        public ExerciseViewModel()

        {
            


        }

        [RelayCommand]
        private void AddSet()
        {

            if (MyExercise.Sets.Count < 4)
            {




               

                
                MyExercise.Sets.Add(new Set(MyExercise.Sets.Last().Weight, MyExercise.Sets.Last().Reps));


                int i = 1;
                foreach (var set in MyExercise.Sets)
                {
                    set.Id = i;
                    i++;
                }


                if(MyExercise.Sets.Count == 4)
                {
                    IsAddButtonVisible=false;
                }
            } 

        }

        [RelayCommand]
        private void DeleteSet(Set obj)
        {
            if (obj is Set set)
            {
                if(MyExercise.Sets.Count > 1)
                    MyExercise.Sets.Remove(set);

                int i = 1;
                foreach (var sett in MyExercise.Sets)
                {
                    sett.Id = i;
                    i++;
                }
                IsAddButtonVisible = true;
            }
            
        }
        [RelayCommand]
        private void AddWeight(Set obj)
        {
            if (obj is Set set)
            {
                
                
                set.Weight += 0.5;
                
                
            }

        }

        [RelayCommand]
        private void ReduceWeight(Set obj)
        {
            if (obj is Set set)
            {
                if (set.Weight >= 0.5)
                {
                    set.Weight -= 0.5;
                }
                

            }

        }
        [RelayCommand]
        private void AddRep(Set obj)
        {
            if (obj is Set set)
            {
                set.Reps += 1;
            }

        }

        [RelayCommand]
        private void ReduceRep(Set obj)
        {
            if (obj is Set set)
            {
                if (set.Reps >= 1)
                {
                    set.Reps -= 1;
                }
                
            }

        }


        [RelayCommand]
        private async Task SaveExercise()
        {
            await Shell.Current.GoToAsync($"..?deleteId={MyExercise.Id}&addExercise={Exercise.EscapeAndSerialize(MyExercise)}");
        }

        

        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    if (query.TryGetValue("openExercise", out object paramValue))
        //    {
        //        // Раскодируем строку

        //        MyExercise = Exercise.UnescapeAndDeserialize(paramValue);
        //        MyExercise.Sets[0].Reps = 10;

        //        OnPropertyChanged(nameof(MyExercise));


        //    }

        //}




    }
}
