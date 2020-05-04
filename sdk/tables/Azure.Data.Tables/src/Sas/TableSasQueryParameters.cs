// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// A <see cref="TableSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="TableSasBuilder"/>.
    ///
    /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas"/>.
    /// </summary>
    public sealed class TableSasQueryParameters : SasQueryParameters
    {
        internal string TableName { get; set; }

        public static new TableSasQueryParameters Empty => new TableSasQueryParameters();

        internal TableSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new TableSasQueryParameters instance.
        /// </summary>
        internal TableSasQueryParameters (
            string version,
            string tableName,
            AccountSasServices? services,
            AccountSasResourceTypes? resourceTypes,
            SasProtocol protocol,
            DateTimeOffset startsOn,
            DateTimeOffset expiresOn,
            SasIPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature,
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default)
            : base(
                version,
                services,
                resourceTypes,
                protocol,
                startsOn,
                expiresOn,
                ipRange,
                identifier,
                resource,
                permissions,
                signature,
                cacheControl,
                contentDisposition,
                contentEncoding,
                contentLanguage,
                contentType)
        {
            TableName = tableName;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="TableSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal TableSasQueryParameters (
            IDictionary<string, string> values)
            : base(values)
        {
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
            this.AppendProperties(sb);
            return sb.ToString();
        }
    }
}
