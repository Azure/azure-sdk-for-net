// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Sas;
using Azure.Storage.Tests.Shared;
using Microsoft.Identity.Client;
using NUnit.Framework;
using Azure.Core.TestFramework.Models;
using Newtonsoft.Json.Linq;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Test.Shared
{
    public abstract partial class StorageTestBase<TEnvironment> : RecordedTestBase<TEnvironment> where TEnvironment : StorageTestEnvironment, new()
    {
        static StorageTestBase()
        {
            // .NET framework defaults to 2, which causes issues for the parallel upload/download tests. Go out of bound like .NET Core does.
#if !NETCOREAPP
            ServicePointManager.DefaultConnectionLimit = int.MaxValue;
#endif
            // To avoid threadpool starvation when we run live tests in parallel.
            ThreadPool.SetMinThreads(100, 100);
        }

        private const string SignatureQueryName = "sig";
        private const string CopySourceName = "x-ms-copy-source";
        private const string RenameSource = "x-ms-rename-source";
        private const string CopySourceAuthorization = "x-ms-copy-source-authorization";
        private const string PreviousSnapshotUrl = "x-ms-previous-snapshot-url";
        private const string FileRenameSource = "x-ms-file-rename-source";
        private const string SasVersion = "sv";

        public StorageTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            SanitizedQueryParameters.Add(SignatureQueryName);
            IgnoredQueryParameters.Add(SasVersion);
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(CopySourceName)
            {
                Value = "sanitized-value",
                Regex = "(?:[?&](sv)=)(?<date>[^&\\\"\\s\\n,\\\\]+)",
                GroupForReplace = "date"
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(RenameSource)
            {
                Value = "sanitized-value",
                Regex = "(?:[?&](sv)=)(?<date>[^&\\\"\\s\\n,\\\\]+)",
                GroupForReplace = "date"
            });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(FileRenameSource)
            {
                Value = "sanitized-value",
                Regex = "(?:[?&](sv)=)(?<date>[^&\\\"\\s\\n,\\\\]+)",
                GroupForReplace = "date"
            });

#if NETFRAMEWORK
            // Uri uses different escaping for some special characters between .NET Framework and Core. Because the Test Proxy runs on .NET
            // Core, we need to normalize to the .NET Core escaping when matching and storing the recordings when running tests on NetFramework.
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\("){ Value = "%28" });
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\)"){ Value = "%29" });
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\!"){ Value = "%21" });
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\'"){ Value = "%27" });
            UriRegexSanitizers.Add(new UriRegexSanitizer("\\*"){ Value = "%2A" });
            // Encode any colons in the Uri except for the one in the scheme
            UriRegexSanitizers.Add(new UriRegexSanitizer("(?<group>:)[^//]")
            {
                GroupForReplace = "group",
                Value = "%3A"
            });
#endif

            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-encryption-key"));
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer(CopySourceAuthorization));

            SanitizedQueryParametersInHeaders.Add((CopySourceName, SignatureQueryName));
            SanitizedQueryParametersInHeaders.Add((RenameSource, SignatureQueryName));
            SanitizedQueryParametersInHeaders.Add((PreviousSnapshotUrl, SignatureQueryName));
            SanitizedQueryParametersInHeaders.Add((FileRenameSource, SignatureQueryName));

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"client_secret=(?<group>.*?)(?=&|$)")
            {
                GroupForReplace = "group",
                Value = SanitizeValue
            });

            Tenants = new TenantConfigurationBuilder(this);
        }

        public string SanitizeUri(string uri)
        {
            var builder = new UriBuilder(uri);
            var query = new UriQueryParamsCollection(builder.Query);
            if (query.ContainsKey(SignatureQueryName))
            {
                query[SignatureQueryName] = SanitizeValue;
                builder.Query = query.ToString();
            }
            return builder.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Source of test tenants.
        /// </summary>
        protected readonly TenantConfigurationBuilder Tenants;

        protected TenantConfiguration TestConfigDefault => Tenants.TestConfigDefault;

        /// <summary>
        /// We need to clear the playback cache before every test because
        /// different recordings might have used different tenant
        /// configurations.
        /// </summary>
        [SetUp]
        public virtual void ClearCaches() =>
            Tenants.ClearPlaybackCache();

        public DateTimeOffset GetUtcNow() => Recording.UtcNow;

        public byte[] GetRandomBuffer(long size)
            => TestHelper.GetRandomBuffer(size, Recording.Random);

        public string GetNewString(int length = 20) => DataProvider.GetNewString(length, Recording.Random);

        public string GetNewMetadataName() => $"test_metadata_{Recording.Random.NewGuid().ToString().Replace("-", "_")}";

        public IDictionary<string, string> BuildMetadata() => DataProvider.BuildMetadata();

        public IPAddress GetIPAddress()
        {
            var a = Recording.Random.Next(0, 256);
            var b = Recording.Random.Next(0, 256);
            var c = Recording.Random.Next(0, 256);
            var d = Recording.Random.Next(0, 256);
            var ipString = $"{a}.{b}.{c}.{d}";
            return IPAddress.Parse(ipString);
        }

        internal SharedAccessSignatureCredentials GetAccountSasCredentials(
            AccountSasServices services = AccountSasServices.All,
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All,
            AccountSasPermissions permissions = AccountSasPermissions.All)
        {
            var sasBuilder = new AccountSasBuilder
            {
                ExpiresOn = Recording.UtcNow.AddHours(1),
                Services = services,
                ResourceTypes = resourceTypes,
                Protocol = SasProtocol.Https,
            };
            sasBuilder.SetPermissions(permissions);
            var cred = new StorageSharedKeyCredential(Tenants.TestConfigDefault.AccountName, Tenants.TestConfigDefault.AccountKey);
            return new SharedAccessSignatureCredentials(sasBuilder.ToSasQueryParameters(cred).ToString());
        }

        public virtual void AssertDictionaryEquality(IDictionary<string, string> expected, IDictionary<string, string> actual)
        {
            Assert.IsNotNull(expected, "Expected metadata is null");
            Assert.IsNotNull(actual, "Actual metadata is null");

            Assert.AreEqual(expected.Count, actual.Count, "Metadata counts are not equal");

            foreach (KeyValuePair<string, string> kvp in expected)
            {
                if (!actual.TryGetValue(kvp.Key, out var value) ||
                    string.Compare(kvp.Value, value, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    Assert.Fail($"Expected key <{kvp.Key}> with value <{kvp.Value}> not found");
                }
            }
        }

        /// <summary>
        /// To prevent test flakiness, we simply warn when certain timing sensitive
        /// tests don't appear to work as expected.  However, we will ask you to run
        /// it again if you're recording a test because it should work correctly at
        /// least then.
        /// </summary>
        public void WarnCopyCompletedTooQuickly()
        {
            if (Mode == RecordedTestMode.Record)
            {
                Assert.Fail("Copy may have completed too quickly to abort.  Please record again.");
            }
            else
            {
                Assert.Inconclusive("Copy may have completed too quickly to abort.");
            }
        }

        /// <summary>
        /// Wait for the progress notifications to complete.
        /// </summary>
        /// <param name="progressList">
        /// The list of progress notifications being updated by the Progress handler.
        /// </param>
        /// <param name="totalSize">The total size we should eventually see.</param>
        /// <returns>A task that will (optionally) delay.</returns>
        protected async Task WaitForProgressAsync(System.Collections.Concurrent.ConcurrentBag<long> progressBag, long totalSize)
        {
            for (var attempts = 0; attempts < 10; attempts++)
            {
                // ConcurrentBag.GetEnumerator() returns a snapshot in time; we can safely use linq queries
                if (progressBag.Count > 0 && progressBag.Max() >= totalSize)
                {
                    return;
                }

                // Wait for lingering progress events
                await Delay(500, 100).ConfigureAwait(false);
            }

            // TODO: #7077 - These are too flaky/noisy so I'm changing to Warn
            Assert.Warn("Progress notifications never completed!");
        }

        protected void AssertSecondaryStorageFirstRetrySuccessful(string primaryHost, string secondaryHost, TestExceptionPolicy testExceptionPolicy)
        {
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(secondaryHost, testExceptionPolicy.HostsSetInRequests[1]);
        }

        protected void AssertSecondaryStorageSecondRetrySuccessful(string primaryHost, string secondaryHost, TestExceptionPolicy testExceptionPolicy)
        {
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(secondaryHost, testExceptionPolicy.HostsSetInRequests[1]);
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[2]);
        }

        protected void AssertSecondaryStorageThirdRetrySuccessful(string primaryHost, string secondaryHost, TestExceptionPolicy testExceptionPolicy)
        {
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(secondaryHost, testExceptionPolicy.HostsSetInRequests[1]);
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[2]);
            Assert.AreEqual(secondaryHost, testExceptionPolicy.HostsSetInRequests[3]);
        }

        protected void AssertSecondaryStorage404OnSecondary(string primaryHost, string secondaryHost, TestExceptionPolicy testExceptionPolicy)
        {
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[0]);
            Assert.AreEqual(secondaryHost, testExceptionPolicy.HostsSetInRequests[1]);
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[2]);
            Assert.AreEqual(primaryHost, testExceptionPolicy.HostsSetInRequests[3]);
        }

        protected async Task<T> EnsurePropagatedAsync<T>(
            Func<Task<T>> getResponse,
            Func<T, bool> hasResponse)
        {
            bool responseReceived = false;
            T response = default;
            // end time of 16 minutes from now to allow for propagation to secondary host
            DateTimeOffset endTime = DateTimeOffset.Now.AddMinutes(16);
            while (!responseReceived && DateTimeOffset.Now < endTime)
            {
                response = await getResponse();
                if (!hasResponse(response))
                {
                    await Delay(TestConstants.RetryDelay);
                }
                else
                {
                    responseReceived = true;
                }
            }
            return response;
        }

        internal void AssertResponseHeaders(TestConstants constants, SasQueryParameters sasQueryParameters)
        {
            Assert.AreEqual(constants.Sas.CacheControl, sasQueryParameters.CacheControl);
            Assert.AreEqual(constants.Sas.ContentDisposition, sasQueryParameters.ContentDisposition);
            Assert.AreEqual(constants.Sas.ContentEncoding, sasQueryParameters.ContentEncoding);
            Assert.AreEqual(constants.Sas.ContentLanguage, sasQueryParameters.ContentLanguage);
            Assert.AreEqual(constants.Sas.ContentType, sasQueryParameters.ContentType);
        }

        protected async Task<T> RetryAsync<T>(
            Func<Task<T>> operation,
            Func<RequestFailedException, bool> shouldRetry,
            int retryDelay = TestConstants.RetryDelay,
            int retryAttempts = Constants.MaxReliabilityRetries) =>
            await RetryAsync(Mode, operation, shouldRetry, retryDelay, retryAttempts);

        public static async Task<T> RetryAsync<T>(
            RecordedTestMode mode,
            Func<Task<T>> operation,
            Func<RequestFailedException, bool> shouldRetry,
            int retryDelay = TestConstants.RetryDelay,
            int retryAttempts = Constants.MaxReliabilityRetries)
        {
            for (int attempt = 0; ;)
            {
                try
                {
                    return await operation();
                }
                catch (RequestFailedException ex)
                    when (attempt++ < retryAttempts && shouldRetry(ex))
                {
                    await Delay(mode, retryDelay);
                }
            }
        }

        /// <summary>
        /// Create a stream of a given size that will not use more than maxMemory memory.
        /// If the size is greater than maxMemory, a TemporaryFileStream will be used that
        /// will delete the file in its Dispose method.
        /// </summary>
        protected async Task<Stream> CreateLimitedMemoryStream(long size, long maxMemory = Constants.MB * 100)
        {
            Stream stream;
            if (size < maxMemory)
            {
                var data = GetRandomBuffer(size);
                stream = new MemoryStream(data);
            }
            else
            {
                var path = Path.GetTempFileName();
                stream = new TemporaryFileStream(path, FileMode.Create);
                var bufferSize = 4 * Constants.KB;

                while (stream.Position + bufferSize < size)
                {
                    await stream.WriteAsync(GetRandomBuffer(bufferSize), 0, bufferSize);
                }
                if (stream.Position < size)
                {
                    await stream.WriteAsync(GetRandomBuffer(size - stream.Position), 0, (int)(size - stream.Position));
                }
                // reset the stream
                stream.Seek(0, SeekOrigin.Begin);
            }
            return stream;
        }

        public string AccountSasPermissionsToPermissionsString(AccountSasPermissions permissions)
        {
            var sb = new StringBuilder();
            if ((permissions & AccountSasPermissions.Read) == AccountSasPermissions.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }
            if ((permissions & AccountSasPermissions.Write) == AccountSasPermissions.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }
            if ((permissions & AccountSasPermissions.Delete) == AccountSasPermissions.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }
            if ((permissions & AccountSasPermissions.DeleteVersion) == AccountSasPermissions.DeleteVersion)
            {
                sb.Append(Constants.Sas.Permissions.DeleteBlobVersion);
            }
            if ((permissions & AccountSasPermissions.List) == AccountSasPermissions.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }
            if ((permissions & AccountSasPermissions.Add) == AccountSasPermissions.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }
            if ((permissions & AccountSasPermissions.Create) == AccountSasPermissions.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }
            if ((permissions & AccountSasPermissions.Update) == AccountSasPermissions.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }
            if ((permissions & AccountSasPermissions.Process) == AccountSasPermissions.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }
            if ((permissions & AccountSasPermissions.Tag) == AccountSasPermissions.Tag)
            {
                sb.Append(Constants.Sas.Permissions.Tag);
            }
            if ((permissions & AccountSasPermissions.Filter) == AccountSasPermissions.Filter)
            {
                sb.Append(Constants.Sas.Permissions.FilterByTags);
            }
            return sb.ToString();
        }

        public async Task<string> GetAuthToken(string[] scopes = default, TenantConfiguration tenantConfiguration = default)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return "auth token";
            }

            scopes ??= Scopes;
            TokenRequestContext tokenRequestContext = new TokenRequestContext(scopes);
            AccessToken accessToken = await TestEnvironment.Credential.GetTokenAsync(tokenRequestContext, CancellationToken.None);
            return accessToken.Token;
        }

        public string[] Scopes => ["https://storage.azure.com/.default"];

        public string CreateRandomDirectory(string parentPath, string directoryName = default)
        {
            return Directory.CreateDirectory(Path.Combine(parentPath, string.IsNullOrEmpty(directoryName) ? Recording.Random.NewGuid().ToString() : directoryName)).FullName;
        }

        public async Task<string> CreateRandomFileAsync(string parentPath, string fileName = default, long size = 0)
        {
            using (FileStream fs = File.OpenWrite(Path.Combine(parentPath, string.IsNullOrEmpty(fileName) ? Recording.Random.NewGuid().ToString() : fileName)))
            {
                int bufferSize = Constants.MB;
                byte[] data = new byte[bufferSize];
                while (fs.Position + bufferSize < size)
                {
                    await fs.WriteAsync(GetRandomBuffer(bufferSize), 0, bufferSize);
                }
                if (fs.Position < size)
                {
                    await fs.WriteAsync(GetRandomBuffer(size - fs.Position), 0, (int)(size - fs.Position));
                }
                return fs.Name;
            }
        }
    }
}
