// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.Tables
{
    internal static class TableConstants
    {
        internal static class HeaderNames
        {
            public const string Date = "x-ms-date";
            public const string SharedKey = "SharedKeyLite";
            public const string Authorization = "Authorization";
            public const string IfMatch = "If-Match";
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

            internal static class AccountServices
            {
                public const string Table = "t";
            }

            internal static class AccountResources
            {
                public const char Service = 's';
                public const char Container = 'c';
                public const char Object = 'o';
            }

            internal static class Permissions
            {
                public const char Read = 'r';
                public const char Write = 'w';
                public const char Delete = 'd';
                public const char List = 'l';
                public const char Add = 'a';
                public const char Update = 'u';
                public const char Process = 'p';
                public const char Create = 'c';
            }

            internal static class Parameters
            {
                public const string Version = "sv";
                public const string TableName = "tn";
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
                public const string KeyObjectId = "skoid";
                public const string KeyObjectIdUpper = "SKOID";
                public const string KeyTenantId = "sktid";
                public const string KeyTenantIdUpper = "SKTID";
                public const string KeyStart = "skt";
                public const string KeyStartUpper = "SKT";
                public const string KeyExpiry = "ske";
                public const string KeyExpiryUpper = "SKE";
                public const string KeyService = "sks";
                public const string KeyServiceUpper = "SKS";
                public const string KeyVersion = "skv";
                public const string KeyVersionUpper = "SKV";
                public const string CacheControl = "rscc";
                public const string CacheControlUpper = "RSCC";
                public const string ContentDisposition = "rscd";
                public const string ContentDispositionUpper = "RSCD";
                public const string ContentEncoding = "rsce";
                public const string ContentEncodingUpper = "RSCE";
                public const string ContentLanguage = "rscl";
                public const string ContentLanguageUpper = "RSCL";
                public const string ContentType = "rsct";
                public const string ContentTypeUpper = "RSCT";
            }
        }
    }
}
