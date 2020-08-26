using System;
using System.Collections.Generic;

namespace helpers
{
    public class RandomManager
    {
        public delegate void Job();

        UInt32 counter = 0;
        public List<(int, Job, string)> Jobs = new List<(int, Job, string)>();

        public void AddJob(int frequency, Job job, string message = "")
        {
            Jobs.Add((frequency, job, message));
        }

        public void Manage()
        {
            counter++;
            foreach ((int, Job, string) job in Jobs.ToArray())
            {  
                // if frequency can be modulated by the counter
                if (counter % job.Item1 == 0)
                {
                    // do the job
                    job.Item2();

                    // do message if not empty
                    if (job.Item3 != "")
                    {
                        Console.WriteLine($"[JOB MANAGER]: {job.Item3}");
                    }
                }
            }
        }
    }
}
