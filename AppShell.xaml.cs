
using WorkoutApp.Views;

namespace WorkoutApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewWorkoutPage),typeof(NewWorkoutPage));
		Routing.RegisterRoute(nameof(ExercisePage),typeof(ExercisePage));
		Routing.RegisterRoute(nameof(AllWorkoutsPage),typeof(AllWorkoutsPage));
        

    }
}
