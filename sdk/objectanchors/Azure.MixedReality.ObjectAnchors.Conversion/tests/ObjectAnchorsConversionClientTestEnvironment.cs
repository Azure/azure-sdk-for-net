// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    public class ObjectAnchorsConversionClientTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the account domain.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_DOMAIN environment variable.
        /// </remarks>
        public string AccountDomain => GetRecordedVariable("ACCOUNT_DOMAIN");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_ID environment variable.
        /// </remarks>
        public string AccountId => GetRecordedVariable("ACCOUNT_ID");

        /// <summary>
        /// Gets the account identifier.
        /// </summary>
        /// <remarks>
        /// Set the OBJECTANCHORS_ACCOUNT_KEY environment variable.
        /// </remarks>
        public string AccountKey => GetRecordedVariable("ACCOUNT_KEY", options => options.IsSecret());
    }
}
