// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [NonParallelizable]
    [LiveOnly]
    public abstract class SamplesBase<TEnvironment>: LiveTestBase<TEnvironment> where TEnvironment : TestEnvironment, new()
    {
        private static AsyncLocal<TokenCredential> CurrentCredential = new AsyncLocal<TokenCredential>();

        // Initialize the environment so new DefaultAzureCredential() works
        [OneTimeSetUp]
        public virtual void SetupDefaultAzureCredential()
        {
            CurrentCredential.Value = TestEnvironment.Credential;
        }

        [OneTimeTearDown]
        public virtual void TearDownDefaultAzureCredential()
        {
            CurrentCredential.Value = null;
        }

        /// <summary>
        /// This class is intended to shade the Identity.DefaultAzureCredential to prevent it from caching hte
        /// </summary>
        protected class DefaultAzureCredential: TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return CurrentCredential.Value.GetTokenAsync(requestContext, cancellationToken);
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return CurrentCredential.Value.GetToken(requestContext, cancellationToken);
            }
        }
    }
}