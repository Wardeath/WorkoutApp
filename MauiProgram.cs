using Microsoft.Extensions.Logging;

using WorkoutApp.Services;
using WorkoutApp.ViewModels;
using WorkoutApp.Views;

namespace WorkoutApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
#if DEBUG
		builder.Logging.AddDebug();

#endif
		builder.Services.AddSingleton<IListOfExercisesProvider>(new ListOfExercisesFromJson());
		builder.Services.AddTransient<NewWorkoutPage>();
		builder.Services.AddTransient<NewWorkoutViewModel>();


        builder.Services.AddTransient<ExerciseViewModel>();
        builder.Services.AddTransient<ExercisePage>();

        builder.Services.AddTransient<AllWorkoutsViewModel>(); 
        builder.Services.AddTransient<AllWorkoutsPage>();

        return builder.Build();
	}
}
