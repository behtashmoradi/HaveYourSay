using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public class QuantitiveObjective : Objective
    {
        public double Summary { get; set; }
        public QuantitiveObjective(Guid clientId, Guid subscriptionId, Guid subjectId, Guid objectiveId, string name, string description)
            : base(clientId, subscriptionId, subjectId, objectiveId, name, description)
        {
            Summary = 0;
        }
    }
}
