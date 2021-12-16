// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:OutputSingle

    public class OutputSingle
    {
        [FunctionName("OutputSingle")]
        public static void Run([Table("MyTable")] out TableEntity entity)
        {
            entity = new TableEntity("<PartitionKey>", "<PartitionKey>")
            {
                ["Text"] = "Hello"
            };
        }
    }
    #endregion
}