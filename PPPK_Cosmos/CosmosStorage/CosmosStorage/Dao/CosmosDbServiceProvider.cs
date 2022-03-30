using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CosmosStorage.Dao
{
    public static class CosmosDbServiceProvider
    {
        public const string DatabaseName = "Tasks";
        public const string ContainerName = "Tasks";
        public const string Account = "https://todoitems20.documents.azure.com:443/";
        public const string Key = "3Dz5HiEMaoyLxQPhJBRGbM1ntFt7t7qp9y29j7aGr2FZXMvBx7dqdKO6U7mRvD7a9HAmXPoz5lCzuUuK60VZgw==";
        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }

    }
}