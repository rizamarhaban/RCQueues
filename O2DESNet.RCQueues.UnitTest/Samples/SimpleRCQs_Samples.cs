﻿using System;
using System.Collections.Generic;

namespace O2DESNet.RCQueues.UnitTest
{
    public static class SimpleRCQs_Samples
    {
        public static SimpleRCQs.Statics Sample1()
        {
            return SimpleRCQs.Statics.ReadFromCSVs("SimpleRCQ\\Sample1");
        }
        public static SimpleRCQs.Statics Sample1s()
        {
            return SimpleRCQs.Statics.ReadFromCSVs("SimpleRCQ\\Sample1s");
        }

        public static SimpleRCQs.Statics Sample2()
        {
            var simpleRCQs = new SimpleRCQs.Statics();
            simpleRCQs.AddResource("Res1", 10, "Resource #1");
            simpleRCQs.AddResource("Res2", 3, "Resource #1");
            simpleRCQs.AddActivity("Act1", rs => TimeSpan.FromMinutes(rs.NextDouble() * 5), description: "Activity #1");
            simpleRCQs.AddActivity("Act2", rs => TimeSpan.FromMinutes(rs.NextDouble() * 4),
                new List<(string, double)>
                {
                    ("Res1", 6),
                    ("Res2", 2),
                });
            simpleRCQs.AddActivity("Act3", rs => TimeSpan.FromMinutes(rs.NextDouble() * 4),
                new List<(string, double)>
                {
                    ("Res1", 4),
                    ("Res2", 1),
                });
            simpleRCQs.AddSucceeding("Act1", "Act2", 1);
            simpleRCQs.AddSucceeding("Act1", "Act3", 1);
            simpleRCQs.Generator.MeanHourlyRate = 10;
            return simpleRCQs;
        }
    }
}
