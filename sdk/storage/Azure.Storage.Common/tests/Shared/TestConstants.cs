// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Test
{
    public class TestConstants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;
        public const int GB = MB * 1024;
        public const long TB = GB * 1024L;
        public const string Https = "https";
        public const int HttpPort = 443;

        public const string InvalidAccountKey = "YWFh";

        // service cache timeout is 60s, but adding a buffer to be safe
        public const int DataLakeRetryDelay = 70000;
        public const int RetryDelay = 10000;

        // quick query fails with with connection reset, retry until it's solved properly https://github.com/Azure/azure-sdk-for-net/issues/17403
        public const int QuickQueryRetryCount = 5;

        public string CacheControl { get; private set; }
        public string ContentDisposition { get; private set; }
        public string ContentEncoding { get; private set; }
        public string ContentLanguage { get; private set; }
        public string ContentType { get; private set; }
        public byte[] ContentMD5 { get; private set; }
        public SasConstants Sas { get; private set; }

        private TestConstants()
        {
        }

        public class SasConstants
        {
            public string KeyObjectId { get; } = "KeyOid";
            public string KeyTenantId { get; } = "KeyTid";
            public string KeyService { get; } = "KeyService";
            public string KeyVersion { get; } = "KeyVersion";
            public string DelegatedObjectId { get; } = "DelegatedOid";
            public string KeyValue { get; } = Convert.ToBase64String(Encoding.UTF8.GetBytes("value"));
            public SasProtocol Protocol { get; } = SasProtocol.Https;

            public string Account { get; protected internal set; }
            public string Identifier { get; protected internal set; }
            public string CacheControl { get; protected internal set; }
            public string ContentDisposition { get; protected internal set; }
            public string ContentEncoding { get; protected internal set; }
            public string ContentLanguage { get; protected internal set; }
            public string ContentType { get; protected internal set; }
            public string EncryptionScope { get; protected internal set; }
            public string AccountKey { get; protected internal set; }
            public DateTimeOffset StartTime { get; protected internal set; }
            public DateTimeOffset ExpiryTime { get; protected internal set; }
            public IPAddress StartAddress { get; protected internal set; }
            public IPAddress EndAddress { get; protected internal set; }
            public SasIPRange IPRange { get; protected internal set; }
            public DateTimeOffset KeyStart { get; protected internal set; }
            public DateTimeOffset KeyExpiry { get; protected internal set; }

            public StorageSharedKeyCredential SharedKeyCredential { get; protected internal set; }
        }

        public static TestConstants Create<TStorageTestEnvironment>(StorageTestBase<TStorageTestEnvironment> test) where TStorageTestEnvironment : StorageTestEnvironment, new()
        {
            var testConstants = new TestConstants()
            {
                CacheControl = test.GetNewString(),
                ContentDisposition = test.GetNewString(),
                ContentEncoding = test.GetNewString(),
                ContentLanguage = test.GetNewString(),
                ContentType = test.GetNewString(),
                ContentMD5 = MD5.Create().ComputeHash(test.GetRandomBuffer(16)),

                Sas = new SasConstants
                {
                    Account = test.GetNewString(),
                    Identifier = test.GetNewString(),
                    CacheControl = test.GetNewString(),
                    ContentDisposition = test.GetNewString(),
                    ContentEncoding = test.GetNewString(),
                    ContentLanguage = test.GetNewString(),
                    ContentType = test.GetNewString(),
                    EncryptionScope = test.GetNewString(),
                    AccountKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(test.GetNewString())),
                    StartTime = test.GetUtcNow().AddHours(-1),
                    ExpiryTime = test.GetUtcNow().AddHours(+1),
                    StartAddress = test.GetIPAddress(),
                    EndAddress = test.GetIPAddress(),
                    KeyStart = test.GetUtcNow().AddHours(-1),
                    KeyExpiry = test.GetUtcNow().AddHours(+1),
                },
            };
            testConstants.Sas.IPRange = new SasIPRange(testConstants.Sas.StartAddress, testConstants.Sas.EndAddress);
            testConstants.Sas.SharedKeyCredential = new StorageSharedKeyCredential(testConstants.Sas.Account, testConstants.Sas.AccountKey);
            return testConstants;
        }
    }
}
