// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.ShortCodes.Tests
{
    public class ShortCodesClientLiveTestBase : RecordedTestBase<ShortCodesClientTestEnvironment>
    {
        public ShortCodesClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        /// <summary>
        /// Creates a <see cref="ShortCodesClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ShortCodesClient" />.</returns>
        protected ShortCodesClient CreateClientWithConnectionString(bool isInstrumented = true)
        {
            var client = new ShortCodesClient(
                    TestEnvironment.LiveTestStaticConnectionString,
                    CreateShortCodesClientOptionsWithCorrelationVectorLogs());

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="ShortCodesClient" /> with the azure key credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ShortCodesClient" />.</returns>
        protected ShortCodesClient CreateClientWithAzureKeyCredential(bool isInstrumented = true)
        {
            var client = new ShortCodesClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                     new AzureKeyCredential(TestEnvironment.LiveTestStaticAccessKey),
                    CreateShortCodesClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="ShortCodesClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ShortCodesClient" />.</returns>
        protected ShortCodesClient CreateClientWithTokenCredential(bool isInstrumented = true)
        {
            var client = new ShortCodesClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateShortCodesClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="ShortCodesClient" /> based on provided authMethod
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="ShortCodesClient" />.</returns>
        protected ShortCodesClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString, bool isInstrumented = true)
        {
            return authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(isInstrumented),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(isInstrumented),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(isInstrumented),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod))
            };
        }

        private ShortCodesClientOptions CreateShortCodesClientOptionsWithCorrelationVectorLogs()
        {
            ShortCodesClientOptions shortCodesClientOptions = new ShortCodesClientOptions();
            shortCodesClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(shortCodesClientOptions);
        }
    }
}
