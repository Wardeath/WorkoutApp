using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WorkoutApp.Models
{
    public class Exercise 
    {
        
        public string Name { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }

        public double WeightMid
        {
            get
            {
                if(Sets.Count != 0)
                {
                    double sum = 0;
                    foreach (var item in Sets)
                    {
                        sum += item.Weight;
                    }
                    double result = sum / Sets.Count;
                    return result;
                }
                else { return 0; }

                
            }

        }

        public double RepsMid
        {
            get
            {
                if (Sets.Count != 0)
                {
                    double sum = 0;
                    foreach (var item in Sets)
                    {
                        sum += item.Reps;
                    }
                    double result = sum / Sets.Count;
                    return result;
                }
                else { return 0; }


            }

        }

        


        public ObservableCollection<Set> Sets { get; set; } = new() { new Set(0, 0) };
        
        public Exercise()
        {
           
            
        }
        public Exercise(int id, string name, string image)
        {
            Name = name;
            Id = id;
            Image = image;
            
            

        }
        public Exercise(int id, string name)
        {
            Name = name;
            
            Id = id;
            
            
        }

        public static string EscapeAndSerialize (object obj)
        {
            return Uri.EscapeDataString(JsonSerializer.Serialize(obj as Exercise));
        }

        public static Exercise UnescapeAndDeserialize(object obj)
        {
            string decodedValue = Uri.UnescapeDataString(obj.ToString());
            return JsonSerializer.Deserialize<Exercise>(decodedValue);
        }

        public static void AddOrUpdateExercise(Exercise exercise , ObservableCollection<Exercise> colection)
        {
            Exercise findElement = colection.FirstOrDefault(c => c.Name == exercise.Name);

            if (findElement != null)
            {
                int index = colection.IndexOf(findElement);
                colection[index] = exercise;
                
            }
            else
            {
                colection.Add(exercise);
                
            }
        }

    }
}
