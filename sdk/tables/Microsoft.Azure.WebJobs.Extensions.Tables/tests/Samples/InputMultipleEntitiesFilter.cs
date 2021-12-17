// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:InputMultipleEntitiesFilter

    public class InputMultipleEntitiesFilter
    {
        [FunctionName("InputMultipleEntitiesFilter")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
            [Table("MyTable", "<PartitionKey>", Filter = "Text ne ''")] IEnumerable<TableEntity> entities, ILogger log)
        {
            foreach (var entity in entities)
            {
                log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity["Text"]}");
            }
        }
    }
    #endregion
}