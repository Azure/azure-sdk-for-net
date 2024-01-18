// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalPublicClient : MsalPublicClient
    {
        public DeviceCodeResult DeviceCodeResult { get; set; } = GetDeviceCodeResult();
        public List<IAccount> Accounts { get; set; }
        public Func<string[], string, AuthenticationResult> AuthFactory { get; set; }
        public Func<string[], string, string, string, string, bool, AuthenticationResult> UserPassAuthFactory { get; set; }
        public Func<string[], string, Prompt, string, string, bool, BrowserCustomizationOptions, CancellationToken, AuthenticationResult> InteractiveAuthFactory { get; set; }
        public Func<string[], string, AuthenticationRecord, string, bool, AuthenticationResult> SilentAuthFactory { get; set; }
        public Func<string[], string, IAccount, string, bool, CancellationToken, AuthenticationResult> ExtendedSilentAuthFactory { get; set; }
        public Func<string[], string, DeviceCodeInfo, bool, CancellationToken, AuthenticationResult> DeviceCodeAuthFactory { get; set; }
        public Func<bool, IPublicClientApplication> ClientAppFactory { get; set; }
        public Func<string[], string, string, AzureCloudInstance, string, bool, CancellationToken, AuthenticationResult> RefreshTokenFactory { get; set; }
        public MockMsalPublicClient() { }

        public MockMsalPublicClient(AuthenticationResult result)
        {
            AuthFactory = (_, _) => result;
            UserPassAuthFactory = (_, _, _, _, _, _) => result;
            InteractiveAuthFactory = (_, _, _, _, _, _, _, _) => result;
            SilentAuthFactory = (_, _, _, _, _) => result;
            ExtendedSilentAuthFactory = (_, _, _, _, _, _) => result;
            DeviceCodeAuthFactory = (_, _, _, _, _) => result;
            RefreshTokenFactory = (_, _, _, _, _, _, _) => result;
        }

        public MockMsalPublicClient(CredentialPipeline pipeline, string tenantId, string clientId, string redirectUrl, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, redirectUrl, options) { }

        protected override ValueTask<List<IAccount>> GetAccountsCoreAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return new(Accounts);
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordCoreAsync(
            string[] scopes,
            string claims,
            string username,
            string password,
            string tenantId,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            if (UserPassAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(UserPassAuthFactory(scopes, claims, username, password, tenantId, enableCae));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenInteractiveCoreAsync(
            string[] scopes,
            string claims,
            Prompt prompt,
            string loginHint,
            string tenantId,
            bool enableCae,
            BrowserCustomizationOptions browserOptions,
            PopTokenRequestContext popTokenRequestContext,
            bool async,
            CancellationToken cancellationToken)
        {
            var interactiveAuthFactory = InteractiveAuthFactory;
            var authFactory = AuthFactory;

            if (interactiveAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(interactiveAuthFactory(scopes, claims, prompt, loginHint, tenantId, async, browserOptions, cancellationToken));
            }
            if (authFactory != null)
            {
                return new ValueTask<AuthenticationResult>(authFactory(scopes, null));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            string claims,
            IAccount account,
            string tenantId,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            if (ExtendedSilentAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(ExtendedSilentAuthFactory(scopes, claims, account, tenantId, async, cancellationToken));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            string claims,
            AuthenticationRecord record,
            string tenantId,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            if (SilentAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(SilentAuthFactory(scopes, claims, record, tenantId, enableCae));
            }

            throw new NotImplementedException();
        }

        protected override async ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeCoreAsync(
            string[] scopes,
            string claims,
            Func<DeviceCodeResult, Task> deviceCodeCallback,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            if (DeviceCodeAuthFactory != null)
            {
                await deviceCodeCallback(DeviceCodeResult);
                var result = DeviceCodeAuthFactory(scopes, claims, new DeviceCodeInfo(DeviceCodeResult), enableCae, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                return result;
            }

            throw new NotImplementedException();
        }

        internal ValueTask<IPublicClientApplication> CallBaseGetClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return GetClientAsync(enableCae, async, cancellationToken);
        }

        internal ValueTask<IPublicClientApplication> CallCreateClientAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            return CreateClientAsync(enableCae, async, cancellationToken);
        }

        protected override ValueTask<IPublicClientApplication> CreateClientCoreAsync(bool enableCae, bool async, CancellationToken cancellationToken)
        {
            if (ClientAppFactory == null)
            {
                return base.CreateClientCoreAsync(enableCae, async, cancellationToken);
            }

            return new ValueTask<IPublicClientApplication>(ClientAppFactory(enableCae));
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenByRefreshTokenCoreAsync(
            string[] scopes,
            string claims,
            string refreshToken,
            AzureCloudInstance azureCloudInstance,
            string tenant,
            bool enableCae,
            bool async,
            CancellationToken cancellationToken)
        {
            if (RefreshTokenFactory == null)
            {
                throw new NotImplementedException();
            }
            return new ValueTask<AuthenticationResult>(RefreshTokenFactory(scopes, claims, refreshToken, azureCloudInstance, tenant, async, cancellationToken));
        }

        internal static DeviceCodeResult GetDeviceCodeResult(
            string userCode = "userCode",
            string deviceCode = "deviceCode",
            string verificationUrl = "https://localhost",
            DateTimeOffset expiresOn = new(),
            long interval = 0,
            string clientId = "clientId",
            ISet<string> scopes = null)
        {
            var ctor = typeof(DeviceCodeResult).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault();
            var message = $"To sign in, use a web browser to open the page {verificationUrl} and enter the code {deviceCode} to authenticate.";
            return (DeviceCodeResult)ctor.Invoke(
                new object[] { userCode, deviceCode, verificationUrl, expiresOn, interval, message, clientId, scopes ?? new HashSet<string>() });
        }
    }
}
