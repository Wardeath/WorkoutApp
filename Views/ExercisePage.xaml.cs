using WorkoutApp.ViewModels;

namespace WorkoutApp.Views;

public partial class ExercisePage : ContentPage
{
	public ExercisePage(ExerciseViewModel exerciseViewModel)
	{
        
        InitializeComponent();

        BindingContext = exerciseViewModel;
    }
}