// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Proxy.OpenAILike;

namespace System.ClientModel.Tests.Proxy.FirstPartyA
{
    /// <summary>
    /// A first-party client that extends the "OpenAI-like" <see cref="ResponseToolsClient"/> and
    /// registers its own conditional proxy <b>internally</b>. The end user constructs this client and
    /// calls it normally — they never see <c>AddProxy</c> or even know a proxy exists. This mirrors how
    /// a first-party Microsoft library (which derives from the OpenAI client) would inject its
    /// deserialization behavior transparently.
    /// </summary>
    public class FirstPartyToolsClient : ResponseToolsClient
    {
        /// <summary>
        /// Creates the client with the first-party proxy registered internally. An optional
        /// <paramref name="configureAdditional"/> lets the consumer layer on extra proxies from other
        /// libraries (e.g. an independent third party) without the first-party proxy being exposed.
        /// </summary>
        public FirstPartyToolsClient(ClientPipelineOptions pipelineOptions, Action<ModelReaderWriterOptions>? configureAdditional = null)
            : base(pipelineOptions, BuildOptions(configureAdditional))
        {
        }

        private static ModelReaderWriterOptions BuildOptions(Action<ModelReaderWriterOptions>? configureAdditional)
        {
            // Register the first-party proxy here so it is invisible to the end user.
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("J").AddAzureTools();
            configureAdditional?.Invoke(options);
            return options;
        }
    }
}
