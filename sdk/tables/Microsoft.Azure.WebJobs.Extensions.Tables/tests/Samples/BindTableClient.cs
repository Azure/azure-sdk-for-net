// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:InputTableClient
    public class BindTableClient
    {
        [FunctionName("BindTableClient")]
        public static async Task Run([Table("MyTable")] TableClient client)
        {
            await client.AddEntityAsync(new TableEntity("<PartitionKey>", "<PartitionKey>")
            {
                ["Column"] = "Value"
            });
        }
    }
    #endregion
}