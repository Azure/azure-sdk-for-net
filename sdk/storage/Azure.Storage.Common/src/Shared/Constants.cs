// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;

namespace Microsoft.Azure.Storage
{
    internal class Constants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public const int GB = MB * 1024;
        public const long TB = GB * 1024L;

        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        internal static Random Random => random.Value;

        internal static string TargetStorageVersion = "2018-03-28";
        internal static string ClientRequestIdHeader = "x-ms-client-request-id";
        internal static string SnapshotParameter = "snapshot";
        internal static string HttpsScheme = "https";

        public static string UserAgentHeader { get; internal set; }
        public static string UserAgentPrefix { get; internal set; }
        public static string UserAgentVersion { get; internal set; }

        internal class Sas
        {
            internal class Permissions
            {
                internal const char Read = 'r';
                internal const char Add = 'a';
                internal const char Create = 'c';
                internal const char Write = 'w';
                internal const char Delete = 'd';
                internal const char List = 'l';
                internal const char Update = 'u';
                internal const char Process = 'p';
            }
            
            internal class Resource
            {
                internal const string Container = "c";
                internal const string Blob = "b";

                internal const string Share = "s";
                internal const string File = "f";

            }

        }
    }
}
