//-----------------------------------------------------------------------
// <copyright file="TableConstants.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if DNCP
    public
#else
    internal
#endif
 class TableConstants
    {
        /// <summary>
        /// Stores the header prefix for continuation information.
        /// </summary>
        public const string TableServicePrefixForTableContinuation = "x-ms-continuation-";

        /// <summary>
        /// Stores the header suffix for the next partition key.
        /// </summary>
        public const string TableServiceNextPartitionKey = "NextPartitionKey";

        /// <summary>
        /// Stores the header suffix for the next row key.
        /// </summary>
        public const string TableServiceNextRowKey = "NextRowKey";

        /// <summary>
        /// Stores the table suffix for the next table name.
        /// </summary>
        public const string TableServiceNextTableName = "NextTableName";

        /// <summary>
        /// Stores the maximum results the table service can return.
        /// </summary>
        public const int TableServiceMaxResults = 1000;

        /// <summary>
        /// The maximum size of a string property for the table service in bytes.
        /// </summary>
        internal const int TableServiceMaxStringPropertySizeInBytes = 64 * 1024;

        /// <summary>
        /// The maximum size of a string property for the table service in bytes.
        /// </summary>
        internal const long TableServiceMaxPayload = 20 * Constants.MB;

        /// <summary>
        /// The maximum size of a string property for the table service in chars.
        /// </summary>
        internal const int TableServiceMaxStringPropertySizeInChars = TableServiceMaxStringPropertySizeInBytes / 2;

        /// <summary>
        /// The name of the special table used to store tables.
        /// </summary>
        internal const string TableServiceTablesName = "Tables";

        /// <summary>
        /// XML element for table error codes.
        /// </summary>
        internal const string TableErrorCodeElement = "code";

        /// <summary>
        /// XML element for table error messages.
        /// </summary>
        internal const string TableErrorMessageElement = "message";

        /// <summary>
        /// The name of the partition key property.
        /// </summary>
        internal const string PartitionKey = "PartitionKey";

        /// <summary>
        /// The name of the row key property.
        /// </summary>
        internal const string RowKey = "RowKey";

        /// <summary>
        /// The name of the Timestamp property.
        /// </summary>
        internal const string Timestamp = "Timestamp";

        /// <summary>
        /// The name of the special table used to store tables.
        /// </summary>
        internal const string Tables = "Tables";

        /// <summary>
        /// The name of the property that stores the table name.
        /// </summary>
        internal const string TableName = "TableName";

        /// <summary>
        /// The query filter clause name.
        /// </summary>
        internal const string Filter = "$filter";

        /// <summary>
        /// The query top clause name.
        /// </summary>
        internal const string Top = "$top";

        /// <summary>
        /// The query select clause name.
        /// </summary>
        internal const string Select = "$select";

        /// <summary>
        /// The minimum DateTime supported.
        /// </summary> 
        public static readonly DateTimeOffset MinDateTime = new DateTimeOffset(1601, 1, 1, 0, 0, 0, TimeSpan.Zero);
    }
}