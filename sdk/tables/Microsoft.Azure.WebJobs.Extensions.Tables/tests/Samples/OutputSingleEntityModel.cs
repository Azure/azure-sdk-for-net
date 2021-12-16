// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests.Samples
{
    #region Snippet:OutputSingleModel

    public class OutputSingleModel
    {
        [FunctionName("OutputSingleModel")]
        public static void Run([Table("MyTable")] out MyEntity entity)
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