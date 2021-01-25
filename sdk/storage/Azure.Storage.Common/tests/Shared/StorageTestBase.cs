// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Sas;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Test.Shared
{
    public abstract class StorageTestBase : RecordedTestBase
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

        public StorageTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode ?? RecordedTestUtilities.GetModeFromEnvironment())
        {
            Sanitizer = new StorageRecordedTestSanitizer();
            Matcher = new StorageRecordMatcher();
        }

        /// <summary>
        /// Gets the tenant to use by default for our tests.
        /// </summary>
        public TenantConfiguration TestConfigDefault => GetTestConfig(
                "Storage_TestConfigDefault",
                () => TestConfigurations.DefaultTargetTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require Read Access
        /// Geo-Redundant Storage to be setup.
        /// </summary>
        public TenantConfiguration TestConfigSecondary => GetTestConfig(
                "Storage_TestConfigSecondary",
                () => TestConfigurations.DefaultSecondaryTargetTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require Premium SSDs.
        /// </summary>
        public TenantConfiguration TestConfigPremiumBlob => GetTestConfig(
                "Storage_TestConfigPremiumBlob",
                () => TestConfigurations.DefaultTargetPremiumBlobTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require preview features.
        /// </summary>
        public TenantConfiguration TestConfigPreviewBlob => GetTestConfig(
                "Storage_TestConfigPreviewBlob",
                () => TestConfigurations.DefaultTargetPreviewBlobTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigOAuth => GetTestConfig(
                "Storage_TestConfigOAuth",
                () => TestConfigurations.DefaultTargetOAuthTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigHierarchicalNamespace => GetTestConfig(
                "Storage_TestConfigHierarchicalNamespace",
                () => TestConfigurations.DefaultTargetHierarchicalNamespaceTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigManagedDisk => GetTestConfig(
                "Storage_TestConfigManagedDisk",
                () => TestConfigurations.DefaultTargetManagedDiskTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigSoftDelete => GetTestConfig(
                "Storage_TestConfigSoftDelete",
                () => TestConfigurations.DefaultTargetSoftDeleteTenant);

        /// <summary>
        /// Gets the tenant to use for any tests premium files.
        /// </summary>
        public TenantConfiguration TestConfigPremiumFile => GetTestConfig(
                "Storage_TestConfigPremiumFile",
                () => TestConfigurations.DefaultPremiumFileTenant);

        /// <summary>
        /// Gets a cache used for storing serialized tenant configurations.  Do
        /// not get values from this directly; use GetTestConfig.
        /// </summary>
        private readonly Dictionary<string, string> _recordingConfigCache =
            new Dictionary<string, string>();

        /// <summary>
        /// Gets a cache used for storing deserialized tenant configurations.
        /// Do not get values from this directly; use GetTestConfig.
        private readonly Dictionary<string, TenantConfiguration> _playbackConfigCache =
            new Dictionary<string, TenantConfiguration>();

        /// <summary>
        /// We need to clear the playback cache before every test because
        /// different recordings might have used different tenant
        /// configurations.
        /// </summary>
        [SetUp]
        public virtual void ClearCaches() =>
            _playbackConfigCache.Clear();

        /// <summary>
        /// Get or create a test configuration tenant to use with our tests.
        ///
        /// If we're recording, we'll save a sanitized version of the test
        /// configuarion.  If we're playing recorded tests, we'll use the
        /// serialized test configuration.  If we're running the tests live,
        /// we'll just return the value.
        ///
        /// While we cache things internally, DO NOT cache them elsewhere
        /// because we need each test to have its configuration recorded.
        /// </summary>
        /// <param name="name">The name of the session record variable.</param>
        /// <param name="getTenant">
        /// A function to get the tenant.  This is wrapped in a Func becuase
        /// we'll throw Assert.Inconclusive if you try to access a tenant with
        /// an invalid config file.
        /// </param>
        /// <returns>A test tenant to use with our tests.</returns>
        private TenantConfiguration GetTestConfig(string name, Func<TenantConfiguration> getTenant)
        {
            TenantConfiguration config;
            string text;
            switch (Mode)
            {
                case RecordedTestMode.Playback:
                    if (!_playbackConfigCache.TryGetValue(name, out config))
                    {
                        text = Recording.GetVariable(name, null);
                        config = TenantConfiguration.Parse(text);
                        _playbackConfigCache[name] = config;
                    }
                    break;
                case RecordedTestMode.Record:
                    config = getTenant();
                    if (!_recordingConfigCache.TryGetValue(name, out text))
                    {
                        text = TenantConfiguration.Serialize(config, true);
                        _recordingConfigCache[name] = text;
                    }
                    Recording.GetVariable(name, text);
                    break;
                case RecordedTestMode.Live:
                default:
                    config = getTenant();
                    break;
            }
            return config;
        }

        public DateTimeOffset GetUtcNow() => Recording.UtcNow;

        protected HttpPipelineTransport GetTransport() =>
            new HttpClientTransport(
                new HttpClient()
                {
                    Timeout = TestConstants.HttpTimeoutDuration
                });

        public byte[] GetRandomBuffer(long size)
            => TestHelper.GetRandomBuffer(size, Recording.Random);

        public string GetNewString(int length = 20)
        {
            var buffer = new char[length];
            for (var i = 0; i < length; i++)
            {
                buffer[i] = (char)('a' + Recording.Random.Next(0, 25));
            }
            return new string(buffer);
        }

        public string GetNewMetadataName() => $"test_metadata_{Recording.Random.NewGuid().ToString().Replace("-", "_")}";

        public IDictionary<string, string> BuildMetadata()
            => new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    { "foo", "bar" },
                    { "meta", "data" },
                    { "Capital", "letter" },
                    { "UPPER", "case" }
                };

        public IPAddress GetIPAddress()
        {
            var a = Recording.Random.Next(0, 256);
            var b = Recording.Random.Next(0, 256);
            var c = Recording.Random.Next(0, 256);
            var d = Recording.Random.Next(0, 256);
            var ipString = $"{a}.{b}.{c}.{d}";
            return IPAddress.Parse(ipString);
        }

        public TokenCredential GetOAuthCredential() =>
            GetOAuthCredential(TestConfigOAuth);

        public TokenCredential GetOAuthCredential(TenantConfiguration config) =>
            GetOAuthCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret,
                new Uri(config.ActiveDirectoryAuthEndpoint));

        public TokenCredential GetOAuthCredential(string tenantId, string appId, string secret, Uri authorityHost) =>
            Mode == RecordedTestMode.Playback ?
                (TokenCredential) new StorageTestTokenCredential() :
                new ClientSecretCredential(
                    tenantId,
                    appId,
                    secret,
                    new TokenCredentialOptions() { AuthorityHost = authorityHost });

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
            var cred = new StorageSharedKeyCredential(TestConfigDefault.AccountName, TestConfigDefault.AccountKey);
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
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public async Task Delay(int milliseconds = 1000, int? playbackDelayMilliseconds = null) =>
            await Delay(Mode, milliseconds, playbackDelayMilliseconds);

        /// <summary>
        /// A number of our tests have built in delays while we wait an expected
        /// amount of time for a service operation to complete and this method
        /// allows us to wait (unless we're playing back recordings, which can
        /// complete immediately).
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds to wait.</param>
        /// <param name="playbackDelayMilliseconds">
        /// An optional number of milliseconds to wait if we're playing back a
        /// recorded test.  This is useful for allowing client side events to
        /// get processed.
        /// </param>
        /// <returns>A task that will (optionally) delay.</returns>
        public static async Task Delay(RecordedTestMode mode, int milliseconds = 1000, int? playbackDelayMilliseconds = null)
        {
            if (mode != RecordedTestMode.Playback)
            {
                await Task.Delay(milliseconds);
            }
            else if (playbackDelayMilliseconds != null)
            {
                await Task.Delay(playbackDelayMilliseconds.Value);
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

        private class StorageTestTokenCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
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
    }
}
