using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public class QuantitiveRate : Rate
    {
        public int RateValue { get; set; }
        public QuantitiveRate(Guid clientId, Guid subscriptionId, Guid subjectId, Guid obectiveId, int rateValue)
            : base(clientId, subscriptionId, subjectId, obectiveId)
        {
            this.RateValue = rateValue;
        }

    }
}
