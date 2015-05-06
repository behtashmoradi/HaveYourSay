using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public class Subject : TableEntity
    {
        public string Name { get; set; }
        public Subject(Guid clientId, Guid subscriptionId, Guid subjectId, string name)
        {
            this.PartitionKey = string.Format("[Subject]-[{0}]-[{1}]", clientId, subscriptionId);
            this.RowKey = string.Format("[{0}]", subjectId);
            this.Name = name;
        }
    }
}
