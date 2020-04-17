// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class VisualStudioCodeCredentialLiveTests : RecordedTestBase<IdentityTestEnvironment>
    {
        private const string ExpectedServiceName = "VS Code Azure";

        public VisualStudioCodeCredentialLiveTests(bool isAsync) : base(isAsync)
        {
            Matcher.ExcludeHeaders.Add("Content-Length");
            Matcher.ExcludeHeaders.Add("client-request-id");
            Matcher.ExcludeHeaders.Add("x-client-OS");
            Matcher.ExcludeHeaders.Add("x-client-SKU");
            Matcher.ExcludeHeaders.Add("x-client-CPU");

            Sanitizer = new IdentityRecordedTestSanitizer();
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true)] // Comment this attribute to run this tests on Linux with Libsecret enabled
        public async Task AuthenticateWithVscCredential()
        {
            var tenantId = GetTenantId();
            var cloudName = Guid.NewGuid().ToString();

            var fileSystem = CreateTestFileSystemService(cloudName: cloudName);
            using IDisposable fixture = await CreateRefreshTokenFixtureAsync(tenantId, cloudName);

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystem, default));
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None);
            Assert.IsNotNull(token.Token);
        }

        [Test]
        public async Task AuthenticateWithVscCredential_NoSettingsFile()
        {
            var tenantId = GetTenantId();
            var refreshToken = await GetRefreshTokenAsync(tenantId);
            var fileSystemService = new TestFileSystemService { ReadAllHandler = s => throw new FileNotFoundException() };
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", refreshToken);

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystemService, vscAdapter));
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None);
            Assert.IsNotNull(token.Token);
        }

        [Test]
        public async Task AuthenticateWithVscCredential_BrokenSettingsFile()
        {
            var tenantId = GetTenantId();
            var refreshToken = await GetRefreshTokenAsync(tenantId);
            var fileSystemService = new TestFileSystemService { ReadAllHandler = s => "{a,}" };
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", refreshToken);

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystemService, vscAdapter));
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None);
            Assert.IsNotNull(token.Token);
        }

        [Test]
        public async Task AuthenticateWithVscCredential_EmptySettingsFile()
        {
            var tenantId = GetTenantId();

            var refreshToken = await GetRefreshTokenAsync(tenantId);
            var fileSystemService = CreateTestFileSystemService();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", refreshToken);

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(default, CredentialPipeline.GetInstance(options), fileSystemService, vscAdapter));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None);
            Assert.IsNotNull(token.Token);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true)] // Comment this attribute to run this tests on Linux with Libsecret enabled
        public async Task AuthenticateWithVscCredential_TenantInSettings()
        {
            var tenantId = GetTenantId();
            var cloudName = Guid.NewGuid().ToString();

            var fileSystemService = CreateTestFileSystemService(tenantId, cloudName);
            using IDisposable fixture = await CreateRefreshTokenFixtureAsync(tenantId, cloudName);

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(Guid.NewGuid().ToString(), CredentialPipeline.GetInstance(options), fileSystemService, default));

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None);
            Assert.IsNotNull(token.Token);
        }

        [Test]
        public void AuthenticateWithVscCredential_NoRefreshToken()
        {
            var tenantId = GetTenantId();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = CreateTestFileSystemService();

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystem, vscAdapter));

            Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVscCredential_AuthenticationCodeInsteadOfRefreshToken()
        {
            var tenantId = GetTenantId();
            var fileSystemService = CreateTestFileSystemService();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", "{}");

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystemService, vscAdapter));

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVscCredential_InvalidRefreshToken()
        {
            var tenantId = GetTenantId();
            var fileSystemService = CreateTestFileSystemService();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", Guid.NewGuid().ToString());

            TokenCredentialOptions options = Recording.InstrumentClientOptions(new TokenCredentialOptions());
            VisualStudioCodeCredential credential = InstrumentClient(new VisualStudioCodeCredential(tenantId, CredentialPipeline.GetInstance(options), fileSystemService, vscAdapter));

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {".default"}), CancellationToken.None));
        }

        private static TestFileSystemService CreateTestFileSystemService(string tenant = default, string cloudName = default)
        {
            var sb = new StringBuilder("{");

            if (tenant != default)
            {
                sb.AppendFormat("\"azure.tenant\": \"{0}\"", tenant);
            }

            if (tenant != default && cloudName != default)
            {
                sb.Append(",");
            }

            if (cloudName != default)
            {
                sb.AppendFormat("\"azure.cloud\": \"{0}\"", cloudName);
            }

            sb.Append("}");

            return new TestFileSystemService {ReadAllHandler = s => sb.ToString()};
        }

        private async Task<IDisposable> CreateRefreshTokenFixtureAsync(string tenantId, string cloudName)
        {
            var refreshToken = await GetRefreshTokenAsync(tenantId);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsRefreshTokenFixture.Create(cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsxRefreshTokenFixture.Create(cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxRefreshTokenFixture.Create(cloudName, refreshToken);
            }

            throw new PlatformNotSupportedException();
        }

        private async Task<string> GetRefreshTokenAsync(string tenantId)
        {
            if (Recording.Mode == RecordedTestMode.Playback)
            {
                return Guid.NewGuid().ToString();
            }

            var clientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
            var username = TestEnvironment.Username;
            var password = TestEnvironment.Password;

            var client = PublicClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .Build();

            var retriever = new RefreshTokenRetriever(client.UserTokenCache);
            await client.AcquireTokenByUsernamePassword(new[] {".default"}, username, password.ToSecureString()).ExecuteAsync();

            StaticCachesUtilities.ClearStaticMetadataProviderCache();
            StaticCachesUtilities.ClearAuthorityEndpointResolutionManagerCache();
            return retriever.RefreshToken;
        }

        private string GetTenantId() => TestEnvironment.TestTenantId;

        private sealed class RefreshTokenRetriever
        {
            public string RefreshToken { get; private set; }

            public RefreshTokenRetriever(ITokenCache tokenCache)
            {
                tokenCache.SetAfterAccess(AfterAccessHandler);
            }

            private void AfterAccessHandler(TokenCacheNotificationArgs args)
            {
                var data = args.TokenCache.SerializeMsalV3();
                var serializedData = new UTF8Encoding().GetString(data);
                var root = JsonDocument.Parse(serializedData).RootElement;
                var refreshTokenObject = root.GetProperty("RefreshToken");
                foreach (JsonProperty property in refreshTokenObject.EnumerateObject())
                {
                    if (property.Name.StartsWith(args.Account.HomeAccountId.Identifier))
                    {
                        RefreshToken = property.Value.GetProperty("secret").GetString();
                        return;
                    }
                }
            }
        }

        private sealed class WindowsRefreshTokenFixture : IDisposable
        {
            private readonly string _target;

            public static IDisposable Create(string cloudName, string refreshToken)
            {
                var target = $"VS Code Azure/{cloudName}";
                var credentialBlobPtr = Marshal.StringToHGlobalAnsi(refreshToken);

                var credentialData = new WindowsNativeMethods.CredentialData
                {
                    AttributeCount = 0,
                    Attributes = IntPtr.Zero,
                    Comment = null,
                    CredentialBlob = credentialBlobPtr,
                    CredentialBlobSize = (uint)refreshToken.Length,
                    Flags = 0,
                    Persist = WindowsNativeMethods.CRED_PERSIST.CRED_PERSIST_LOCAL_MACHINE,
                    TargetAlias = null,
                    TargetName = $"{ExpectedServiceName}/{cloudName}",
                    Type = WindowsNativeMethods.CRED_TYPE.GENERIC,
                    UserName = "Azure"
                };

                var credentialDataPtr = Marshal.AllocHGlobal(Marshal.SizeOf(credentialData));

                try
                {
                    Marshal.StructureToPtr(credentialData, credentialDataPtr, false);
                    WindowsNativeMethods.CredWrite(credentialDataPtr);
                    return new WindowsRefreshTokenFixture(target);
                }
                finally
                {
                    Marshal.FreeHGlobal(credentialDataPtr);
                    Marshal.FreeHGlobal(credentialBlobPtr);
                }
            }

            private WindowsRefreshTokenFixture(string target)
            {
                _target = target;
            }

            public void Dispose() => WindowsNativeMethods.CredDelete(_target, WindowsNativeMethods.CRED_TYPE.GENERIC);
        }

        private sealed class OsxRefreshTokenFixture : IDisposable
        {
            private readonly string _cloudName;

            public static IDisposable Create(string cloudName, string refreshToken)
            {
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainAddGenericPassword(IntPtr.Zero, ExpectedServiceName, cloudName, refreshToken, out itemRef);
                }
                finally
                {
                    MacosNativeMethods.CFRelease(itemRef);
                }

                return new OsxRefreshTokenFixture(cloudName);
            }

            private OsxRefreshTokenFixture(string cloudName)
            {
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr credentialsPtr = IntPtr.Zero;
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainFindGenericPassword(IntPtr.Zero, ExpectedServiceName, _cloudName, out _, out credentialsPtr, out itemRef);
                    MacosNativeMethods.SecKeychainItemDelete(itemRef);
                }
                finally
                {
                    try
                    {
                        MacosNativeMethods.SecKeychainItemFreeContent(IntPtr.Zero, credentialsPtr);
                    }
                    finally
                    {
                        MacosNativeMethods.CFRelease(itemRef);
                    }
                }
            }
        }

        private sealed class LinuxRefreshTokenFixture : IDisposable
        {
            private readonly string _cloudName;

            public static IDisposable Create(string cloudName, string refreshToken)
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_store_sync(schemaPtr, LinuxNativeMethods.SECRET_COLLECTION_SESSION, $"{ExpectedServiceName}/{cloudName}", refreshToken, IntPtr.Zero, "service", ExpectedServiceName, "account", cloudName);
                }
                finally
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }

                return new LinuxRefreshTokenFixture(cloudName);
            }

            public LinuxRefreshTokenFixture(string cloudName)
            {
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_clear_sync(schemaPtr, IntPtr.Zero, "service", ExpectedServiceName, "account", _cloudName);
                }
                finally
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }
            }

            private static IntPtr GetLibsecretSchema()
                => LinuxNativeMethods.secret_schema_new("org.freedesktop.Secret.Generic",
                    LinuxNativeMethods.SecretSchemaFlags.SECRET_SCHEMA_DONT_MATCH_NAME,
                    "service",
                    LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING,
                    "account",
                    LinuxNativeMethods.SecretSchemaAttributeType.SECRET_SCHEMA_ATTRIBUTE_STRING);
        }

        private sealed class TestVscAdapter : IVisualStudioCodeAdapter
        {
            private readonly string _expectedServiceName;
            private readonly string _expectedAccountName;
            private readonly string _refreshToken;

            public TestVscAdapter(string expectedServiceName, string expectedAccountName, string refreshToken)
            {
                _expectedServiceName = expectedServiceName;
                _expectedAccountName = expectedAccountName;
                _refreshToken = refreshToken;
            }

            public string GetUserSettingsPath() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            public string GetCredentials(string serviceName, string accountName)
            {
                Assert.AreEqual(_expectedServiceName, serviceName);
                Assert.AreEqual(_expectedAccountName, accountName);
                return _refreshToken ?? throw new InvalidOperationException("No token found");
            }
        }
    }
}
