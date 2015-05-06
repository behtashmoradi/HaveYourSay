using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public abstract class Objective : TableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Objective(Guid clientId, Guid subscriptionId, Guid subjectId, Guid objectiveId, string name, string description)
        {
            this.PartitionKey = string.Format("[Objective]-[{0}]-[{1}]-[{2}]", clientId, subscriptionId, subjectId);
            this.RowKey = objectiveId.ToString();
            this.Name = name;
            this.Description = description;
        }
    }
}
