// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Protocols
{
    /// <summary>Represents a parameter bound to a table entity in Azure Storage.</summary>
    [JsonTypeName("TableEntity")]
    public class TableEntityParameterDescriptor : ParameterDescriptor
    {
        /// <summary>Gets or sets the name of the storage account.</summary>
        public string AccountName { get; set; }

        /// <summary>Gets or sets the name of the table.</summary>
        public string TableName { get; set; }

        /// <summary>Gets or sets the partition key of the entity.</summary>
        public string PartitionKey { get; set; }

        /// <summary>Gets or sets the row key of the entity.</summary>
        public string RowKey { get; set; }
    }
}