using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityFarmActivities.Data
{
    public class ActivityName
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public bool Complete { get; set; }
        public string Owner { get; set; }
    }
}
