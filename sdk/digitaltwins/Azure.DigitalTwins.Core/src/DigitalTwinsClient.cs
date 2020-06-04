// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.DigitalTwins.Core.Models;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The Digital Twins Service Client contains methods to retrieve digital twin information, like models, components, and relationships.
    /// </summary>
    public class DigitalTwinsClient
    {
        private const bool IncludeModelDefinition = true;
        private const string DateTimeOffsetFormat = "MM/dd/yy H:mm:ss zzz";

        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly DigitalTwinsRestClient _dtRestClient;
        private readonly DigitalTwinModelsRestClient _dtModelsRestClient;
        private readonly EventRoutesRestClient _eventRoutesRestClient;
        private readonly QueryRestClient _queryClient;

        /// <summary>
        /// Creates a new instance of the <see cref="DigitalTwinsClient"/> class.
        /// </summary>
        /// <param name='endpoint'>The Azure digital twins service instance URI to connect to.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <seealso cref="DigitalTwinsClient(Uri, TokenCredential)">
        /// This other constructor provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </seealso>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret">
        /// // By using the ClientSecretCredential, a specified application Id can login using a
        /// // client secret.
        /// var tokenCredential = new ClientSecretCredential(
        ///     tenantId,
        ///     clientId,
        ///     clientSecret,
        ///     new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });
        ///
        /// var client = new DigitalTwinsClient(
        ///     new Uri(adtEndpoint),
        ///     tokenCredential);
        /// </code>
        /// </example>
        public DigitalTwinsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new DigitalTwinsClientOptions())
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DigitalTwinsClient"/> class, with options.
        /// </summary>
        /// <param name='endpoint'>The Azure digital twins service instance URI to connect to.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <param name="options">Options that allow configuration of requests sent to the digital twins service.</param>
        /// <remarks>
        /// The options parameter provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateServiceClientInteractiveLogin">
        /// // This illustrates how to specify client options, in this case, by providing an
        /// // instance of HttpClient for the digital twins client to use.
        /// var clientOptions = new DigitalTwinsClientOptions
        /// {
        ///     Transport = new HttpClientTransport(httpClient),
        /// };
        ///
        /// // By using the InteractiveBrowserCredential, the current user can login using a web browser
        /// // interactively with the AAD
        /// var tokenCredential = new InteractiveBrowserCredential(
        ///     tenantId,
        ///     clientId,
        ///     new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });
        ///
        /// var client = new DigitalTwinsClient(
        ///     new Uri(adtEndpoint),
        ///     tokenCredential,
        ///     clientOptions);
        /// </code>
        /// </example>
        public DigitalTwinsClient(Uri endpoint, TokenCredential credential, DigitalTwinsClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes(endpoint)), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            _dtRestClient = new DigitalTwinsRestClient(_clientDiagnostics, _httpPipeline, endpoint, options.GetVersionString());
            _dtModelsRestClient = new DigitalTwinModelsRestClient(_clientDiagnostics, _httpPipeline, endpoint, options.GetVersionString());
            _eventRoutesRestClient = new EventRoutesRestClient(_clientDiagnostics, _httpPipeline, endpoint, options.GetVersionString());
            _queryClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, endpoint);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DigitalTwinsClient"/> class, provided for unit testing purposes only.
        /// </summary>
        protected DigitalTwinsClient()
        {
            // This constructor only exists for mocking purposes in unit tests. It should not be used otherwise.
        }

        /// <summary>
        /// Gets a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <remarks>
        /// The returned application/json string can always be deserialized into an instance of <see cref="Serialization.BasicDigitalTwin"/>.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="Serialization.BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// This sample demonstrates getting and deserializing a digital twin into a custom data type.
        ///
        /// <code snippet="Snippet:DigitalTwinsSampleGetCustomDigitalTwin">
        /// Response&lt;string&gt; getCustomDtResponse = await client.GetDigitalTwinAsync(customDtId);
        /// if (getCustomDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
        /// {
        ///     CustomDigitalTwin customDt = JsonSerializer.Deserialize&lt;CustomDigitalTwin&gt;(getCustomDtResponse.Value);
        ///     Console.WriteLine($&quot;Retrieved and deserialized digital twin {customDt.Id} with ETag {customDt.ETag} &quot; +
        ///         $&quot;and Prop1 &apos;{customDt.Prop1}&apos;, Prop2 &apos;{customDt.Prop2}&apos;, &quot; +
        ///         $&quot;ComponentProp1 &apos;{customDt.Component1.ComponentProp1}, ComponentProp2 &apos;{customDt.Component1.ComponentProp2}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual Task<Response<string>> GetDigitalTwinAsync(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetByIdAsync(digitalTwinId, cancellationToken);
        }

        /// <summary>
        /// Gets a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <remarks>
        /// The returned application/json string can always be deserialized into an instance of <see cref="Serialization.BasicDigitalTwin"/>.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="Serialization.BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        public virtual Response<string> GetDigitalTwin(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetById(digitalTwinId, cancellationToken);
        }

        /// <summary>
        /// Creates a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateCustomTwin">
        /// string customDtId = await GetUniqueTwinIdAsync(SamplesConstants.TemporaryTwinPrefix, client);
        /// var customDigitalTwin = new CustomDigitalTwin
        /// {
        ///     Id = customDtId,
        ///     Metadata = new CustomDigitalTwinMetadata { ModelId = modelId },
        ///     Prop1 = &quot;Prop1 val&quot;,
        ///     Prop2 = &quot;Prop2 val&quot;,
        ///     Component1 = new Component1
        ///     {
        ///         Metadata = new Component1Metadata { ModelId = componentModelId },
        ///         ComponentProp1 = &quot;Component prop1 val&quot;,
        ///         ComponentProp2 = &quot;Component prop2 val&quot;,
        ///     }
        /// };
        /// string dt2Payload = JsonSerializer.Serialize(customDigitalTwin);
        ///
        /// Response&lt;string&gt; createCustomDtResponse = await client.CreateDigitalTwinAsync(customDtId, dt2Payload);
        /// Console.WriteLine($&quot;Created digital twin {customDtId} with response {createCustomDtResponse.GetRawResponse().Status}.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<string>> CreateDigitalTwinAsync(string digitalTwinId, string digitalTwin, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.AddAsync(digitalTwinId, digitalTwin, cancellationToken);
        }

        /// <summary>
        /// Creates a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        public virtual Response<string> CreateDigitalTwin(string digitalTwinId, string digitalTwin, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.Add(digitalTwinId, digitalTwin, cancellationToken);
        }

        /// <summary>
        /// Deletes a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// To delete a digital twin, any relationships referencing it must be deleted first.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteTwin">
        /// await client.DeleteDigitalTwinAsync(twin.Key);
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteDigitalTwinAsync(string digitalTwinId, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteAsync(digitalTwinId, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Deletes a digital twin synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// To delete a digital twin, any relationships referencing it must be deleted first.
        /// </remarks>
        public virtual Response DeleteDigitalTwin(string digitalTwinId, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.Delete(digitalTwinId, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Updates a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="digitalTwinUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwinUpdateOperations"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response<string>> UpdateDigitalTwinAsync(string digitalTwinId, string digitalTwinUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.UpdateAsync(digitalTwinId, digitalTwinUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Updates a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="digitalTwinUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwinUpdateOperations"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateDigitalTwinAsync(string, string, RequestOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<string> UpdateDigitalTwin(string digitalTwinId, string digitalTwinUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.Update(digitalTwinId, digitalTwinUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Gets a component on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentPath">The component being retrieved.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Json string representation of the component corresponding to the provided componentPath and the HTTP response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentPath"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetComponent">
        /// response = await client.GetComponentAsync(basicDtId, SamplesConstants.ComponentPath);
        ///
        /// Console.WriteLine($&quot;Get component for digital twin: \n{response.Value}. Get response status: {response.GetRawResponse().Status}&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<string>> GetComponentAsync(string digitalTwinId, string componentPath, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetComponentAsync(digitalTwinId, componentPath, cancellationToken);
        }

        /// <summary>
        /// Gets a component on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentPath">The component being retrieved.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Json string representation of the component corresponding to the provided componentPath and the HTTP response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentPath"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetComponentAsync(string, string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<string> GetComponent(string digitalTwinId, string componentPath, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetComponent(digitalTwinId, componentPath, cancellationToken);
        }

        /// <summary>
        /// Updates properties of a component on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentPath">The component being modified.</param>
        /// <param name="componentUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentPath"/> is <c>null</c>.
        /// </exception>
        /// <code snippet="Snippet:DigitalTwinsSampleUpdateComponent">
        /// // Update Component1 by replacing the property ComponentProp1 value
        /// var componentUpdateUtility = new UpdateOperationsUtility();
        /// componentUpdateUtility.AppendReplaceOp(&quot;/ComponentProp1&quot;, &quot;Some new value&quot;);
        /// string updatePayload = componentUpdateUtility.Serialize();
        ///
        /// Response&lt;string&gt; response = await client.UpdateComponentAsync(basicDtId, &quot;Component1&quot;, updatePayload);
        ///
        /// Console.WriteLine($&quot;Updated component for digital twin {basicDtId}. Update response status: {response.GetRawResponse().Status}&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<string>> UpdateComponentAsync(string digitalTwinId, string componentPath, string componentUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            // TODO how can we make this patch easier to construct?
            return _dtRestClient.UpdateComponentAsync(digitalTwinId, componentPath, componentUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Updates properties of a component on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentPath">The component being modified.</param>
        /// <param name="componentUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response.</returns>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentPath"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="UpdateComponentAsync(string, string, string, RequestOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<string> UpdateComponent(string digitalTwinId, string componentPath, string componentUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.UpdateComponent(digitalTwinId, componentPath, componentUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Gets all the relationships on a digital twin by iterating through a collection asynchronously <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of application/json relationships belonging to the specified digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetRelationships">
        /// AsyncPageable&lt;string&gt; relationships = client.GetRelationshipsAsync(twin.Key);
        /// </code>
        /// </example>
        public virtual AsyncPageable<string> GetRelationshipsAsync(string digitalTwinId, string relationshipName = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }

            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                scope.Start();
                try
                {
                    Response<RelationshipCollection> response = await _dtRestClient.ListRelationshipsAsync(digitalTwinId, relationshipName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                scope.Start();
                try
                {
                    Response<RelationshipCollection> response = await _dtRestClient.ListRelationshipsNextPageAsync(nextLink, digitalTwinId, relationshipName, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all the relationships on a digital twin by iterating through a collection synchronously <see cref="Pageable{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of application/json relationships belonging to the specified digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipsAsync(string, string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<string> GetRelationships(string digitalTwinId, string relationshipName = null, CancellationToken cancellationToken = default)
        {
            if (digitalTwinId == null)
            {
                throw new ArgumentNullException(nameof(digitalTwinId));
            }

            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                scope.Start();
                try
                {
                    Response<RelationshipCollection> response = _dtRestClient.ListRelationships(digitalTwinId, relationshipName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            Page<string> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                scope.Start();
                try
                {
                    Response<RelationshipCollection> response = _dtRestClient.ListRelationshipsNextPage(nextLink, digitalTwinId, relationshipName, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection asynchronously <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of application/json relationships directed towards the specified digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetIncomingRelationships">
        /// AsyncPageable&lt;IncomingRelationship&gt; incomingRelationships = client.GetIncomingRelationshipsAsync(twin.Key);
        /// </code>
        /// </example>
        public virtual AsyncPageable<IncomingRelationship> GetIncomingRelationshipsAsync(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            async Task<Page<IncomingRelationship>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = await _dtRestClient.ListIncomingRelationshipsAsync(digitalTwinId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<IncomingRelationship>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = await _dtRestClient.ListIncomingRelationshipsNextPageAsync(nextLink, digitalTwinId, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection synchronously <see cref="Pageable{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of application/json relationships directed towards the specified digital twin and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetIncomingRelationshipsAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<IncomingRelationship> GetIncomingRelationships(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            Page<IncomingRelationship> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsGeneratedClient.ListIncomingRelationships");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationships(digitalTwinId, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<IncomingRelationship> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsGeneratedClient.ListIncomingRelationships");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationshipsNextPage(nextLink, digitalTwinId, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a relationship on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json relationship corresponding to the provided relationshipId and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response<string>> GetRelationshipAsync(string digitalTwinId, string relationshipId, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetRelationshipByIdAsync(digitalTwinId, relationshipId, cancellationToken);
        }

        /// <summary>
        /// Gets a relationship on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json relationship corresponding to the provided relationshipId and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipAsync(string, string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<string> GetRelationship(string digitalTwinId, string relationshipId, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.GetRelationshipById(digitalTwinId, relationshipId, cancellationToken);
        }

        /// <summary>
        /// Deletes a relationship on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        public virtual Task<Response> DeleteRelationshipAsync(string digitalTwinId, string relationshipId, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteRelationshipAsync(digitalTwinId, relationshipId, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Deletes a relationship on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteRelationshipAsync(string, string, RequestOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteRelationship(string digitalTwinId, string relationshipId, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteRelationship(digitalTwinId, relationshipId, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Creates a relationship on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship which is being created.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <para>Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.</para>
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateRelationship">
        /// string serializedRelationship = JsonSerializer.Serialize(relationship);
        ///
        /// await client.CreateRelationshipAsync(
        ///     relationship.SourceId,
        ///     relationship.Id,
        ///     serializedRelationship);
        /// </code>
        /// </example>
        public virtual Task<Response<string>> CreateRelationshipAsync(string digitalTwinId, string relationshipId, string relationship, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.AddRelationshipAsync(digitalTwinId, relationshipId, relationship, cancellationToken);
        }

        /// <summary>
        /// Creates a relationship on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <para>Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.</para>
        /// </remarks>
        /// <seealso cref="CreateRelationshipAsync(string, string, string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<string> CreateRelationship(string digitalTwinId, string relationshipId, string relationship, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.AddRelationship(digitalTwinId, relationshipId, relationship, cancellationToken);
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="relationshipUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response> UpdateRelationshipAsync(string digitalTwinId, string relationshipId, string relationshipUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            // TODO how can we make this patch easier to construct?
            return _dtRestClient.UpdateRelationshipAsync(digitalTwinId, relationshipId, relationshipUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="relationshipUpdateOperations">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="requestOptions">The optional settings for this request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateRelationshipAsync(string, string, string, RequestOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response UpdateRelationship(string digitalTwinId, string relationshipId, string relationshipUpdateOperations, RequestOptions requestOptions = default, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.UpdateRelationship(digitalTwinId, relationshipId, relationshipUpdateOperations, requestOptions?.IfMatchEtag, cancellationToken);
        }

        /// <summary>
        /// Gets the list of models by iterating through a collection asynchronously <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <param name="dependenciesFor">The model Ids to have dependencies retrieved.</param>
        /// <param name="includeModelDefinition">Whether to include the model definition in the result. If false, only the model metadata will be returned.</param>
        /// <param name="options">The options to follow when listing the models. For example, the page size hint can be specified.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of application/json models and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModels">
        /// AsyncPageable&lt;ModelData&gt; allModels = client.GetModelsAsync();
        /// await foreach (ModelData model in allModels)
        /// {
        ///     Console.WriteLine($&quot;Model Id: {model.Id}, display name: {model.DisplayName[&quot;en&quot;]}, upload time: {model.UploadTime}, is decommissioned: {model.Decommissioned}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<ModelData> GetModelsAsync(IEnumerable<string> dependenciesFor = default, bool includeModelDefinition = false, GetModelsOptions options = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<ModelData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedModelDataCollection> response = await _dtModelsRestClient.ListAsync(dependenciesFor, includeModelDefinition, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ModelData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedModelDataCollection> response = await _dtModelsRestClient.ListNextPageAsync(nextLink, dependenciesFor, includeModelDefinition, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets the list of models by iterating through a collection synchronously <see cref="Pageable{T}"/>.
        /// </summary>
        /// <param name="dependenciesFor">The model Ids to have dependencies retrieved.</param>
        /// <param name="includeModelDefinition">Whether to include the model definition in the result. If false, only the model metadata will be returned.</param>
        /// <param name="options">The options to follow when listing the models. For example, the page size hint can be specified.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of application/json models and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetModelsAsync(IEnumerable{string}, bool, GetModelsOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<ModelData> GetModels(IEnumerable<string> dependenciesFor = default, bool includeModelDefinition = false, GetModelsOptions options = default, CancellationToken cancellationToken = default)
        {
            Page<ModelData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedModelDataCollection> response = _dtModelsRestClient.List(dependenciesFor, includeModelDefinition, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ModelData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedModelDataCollection> response = _dtModelsRestClient.ListNextPage(nextLink, dependenciesFor, includeModelDefinition, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a model, including the model metadata and the model definition asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModel">
        /// Response&lt;ModelData&gt; sampleModel = await client.GetModelAsync(sampleModelId);
        /// </code>
        /// </example>
        public virtual Task<Response<ModelData>> GetModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            // The GetModel API will include the model definition in its response by default.
            return _dtModelsRestClient.GetByIdAsync(modelId, IncludeModelDefinition, cancellationToken);
        }

        /// <summary>
        /// Gets a model, including the model metadata and the model definition synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetModelAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<ModelData> GetModel(string modelId, CancellationToken cancellationToken = default)
        {
            // The GetModel API will include the model definition in its response by default.
            return _dtModelsRestClient.GetById(modelId, IncludeModelDefinition, cancellationToken);
        }

        /// <summary>
        /// Decommissions a model asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// When a model is decomissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decomissioned, it may not be recommissioned.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDecommisionModel">
        /// try
        /// {
        ///     await client.DecommissionModelAsync(sampleModelId);
        ///
        ///     Console.WriteLine($&quot;Successfully decommissioned model {sampleModelId}&quot;);
        /// }
        /// catch (Exception ex)
        /// {
        ///     FatalError($&quot;Failed to decommision model {sampleModelId} due to:\n{ex}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual Task<Response> DecommissionModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.UpdateAsync(modelId, ModelsConstants.DecommissionModelOperationList, cancellationToken);
        }

        /// <summary>
        /// Decommissions a model synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// When a model is decomissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decomissioned, it may not be recommissioned.
        /// </remarks>
        /// <seealso cref="DecommissionModelAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DecommissionModel(string modelId, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.Update(modelId, ModelsConstants.DecommissionModelOperationList, cancellationToken);
        }

        /// <summary>
        /// Creates one or many models asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="models">The set of models to create. Each string corresponds to exactly one model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <remarks>
        /// Bulk model creation is useful when several models have references to each other.
        /// It simplifies creation for the client because otherwise the models would have to be created in a very specific order.
        /// The service evaluates all models to ensure all references are satisfied, and then accepts or rejects the set.
        /// So using this method, model creation is transactional.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateModels">
        /// Response&lt;IReadOnlyList&lt;ModelData&gt;&gt; response = await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
        /// Console.WriteLine($&quot;Successfully created a model with Id: {newComponentModelId}, {sampleModelId}, status: {response.GetRawResponse().Status}&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<IReadOnlyList<ModelData>>> CreateModelsAsync(IEnumerable<string> models, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.AddAsync(models, cancellationToken);
        }

        /// <summary>
        /// Creates one or many models synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="models">The set of models to create. Each string corresponds to exactly one model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <remarks>
        /// Bulk model creation is useful when several models have references to each other.
        /// It simplifies creation for the client because otherwise the models would have to be created in a very specific order.
        /// The service evaluates all models to ensure all references are satisfied, and then accepts or rejects the set.
        /// So using this method, model creation is transactional.
        /// </remarks>
        /// <seealso cref="CreateModelsAsync(IEnumerable{string}, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<IReadOnlyList<ModelData>> CreateModels(IEnumerable<string> models, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.Add(models, cancellationToken);
        }

        /// <summary>
        /// Deletes a model asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// A model can only be deleted if no other models reference it.
        /// Status codes:
        /// 204 (No Content): Success.
        /// 400 (Bad Request): The request is invalid.
        /// 404 (Not Found): There is no model with the provided id.
        /// 409 (Conflict): There are dependencies on the model that prevent it from being deleted.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteModel">
        /// try
        /// {
        ///     await client.DeleteModelAsync(sampleModelId);
        ///
        ///     Console.WriteLine($&quot;Deleted model {sampleModelId}&quot;);
        /// }
        /// catch (Exception ex)
        /// {
        ///     FatalError($&quot;Failed to delete model {sampleModelId} due to:\n{ex}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.DeleteAsync(modelId, cancellationToken);
        }

        /// <summary>
        /// Deletes a model synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// A model can only be deleted if no other models reference it.
        /// Status codes:
        /// 204 (No Content): Success.
        /// 400 (Bad Request): The request is invalid.
        /// 404 (Not Found): There is no model with the provided id.
        /// 409 (Conflict): There are dependencies on the model that prevent it from being deleted.
        /// </remarks>
        /// <seealso cref="DeleteModelAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.Delete(modelId, cancellationToken);
        }

        /// <summary>
        /// Queries for digital twins by iterating through a collection asynchronously <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of query results.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleQueryTwins">
        /// // This code snippet demonstrates the simplest way to iterate over the digital twin results, where paging
        /// // happens under the covers.
        /// AsyncPageable&lt;string&gt; asyncPageableResponse = client.QueryAsync(&quot;SELECT * FROM digitaltwins&quot;);
        ///
        /// // Iterate over the twin instances in the pageable response.
        /// // The &quot;await&quot; keyword here is required because new pages will be fetched when necessary,
        /// // which involves a request to the service.
        /// await foreach (string response in asyncPageableResponse)
        /// {
        ///     BasicDigitalTwin twin = JsonSerializer.Deserialize&lt;BasicDigitalTwin&gt;(response);
        ///     Console.WriteLine($&quot;Found digital twin: {twin.Id}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<string> QueryAsync(string query, CancellationToken cancellationToken = default)
        {
            // Note: pageSizeHint is not supported as a parameter in the service for query API, so ignoring it.
            // Cannot remove the parameter as the function signature in Azure.Core helper needs it.
            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var querySpecification = new QuerySpecification
                    {
                        Query = query
                    };
                    Response<QueryResult> response = await _queryClient.QueryTwinsAsync(querySpecification, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Items, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var querySpecification = new QuerySpecification
                    {
                        ContinuationToken = nextLink
                    };
                    Response<QueryResult> response = await _queryClient.QueryTwinsAsync(querySpecification, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Items, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Queries for digital twins by iterating through a collection synchronously <see cref="Pageable{T}"/>.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list of query results.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// A basic query for all digital twins: SELECT * FROM digitalTwins.
        /// </example>
        /// <seealso cref="QueryAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<string> Query(string query, CancellationToken cancellationToken = default)
        {
            // Note: pageSizeHint is not supported as a parameter in the service for query API, so ignoring it.
            // Cannot remove the parameter as the function signature in Azure.Core helper needs it.
            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var querySpecification = new QuerySpecification
                    {
                        Query = query
                    };
                    Response<QueryResult> response = _queryClient.QueryTwins(querySpecification, cancellationToken);
                    return Page.FromValues(response.Value.Items, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            Page<string> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                scope.Start();
                try
                {
                    var querySpecification = new QuerySpecification
                    {
                        ContinuationToken = nextLink
                    };
                    Response<QueryResult> response = _queryClient.QueryTwins(querySpecification, cancellationToken);
                    return Page.FromValues(response.Value.Items, response.Value.ContinuationToken, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>.
        /// Lists the event routes in a digital twins instance by iterating through a collection asynchronously <see cref="AsyncPageable{T}"/>.
        /// </summary>
        /// <param name="options">The options to use when listing the event routes. One can set the maximum number of items to retrieve per request, however the service may return less than requested.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of application/json event routes and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetEventRoutes">
        /// AsyncPageable&lt;EventRoute&gt; response = client.GetEventRoutesAsync();
        /// await foreach (EventRoute er in response)
        /// {
        ///     Console.WriteLine($&quot;Event route: {er.Id}, endpoint name: {er.EndpointName}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<EventRoute> GetEventRoutesAsync(EventRoutesListOptions options = default, CancellationToken cancellationToken = default)
        {
            async Task<Page<EventRoute>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("EventRoutesClient.List");
                scope.Start();
                try
                {
                    Response<EventRouteCollection> response = await _eventRoutesRestClient.ListAsync(options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<EventRoute>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("EventRoutesClient.List");
                scope.Start();
                try
                {
                    Response<EventRouteCollection> response = await _eventRoutesRestClient.ListNextPageAsync(nextLink, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>.
        /// Lists the event routes in a digital twins instance by iterating through a collection synchronously <see cref="Pageable{T}"/>.
        /// </summary>
        /// <param name="options">The options to use when listing the event routes. One can set the maximum number of items to retrieve per request, however the service may return less than requested.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of application/json event routes and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetEventRoutesAsync(EventRoutesListOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<EventRoute> GetEventRoutes(EventRoutesListOptions options = default, CancellationToken cancellationToken = default)
        {
            Page<EventRoute> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("EventRoutesClient.List");
                scope.Start();
                try
                {
                    Response<EventRouteCollection> response = _eventRoutesRestClient.List(options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<EventRoute> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("EventRoutesClient.List");
                scope.Start();
                try
                {
                    Response<EventRouteCollection> response = _eventRoutesRestClient.ListNextPage(nextLink, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets an event route by Id asynchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response<EventRoute>> GetEventRouteAsync(string eventRouteId, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.GetByIdAsync(eventRouteId, cancellationToken);
        }

        /// <summary>
        /// Gets an event route by Id synchronously. After the task completes, the result will be set to <see cref="Response{T}"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetEventRouteAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<EventRoute> GetEventRoute(string eventRouteId, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.GetById(eventRouteId, cancellationToken);
        }

        /// <summary>
        /// Creates an event route asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateEventRoute">
        /// string eventFilter = &quot;$eventType = &apos;DigitalTwinTelemetryMessages&apos; or $eventType = &apos;DigitalTwinLifecycleNotification&apos;&quot;;
        /// var eventRoute = new EventRoute(eventhubEndpointName)
        /// {
        ///     Filter = eventFilter
        /// };
        ///
        /// Response createEventRouteResponse = await client.CreateEventRouteAsync(_eventRouteId, eventRoute);
        /// </code>
        /// </example>
        public virtual Task<Response> CreateEventRouteAsync(string eventRouteId, EventRoute eventRoute, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.AddAsync(eventRouteId, eventRoute, cancellationToken);
        }

        /// <summary>
        /// Creates an event route synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="CreateEventRouteAsync(string, EventRoute, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response CreateEventRoute(string eventRouteId, EventRoute eventRoute, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.Add(eventRouteId, eventRoute, cancellationToken);
        }

        /// <summary>
        /// Deletes an event route asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteEventRoute">
        /// Response response = await client.DeleteEventRouteAsync(_eventRouteId);
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteEventRouteAsync(string eventRouteId, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.DeleteAsync(eventRouteId, cancellationToken);
        }

        /// <summary>
        /// Deletes an event route synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteEventRouteAsync(string, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteEventRoute(string eventRouteId, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.Delete(eventRouteId, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The additional information to be used when processing a telemetry request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSamplePublishTelemetry">
        /// // construct your json telemetry payload by hand.
        /// Response publishTelemetryResponse = await client.PublishTelemetryAsync(twinId, &quot;{\&quot;Telemetry1\&quot;: 5}&quot;);
        /// Console.WriteLine($&quot;Successfully published telemetry message, status: {publishTelemetryResponse.Status}&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> PublishTelemetryAsync(string digitalTwinId, string payload, TelemetryOptions options = default, CancellationToken cancellationToken = default)
        {
            TelemetryOptions telemetryOptions = options ?? new TelemetryOptions();
            var dateTimeInString = TypeFormatters.ToString(telemetryOptions.TimeStamp, DateTimeOffsetFormat);

            return _dtRestClient
                .SendTelemetryAsync(digitalTwinId, telemetryOptions.MessageId, payload, dateTimeInString, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The additional information to be used when processing a telemetry request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishTelemetryAsync(string, string, TelemetryOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response PublishTelemetry(string digitalTwinId, string payload, TelemetryOptions options = default, CancellationToken cancellationToken = default)
        {
            TelemetryOptions telemetryOptions = options ?? new TelemetryOptions();
            var dateTimeInString = TypeFormatters.ToString(telemetryOptions.TimeStamp, DateTimeOffsetFormat);

            return _dtRestClient.SendTelemetry(digitalTwinId, telemetryOptions.MessageId, payload, dateTimeInString, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component asynchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The additional information to be used when processing a telemetry request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSamplePublishComponentTelemetry">
        /// // construct your json telemetry payload by serializing a dictionary.
        /// var telemetryPayload = new Dictionary&lt;string, int&gt;
        /// {
        ///     { &quot;ComponentTelemetry1&quot;, 9}
        /// };
        /// Response publishTelemetryToComponentResponse = await client.PublishComponentTelemetryAsync(
        ///     twinId,
        ///     &quot;Component1&quot;,
        ///     JsonSerializer.Serialize(telemetryPayload));
        /// Console.WriteLine($&quot;Successfully published component telemetry message, status: {publishTelemetryToComponentResponse.Status}&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> PublishComponentTelemetryAsync(string digitalTwinId, string componentName, string payload, TelemetryOptions options = default, CancellationToken cancellationToken = default)
        {
            TelemetryOptions telemetryOptions = options ?? new TelemetryOptions();
            var dateTimeInString = TypeFormatters.ToString(telemetryOptions.TimeStamp, DateTimeOffsetFormat);

            return _dtRestClient
                .SendComponentTelemetryAsync(digitalTwinId, componentName, telemetryOptions.MessageId, payload, dateTimeInString, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component synchronously. After the task completes, the result will be set to <see cref="Response"/>.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The additional information to be used when processing a telemetry request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishComponentTelemetryAsync(string, string, string, TelemetryOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response PublishComponentTelemetry(string digitalTwinId, string componentName, string payload, TelemetryOptions options = default, CancellationToken cancellationToken = default)
        {
            TelemetryOptions telemetryOptions = options ?? new TelemetryOptions();
            var dateTimeInString = TypeFormatters.ToString(telemetryOptions.TimeStamp, DateTimeOffsetFormat);

            return _dtRestClient.SendComponentTelemetry(digitalTwinId, componentName, telemetryOptions.MessageId, payload, dateTimeInString, cancellationToken);
        }

        /// <summary>
        /// Gets the scope for authentication/authorization policy.
        /// </summary>
        /// <param name="endpoint">Azure digital twins instance Uri.</param>
        /// <returns>List of scopes for the specified endpoint.</returns>
        internal static string[] GetAuthorizationScopes(Uri endpoint)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(endpoint.AbsoluteUri, nameof(endpoint.AbsoluteUri));

            // Uri representation for azure digital twin app Id "0b07f429-9f4b-4714-9392-cc5e8e80c8b0" in the public cloud.
            const string adtPublicCloudAppId = "https://digitaltwins.azure.net";
            const string defaultPermissionConsent = "/.default";

            // If the endpoint is in Azure public cloud, the suffix will have "azure.net" or "ppe.net".
            // Once ADT becomes available in other clouds, their corresponding scope has to be matched and set.
            if (endpoint.AbsoluteUri.IndexOf("azure.net", StringComparison.OrdinalIgnoreCase) > 0
                || endpoint.AbsoluteUri.IndexOf("ppe.net", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return new[] { adtPublicCloudAppId + defaultPermissionConsent };
            }

            throw new InvalidOperationException($"Azure digital twins instance endpoint '{endpoint.AbsoluteUri}' is not valid.");
        }
    }
}
