// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Azure.Identity.Tests.Mock
{
    internal class MockMsalPublicClient : MsalPublicClient
    {
        public DeviceCodeResult DeviceCodeResult { get; set; } = GetDeviceCodeResult();
        public List<IAccount> Accounts { get; set; }

        public Func<string[], string, AuthenticationResult> AuthFactory { get; set; }

        public Func<string[], string, AuthenticationResult> UserPassAuthFactory { get; set; }

        public Func<string[], string, Prompt, string, string, bool, CancellationToken, AuthenticationResult> InteractiveAuthFactory { get; set; }

        public Func<string[], string, AuthenticationResult> SilentAuthFactory { get; set; }

        public Func<string[], string, IAccount, string, bool, CancellationToken, AuthenticationResult> ExtendedSilentAuthFactory { get; set; }

        public Func<DeviceCodeInfo, CancellationToken, AuthenticationResult> DeviceCodeAuthFactory { get; set; }

        public Func<string[], IPublicClientApplication> PubClientAppFactory { get; set; }

        public Func<string[], string,
            string,
            AzureCloudInstance,
            string,
            bool,
            CancellationToken, AuthenticationResult> RefreshTokenFactory
        { get; set; }

        public MockMsalPublicClient() { }

        public MockMsalPublicClient(AuthenticationResult result)
        {
            AuthFactory = (_,_) => result;
            UserPassAuthFactory = (_,_) => result;
            InteractiveAuthFactory = (_,_,_,_,_,_,_) => result;
            SilentAuthFactory = (_,_) => result;
            ExtendedSilentAuthFactory = (_,_,_,_,_,_) => result;
            DeviceCodeAuthFactory = (_,_) => result;
            RefreshTokenFactory = (_,_,_,_,_,_,_) => result;
        }

        public MockMsalPublicClient(CredentialPipeline pipeline, string tenantId, string clientId, string redirectUrl, TokenCredentialOptions options)
            : base(pipeline, tenantId, clientId, redirectUrl, options) { }

        protected override ValueTask<List<IAccount>> GetAccountsCoreAsync(bool async, CancellationToken cancellationToken)
        {
            return new(Accounts);
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenByUsernamePasswordCoreAsync(
            string[] scopes,
            string claims,
            string username,
            string password,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            Func<string[], string, AuthenticationResult> factory = UserPassAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes, tenantId));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenInteractiveCoreAsync(
            string[] scopes,
            string claims,
            Prompt prompt,
            string loginHint,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            var interactiveAuthFactory = InteractiveAuthFactory;
            var authFactory = AuthFactory;

            if (interactiveAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(interactiveAuthFactory(scopes, claims, prompt, loginHint, tenantId, async, cancellationToken));
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
            bool async,
            CancellationToken cancellationToken)
        {
            if (ExtendedSilentAuthFactory != null)
            {
                return new ValueTask<AuthenticationResult>(ExtendedSilentAuthFactory(scopes, claims, account, tenantId, async, cancellationToken));
            }

            Func<string[], string, AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes, null));
            }

            throw new NotImplementedException();
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenSilentCoreAsync(
            string[] scopes,
            string claims,
            AuthenticationRecord record,
            string tenantId,
            bool async,
            CancellationToken cancellationToken)
        {
            Func<string[], string, AuthenticationResult> factory = SilentAuthFactory ?? AuthFactory;

            if (factory != null)
            {
                return new ValueTask<AuthenticationResult>(factory(scopes, tenantId));
            }

            throw new NotImplementedException();
        }

        protected override async ValueTask<AuthenticationResult> AcquireTokenWithDeviceCodeCoreAsync(
            string[] scopes,
            string claims,
            Func<DeviceCodeResult, Task> deviceCodeCallback,
            bool async,
            CancellationToken cancellationToken)
        {
            if (DeviceCodeAuthFactory != null)
            {
                await deviceCodeCallback(DeviceCodeResult);
                var result = DeviceCodeAuthFactory(new DeviceCodeInfo(DeviceCodeResult), cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                return result;
            }

            throw new NotImplementedException();
        }

        internal ValueTask<IPublicClientApplication> CallCreateClientAsync(bool async, CancellationToken cancellationToken)
        {
            return CreateClientAsync(async, cancellationToken);
        }

        protected override ValueTask<IPublicClientApplication> CreateClientCoreAsync(string[] clientCapabilities, bool async, CancellationToken cancellationToken)
        {
            if (PubClientAppFactory == null)
            {
                throw new NotImplementedException();
            }

            return new ValueTask<IPublicClientApplication>(PubClientAppFactory(clientCapabilities));
        }

        protected override ValueTask<AuthenticationResult> AcquireTokenByRefreshTokenCoreAsync(
            string[] scopes,
            string claims,
            string refreshToken,
            AzureCloudInstance azureCloudInstance,
            string tenant,
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
