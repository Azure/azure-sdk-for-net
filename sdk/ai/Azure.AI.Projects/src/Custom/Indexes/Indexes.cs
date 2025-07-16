// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class Indexes
    {
        /// <summary>
        /// [Protocol Method] Create a new or update an existing Index with the given version id
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the Index to create or update. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult<DatasetIndex> CreateOrUpdate(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateOrUpdateRequest(name, version, content, options);
            ClientResult result = ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
            return ClientResult.FromValue((DatasetIndex)result, result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Create a new or update an existing Index with the given version id
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the Index to create or update. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult<DatasetIndex>> CreateOrUpdateAsync(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateOrUpdateRequest(name, version, content, options);
            ClientResult result =  ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
            return ClientResult.FromValue((DatasetIndex)result, result.GetRawResponse());
        }
    }
}
