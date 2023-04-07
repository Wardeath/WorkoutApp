using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutApp.Models;

namespace WorkoutApp.Services
{
    public interface IListOfExercisesProvider
    {
         Task<List<Exercise>> GetListOfExercises();


    }
}
