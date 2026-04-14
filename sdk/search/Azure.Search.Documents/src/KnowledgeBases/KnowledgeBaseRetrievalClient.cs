// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an knowledge base.
    /// </summary>
    //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
    [CodeGenSuppress(nameof(KnowledgeBaseRetrievalClient), typeof(HttpPipelinePolicy), typeof(Uri), typeof(string), typeof(KnowledgeBaseRetrievalClientOptions))]
    [CodeGenSuppress(nameof(KnowledgeBaseRetrievalClient), typeof(Uri), typeof(string), typeof(TokenCredential), typeof(KnowledgeBaseRetrievalClientOptions))]
    [CodeGenSuppress(nameof(KnowledgeBaseRetrievalClient), typeof(Uri), typeof(string), typeof(AzureKeyCredential), typeof(KnowledgeBaseRetrievalClientOptions))]
#pragma warning disable SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    [CodeGenSuppress(nameof(KnowledgeBaseRetrievalClient), typeof(KnowledgeBaseRetrievalClientSettings))]
#pragma warning restore SCME0002 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    public partial class KnowledgeBaseRetrievalClient
    {
        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Gets the name of the knowledge base.
        /// </summary>
        public virtual string KnowledgeBaseName => _knowledgeBaseName;

        //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="knowledgeBaseName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential) : this(endpoint, knowledgeBaseName, credential, new SearchClientOptions())
        {
        }

        //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="knowledgeBaseName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, TokenCredential credential) : this(endpoint, knowledgeBaseName, credential, new SearchClientOptions())
        {
        }

        //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="authenticationPolicy"> The authentication policy to use for pipeline creation. </param>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal KnowledgeBaseRetrievalClient(HttpPipelinePolicy authenticationPolicy, Uri endpoint, string knowledgeBaseName, SearchClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(knowledgeBaseName, nameof(knowledgeBaseName));

            options ??= new SearchClientOptions();

            _endpoint = endpoint;
            _knowledgeBaseName = knowledgeBaseName;
            if (authenticationPolicy != null)
            {
                Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authenticationPolicy });
            }
            else
            {
                Pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>());
            }
            _apiVersion = options.Version.ToVersionString();
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="knowledgeBaseName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, AzureKeyCredential credential, SearchClientOptions options) : this(new AzureKeyCredentialPolicy(credential, AuthorizationHeader), endpoint, knowledgeBaseName, options)
        {
        }

        //TODO: Remove ctors and suppresions once emitter fixes issue with generating client with KnowledgeBaseRetrievalClientOptions instead of SearchClientOptions
        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient. </summary>
        /// <param name="endpoint"> Service endpoint. </param>
        /// <param name="knowledgeBaseName"> The name of the knowledge base. </param>
        /// <param name="credential"> A credential used to authenticate to the service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="knowledgeBaseName"/> or <paramref name="credential"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="knowledgeBaseName"/> is an empty string, and was expected to be non-empty. </exception>
        public KnowledgeBaseRetrievalClient(Uri endpoint, string knowledgeBaseName, TokenCredential credential, SearchClientOptions options) : this(new BearerTokenAuthenticationPolicy(credential, AuthorizationScopes), endpoint, knowledgeBaseName, options)
        {
        }
    }
}
