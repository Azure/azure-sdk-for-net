// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.MixedReality.ObjectAnchors.Tests
{
    public class ObjectAnchorsClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_AOA_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("AOA_ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_AOA_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("AOA_ACCOUNT_ID");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_AOA_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("AOA_ACCOUNT_KEY", options => options.IsSecret());
    }
}
