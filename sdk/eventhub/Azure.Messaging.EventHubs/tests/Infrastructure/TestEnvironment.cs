// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   Represents the ambient environment in which the test suite is
    ///   being run, offering access to information such as environment
    ///   variables.
    /// </summary>
    ///
    public static class TestEnvironment
    {
        /// <summary>The environment variable value for the event hubs connection string, lazily evaluated.</summary>
        private static readonly Lazy<string> EventHubsConnectionStringInstance =
            new Lazy<string>(() => ReadAndVerifyEnvironmentVariable("EVENT_HUBS_CONNECTION_STRING"), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///   The connection string for the Event Hubs namespace instance to be used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The connection string is read from the "EVENT_HUBS_CONNECTION_STRING" environment variable.</value>
        ///
        public static string EventHubsConnectionString => EventHubsConnectionStringInstance.Value;

        /// <summary>
        ///   Builds a connection string for a specific Event Hub instance under the Event Hubs namespace used for
        ///   Live tests.
        /// </summary>
        ///
        /// <value>The namepsace connection string is read from the "EVENT_HUBS_CONNECTION_STRING" environment variable.</value>
        ///
        public static string BuildConnectionStringForEventHub(string eventHubName) => $"{ EventHubsConnectionString };EntityPath={eventHubName}";

        /// <summary>
        ///   Reads an environment variable, ensuring that it is populated.
        /// </summary>
        ///
        /// <param name="variableName">The name of the environment variable to read.</param>
        ///
        /// <returns>The value of the environment variable, if present and populated; otherwise, a <see cref="InvalidOperationException" /> is thrown.</returns>
        ///
        private static string ReadAndVerifyEnvironmentVariable(string variableName)
        {
            var environmentValue = Environment.GetEnvironmentVariable(variableName);

            if (String.IsNullOrWhiteSpace(environmentValue))
            {
                throw new InvalidOperationException($"The environment variable '{ variableName }' was not found or was not populated.");
            }

            return environmentValue;
        }
    }
}
