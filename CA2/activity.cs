using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{

    public enum ActivityType { Air,Water,Land}

   
    public class activity : IComparable
    {
        

        //props
        public string Name { get; set; }

        public DateTime ActivitiyDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public ActivityType Suitable { get; set; }


        //construct

        public activity(string name, DateTime activitydate,decimal cost, string description,ActivityType activitytype)
        {
            Name = name;
            ActivitiyDate = activitydate;
            Cost = cost;
            Description = description;
            Suitable = activitytype; 
        }

        

        //method 
        public override string ToString()
        {
            return $"{Name} - {ActivitiyDate}"; 
        }

        public int CompareTo(Object  obj)
        {
            activity that = (activity)obj;
            return ActivitiyDate.CompareTo(that.ActivitiyDate); 
        }
        
      


    }
}
