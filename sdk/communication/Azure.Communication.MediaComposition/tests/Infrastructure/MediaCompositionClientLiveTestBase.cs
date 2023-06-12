// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.MediaComposition.Tests.Infrastructure;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.MediaComposition.Tests
{
    public class MediaCompositionClientLiveTestBase : RecordedTestBase<MediaCompositionClientTestEnvironment>
    {
        public MediaCompositionClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        /// <summary>
        /// Creates a <see cref="MediaCompositionClient" /> with the connection string via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="MediaCompositionClient" />.</returns>
        protected MediaCompositionClient CreateClientWithConnectionString(bool isInstrumented = true)
        {
            var client = new MediaCompositionClient(
                    TestEnvironment.LiveTestStaticConnectionString,
                    CreateMediaCompositionClientOptionsWithCorrelationVectorLogs());

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="MediaCompositionClient" /> with the azure key credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="MediaCompositionClient" />.</returns>
        protected MediaCompositionClient CreateClientWithAzureKeyCredential(bool isInstrumented = true)
        {
            var client = new MediaCompositionClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                     new AzureKeyCredential(TestEnvironment.LiveTestStaticAccessKey),
                    CreateMediaCompositionClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="MediaCompositionClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="MediaCompositionClient" />.</returns>
        protected MediaCompositionClient CreateClientWithTokenCredential(bool isInstrumented = true)
        {
            var client = new MediaCompositionClient(
                    TestEnvironment.LiveTestStaticEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateMediaCompositionClientOptionsWithCorrelationVectorLogs());

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="MediaCompositionClient" /> based on provided authMethod
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="MediaCompositionClient" />.</returns>
        protected MediaCompositionClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString, bool isInstrumented = true)
        {
            return authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(isInstrumented),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(isInstrumented),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(isInstrumented),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod))
            };
        }
        private MediaCompositionClientOptions CreateMediaCompositionClientOptionsWithCorrelationVectorLogs()
        {
            MediaCompositionClientOptions mediaCompositionClientOptions = new MediaCompositionClientOptions();
            mediaCompositionClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(mediaCompositionClientOptions);
        }
    }
}
