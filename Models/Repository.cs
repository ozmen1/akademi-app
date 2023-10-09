using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BtkAkademi.Models
{
    public static class Repository
    {
        private static List<Candidate> applications = new List<Candidate> ();
        public static IEnumerable<Candidate> Applications => applications;

        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }
    }
}