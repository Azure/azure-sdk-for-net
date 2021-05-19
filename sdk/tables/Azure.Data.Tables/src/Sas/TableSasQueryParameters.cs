// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// A <see cref="TableSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="TableSasBuilder"/>.
    ///
    /// For more information, <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">Create a service SAS</see>.
    /// </summary>
    public sealed class TableSasQueryParameters : TableAccountSasQueryParameters
    {
        internal string TableName { get; set; }

        /// <summary>
        /// The start of PartionKey range.
        /// </summary>
        public string StartPartitionKey { get; set; }

        /// <summary>
        /// The end of PartionKey range.
        /// </summary>
        public string StartRowKey { get; set; }

        /// <summary>
        /// The start of RowKey range.
        /// </summary>
        public string EndPartitionKey { get; set; }

        /// <summary>
        /// The end of RowKey range.
        /// </summary>
        public string EndRowKey { get; set; }

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static TableSasQueryParameters Empty => new TableSasQueryParameters();

        internal TableSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new TableSasQueryParameters instance.
        /// </summary>
        internal TableSasQueryParameters(
            string version,
            TableAccountSasResourceTypes? resourceTypes,
            string tableName,
            string partitionKeyStart,
            string rowKeyStart,
            string partitionKeyEnd,
            string rowKeyEnd,
            TableSasProtocol protocol,
            DateTimeOffset startsOn,
            DateTimeOffset expiresOn,
            TableSasIPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature)
            : base(
                version,
                resourceTypes,
                protocol,
                startsOn,
                expiresOn,
                ipRange,
                identifier,
                resource,
                permissions,
                signature)
        {
            TableName = tableName;
            StartPartitionKey = partitionKeyStart;
            EndPartitionKey = partitionKeyEnd;
            StartRowKey = rowKeyStart;
            EndRowKey = rowKeyEnd;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TableSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal TableSasQueryParameters(
            IDictionary<string, string> values)
            : base(values)
        {
            foreach (var key in values.Keys.ToList())
            {
                // these are already decoded
                var isSasKey = true;
                switch (key.ToUpperInvariant())
                {
                    case TableConstants.Sas.Parameters.TableNameUpper:
                        TableName = values[key];
                        break;

                    // We didn't recognize the query parameter
                    default:
                        isSasKey = false;
                        break;
                }

                // Set the value to null if it's part of the SAS
                if (isSasKey)
                {
                    values[key] = null;
                }
            }
        }

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendQueryParameter(TableConstants.Sas.Parameters.TableName, TableName);
            if (!string.IsNullOrWhiteSpace(StartPartitionKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.StartPartitionKey, StartPartitionKey);
            }
            if (!string.IsNullOrWhiteSpace(EndPartitionKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.EndPartitionKey, EndPartitionKey);
            }
            if (!string.IsNullOrWhiteSpace(StartRowKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.StartRowKey, StartRowKey);
            }
            if (!string.IsNullOrWhiteSpace(EndRowKey))
            {
                sb.AppendQueryParameter(TableConstants.Sas.Parameters.EndRowKey, EndRowKey);
            }
            this.AppendProperties(sb);
            return sb.ToString();
        }
    }
}
