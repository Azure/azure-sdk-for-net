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
        /// Creates the client with the first-party proxy registered internally on the pipeline options'
        /// <see cref="ClientPipelineOptions.ModelReaderWriterOptions"/>. An optional
        /// <paramref name="configureAdditional"/> lets the consumer layer on extra proxies from other
        /// libraries (e.g. an independent third party) without the first-party proxy being exposed.
        /// </summary>
        public FirstPartyToolsClient(ClientPipelineOptions pipelineOptions, Action<ModelReaderWriterOptions>? configureAdditional = null)
            : base(InjectOptions(pipelineOptions, configureAdditional))
        {
        }

        private static ClientPipelineOptions InjectOptions(ClientPipelineOptions pipelineOptions, Action<ModelReaderWriterOptions>? configureAdditional)
        {
            pipelineOptions ??= new ClientPipelineOptions();

            // Inject the first-party proxy by carrying it on the pipeline options, the way a first-party
            // library would when constructing the underlying client. The end user never sees AddProxy.
            ModelReaderWriterOptions options = new ModelReaderWriterOptions("J").AddAzureTools();
            configureAdditional?.Invoke(options);
            pipelineOptions.ModelReaderWriterOptions = options;
            return pipelineOptions;
        }
    }
}
