// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;

namespace Azure.MixedReality.RemoteRendering.Tests
{
    public class RemoteRenderingTestEnvironment : TestEnvironment
    {
        // TODO Review for secrets.

        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("ACCOUNT_ID", options => options.IsSecret());

        /// <summary>
        /// Gets the account key.
        /// </summary>
        /// <remarks>
        /// Set the MIXEDREALITY_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("ACCOUNT_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        /// <remarks>
        /// Set the MIXED_REALITY_SERVICE_ENDPOINT environment variable.
        /// </remarks>
        public string ServiceEndpoint => GetRecordedVariable("SERVICE_ENDPOINT");
    }
}
