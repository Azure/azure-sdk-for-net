// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The classification of a test or a suite of related tests.
    /// </summary>
    ///
    public static class TestCategory
    {
        /// <summary>The associated test is meant to verify a scenario which depends upon one ore more live Azure services.</summary>
        public const string Live = "Live";

        /// <summary>The associated test should not be included when Visual Studio is performing "Live Unit Testing" runs.</summary>
        public const string DisallowVisualStudioLiveUnitTesting = "SkipWhenLiveUnitTesting";
    }
}