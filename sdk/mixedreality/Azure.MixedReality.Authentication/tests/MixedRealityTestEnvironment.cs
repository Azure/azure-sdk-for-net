// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ASA_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("ASA_ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ASA_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("ASA_ACCOUNT_ID");

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ASA_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("ASA_ACCOUNT_KEY");
    }
}
