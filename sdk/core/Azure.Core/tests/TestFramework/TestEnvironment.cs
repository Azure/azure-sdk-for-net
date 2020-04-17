// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Core.Testing
{
    public class TestEnvironment
    {
        private readonly string _prefix;
        private TestRecording _recording;
        private bool _playback;

        public TestEnvironment(string serviceName)
        {
            _prefix = serviceName.ToUpperInvariant() + "_";
        }

        protected string GetRecordedOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            if (_playback)
            {
                return _recording.GetVariable(name, null);
            }

            var value = Environment.GetEnvironmentVariable(prefixedName) ??
                   Environment.GetEnvironmentVariable(name);

            _recording?.SetVariable(name, value);

            return value;
        }

        public void SetRecording(TestRecording recording, bool playback)
        {
            _recording = recording;
            _playback = playback;
        }

        protected string GetRecordedVariable(string name)
        {
            var value = GetRecordedOptionalVariable(name);
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }

            return value;
        }
        protected string GetOptionalVariable(string name)
        {
            var prefixedName = _prefix + name;

            var value = Environment.GetEnvironmentVariable(prefixedName) ??
                        Environment.GetEnvironmentVariable(name);

            return value;
        }

        protected string GetVariable(string name)
        {
            var value = GetOptionalVariable(name);
            if (value == null)
            {
                var prefixedName = _prefix + name;
                throw new InvalidOperationException(
                    $"Unable to find environment variable {prefixedName} or {name} required by test." + Environment.NewLine +
                    "Make sure the test environment was initialized using eng/common/TestResources/New-TestResources.ps1 script.");
            }

            return value;
        }

        public TokenCredential Credential => _playback ? (TokenCredential)new TestCredential() : new ClientSecretCredential(
            GetVariable("TENANT_ID"),
            GetVariable("CLIENT_ID"),
            GetVariable("CLIENT_SECRET")
            );

        public string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");
        public string ResourceGroup => GetRecordedVariable("RESOURCE_GROUP");
        public string Location => GetRecordedVariable("LOCATION");
        public string AzureEnvironment => GetRecordedVariable("ENVIRONMENT");
        public string TenantId => GetRecordedVariable("TENANT_ID");

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