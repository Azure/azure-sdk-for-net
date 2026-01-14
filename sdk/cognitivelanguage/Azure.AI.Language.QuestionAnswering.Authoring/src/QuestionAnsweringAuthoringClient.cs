// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    /// <summary>
    /// Hand-authored extensions for <see cref="QuestionAnsweringAuthoringClient"/>.
    /// </summary>
    public partial class QuestionAnsweringAuthoringClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="QuestionAnsweringAuthoringClient"/> using Azure Active Directory authentication.
        /// </summary>
        /// <param name="endpoint">The Question Answering Authoring endpoint on which to operate.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> to use for authenticating requests.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringAuthoringClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new QuestionAnsweringAuthoringClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="QuestionAnsweringAuthoringClient"/> using Azure Active Directory authentication.
        /// </summary>
        /// <param name="endpoint">The Question Answering Authoring endpoint on which to operate.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> to use for authenticating requests.</param>
        /// <param name="options">The client configuration to apply.</param>
        /// <exception cref="ArgumentNullException"><paramref name="endpoint"/> or <paramref name="credential"/> is null.</exception>
        public QuestionAnsweringAuthoringClient(
            Uri endpoint,
            TokenCredential credential,
            QuestionAnsweringAuthoringClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new QuestionAnsweringAuthoringClientOptions();

            var audience = options.Audience ?? QuestionAnsweringAuthoringAudience.AzurePublicCloud;
            var authorizationScope = $"{audience}/.default";

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                new HttpPipelinePolicy[]
                {
                    new BearerTokenAuthenticationPolicy(_tokenCredential, authorizationScope)
                },
                new ResponseClassifier()
            );
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }
    }
}
