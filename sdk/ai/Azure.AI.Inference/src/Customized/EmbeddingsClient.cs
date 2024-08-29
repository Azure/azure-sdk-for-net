// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.AI.Inference
{
    // CUSTOM CODE NOTE:
    //   Modified code for the ChatCompletionsClient

    /// <summary> The Embeddings service client. </summary>
    public partial class EmbeddingsClient
    {
        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="../Generated/Docs/EmbeddingsClient.xml" path="doc/members/member[@name='EmbedAsync(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual async Task<Response<EmbeddingsResult>> EmbedAsync(EmbeddingsOptions embeddingsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await EmbedAsync(content, extraParams?.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }

        /// <summary>
        /// Return the embedding vectors for given text prompts.
        /// The method makes a REST API call to the `/embeddings` route on the given endpoint.
        /// </summary>
        /// <param name="embeddingsOptions"></param>
        /// <param name="extraParams">
        /// Controls what happens if extra parameters, undefined by the REST API,
        /// are passed in the JSON request payload.
        /// This sets the HTTP request header `extra-parameters`.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="embeddingsOptions"/> is null. </exception>
        /// <include file="../Generated/Docs/EmbeddingsClient.xml" path="doc/members/member[@name='Embed(EmbeddingsOptions,ExtraParameters?,CancellationToken)']/*" />
        public virtual Response<EmbeddingsResult> Embed(EmbeddingsOptions embeddingsOptions, ExtraParameters? extraParams = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(embeddingsOptions, nameof(embeddingsOptions));

            using RequestContent content = embeddingsOptions.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Embed(content, extraParams?.ToString(), context);
            return Response.FromValue(EmbeddingsResult.FromResponse(response), response);
        }
    }
}
