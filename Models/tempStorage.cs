using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.Models
{
    public static class tempStorage
    {
        private static List<AppResponse> applications = new List<AppResponse>();

        public static IEnumerable<AppResponse> Applications => applications;

        public static void AddApplication(AppResponse application)
        {
            applications.Add(application);
        }
    }
}
