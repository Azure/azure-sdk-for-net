// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:OutputSingleModel

    public class OutputSingleModel
    {
        [FunctionName("OutputSingleModel")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET")] HttpRequest request,
            [Table("MyTable")] out MyEntity entity)
        {
            entity = new MyEntity()
            {
                PartitionKey = "<PartitionKey>",
                RowKey = "<RowKey>",
                Text = "Hello"
            };
        }
    }
    #endregion
}