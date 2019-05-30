// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The classification of a test or a suite of related tests.
    /// </summary>
    ///
    public static class TestCategory
    {
        /// <summary>The associated test is meant to verify a small, focused unit of functionality at build time and is safe to run in isolation; it has no external dependencies.</summary>
        public const string BuildVerification = "BuildVerification";

        /// <summary>The associated test is meant to verify a scenario which depends upon one ore more live Azure services.</summary>
        public const string Live = "Live";

        /// <summary>The associated test is meant to verify a scenario from end-to-end which is safe to run in isolation; it has no external dependencies</summary>
        public const string EndToEnd = "EndToEnd";
    }
}
