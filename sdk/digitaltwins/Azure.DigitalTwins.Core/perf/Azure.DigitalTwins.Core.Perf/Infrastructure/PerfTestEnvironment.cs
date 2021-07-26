// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Perf
{
    /// <summary>
    /// Represents the ambient environment in which the test suite is being run, offering access to information such as environment variables.
    /// </summary>
    internal sealed class PerfTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// The shared instance of the <see cref="PerfTestEnvironment"/> to be used during test runs.
        /// </summary>
        public static PerfTestEnvironment Instance { get; } = new PerfTestEnvironment();

        /// <summary>
        ///   The Digital Twins instance endpoint to run the tests against.
        /// </summary>
        public string DigitalTwinsUrl => GetVariable("DIGITALTWINS_URL");

        /// <summary>
        /// The Microsoft tenant Id for the App registration.
        /// </summary>
        /// <value>The Microsoft tenant Id for the App registration, read from the "DIGITALTWINS_TENANT_ID" environment variable.</value>
        public string DigitalTwinsTenantId => GetVariable("DIGITALTWINS_TENANT_ID");

        /// <summary>
        /// The App registration client Id used to authenticate against the instance.
        /// </summary>
        /// <value>The App registration client Id used to authenticate against the instance, read from the "DIGITALTWINS_CLIENT_ID" environment variable.</value>
        public string DigitalTwinsClientId => GetVariable("DIGITALTWINS_CLIENT_ID");

        /// <summary>
        /// The App registration client secret.
        /// </summary>
        /// <value>The App registration client secret, read from the "DIGITALTWINS_CLIENT_SECRET" environment variable.</value>
        public string DigitalTwinsClientSecret => GetVariable("DIGITALTWINS_CLIENT_SECRET");

        /// <summary>
        /// Initializes a new instance of the <see cref="PerfTestEnvironment"/> class.
        /// </summary>
        public PerfTestEnvironment()
        {
        }
    }
}
