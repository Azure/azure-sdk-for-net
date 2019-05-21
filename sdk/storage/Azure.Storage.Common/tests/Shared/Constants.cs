// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Azure.Storage.Common;

namespace Azure.Storage.Test
{
    internal static class Constants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public const int GB = MB * 1024;
        public const long TB = GB * 1024L;

        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static readonly string CacheControl = TestHelper.GetNewString();
        public static readonly string ContentDisposition = TestHelper.GetNewString();
        public static readonly string ContentEncoding = TestHelper.GetNewString();
        public static readonly string ContentLanguage = TestHelper.GetNewString();
        public static readonly string ContentType = TestHelper.GetNewString();
        public static readonly byte[] ContentMD5 = MD5.Create().ComputeHash(TestHelper.GetRandomBuffer(16));

        public static Random Random => random.Value;
        internal static class Sas
        {
            public static readonly string Version = TestHelper.GetNewString();
            public static readonly string Account = TestHelper.GetNewString();
            public static readonly string Identifier = TestHelper.GetNewString();
            public static readonly string CacheControl = TestHelper.GetNewString();
            public static readonly string ContentDisposition = TestHelper.GetNewString();
            public static readonly string ContentEncoding = TestHelper.GetNewString();
            public static readonly string ContentLanguage = TestHelper.GetNewString();
            public static readonly string ContentType = TestHelper.GetNewString();
            public static readonly SasProtocol Protocol = SasProtocol.Https;
            public static readonly string AccountKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(TestHelper.GetNewString()));
            public static readonly DateTimeOffset StartTime = DateTimeOffset.UtcNow.AddHours(-1);
            public static readonly DateTimeOffset ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1);
            public static readonly IPAddress startAddress = TestHelper.GetIPAddress();
            public static readonly IPAddress endAddress = TestHelper.GetIPAddress();
            public static readonly IPRange IPRange = new IPRange
            {
                Start = startAddress,
                End = endAddress
            };
            public static readonly string KeyOid = "KeyOid";
            public static readonly string KeyTid = "KeyTid";
            public static readonly DateTimeOffset KeyStart = DateTimeOffset.UtcNow.AddHours(-1);
            public static readonly DateTimeOffset KeyExpiry = DateTimeOffset.UtcNow.AddHours(1);
            public static readonly string KeyService = "KeyService";
            public static readonly string KeyVersion = "KeyVersion";
            public static readonly string KeyValue = Convert.ToBase64String(Encoding.UTF8.GetBytes("value"));
            public static readonly SharedKeyCredentials SharedKeyCredential
                = new SharedKeyCredentials(Account, AccountKey);
        }
    }
}
