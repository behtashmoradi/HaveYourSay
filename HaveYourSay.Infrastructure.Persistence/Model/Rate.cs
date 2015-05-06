using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaveYourSay.Infrastructure.Persistence.Model
{
    public abstract class Rate : TableEntity
    {
        public Rate(Guid clientId, Guid subscriptionId, Guid subjectId, Guid obectiveId)
        {
            this.PartitionKey = string.Format("[{0}]-[{1}]-[{2}]", clientId, subscriptionId, subjectId);
            this.RowKey = obectiveId.ToString();

        }
    }
}
