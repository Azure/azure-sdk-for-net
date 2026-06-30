// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    /// <summary> The AIProjectModels sub-client. </summary>
    public partial class AIProjectModels
    {
        internal virtual CollectionResult GetModelVersions(string name, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return new AIProjectModelsGetModelVersionsCollectionResult(this, name, options);
        }

        /// <summary>
        /// [Protocol Method] List all versions of the given ModelVersion
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual AsyncCollectionResult GetModelVersionsAsync(string name, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return new AIProjectModelsGetModelVersionsAsyncCollectionResult(this, name, options);
        }

        /// <summary> List all versions of the given ModelVersion. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual CollectionResult<ModelVersion> GetModelVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return new AIProjectModelsGetModelVersionsCollectionResultOfT(this, name, cancellationToken.ToRequestOptions());
        }

        /// <summary> List all versions of the given ModelVersion. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual AsyncCollectionResult<ModelVersion> GetModelVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            return new AIProjectModelsGetModelVersionsAsyncCollectionResultOfT(this, name, cancellationToken.ToRequestOptions());
        }

        /// <summary>
        /// [Protocol Method] List the latest version of each ModelVersion
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual CollectionResult GetLatestModelVersions(RequestOptions options)
        {
            return new AIProjectModelsGetLatestModelVersionsCollectionResult(this, options);
        }

        /// <summary>
        /// [Protocol Method] List the latest version of each ModelVersion
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual AsyncCollectionResult GetLatestModelVersionsAsync(RequestOptions options)
        {
            return new AIProjectModelsGetLatestModelVersionsAsyncCollectionResult(this, options);
        }

        /// <summary> List the latest version of each ModelVersion. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual CollectionResult<ModelVersion> GetLatestModelVersions(CancellationToken cancellationToken = default)
        {
            return new AIProjectModelsGetLatestModelVersionsCollectionResultOfT(this, cancellationToken.ToRequestOptions());
        }

        /// <summary> List the latest version of each ModelVersion. </summary>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual AsyncCollectionResult<ModelVersion> GetLatestModelVersionsAsync(CancellationToken cancellationToken = default)
        {
            return new AIProjectModelsGetLatestModelVersionsAsyncCollectionResultOfT(this, cancellationToken.ToRequestOptions());
        }

        /// <summary>
        /// [Protocol Method] Get the specific version of the ModelVersion. The service returns 404 Not Found error if the ModelVersion does not exist.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the ModelVersion to retrieve. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult GetModelVersion(string name, string version, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using PipelineMessage message = CreateGetModelVersionRequest(name, version, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Get the specific version of the ModelVersion. The service returns 404 Not Found error if the ModelVersion does not exist.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the ModelVersion to retrieve. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> GetModelVersionAsync(string name, string version, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using PipelineMessage message = CreateGetModelVersionRequest(name, version, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary> Get the specific version of the ModelVersion. The service returns 404 Not Found error if the ModelVersion does not exist. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the ModelVersion to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual ClientResult<ModelVersion> GetModelVersion(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            ClientResult result = GetModelVersion(name, version, cancellationToken.ToRequestOptions());
            return ClientResult.FromValue((ModelVersion)result, result.GetRawResponse());
        }

        /// <summary> Get the specific version of the ModelVersion. The service returns 404 Not Found error if the ModelVersion does not exist. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the ModelVersion to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual async Task<ClientResult<ModelVersion>> GetModelVersionAsync(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            ClientResult result = await GetModelVersionAsync(name, version, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
            return ClientResult.FromValue((ModelVersion)result, result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Delete the specific version of the ModelVersion. The service returns 200 OK if the ModelVersion was deleted successfully or if the ModelVersion does not exist.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The version of the ModelVersion to delete. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult DeleteModelVersion(string name, string version, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using PipelineMessage message = CreateDeleteModelVersionRequest(name, version, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Delete the specific version of the ModelVersion. The service returns 200 OK if the ModelVersion was deleted successfully or if the ModelVersion does not exist.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The version of the ModelVersion to delete. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> DeleteModelVersionAsync(string name, string version, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using PipelineMessage message = CreateDeleteModelVersionRequest(name, version, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary> Delete the specific version of the ModelVersion. The service returns 200 OK if the ModelVersion was deleted successfully or if the ModelVersion does not exist. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The version of the ModelVersion to delete. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual ClientResult DeleteModelVersion(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            return DeleteModelVersion(name, version, cancellationToken.ToRequestOptions());
        }

        /// <summary> Delete the specific version of the ModelVersion. The service returns 200 OK if the ModelVersion was deleted successfully or if the ModelVersion does not exist. </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The version of the ModelVersion to delete. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual async Task<ClientResult> DeleteModelVersionAsync(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            return await DeleteModelVersionAsync(name, version, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        }

        /// <summary>
        /// [Protocol Method] Update an existing ModelVersion with the given version id
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the UpdateModelVersionRequest to create or update. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult UpdateModelVersion(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateUpdateModelVersionRequest(name, version, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Update an existing ModelVersion with the given version id
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="version"> The specific version id of the UpdateModelVersionRequest to create or update. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> UpdateModelVersionAsync(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateUpdateModelVersionRequest(name, version, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Creates a model version asynchronously with blob content validation. Returns 202 Accepted with a Location header for polling.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult CreateModelVersionRequest(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateModelVersionRequestRequest(name, version, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Creates a model version asynchronously with blob content validation. Returns 202 Accepted with a Location header for polling.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> CreateModelVersionRequestAsync(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateModelVersionRequestRequest(name, version, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary> Creates a model version asynchronously with blob content validation. Returns 202 Accepted with a Location header for polling. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="modelVersion"> Model version to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="modelVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual ClientResult<CreateAsyncResponse> CreateModelVersionRequest(string name, string version, ModelVersion modelVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(modelVersion, nameof(modelVersion));

            ClientResult result = CreateModelVersionRequest(name, version, modelVersion, cancellationToken.ToRequestOptions());
            return ClientResult.FromValue((CreateAsyncResponse)result, result.GetRawResponse());
        }

        /// <summary> Creates a model version asynchronously with blob content validation. Returns 202 Accepted with a Location header for polling. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="modelVersion"> Model version to create. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="modelVersion"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual async Task<ClientResult<CreateAsyncResponse>> CreateModelVersionRequestAsync(string name, string version, ModelVersion modelVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(modelVersion, nameof(modelVersion));

            ClientResult result = await CreateModelVersionRequestAsync(name, version, modelVersion, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
            return ClientResult.FromValue((CreateAsyncResponse)result, result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Start or retrieve a pending upload for a model version.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult StartModelPendingUpload(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateStartModelPendingUploadRequest(name, version, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Start or retrieve a pending upload for a model version.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> StartModelPendingUploadAsync(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateStartModelPendingUploadRequest(name, version, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary> Start or retrieve a pending upload for a model version. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="pendingUploadContent"></param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="pendingUploadContent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual ClientResult<ModelPendingUploadResult> StartModelPendingUpload(string name, string version, ModelPendingUploadContent pendingUploadContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(pendingUploadContent, nameof(pendingUploadContent));

            ClientResult result = StartModelPendingUpload(name, version, pendingUploadContent, cancellationToken.ToRequestOptions());
            return ClientResult.FromValue((ModelPendingUploadResult)result, result.GetRawResponse());
        }

        /// <summary> Start or retrieve a pending upload for a model version. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="pendingUploadContent"></param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="pendingUploadContent"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        public virtual async Task<ClientResult<ModelPendingUploadResult>> StartModelPendingUploadAsync(string name, string version, ModelPendingUploadContent pendingUploadContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(pendingUploadContent, nameof(pendingUploadContent));

            ClientResult result = await StartModelPendingUploadAsync(name, version, pendingUploadContent, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
            return ClientResult.FromValue((ModelPendingUploadResult)result, result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get credentials for a model version asset.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual ClientResult GetModelCredentials(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateGetModelCredentialsRequest(name, version, content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        /// <summary>
        /// [Protocol Method] Get credentials for a model version asset.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<ClientResult> GetModelCredentialsAsync(string name, string version, BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateGetModelCredentialsRequest(name, version, content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary> Get credentials for a model version asset. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="credentialRequest"></param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialRequest"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual ClientResult<DatasetCredential> GetModelCredentials(string name, string version, ModelCredentialRequest credentialRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(credentialRequest, nameof(credentialRequest));

            ClientResult result = GetModelCredentials(name, version, credentialRequest, cancellationToken.ToRequestOptions());
            return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
        }

        /// <summary> Get credentials for a model version asset. </summary>
        /// <param name="name"> Name of the model. </param>
        /// <param name="version"> Version of the model. </param>
        /// <param name="credentialRequest"></param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="version"/> or <paramref name="credentialRequest"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="name"/> or <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        internal virtual async Task<ClientResult<DatasetCredential>> GetModelCredentialsAsync(string name, string version, ModelCredentialRequest credentialRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));
            Argument.AssertNotNull(credentialRequest, nameof(credentialRequest));

            ClientResult result = await GetModelCredentialsAsync(name, version, credentialRequest, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
            return ClientResult.FromValue((DatasetCredential)result, result.GetRawResponse());
        }
    }
}
