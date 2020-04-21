// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Testing
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run.
    /// </summary>
    public partial class TestEnvironment
    {
        private TokenCredential _credential;
        private readonly string _prefix;

        public TestEnvironment(string serviceName)
        {
            _prefix = serviceName.ToUpperInvariant() + "_";
        }

        /// <summary>
        ///   The name of the Azure subscription containing the resource group to be used for Live tests. Recorded.
        /// </summary>
        public string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");

        /// <summary>
        ///   The name of the Azure resource group to be used for Live tests. Recorded.
        /// </summary>
        public string ResourceGroup => GetRecordedVariable("RESOURCE_GROUP");

        /// <summary>
        ///   The location of the Azure resource group to be used for Live tests (e.g. westus2). Recorded.
        /// </summary>
        public string Location => GetRecordedVariable("LOCATION");

        /// <summary>
        ///   The environment of the Azure resource group to be used for Live tests (e.g. AzureCloud). Recorded.
        /// </summary>
        public string AzureEnvironment => GetRecordedVariable("ENVIRONMENT");

        /// <summary>
        ///   The name of the Azure Active Directory tenant that holds the service principal to use during Live tests. Recorded.
        /// </summary>
        public string TenantId => GetRecordedVariable("TENANT_ID");

        /// <summary>
        ///   The client id of the Azure Active Directory service principal to use during Live tests. Recorded.
        /// </summary>
        public string ClientId => GetRecordedVariable("CLIENT_ID");

        /// <summary>
        ///   The client secret of the Azure Active Directory service principal to use during Live tests. Not recorded.
        /// </summary>
        public string ClientSecret => GetVariable("CLIENT_SECRET");


        public TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }

                var playback = false;
                GetIsPlayback(ref playback);

                if (playback)
                {
                    _credential = new TestCredential();
                }
                else
                {
                    // Don't take a hard dependency on Azure.Identity
                    var type = Type.GetType("Azure.Identity.ClientSecretCredential, Azure.Identity");
                    if (type == null)
                    {
                        throw new InvalidOperationException("Azure.Identity must be referenced to use Credential in Live environment.");
                    }

                    _credential = (TokenCredential) Activator.CreateInstance(
                        type,
                        GetVariable("TENANT_ID"),
                        GetVariable("CLIENT_ID"),
                        GetVariable("CLIENT_SECRET")
                    );
                }

                return _credential;
            }
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// </summary>
        protected string GetRecordedOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            string value = null;
            bool isPlayback = false;

            GetIsPlayback(ref isPlayback);
            if (isPlayback)
            {
                GetRecordedValue(name, ref value);
                return value;
            }

            value = Environment.GetEnvironmentVariable(prefixedName) ??
                   Environment.GetEnvironmentVariable(name);

            SetRecordedValue(name, value);

            return value;
        }

        /// <summary>
        /// Returns and records an environment variable value when running live or recorded value during playback.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetRecordedVariable(string name)
        {
            var value = GetRecordedOptionalVariable(name);
            EnsureValue(name, value);
            return value;
        }

        /// <summary>
        /// Returns an environment variable value.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            var value = Environment.GetEnvironmentVariable(prefixedName) ??
                        Environment.GetEnvironmentVariable(name);

            return value;
        }

        /// <summary>
        /// Returns an environment variable value.
        /// Throws when variable is not found.
        /// </summary>
        protected string GetVariable(string name)
        {
            var value = GetOptionalVariable(name);
            EnsureValue(name, value);
            return value;
        }

        private void EnsureValue(string name, string value)
        {
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }
        }

        partial void GetRecordedValue(string name, ref string value);
        partial void GetIsPlayback(ref bool isPlayback);
        partial void SetRecordedValue(string name, string value);

        private class TestCredential : TokenCredential
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
    }
}