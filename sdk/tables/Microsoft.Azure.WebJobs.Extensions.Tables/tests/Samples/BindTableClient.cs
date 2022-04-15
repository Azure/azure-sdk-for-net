// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:InputTableClient
    public class BindTableClient
    {
        [FunctionName("BindTableClient")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequest request,
            [Table("MyTable")] TableClient client)
        {
            await client.AddEntityAsync(new TableEntity("<PartitionKey>", "<RowKey>")
            {
                ["Text"] = request.GetEncodedPathAndQuery()
            });
        }
    }
    #endregion
}