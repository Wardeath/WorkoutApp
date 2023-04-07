using WorkoutApp.ViewModels;

namespace WorkoutApp.Views;

public partial class NewWorkoutPage : ContentPage
{
	public NewWorkoutPage(NewWorkoutViewModel newWorkoutViewModel)
	{
		InitializeComponent();

        BindingContext = newWorkoutViewModel;
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        exercisesCollection.SelectedItem = null;
        workoutCollection.SelectedItem = null;

    }
}