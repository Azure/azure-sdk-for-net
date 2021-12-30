// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:OutputMultiple
    public class OutputMultiple
    {
        [FunctionName("OutputMultiple")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST")] HttpRequest request,
            [Table("MyTable")] IAsyncCollector<TableEntity> collector)
        {
            for (int i = 0; i < 10; i++)
            {
                collector.AddAsync(new TableEntity("<PartitionKey>", i.ToString())
                {
                    ["Text"] = i.ToString()
                });
            }
        }
    }
    #endregion
}