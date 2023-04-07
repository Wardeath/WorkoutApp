
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutApp.Views;

namespace WorkoutApp.ViewModels
{
     partial class MainViewModel : ObservableObject
    {

        

        [RelayCommand]
        private async Task GoToNew()
        {
            await Shell.Current.GoToAsync($"{nameof(NewWorkoutPage)}?newWorkout=1");
        }

        [RelayCommand]
        private async Task GoToWorkouts()
        {
            await Shell.Current.GoToAsync(nameof(AllWorkoutsPage));
        }
    }
}
