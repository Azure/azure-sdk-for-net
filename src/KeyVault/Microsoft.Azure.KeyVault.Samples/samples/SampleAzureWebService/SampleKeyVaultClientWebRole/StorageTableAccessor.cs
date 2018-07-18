// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using SampleKeyVaultClientWebRole.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SampleKeyVaultClientWebRole
{
    /// <summary>
    /// Azure Storage Table operations: Add entity and retrieve entities
    /// </summary>
    public class StorageTableAccessor
    {
        private const string messageTableName = "SampleKeyVaultClientMessageTable";
        private const string messageTablePartitionKey = "1";
        private CloudTable table;
        private static ulong lastRowKey = 0;
        public StorageTableAccessor(CloudStorageAccount storageAccount)
        {
            CloudTableClient tableClient = new CloudTableClient(storageAccount.TableStorageUri, storageAccount.Credentials);
            this.table = tableClient.GetTableReference(messageTableName);
            this.table.CreateIfNotExists();
            ReadFirstEntry();
        }

        /// <summary>
        /// Get the required number of entries from storage
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private IEnumerable<Message> GetEntriesInPartition(string partitionKey, int num)
        {
            var query = new TableQuery<Message>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey))
                .Take(num);
            return table.ExecuteQuery(query);
        }

        /// <summary>
        /// Read the top entry, just to get the next row key to use. See AddEntry
        /// method for row key design.
        /// 
        /// If we have an empty table, then start with max value.
        /// </summary>
        private void ReadFirstEntry()
        {            
            var first = GetEntriesInPartition(messageTablePartitionKey, 1).FirstOrDefault();

            if (first != null)
            {
                lastRowKey = ulong.Parse(first.RowKey, CultureInfo.InvariantCulture);
            }
            else
            {
                lastRowKey = ulong.MaxValue;
            }
        }

        /// <summary>
        /// Get the most recent 10 entries from storage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Message> GetRecentEntries()
        {
            return GetEntriesInPartition(messageTablePartitionKey, 10);
        }

        /// <summary>
        /// Add an entry into storage. 
        /// 
        /// Use a constant partition key. This is a sample app not designed for scale.
        /// 
        /// Use a row key that's a decreasing number each time,
        /// so that we can later retrieve most-recent entries easily. Row key determines
        /// the order in which storage table entities are returned.
        /// </summary>
        /// <param name="message"></param>
        public void AddEntry(Message message)
        {
            var entry = new Message(message.UserName, message.MessageText);
            entry.PartitionKey = messageTablePartitionKey;

            checked { --lastRowKey; }
            entry.RowKey = lastRowKey.ToString("D20", CultureInfo.InvariantCulture);
            entry.CreationTime = DateTime.Now;

            var operation = TableOperation.Insert(entry);
            table.Execute(operation);
        }

    }
}