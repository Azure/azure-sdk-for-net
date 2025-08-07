// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Data.Tables.Tests;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Data.Tables.Samples
{
    public partial class TablesSamples : TablesTestEnvironment
    {
        [Test]
        public async Task CustomizeSerialization()
        {
            string storageUri = StorageUri;
            string tableName = "OfficeSupplies" + _random.Next();

#region Snippet:TablesSample7ModelProperties
            // Construct a new TableClient using a TokenCredential.
            var client = new TableClient(
                new Uri(storageUri),
                tableName,
#if SNIPPET
                new DefaultAzureCredential());
#else
                Credential);
#endif

            // Create the table if it doesn't already exist.
            client.CreateIfNotExists();

            // Create a new entity with our customization attributes.
            var entity = new CustomSerializationEntity
            {
                PartitionKey = "CustomInventory",
                RowKey = "special stock",
                Product = "Fancy Marker",
                Price = 1.00,
                Quantity = 42,
                IgnoreMe = "nothing to see here",
                RenameMe = "This property will be saved to the table as 'rename_me'"
            };

            // Add the entity to the table. It will be serialized according to our customizations.
            await client.AddEntityAsync(entity);

            // Fetch the entity as a TableEntity so that we can verify that things were serialized as expected.
            var fetchedEntity = await client.GetEntityAsync<TableEntity>(entity.PartitionKey, entity.RowKey);

            // Print each property name to the console.
            foreach (string propertyName in fetchedEntity.Value.Keys)
            {
                Console.WriteLine(propertyName);
            }
            /*
            Console output:

            odata.etag
            PartitionKey
            RowKey
            Timestamp
            Product
            Price
            Quantity
            rename_me
            */
        }
#endregion

#region Snippet:TablesSample7ModelPropertiesClass

        // Define a strongly typed entity by implementing the ITableEntity interface.
        public class CustomSerializationEntity : ITableEntity
        {
            public string Product { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }

            [IgnoreDataMember] public string IgnoreMe { get; set; }

            [DataMember(Name = "rename_me")] public string RenameMe { get; set; }
        }
#endregion
    }
}
