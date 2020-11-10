// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Template.Tests
{
    public class MixedRealityStsClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetVariable("ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetVariable("ACCOUNT_ID");

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetVariable("ACCOUNT_KEY");

        public MixedRealityStsClientTestEnvironment()
            : base("mixedreality")
        {
        }
    }
}
