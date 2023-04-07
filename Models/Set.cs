using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public partial class Set : ObservableObject
    {
        [ObservableProperty]
        public int reps = 0;

        [ObservableProperty]
        public double weight = 0;

        public Set(double weight,int reps)
        {
            
            Weight = weight;
            Reps = reps;
        }

        [ObservableProperty]
        public int id = 1;


    }
}
