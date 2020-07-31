// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    internal static class TableConstants
    {
        internal const string LegacyCosmosTableDomain = ".table.cosmosdb.";
        internal const string CosmosTableDomain = ".table.cosmos.";

        internal static class HeaderNames
        {
            public const string Date = "x-ms-date";
            public const string SharedKey = "SharedKeyLite";
            public const string Authorization = "Authorization";
            public const string IfMatch = "If-Match";
            public const string Accept = "Accept";
            public const string Content = "Content-Type";
        }

        internal static class MimeType
        {
            internal const string ApplicationJson = "application/json";
            internal const string ApplicationXml = "application/xml";
        }

        internal static class QueryParameterNames
        {
            public const string NextTableName = "NextTableName";
            public const string NextPartitionKey = "NextPartitionKey";
            public const string NextRowKey = "NextRowKey";
        }

        internal static class PropertyNames
        {
            public const string TimeStamp = "Timestamp";
            public const string PartitionKey = "PartitionKey";
            public const string RowKey = "RowKey";
            public const string Etag = "odata.etag";
        }

        internal static class Odata
        {
            internal const string OdataTypeString = "@odata.type";
            internal const string EdmBinary = "Edm.Binary";
            internal const string EdmBoolean = "Emd.Boolean";
            internal const string EdmDateTime = "Edm.DateTime";
            internal const string EdmDouble = "Edm.Double";
            internal const string EdmGuid = "Edm.Guid";
            internal const string EdmInt32 = "Edm.Int32";
            internal const string EdmInt64 = "Edm.Int64";
            internal const string EdmString = "Edm.String";
        }

        internal static class ExceptionMessages
        {
            internal const string MissingPartitionKey = "The entity must contain a PartitionKey value";
            internal const string MissingRowKey = "The entity must contain a RowKey value";
        }

        /// <summary>
        /// Sas constant values.
        /// </summary>
        internal static class Sas
        {
            // SASTimeFormat represents the format of a SAS start or expiry time. Use it when formatting/parsing a time.Time.
            // ISO 8601 uses "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
            public const string SasTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

            /// <summary>
            /// Gets the default service version to use when building shared access
            /// signatures.
            /// </summary>
            public const string DefaultSasVersion = "2019-07-07";

            internal static class Permissions
            {
                public const char Read = 'r';
                public const char Write = 'w';
                public const char Delete = 'd';
                public const char List = 'l';
                public const char Add = 'a';
                public const char Update = 'u';
                public const char Create = 'c';
            }

            internal static class Parameters
            {
                public const string Version = "sv";
                public const string TableName = "tn";
                public const string StartPartitionKey = "startpk";
                public const string EndPartitionKey = "startrk";
                public const string StartRowKey = "endpk";
                public const string EndRowKey = "endrk";
                public const string TableNameUpper = "TN";
                public const string VersionUpper = "SV";
                public const string Services = "ss";
                public const string ServicesUpper = "SS";
                public const string ResourceTypes = "srt";
                public const string ResourceTypesUpper = "SRT";
                public const string Protocol = "spr";
                public const string ProtocolUpper = "SPR";
                public const string StartTime = "st";
                public const string StartTimeUpper = "ST";
                public const string ExpiryTime = "se";
                public const string ExpiryTimeUpper = "SE";
                public const string IPRange = "sip";
                public const string IPRangeUpper = "SIP";
                public const string Identifier = "si";
                public const string IdentifierUpper = "SI";
                public const string Resource = "sr";
                public const string ResourceUpper = "SR";
                public const string Permissions = "sp";
                public const string PermissionsUpper = "SP";
                public const string Signature = "sig";
                public const string SignatureUpper = "SIG";
            }

            internal static class TableAccountResources
            {
                public const char Service = 's';
                public const char Container = 'c';
                public const char Object = 'o';
            }

            internal static class TableAccountServices
            {
                public const string Table = "t";
            }
        }
    }
}
