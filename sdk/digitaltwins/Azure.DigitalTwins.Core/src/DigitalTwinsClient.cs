// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The Digital Twins Service Client contains methods to retrieve digital twin information, like models, components, and relationships.
    /// </summary>
    public class DigitalTwinsClient
    {
        private const bool IncludeModelDefinition = true;

        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly ObjectSerializer _objectSerializer;

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
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret">
        /// // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
        /// // It attempts to use multiple credential types in an order until it finds a working credential.
        /// var tokenCredential = new DefaultAzureCredential();
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
        /// <para>
        /// The options parameter provides an opportunity to override default behavior, including specifying API version,
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        public DigitalTwinsClient(Uri endpoint, TokenCredential credential, DigitalTwinsClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);

            _objectSerializer = options.Serializer ?? new JsonObjectSerializer();

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes(endpoint)), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _dtRestClient = new DigitalTwinsRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _dtModelsRestClient = new DigitalTwinModelsRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _eventRoutesRestClient = new EventRoutesRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _queryClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DigitalTwinsClient"/> class, provided for unit testing purposes only.
        /// </summary>
        protected DigitalTwinsClient()
        {
            // This constructor only exists for mocking purposes in unit tests. It should not be used otherwise.
        }

        /// <summary>
        /// Gets a digital twin asynchronously.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A strongly typed object type such as <see cref="Serialization.BasicDigitalTwin"/> can be used as a generic type for <typeparamref name="T"/>
        /// to indicate what type is used to deserialize the response value.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="Serialization.BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json digital twin and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the digital twin with.</typeparam>
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
        /// Response&lt;CustomDigitalTwin&gt; getCustomDtResponse = await client.GetDigitalTwinAsync&lt;CustomDigitalTwin&gt;(customDtId);
        /// CustomDigitalTwin customDt = getCustomDtResponse.Value;
        /// Console.WriteLine($&quot;Retrieved and deserialized digital twin {customDt.Id}:\n\t&quot; +
        ///     $&quot;ETag: {customDt.ETag}\n\t&quot; +
        ///     $&quot;Prop1: {customDt.Prop1}\n\t&quot; +
        ///     $&quot;Prop2: {customDt.Prop2}\n\t&quot; +
        ///     $&quot;ComponentProp1: {customDt.Component1.ComponentProp1}\n\t&quot; +
        ///     $&quot;ComponentProp2: {customDt.Component1.ComponentProp2}&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<T>> GetDigitalTwinAsync<T>(string digitalTwinId, GetDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the digital twin as a Stream object
            Response<Stream> digitalTwinStream = await _dtRestClient.GetByIdAsync(digitalTwinId, options, cancellationToken).ConfigureAwait(false);

            // Deserialize the stream into the generic type
            T deserializedDigitalTwin = (T)await _objectSerializer.DeserializeAsync(digitalTwinStream, typeof(T), cancellationToken).ConfigureAwait(false);

            return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
        }

        /// <summary>
        /// Gets a digital twin synchronously.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A strongly typed object type such as <see cref="Serialization.BasicDigitalTwin"/> can be used as a generic type for <typeparamref name="T"/>
        /// to indicate what type is used to deserialize the response value.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="Serialization.BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <returns>The deserialized application/json digital twin and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the digital twin with.</typeparam>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        public virtual Response<T> GetDigitalTwin<T>(string digitalTwinId, GetDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the digital twin as a Stream object
            Response<Stream> digitalTwinStream = _dtRestClient.GetById(digitalTwinId, options, cancellationToken);

            // Deserialize the stream into the generic type
            T deserializedDigitalTwin = (T)_objectSerializer.Deserialize(digitalTwinStream, typeof(T), cancellationToken);

            return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
        }

        /// <summary>
        /// Creates a digital twin asynchronously. If the provided digital twin Id is already in use, then this will attempt to replace the existing digital twin
        /// with the provided digital twin.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the digital twin with.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateCustomTwin">
        /// var customTwin = new CustomDigitalTwin
        /// {
        ///     Id = customDtId,
        ///     Metadata = { ModelId = modelId },
        ///     Prop1 = &quot;Prop1 val&quot;,
        ///     Prop2 = 987,
        ///     Component1 = new MyCustomComponent
        ///     {
        ///         ComponentProp1 = &quot;Component prop1 val&quot;,
        ///         ComponentProp2 = 123,
        ///     }
        /// };
        /// Response&lt;CustomDigitalTwin&gt; createCustomDigitalTwinResponse = await client.CreateDigitalTwinAsync&lt;CustomDigitalTwin&gt;(customDtId, customTwin);
        /// Console.WriteLine($&quot;Created digital twin &apos;{createCustomDigitalTwinResponse.Value.Id}&apos;.&quot;);
        /// </code>
        /// </example>
        public async virtual Task<Response<T>> CreateDigitalTwinAsync<T>(string digitalTwinId, T digitalTwin, CreateDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            // Serialize the digital twin object and write it to a Stream
            using MemoryStream memoryStream = await WriteToStream<T>(digitalTwin, _objectSerializer, true /*async*/, cancellationToken).ConfigureAwait(false);

            // Get the digital twin as a Stream object
            Response<Stream> digitalTwinStream = await _dtRestClient.AddAsync(digitalTwinId, memoryStream, options, cancellationToken).ConfigureAwait(false);

            // Deserialize the stream into the generic type
            T deserializedDigitalTwin = (T)await _objectSerializer.DeserializeAsync(digitalTwinStream, typeof(T), cancellationToken).ConfigureAwait(false);

            return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
        }

        /// <summary>
        /// Creates a digital twin synchronously. If the provided digital twin Id is already in use, then this will attempt to replace the existing digital twin
        /// with the provided digital twin.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the digital twin with.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        public virtual Response<T> CreateDigitalTwin<T>(string digitalTwinId, T digitalTwin, CreateDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            // Serialize the digital twin object and write it to a Stream
            using MemoryStream memoryStream = WriteToStream<T>(digitalTwin, _objectSerializer, false /*async*/, cancellationToken).EnsureCompleted();

            // Get the digital twin as a Stream object
            Response<Stream> digitalTwinStream = _dtRestClient.Add(digitalTwinId, memoryStream, options, cancellationToken);

            // Deserialize the stream into the generic type
            T deserializedDigitalTwin = (T)_objectSerializer.Deserialize(digitalTwinStream, typeof(T), cancellationToken);

            return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
        }

        /// <summary>
        /// Deletes a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
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
        /// await client.DeleteDigitalTwinAsync(digitalTwinId);
        /// Console.WriteLine($&quot;Deleted digital twin &apos;{digitalTwinId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteDigitalTwinAsync(string digitalTwinId, DeleteDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteAsync(digitalTwinId, options, cancellationToken);
        }

        /// <summary>
        /// Deletes a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// To delete a digital twin, any relationships referencing it must be deleted first.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        public virtual Response DeleteDigitalTwin(string digitalTwinId, DeleteDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.Delete(digitalTwinId, options, cancellationToken);
        }

        /// <summary>
        /// Updates a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="jsonPatchDocument"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response> UpdateDigitalTwinAsync(string digitalTwinId, JsonPatchDocument jsonPatchDocument, UpdateDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.UpdateAsync(digitalTwinId, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Updates a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="jsonPatchDocument"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateDigitalTwinAsync(string, JsonPatchDocument, UpdateDigitalTwinOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response UpdateDigitalTwin(string digitalTwinId, JsonPatchDocument jsonPatchDocument, UpdateDigitalTwinOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.Update(digitalTwinId, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Gets a component on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being retrieved.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized object representation of the component corresponding to the provided componentName and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the component with.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetComponent">
        /// await client.GetComponentAsync&lt;MyCustomComponent&gt;(basicDtId, SamplesConstants.ComponentName);
        /// Console.WriteLine($&quot;Retrieved component for digital twin &apos;{basicDtId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<T>> GetComponentAsync<T>(string digitalTwinId, string componentName, GetComponentOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the component as a Stream object
            Response<Stream> componentStream = await _dtRestClient.GetComponentAsync(digitalTwinId, componentName, options, cancellationToken).ConfigureAwait(false);

            // Deserialize the stream into the generic type
            T deserializedComponent = (T)await _objectSerializer.DeserializeAsync(componentStream, typeof(T), cancellationToken).ConfigureAwait(false);

            return Response.FromValue<T>(deserializedComponent, componentStream.GetRawResponse());
        }

        /// <summary>
        /// Gets a component on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being retrieved.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized object representation of the component corresponding to the provided componentName and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the component with.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetComponentAsync(string, string, GetComponentOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<T> GetComponent<T>(string digitalTwinId, string componentName, GetComponentOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the component as a Stream object
            Response<Stream> componentStream = _dtRestClient.GetComponent(digitalTwinId, componentName, options, cancellationToken);

            // Deserialize the stream into the generic type
            T deserializedComponent = (T)_objectSerializer.Deserialize(componentStream, typeof(T), cancellationToken);

            return Response.FromValue<T>(deserializedComponent, componentStream.GetRawResponse());
        }

        /// <summary>
        /// Updates properties of a component on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being modified.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <code snippet="Snippet:DigitalTwinsSampleUpdateComponent">
        /// // Update Component1 by replacing the property ComponentProp1 value,
        /// // using an optional utility to build the payload.
        /// var componentJsonPatchDocument = new JsonPatchDocument();
        /// componentJsonPatchDocument.AppendReplace(&quot;/ComponentProp1&quot;, &quot;Some new value&quot;);
        /// await client.UpdateComponentAsync(basicDtId, &quot;Component1&quot;, componentJsonPatchDocument);
        /// Console.WriteLine($&quot;Updated component for digital twin &apos;{basicDtId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> UpdateComponentAsync(string digitalTwinId, string componentName, JsonPatchDocument jsonPatchDocument, UpdateComponentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.UpdateComponentAsync(digitalTwinId, componentName, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Updates properties of a component on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being modified.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="UpdateComponentAsync(string, string, JsonPatchDocument, UpdateComponentOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response UpdateComponent(string digitalTwinId, string componentName, JsonPatchDocument jsonPatchDocument, UpdateComponentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.UpdateComponent(digitalTwinId, componentName, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Gets all the relationships on a digital twin by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json relationships belonging to the specified digital twin and the http response.</returns>
        /// <remarks>
        /// <para>
        /// String relationships that are returned as part of the pageable list can always be deserialized into an instnace of <see cref="Serialization.BasicRelationship"/>.
        /// You may also deserialize the relationship into custom type that extend the <see cref="Serialization.BasicRelationship"/>.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// This sample demonstrates iterating over outgoing relationships and deserializing relationship strings into BasicRelationship objects.
        /// <code snippet="Snippet:DigitalTwinsSampleGetAllRelationships">
        /// AsyncPageable&lt;string&gt; relationships = client.GetRelationshipsAsync(&quot;buildingTwinId&quot;);
        /// await foreach (var relationshipJson in relationships)
        /// {
        ///     BasicRelationship relationship = JsonSerializer.Deserialize&lt;BasicRelationship&gt;(relationshipJson);
        ///     Console.WriteLine($&quot;Retrieved relationship &apos;{relationship.Id}&apos; with source {relationship.SourceId}&apos; and &quot; +
        ///         $&quot;target {relationship.TargetId}.\n\t&quot; +
        ///         $&quot;Prop1: {relationship.CustomProperties[&quot;Prop1&quot;]}\n\t&quot; +
        ///         $&quot;Prop2: {relationship.CustomProperties[&quot;Prop2&quot;]}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<string> GetRelationshipsAsync(string digitalTwinId, string relationshipName = null, GetRelationshipsOptions options = null, CancellationToken cancellationToken = default)
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
                    Response<RelationshipCollection> response = await _dtRestClient.ListRelationshipsAsync(digitalTwinId, relationshipName, options, cancellationToken).ConfigureAwait(false);
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
                    Response<RelationshipCollection> response = await _dtRestClient.ListRelationshipsNextPageAsync(nextLink, digitalTwinId, relationshipName, options, cancellationToken).ConfigureAwait(false);
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
        /// Gets all the relationships on a digital twin by iterating through a collection synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json relationships belonging to the specified digital twin and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipsAsync(string, string, GetRelationshipsOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<string> GetRelationships(string digitalTwinId, string relationshipName = null, GetRelationshipsOptions options = null, CancellationToken cancellationToken = default)
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
                    Response<RelationshipCollection> response = _dtRestClient.ListRelationships(digitalTwinId, relationshipName, options, cancellationToken);
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
                    Response<RelationshipCollection> response = _dtRestClient.ListRelationshipsNextPage(nextLink, digitalTwinId, relationshipName, options, cancellationToken);
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
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json relationships directed towards the specified digital twin and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetIncomingRelationships">
        /// AsyncPageable&lt;IncomingRelationship&gt; incomingRelationships = client.GetIncomingRelationshipsAsync(&quot;buildingTwinId&quot;);
        ///
        /// await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
        /// {
        ///     Console.WriteLine($&quot;Found an incoming relationship &apos;{incomingRelationship.RelationshipId}&apos; from &apos;{incomingRelationship.SourceId}&apos;.&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<IncomingRelationship> GetIncomingRelationshipsAsync(string digitalTwinId, GetIncomingRelationshipsOptions options = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<IncomingRelationship>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = await _dtRestClient.ListIncomingRelationshipsAsync(digitalTwinId, options, cancellationToken).ConfigureAwait(false);
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
                    Response<IncomingRelationshipCollection> response = await _dtRestClient.ListIncomingRelationshipsNextPageAsync(nextLink, digitalTwinId, options, cancellationToken).ConfigureAwait(false);
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
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json relationships directed towards the specified digital twin and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetIncomingRelationshipsAsync(string, GetIncomingRelationshipsOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<IncomingRelationship> GetIncomingRelationships(string digitalTwinId, GetIncomingRelationshipsOptions options = null, CancellationToken cancellationToken = default)
        {
            Page<IncomingRelationship> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsGeneratedClient.ListIncomingRelationships");
                scope.Start();
                try
                {
                    Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationships(digitalTwinId, options, cancellationToken);
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
                    Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationshipsNextPage(nextLink, digitalTwinId, options, cancellationToken);
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
        /// Gets a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json relationship corresponding to the provided relationshipId and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the relationship with.</typeparam>
        /// <remarks>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// This sample demonstrates getting and deserializing a digital twin relationship into a custom data type.
        /// <code snippet="Snippet:DigitalTwinsSampleGetCustomRelationship">
        /// Response&lt;CustomRelationship&gt; getCustomRelationshipResponse = await client.GetRelationshipAsync&lt;CustomRelationship&gt;(
        ///     &quot;floorTwinId&quot;,
        ///     &quot;floorBuildingRelationshipId&quot;);
        /// CustomRelationship getCustomRelationship = getCustomRelationshipResponse.Value;
        /// Console.WriteLine($&quot;Retrieved and deserialized relationship &apos;{getCustomRelationship.Id}&apos; from twin &apos;{getCustomRelationship.SourceId}&apos;.\n\t&quot; +
        ///     $&quot;Prop1: {getCustomRelationship.Prop1}\n\t&quot; +
        ///     $&quot;Prop2: {getCustomRelationship.Prop2}&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<T>> GetRelationshipAsync<T>(string digitalTwinId, string relationshipId, GetRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the relationship as a Stream object
            Response<Stream> relationshipStream = await _dtRestClient.GetRelationshipByIdAsync(digitalTwinId, relationshipId, options, cancellationToken).ConfigureAwait(false);

            // Deserialize the stream into the generic type
            T deserializedRelationship = (T)await _objectSerializer.DeserializeAsync(relationshipStream, typeof(T), cancellationToken).ConfigureAwait(false);

            return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
        }

        /// <summary>
        /// Gets a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json relationship corresponding to the provided relationshipId and the http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the relationship with.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipAsync(string, string, GetRelationshipOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<T> GetRelationship<T>(string digitalTwinId, string relationshipId, GetRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            // Get the relationship as a Stream object
            Response<Stream> relationshipStream = _dtRestClient.GetRelationshipById(digitalTwinId, relationshipId, options, cancellationToken);

            // Deserialize the stream into the generic type
            T deserializedRelationship = (T)_objectSerializer.Deserialize(relationshipStream, typeof(T), cancellationToken);

            return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
        }

        /// <summary>
        /// Deletes a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        public virtual Task<Response> DeleteRelationshipAsync(string digitalTwinId, string relationshipId, DeleteRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteRelationshipAsync(digitalTwinId, relationshipId, options, cancellationToken);
        }

        /// <summary>
        /// Deletes a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteRelationshipAsync(string, string, DeleteRelationshipOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteRelationship(string digitalTwinId, string relationshipId, DeleteRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtRestClient.DeleteRelationship(digitalTwinId, relationshipId, options, cancellationToken);
        }

        /// <summary>
        /// Creates a relationship on a digital twin asynchronously. If the provided relationship Id is already in use, this will attempt to replace the
        /// existing relationship with the provided relationship.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship which is being created.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// <para>
        /// Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">The generic type to deserialize the relationship with.</typeparam>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateCustomRelationship">
        /// var floorBuildingRelationshipPayload = new CustomRelationship
        /// {
        ///     Id = &quot;floorBuildingRelationshipId&quot;,
        ///     SourceId = &quot;floorTwinId&quot;,
        ///     TargetId = &quot;buildingTwinId&quot;,
        ///     Name = &quot;containedIn&quot;,
        ///     Prop1 = &quot;Prop1 val&quot;,
        ///     Prop2 = 4
        /// };
        ///
        /// Response&lt;CustomRelationship&gt; createCustomRelationshipResponse = await client
        ///     .CreateRelationshipAsync&lt;CustomRelationship&gt;(&quot;floorTwinId&quot;, &quot;floorBuildingRelationshipId&quot;, floorBuildingRelationshipPayload);
        /// Console.WriteLine($&quot;Created a digital twin relationship &apos;{createCustomRelationshipResponse.Value.Id}&apos; &quot; +
        ///     $&quot;from twin &apos;{createCustomRelationshipResponse.Value.SourceId}&apos; to twin &apos;{createCustomRelationshipResponse.Value.TargetId}&apos;.&quot;);
        /// </code>
        /// </example>
        public async virtual Task<Response<T>> CreateRelationshipAsync<T>(string digitalTwinId, string relationshipId, T relationship, CreateRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            // Serialize the digital twin object and write it to a Stream
            using MemoryStream memoryStream = await WriteToStream<T>(relationship, _objectSerializer, true /*async*/, cancellationToken).ConfigureAwait(false);

            // Get the component as a Stream object
            Response<Stream> relationshipStream = await _dtRestClient.AddRelationshipAsync(digitalTwinId, relationshipId, memoryStream, options, cancellationToken).ConfigureAwait(false);

            // Deserialize the stream into the generic type
            T deserializedRelationship = (T)await _objectSerializer.DeserializeAsync(relationshipStream, typeof(T), cancellationToken).ConfigureAwait(false);

            return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
        }

        /// <summary>
        /// Creates a relationship on a digital twin synchronously. If the provided relationship Id is already in use, this will attempt to replace the
        /// existing relationship with the provided relationship.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The generic type to deserialize the relationship with.</typeparam>
        /// <remarks>
        /// <para>
        /// Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="CreateRelationshipAsync{T}(string, string, T, CreateRelationshipOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<T> CreateRelationship<T>(
            string digitalTwinId,
            string relationshipId,
            T relationship,
            CreateRelationshipOptions options = null,
            CancellationToken cancellationToken = default)
        {
            // Serialize the digital twin object and write it to a Stream
            using MemoryStream memoryStream = WriteToStream<T>(relationship, _objectSerializer, false /*async*/, cancellationToken).EnsureCompleted();

            // Get the relationship as a Stream object
            Response<Stream> relationshipStream = _dtRestClient.AddRelationship(digitalTwinId, relationshipId, memoryStream, options, cancellationToken);

            // Deserialize the stream into the generic type
            T deserializedRelationship = (T)_objectSerializer.Deserialize(relationshipStream, typeof(T), cancellationToken);

            return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response> UpdateRelationshipAsync(string digitalTwinId, string relationshipId, JsonPatchDocument jsonPatchDocument, UpdateRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.UpdateRelationshipAsync(digitalTwinId, relationshipId, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateRelationshipAsync(string, string, JsonPatchDocument, UpdateRelationshipOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response UpdateRelationship(string digitalTwinId, string relationshipId, JsonPatchDocument jsonPatchDocument, UpdateRelationshipOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
            return _dtRestClient.UpdateRelationship(digitalTwinId, relationshipId, jsonPatchDocument.ToString(), options, cancellationToken);
        }

        /// <summary>
        /// Gets the list of models by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json models and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModels">
        /// AsyncPageable&lt;DigitalTwinsModelData&gt; allModels = client.GetModelsAsync();
        /// await foreach (DigitalTwinsModelData model in allModels)
        /// {
        ///     Console.WriteLine($&quot;Retrieved model &apos;{model.Id}&apos;, &quot; +
        ///         $&quot;display name &apos;{model.DisplayName[&quot;en&quot;]}&apos;, &quot; +
        ///         $&quot;upload time &apos;{model.UploadTime}&apos;, &quot; +
        ///         $&quot;and decommissioned &apos;{model.Decommissioned}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<DigitalTwinsModelData> GetModelsAsync(GetModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DigitalTwinsModelData>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedDigitalTwinsModelDataCollection> response = await _dtModelsRestClient.ListAsync(options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DigitalTwinsModelData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedDigitalTwinsModelDataCollection> response = await _dtModelsRestClient.ListNextPageAsync(nextLink, options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken).ConfigureAwait(false);
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
        /// Gets the list of models by iterating through a collection synchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json models and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetModelsAsync(GetModelsOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<DigitalTwinsModelData> GetModels(GetModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            Page<DigitalTwinsModelData> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedDigitalTwinsModelDataCollection> response = _dtModelsRestClient.List(options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DigitalTwinsModelData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinModelsClient.List");
                scope.Start();
                try
                {
                    Response<PagedDigitalTwinsModelDataCollection> response = _dtModelsRestClient.ListNextPage(nextLink, options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken);
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
        /// Gets a model, including the model metadata and the model definition asynchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModel">
        /// Response&lt;DigitalTwinsModelData&gt; sampleModelResponse = await client.GetModelAsync(sampleModelId);
        /// Console.WriteLine($&quot;Retrieved model &apos;{sampleModelResponse.Value.Id}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response<DigitalTwinsModelData>> GetModelAsync(string modelId, GetModelOptions options = null, CancellationToken cancellationToken = default)
        {
            // The GetModel API will include the model definition in its response by default.
            return _dtModelsRestClient.GetByIdAsync(modelId, IncludeModelDefinition, options, cancellationToken);
        }

        /// <summary>
        /// Gets a model, including the model metadata and the model definition synchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetModelAsync(string, GetModelOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<DigitalTwinsModelData> GetModel(string modelId, GetModelOptions options = null, CancellationToken cancellationToken = default)
        {
            // The GetModel API will include the model definition in its response by default.
            return _dtModelsRestClient.GetById(modelId, IncludeModelDefinition, options, cancellationToken);
        }

        /// <summary>
        /// Decommissions a model asynchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// When a model is decomissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decomissioned, it may not be recommissioned.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDecommisionModel">
        /// try
        /// {
        ///     await client.DecommissionModelAsync(sampleModelId);
        ///     Console.WriteLine($&quot;Decommissioned model &apos;{sampleModelId}&apos;.&quot;);
        /// }
        /// catch (RequestFailedException ex)
        /// {
        ///     FatalError($&quot;Failed to decommision model &apos;{sampleModelId}&apos; due to:\n{ex}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual Task<Response> DecommissionModelAsync(string modelId, DecomissionModelOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.UpdateAsync(modelId, ModelsConstants.DecommissionModelOperationList, options, cancellationToken);
        }

        /// <summary>
        /// Decommissions a model synchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// When a model is decomissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decomissioned, it may not be recommissioned.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DecommissionModelAsync(string, DecomissionModelOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DecommissionModel(string modelId, DecomissionModelOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.Update(modelId, ModelsConstants.DecommissionModelOperationList, options, cancellationToken);
        }

        /// <summary>
        /// Creates one or many models asynchronously.
        /// </summary>
        /// <param name="dtdlModels">The set of models conforming to the Digital Twins Definition Language (DTDL) to create. Each string corresponds to exactly one model.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the http response <see cref="Response{T}"/>.</returns>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Bulk model creation is useful when several models have references to each other.
        /// It simplifies creation for the client because otherwise the models would have to be created in a very specific order.
        /// The service evaluates all models to ensure all references are satisfied, and then accepts or rejects the set.
        /// So using this method, model creation is transactional.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models" />
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateModels">
        /// await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
        /// Console.WriteLine($&quot;Created models &apos;{componentModelId}&apos; and &apos;{sampleModelId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<DigitalTwinsModelData[]>> CreateModelsAsync(IEnumerable<string> dtdlModels, CreateModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyList<DigitalTwinsModelData>> response = await _dtModelsRestClient.AddAsync(dtdlModels, options, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.ToArray(), response.GetRawResponse());
        }

        /// <summary>
        /// Creates one or many models synchronously.
        /// </summary>
        /// <param name="dtdlModels">The set of models conforming to the Digital Twins Definition Language (DTDL) to create. Each string corresponds to exactly one model.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// <para>
        /// Bulk model creation is useful when several models have references to each other.
        /// It simplifies creation for the client because otherwise the models would have to be created in a very specific order.
        /// The service evaluates all models to ensure all references are satisfied, and then accepts or rejects the set.
        /// So using this method, model creation is transactional.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models" />
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="CreateModelsAsync(IEnumerable{string}, CreateModelsOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<DigitalTwinsModelData[]> CreateModels(IEnumerable<string> dtdlModels, CreateModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            Response<IReadOnlyList<DigitalTwinsModelData>> response = _dtModelsRestClient.Add(dtdlModels, options, cancellationToken);
            return Response.FromValue(response.Value.ToArray(), response.GetRawResponse());
        }

        /// <summary>
        /// Deletes a model asynchronously.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// A model can only be deleted if no other models reference it.
        /// Status codes:
        /// 204 (No Content): Success.
        /// 400 (Bad Request): The request is invalid.
        /// 404 (Not Found): There is no model with the provided id.
        /// 409 (Conflict): There are dependencies on the model that prevent it from being deleted.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteModel">
        /// try
        /// {
        ///     await client.DeleteModelAsync(sampleModelId);
        ///     Console.WriteLine($&quot;Deleted model &apos;{sampleModelId}&apos;.&quot;);
        /// }
        /// catch (Exception ex)
        /// {
        ///     FatalError($&quot;Failed to delete model &apos;{sampleModelId}&apos; due to:\n{ex}&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteModelAsync(string modelId, DeleteModelOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.DeleteAsync(modelId, options, cancellationToken);
        }

        /// <summary>
        /// Deletes a model synchronously.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// A model can only be deleted if no other models reference it.
        /// Status codes:
        /// 204 (No Content): Success.
        /// 400 (Bad Request): The request is invalid.
        /// 404 (Not Found): There is no model with the provided id.
        /// 409 (Conflict): There are dependencies on the model that prevent it from being deleted.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteModelAsync(string, DeleteModelOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteModel(string modelId, DeleteModelOptions options = null, CancellationToken cancellationToken = default)
        {
            return _dtModelsRestClient.Delete(modelId, options, cancellationToken);
        }

        /// <summary>
        /// Queries for digital twins by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of query results.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
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
        ///     Console.WriteLine($&quot;Found digital twin &apos;{twin.Id}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<string> QueryAsync(string query, QueryOptions options = null, CancellationToken cancellationToken = default)
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
                    Response<QueryResult> response = await _queryClient.QueryTwinsAsync(querySpecification, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
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
                    Response<QueryResult> response = await _queryClient.QueryTwinsAsync(querySpecification, options, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
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
        /// Queries for digital twins by iterating through a collection synchronously.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of query results.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// A basic query for all digital twins: SELECT * FROM digitalTwins.
        /// </example>
        /// <seealso cref="QueryAsync(string, QueryOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<string> Query(string query, QueryOptions options = null, CancellationToken cancellationToken = default)
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
                    Response<QueryResult> response = _queryClient.QueryTwins(querySpecification, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
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
                    Response<QueryResult> response = _queryClient.QueryTwins(querySpecification, options, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
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
        /// Lists the event routes in a digital twins instance by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json event routes and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetEventRoutes">
        /// AsyncPageable&lt;EventRoute&gt; response = client.GetEventRoutesAsync();
        /// await foreach (EventRoute er in response)
        /// {
        ///     Console.WriteLine($&quot;Event route &apos;{er.Id}&apos;, endpoint name &apos;{er.EndpointName}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        public virtual AsyncPageable<EventRoute> GetEventRoutesAsync(GetEventRoutesOptions options = null, CancellationToken cancellationToken = default)
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
        /// Lists the event routes in a digital twins instance by iterating through a collection synchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json event routes and the http response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetEventRoutesAsync(GetEventRoutesOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Pageable<EventRoute> GetEventRoutes(GetEventRoutesOptions options = null, CancellationToken cancellationToken = default)
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
        /// Gets an event route by Id asynchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        public virtual Task<Response<EventRoute>> GetEventRouteAsync(string eventRouteId, GetEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.GetByIdAsync(eventRouteId, options, cancellationToken);
        }

        /// <summary>
        /// Gets an event route by Id synchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the http response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetEventRouteAsync(string, GetEventRouteOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response<EventRoute> GetEventRoute(string eventRouteId, GetEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.GetById(eventRouteId, options, cancellationToken);
        }

        /// <summary>
        /// Creates an event route asynchronously. If the provided event route Id is already in use, then this will attempt to replace the existing
        /// event route with the provided event route.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateEventRoute">
        /// string eventFilter = &quot;$eventType = &apos;DigitalTwinTelemetryMessages&apos; or $eventType = &apos;DigitalTwinLifecycleNotification&apos;&quot;;
        /// var eventRoute = new EventRoute(eventhubEndpointName, eventFilter);
        ///
        /// await client.CreateEventRouteAsync(_eventRouteId, eventRoute);
        /// Console.WriteLine($&quot;Created event route &apos;{_eventRouteId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> CreateEventRouteAsync(string eventRouteId, EventRoute eventRoute, CreateEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.AddAsync(eventRouteId, eventRoute, options, cancellationToken);
        }

        /// <summary>
        /// Creates an event route synchronously. If the provided event route Id is already in use, then this will attempt to replace the existing
        /// event route with the provided event route.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="CreateEventRouteAsync(string, EventRoute, CreateEventRouteOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response CreateEventRoute(string eventRouteId, EventRoute eventRoute, CreateEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.Add(eventRouteId, eventRoute, options, cancellationToken);
        }

        /// <summary>
        /// Deletes an event route asynchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteEventRoute">
        /// await client.DeleteEventRouteAsync(_eventRouteId);
        /// Console.WriteLine($&quot;Deleted event route &apos;{_eventRouteId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> DeleteEventRouteAsync(string eventRouteId, DeleteEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.DeleteAsync(eventRouteId, options, cancellationToken);
        }

        /// <summary>
        /// Deletes an event route synchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteEventRouteAsync(string, DeleteEventRouteOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response DeleteEventRoute(string eventRouteId, DeleteEventRouteOptions options = null, CancellationToken cancellationToken = default)
        {
            return _eventRoutesRestClient.Delete(eventRouteId, options, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin asynchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random guid if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSamplePublishTelemetry">
        /// // construct your json telemetry payload by hand.
        /// await client.PublishTelemetryAsync(twinId, Guid.NewGuid().ToString(), &quot;{\&quot;Telemetry1\&quot;: 5}&quot;);
        /// Console.WriteLine($&quot;Published telemetry message to twin &apos;{twinId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> PublishTelemetryAsync(
            string digitalTwinId,
            string messageId,
            string payload,
            PublishTelemetryOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                messageId = Guid.NewGuid().ToString();
            }

            return _dtRestClient
                .SendTelemetryAsync(digitalTwinId, messageId, payload, options, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin synchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random guid if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishTelemetryAsync(string, string, string, PublishTelemetryOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response PublishTelemetry(string digitalTwinId, string messageId, string payload, PublishTelemetryOptions options = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                messageId = Guid.NewGuid().ToString();
            }

            return _dtRestClient.SendTelemetry(digitalTwinId, messageId, payload, options, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component asynchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random guid if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
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
        ///     { &quot;ComponentTelemetry1&quot;, 9 }
        /// };
        /// await client.PublishComponentTelemetryAsync(
        ///     twinId,
        ///     &quot;Component1&quot;,
        ///     Guid.NewGuid().ToString(),
        ///     JsonSerializer.Serialize(telemetryPayload));
        /// Console.WriteLine($&quot;Published component telemetry message to twin &apos;{twinId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual Task<Response> PublishComponentTelemetryAsync(string digitalTwinId,
            string componentName,
            string messageId,
            string payload,
            PublishComponentTelemetryOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                messageId = Guid.NewGuid().ToString();
            }

            return _dtRestClient
                .SendComponentTelemetryAsync(digitalTwinId, componentName, messageId, payload, options, cancellationToken);
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component synchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="EventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random guid if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishComponentTelemetryAsync(string, string, string, string, PublishComponentTelemetryOptions, CancellationToken)">
        /// See the asynchronous version of this method for examples.
        /// </seealso>
        public virtual Response PublishComponentTelemetry(string digitalTwinId,
            string componentName,
            string messageId,
            string payload,
            PublishComponentTelemetryOptions options = null,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(messageId))
            {
                //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                messageId = Guid.NewGuid().ToString();
            }

            return _dtRestClient.SendComponentTelemetry(digitalTwinId, componentName, messageId, payload, options, cancellationToken);
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

        /// <summary>
        /// Serializes an object and writes it into a memory stream.
        /// </summary>
        /// <typeparam name="T">Generic type of the object being serialized.</typeparam>
        /// <param name="obj">Object being serialized.</param>
        /// <param name="objectSerializer">Object serializer used to serialize/deserialize an object.</param>
        /// <param name="async">Indicates whether or not to use async operations during serialization.</param>
        /// <param name="cancellationToken">Then cancellation token.</param>
        /// <returns>A binary representation of the object written to a stream.</returns>
        internal static async Task<MemoryStream> WriteToStream<T>(T obj, ObjectSerializer objectSerializer, bool async, CancellationToken cancellationToken)
        {
            var memoryStream = new MemoryStream();

            if (async)
            {
                await objectSerializer.SerializeAsync(memoryStream, obj, typeof(T), cancellationToken).ConfigureAwait(false);
            }
            else
            {
                objectSerializer.Serialize(memoryStream, obj, typeof(T), cancellationToken);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
