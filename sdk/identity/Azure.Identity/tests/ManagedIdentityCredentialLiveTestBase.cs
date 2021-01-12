// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [NonParallelizable]
    public class ManagedIdentityCredentialLiveTestBase : IdentityRecordedTestBase
    {
        public ManagedIdentityCredentialLiveTestBase(bool isAsync) : base(isAsync)
        {
        }

        public ManagedIdentityCredentialLiveTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected IDisposable ReadOrRestoreManagedIdentityEnvironment()
        {
            return new ManagedIdenityEnvironment(TestEnvironment);
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                typeof(SecretClient).Assembly.GetType("Azure.Security.KeyVault.ChallengeBasedAuthenticationPolicy+AuthenticationChallenge").GetMethod("ClearCache", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null);
            }
        }

        private class ManagedIdenityEnvironment : IDisposable
        {
            private readonly TestEnvVar[] _envVars;

            public ManagedIdenityEnvironment(IdentityTestEnvironment env)
            {
                _envVars = new TestEnvVar[]
                {
                    new TestEnvVar("IDENTITY_ENDPOINT", env.IdentityEndpoint),
                    new TestEnvVar("IMDS_ENDPOINT", env.ImdsEndpoint),
                    new TestEnvVar("MSI_ENDPOINT", env.MsiEndpoint),
                    new TestEnvVar("MSI_SECRET", env.MsiSecret),
                    new TestEnvVar("IDENTITY_HEADER", env.IdentityHeader),
                    new TestEnvVar("IDENTITY_SERVER_THUMBPRINT", env.IdentityServerThumbprint)
                };
            }

            public void Dispose()
            {
                foreach (TestEnvVar envVar in _envVars)
                {
                    envVar.Dispose();
                }
            }
        }
    }
}
