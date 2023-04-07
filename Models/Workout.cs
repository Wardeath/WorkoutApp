using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class Workout
    {
        public ObservableCollection<Exercise> WorkoutExercises { get;  set; }
        public ObservableCollection<Exercise> ChooseExercises { get;  set; }

        public DateTime Date { get; set; }

        

        public string DateShow
        {
            get { return Date.ToString(); }
            
        }

        public Workout()
        {
            WorkoutExercises = new ObservableCollection<Exercise>();
            ChooseExercises = new ObservableCollection<Exercise>();
            Date = DateTime.Now;
        }
        public Workout(ObservableCollection<Exercise> workoutE, ObservableCollection<Exercise> cooseE, DateTime date)
        {
            WorkoutExercises = workoutE;
            ChooseExercises = cooseE;
            Date = date;
        }

    }
}
