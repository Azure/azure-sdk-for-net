// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:InputSingle
    public class InputSingle
    {
        [FunctionName("InputSingle")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
            [Table("MyTable", "<PartitionKey>", "<RowKey>")] TableEntity entity, ILogger log)
        {
            log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity["Text"]}");
        }
    }
    #endregion
}