// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:InputSingleModel
    public class InputSingleModel
    {
        [FunctionName("InputSingleModel")]
        public static void Run([Table("MyTable", "<PartitionKey>", "<RowKey>")] MyEntity entity, ILogger log)
        {
            log.LogInformation($"PK={entity.PartitionKey}, RK={entity.RowKey}, Text={entity.Text}");
        }
    }
    #endregion
}