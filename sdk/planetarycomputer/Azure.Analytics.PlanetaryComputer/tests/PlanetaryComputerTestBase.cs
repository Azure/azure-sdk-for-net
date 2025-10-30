// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Base class for Azure Planetary Computer tests that provides recording capabilities.
    /// Inherits from RecordedTestBase to enable test recording and playback functionality.
    /// All test classes should extend this class to ensure consistent test infrastructure.
    /// </summary>
    public class PlanetaryComputerTestBase : RecordedTestBase<PlanetaryComputerTestEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetaryComputerTestBase"/> class.
        /// </summary>
        /// <param name="isAsync">Whether the test should run in async mode.</param>
        public PlanetaryComputerTestBase(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;

            // Apply sanitizers to protect sensitive information in recordings
            PlanetaryComputerTestSanitizers.ApplySanitizers(this);
        }

        /// <summary>
        /// Creates a test client with recording capabilities and proper instrumentation.
        /// This method ensures the client uses the test proxy for recording and playback.
        /// </summary>
        /// <param name="options">Optional client options. If null, default instrumented options will be used.</param>
        /// <returns>An instrumented PlanetaryComputerProClient instance ready for testing.</returns>
        protected PlanetaryComputerProClient GetTestClient(PlanetaryComputerProClientOptions options = null)
        {
            options ??= InstrumentClientOptions(new PlanetaryComputerProClientOptions());

            var endpoint = new Uri(TestEnvironment.Endpoint);
            var credential = TestEnvironment.Credential;

            var client = new PlanetaryComputerProClient(endpoint, credential, options);

            return InstrumentClient(client);
        }

        /// <summary>
        /// Validates that a string value is not null or empty.
        /// </summary>
        /// <param name="value">The string value to validate.</param>
        /// <param name="propertyName">The name of the property being validated, used in error messages.</param>
        protected static void ValidateNotNullOrEmpty(string value, string propertyName)
        {
            Assert.IsNotNull(value, $"{propertyName} should not be null");
            Assert.IsNotEmpty(value, $"{propertyName} should not be empty");
        }

        /// <summary>
        /// Validates that a response object is not null.
        /// </summary>
        /// <typeparam name="T">The type of the response object.</typeparam>
        /// <param name="response">The response object to validate.</param>
        /// <param name="responseName">Optional name of the response, used in error messages. If null, the type name is used.</param>
        protected static void ValidateResponse<T>(T response, string responseName = null) where T : class
        {
            Assert.IsNotNull(response, $"{responseName ?? typeof(T).Name} response should not be null");
        }
    }
}
