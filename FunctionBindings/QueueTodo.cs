using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionBindings
{
    public static class QueueTodo
    {
        [FunctionName("QueueTodo")]
        public static void Run(
            [QueueTrigger("todoactions")]string myQueueItem,
            [CosmosDB(
                databaseName: "ToDoItems",
                collectionName: "Items",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "{ToDoItemId}",
                PartitionKey = "{ToDoItemPartitionKeyValue}")] db,
            ILogger log
        )
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
