// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;

namespace Azure.Storage
{
    internal static class Constants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public const int GB = MB * 1024;
        public const long TB = GB * 1024L;

        public const int MaxReliabilityRetries = 5;

        /// <summary>
        /// Gets the default service version to use when building shared access
        /// signatures.
        /// </summary>
        public const string DefaultSasVersion = "2018-11-09";

        public const int DefaultBufferSize = 4 * Constants.MB;
        public const int DefaultMaxTotalBufferAllowed = 100 * Constants.MB;

        public const string CloseAllHandles = "*";

        public const string ISO8601Format = "yyyy-MM-ddTHH:mm:ssZ";

        internal static class Sas
        {
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
                public const string KeyOid = "skoid";
                public const string KeyOidUpper = "SKOID";
                public const string KeyTid = "sktid";
                public const string KeyTidUpper = "SKTID";
                public const string KeyStart = "skt";
                public const string KeyStartUpper = "SKT";
                public const string KeyExpiry = "ske";
                public const string KeyExpiryUpper = "SKE";
                public const string KeyService = "sks";
                public const string KeyServiceUpper = "SKS";
                public const string KeyVersion = "skv";
                public const string KeyVersionUpper = "SKV";
            }

            internal static class Resource
            {
                public const string BlobSnapshot = "bs";
                public const string Blob = "b";
                public const string Container = "c";
                public const string File = "f";
                public const string Share = "s";
            }

            internal static class AccountServices
            {
                public const char Blob = 'b';
                public const char Queue = 'q';
                public const char File = 'f';
            }

            internal static class AccountResources
            {
                public const char Service = 's';
                public const char Container = 'c';
                public const char Object = 'o';
            }
        }
    }
}
