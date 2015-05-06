using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaveYourSay.Domain.Model;
using HaveYourSay.Domain.Model.Repository;
using Microsoft.WindowsAzure.Storage.Table;
using PersistenceModel=HaveYourSay.Infrastructure.Persistence.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure;

namespace HaveYourSay.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CloudTable objectiveTable;
        private readonly CloudTable rateTable;
        #region constructors
        public SubjectRepository()
        {
            objectiveTable = CreateTable("Objectives").Result;
            rateTable = CreateTable("Rates").Result;
        }
        #endregion
        #region ISubjectRepository implementation
        public Guid CreateClient(Client client)
        {
            Guid id = Guid.NewGuid();
            var newClient= InsertOrMergeAsync(objectiveTable, new PersistenceModel.Client(id, client.Name));
            return id;
        }

        public Guid CreateSubscription(Guid clientId, Subscription subscription)
        {
            Guid subscriptionId = Guid.NewGuid();
            var newClient = InsertOrMergeAsync(objectiveTable, new PersistenceModel.Subscription(clientId,subscriptionId, subscription.Name));
            return subscriptionId;
        }

        public Guid CreateSubject(Guid clientId, Guid subscriptionId, ISubject subject)
        {
            Guid subjectId = Guid.NewGuid();
            var newClient = InsertOrMergeAsync(objectiveTable, new PersistenceModel.Subject(clientId, subscriptionId,subjectId, subject.Name));
            return subjectId;
        }

        public void CreateObjectives(Guid clientId, Guid subscriptionId, Guid subjectId, IEnumerable<IObjective> objectives)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscription> GetSubscriptions(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISubject> GetSubjects(Guid clientId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IObjective> GetObjectives(Guid clientId, Guid subscriptionId, Guid subjectId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private methods
        private static async Task<CloudTable> CreateTable(string tableName)
        {
            // Retrieve storage account information from connection string.
            CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            var cloudTable = tableClient.GetTableReference(tableName);
            try
            {
                if (await cloudTable.CreateIfNotExistsAsync())
                {
                    Console.WriteLine("Created Table named: {0}", tableName);
                }
                else
                {
                    Console.WriteLine("Table {0} already exists", tableName);
                }
            }
            catch (StorageException)
            {
                Console.WriteLine("If you are running with the default configuration please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return cloudTable;

        }
        private static CloudStorageAccount CreateStorageAccountFromConnectionString(string connectionstring)
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(connectionstring);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }

        private static async Task<PersistenceModel.Client> InsertOrMergeAsync(CloudTable table,PersistenceModel.Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // Create the InsertOrReplace  TableOperation
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            PersistenceModel.Client insertedEntity = result.Result as PersistenceModel.Client;
            return insertedEntity;
        }
        private static async Task<PersistenceModel.Subscription> InsertOrMergeAsync(CloudTable table, PersistenceModel.Subscription entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // Create the InsertOrReplace  TableOperation
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            var insertedRate = result.Result as PersistenceModel.Subscription;
            return insertedRate;
        }
        private static async Task<PersistenceModel.Subject> InsertOrMergeAsync(CloudTable table, PersistenceModel.Subject entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // Create the InsertOrReplace  TableOperation
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
            var insertedRate = result.Result as PersistenceModel.Subject;
            return insertedRate;
        }
        private static async Task InsertOrMergeAsync(CloudTable table, IEnumerable<PersistenceModel.Objective> objectives)
        {
            if (objectives == null)
            {
                throw new ArgumentNullException("objectives");
            }
            TableBatchOperation batchOperation = new TableBatchOperation();
            // Create the InsertOrReplace  TableOperation
            foreach (var objective in objectives)
            {
                batchOperation.InsertOrMerge(objective);
            }


            // Execute the operation.
            IList<TableResult> results = await table.ExecuteBatchAsync(batchOperation);

        }
        #endregion
    }
}
