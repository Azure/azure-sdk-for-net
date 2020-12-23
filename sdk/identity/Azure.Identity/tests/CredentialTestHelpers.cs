// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests
{
    internal static class CredentialTestHelpers
    {
        public static (string token, DateTimeOffset expiresOn, string json) CreateTokenForAzureCli() => CreateTokenForAzureCli(TimeSpan.FromSeconds(30));

        public static (string token, DateTimeOffset expiresOn, string json) CreateTokenForAzureCli(TimeSpan expiresOffset)
        {
            const string expiresOnStringFormat = "yyyy-MM-dd HH:mm:ss.ffffff";

            var expiresOnString = DateTimeOffset.Now.Add(expiresOffset).ToString(expiresOnStringFormat);
            var expiresOn = DateTimeOffset.ParseExact(expiresOnString, expiresOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeLocal);
            var token = Guid.NewGuid().ToString();
            var json = $"{{ \"accessToken\": \"{token}\", \"expiresOn\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        public static (string token, DateTimeOffset expiresOn, string json) CreateTokenForAzureCliExpiresIn(int seconds = 30)
        {
            var expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(seconds);
            var token = Guid.NewGuid().ToString();
            var json = $"{{ \"accessToken\": \"{token}\", \"expiresIn\": {seconds} }}";
            return (token, expiresOn, json);
        }

        public static (string token, DateTimeOffset expiresOn, string json) CreateTokenForVisualStudio() => CreateTokenForVisualStudio(TimeSpan.FromSeconds(30));

        public static (string token, DateTimeOffset expiresOn, string json) CreateTokenForVisualStudio(TimeSpan expiresOffset)
        {
            var expiresOnString = DateTimeOffset.UtcNow.Add(expiresOffset).ToString("s");
            var expiresOn = DateTimeOffset.Parse(expiresOnString);
            var token = Guid.NewGuid().ToString();
            var json = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        public static TestFileSystemService CreateFileSystemForVisualStudio(params int[] preferences)
        {
            var sb = new StringBuilder();
            var paths = new List<string>();

            for (var i = 0; i < preferences.Length || i == 0; i++)
            {
                var preference = preferences.Length > 0 ? preferences[i] : 0;
                if (i > 0)
                {
                    sb.Append(", ");
                }

                paths.Add($"c:\\VS{preference}\\service.exe");
                sb.Append($"{{\"Path\": \"c:\\\\VS{preference}\\\\service.exe\", \"Arguments\": [\"{preference}\"], \"Preference\": {preference}}}");
            }

            var json = $"{{ \"TokenProviders\": [{sb}] }}";
            return new TestFileSystemService
            {
                FileExistsHandler = p => paths.Contains(p),
                ReadAllHandler = p => json
            };
        }

        public static TestFileSystemService CreateFileSystemForVisualStudioCode(IdentityTestEnvironment testEnvironment, string cloudName = default)
        {
            var sb = new StringBuilder("{");

            if (testEnvironment.TestTenantId != default)
            {
                sb.AppendFormat("\"azure.tenant\": \"{0}\"", testEnvironment.TestTenantId);
            }

            if (testEnvironment.TestTenantId != default && cloudName != default)
            {
                sb.Append(',');
            }

            if (cloudName != default)
            {
                sb.AppendFormat("\"azure.cloud\": \"{0}\"", cloudName);
            }

            sb.Append('}');

            return new TestFileSystemService
            {
                FileExistsHandler = p => Path.HasExtension("json"),
                ReadAllHandler = s => sb.ToString()
            };
        }

        public static async ValueTask<AuthenticationRecord> GetAuthenticationRecordAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode)
        {
            var clientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";
            if (mode == RecordedTestMode.Playback)
            {
                var mockUsername = "mockuser@mockdomain.com";
                var mockEnvironment = AzureAuthorityHosts.AzurePublicCloud.ToString();
                var mockHomeId = $"{Guid.NewGuid()}.{Guid.NewGuid()}";
                var mockTenantId = Guid.NewGuid().ToString();

                return new AuthenticationRecord(mockUsername, mockEnvironment, mockHomeId, mockTenantId, clientId);
            }

            var username = testEnvironment.Username;
            var password = testEnvironment.Password;
            var tenantId = testEnvironment.TestTenantId;

            var result = await PublicClientApplicationBuilder.Create(clientId).WithTenantId(tenantId).Build()
                .AcquireTokenByUsernamePassword(new[] {".default"}, username, password.ToSecureString())
                .ExecuteAsync();

            return new AuthenticationRecord(result, clientId);
        }

        public static async Task<string> GetRefreshTokenAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode)
        {
            if (mode == RecordedTestMode.Playback)
            {
                return Guid.NewGuid().ToString();
            }

            var clientId = "aebc6443-996d-45c2-90f0-388ff96faa56";
            var username = testEnvironment.Username;
            var password = testEnvironment.Password;

            var client = PublicClientApplicationBuilder.Create(clientId)
                .WithTenantId(testEnvironment.TestTenantId)
                .Build();

            var retriever = new RefreshTokenRetriever(client.UserTokenCache);
            await client.AcquireTokenByUsernamePassword(new[] {".default"}, username, password.ToSecureString()).ExecuteAsync();

            StaticCachesUtilities.ClearStaticMetadataProviderCache();
            StaticCachesUtilities.ClearAuthorityEndpointResolutionManagerCache();
            return retriever.RefreshToken;
        }

        public static async Task<IDisposable> CreateRefreshTokenFixtureAsync(IdentityTestEnvironment testEnvironment, RecordedTestMode mode, string serviceName, string cloudName)
        {
            var refreshToken = await GetRefreshTokenAsync(testEnvironment, mode);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return WindowsRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OsxRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LinuxRefreshTokenFixture.Create(serviceName, cloudName, refreshToken);
            }

            throw new PlatformNotSupportedException();
        }

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

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
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
                    TargetName = $"{serviceName}/{cloudName}",
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
            private readonly string _serviceName;
            private readonly string _cloudName;

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
            {
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainAddGenericPassword(IntPtr.Zero, serviceName, cloudName, refreshToken, out itemRef);
                }
                finally
                {
                    MacosNativeMethods.CFRelease(itemRef);
                }

                return new OsxRefreshTokenFixture(serviceName, cloudName);
            }

            private OsxRefreshTokenFixture(string serviceName, string cloudName)
            {
                _serviceName = serviceName;
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr credentialsPtr = IntPtr.Zero;
                IntPtr itemRef = IntPtr.Zero;

                try
                {
                    MacosNativeMethods.SecKeychainFindGenericPassword(IntPtr.Zero, _serviceName, _cloudName, out _, out credentialsPtr, out itemRef);
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
            private readonly string _serviceName;
            private readonly string _cloudName;

            public static IDisposable Create(string serviceName, string cloudName, string refreshToken)
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_store_sync(schemaPtr, LinuxNativeMethods.SECRET_COLLECTION_SESSION, $"{serviceName}/{cloudName}", refreshToken, IntPtr.Zero, "service", serviceName, "account", cloudName);
                }
                finally
                {
                    LinuxNativeMethods.secret_schema_unref(schemaPtr);
                }

                return new LinuxRefreshTokenFixture(serviceName, cloudName);
            }

            public LinuxRefreshTokenFixture(string serviceName, string cloudName)
            {
                _serviceName = serviceName;
                _cloudName = cloudName;
            }

            public void Dispose()
            {
                IntPtr schemaPtr = GetLibsecretSchema();

                try
                {
                    LinuxNativeMethods.secret_password_clear_sync(schemaPtr, IntPtr.Zero, "service", _serviceName, "account", _cloudName);
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
    }
}
