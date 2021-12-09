// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityContext
    {
        public CloudTable Table { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        public string ToInvokeString()
        {
            return Table.Name + "/" + PartitionKey + "/" + RowKey;
        }
    }
}