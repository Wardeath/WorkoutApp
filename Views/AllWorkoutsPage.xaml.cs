using WorkoutApp.ViewModels;

namespace WorkoutApp.Views;

public partial class AllWorkoutsPage : ContentPage
{
	public AllWorkoutsPage(AllWorkoutsViewModel allWorkoutsViewModel)
	{
		InitializeComponent();

		BindingContext = allWorkoutsViewModel;
	}
}