using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public class Subscription : TableEntity
    {
        public string Name { get; set; }
        public Subscription(Guid clientId, Guid SubscriptionId, string name)
        {
            this.PartitionKey = string.Format("[{0}]", clientId);
            this.RowKey = string.Format("[{0}]", SubscriptionId);
            this.Name = name;
        }
    }
}
