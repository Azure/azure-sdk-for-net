// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using Azure.DigitalTwins.Core.Models;
using static Azure.DigitalTwins.Core.StreamHelper;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The Digital Twins Service Client contains methods to retrieve digital twin information, like models, components, and relationships.
    /// </summary>
    public class DigitalTwinsClient
    {
        private const bool IncludeModelDefinition = true;
        private const string OTelTwinIdKey = "az.digitaltwins.twin.id";
        private const string OTelModelIdKey = "az.digitaltwins.model.id";
        private const string OTelComponentNameKey = "az.digitaltwins.component.name";
        private const string OTelRelationshipNameKey = "az.digitaltwins.relationship.name";
        private const string OTelRelationshipIdKey = "az.digitaltwins.relationship.id";
        private const string OTelMessageIdKey = "az.digitaltwins.message.id";
        private const string OTelJobIdKey = "az.digitaltwins.job.id";
        private const string OTeQueryKey = "az.digitaltwins.query";
        private const string OTelEventRouteIdKey = "az.digitaltwins.event_route.id";

        // Vanity representation for azure digital twin app Id "0b07f429-9f4b-4714-9392-cc5e8e80c8b0" in the public cloud
        // and shared by other clouds.
        private const string AdtDefaultAppId = "https://digitaltwins.azure.net";

        private const string DefaultPermissionConsent = "/.default";
        private static readonly string[] s_adtDefaultScopes = new[] { AdtDefaultAppId + DefaultPermissionConsent };

        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;

        private readonly ObjectSerializer _objectSerializer;

        private readonly DigitalTwinsRestClient _dtRestClient;
        private readonly DigitalTwinModelsRestClient _dtModelsRestClient;
        private readonly EventRoutesRestClient _eventRoutesRestClient;
        private readonly QueryRestClient _queryClient;
        private readonly ImportJobsRestClient _importJobsRestClient;

        /// <summary>
        /// Creates a new instance of the <see cref="DigitalTwinsClient"/> class.
        /// </summary>
        /// <param name='endpoint'>The Azure digital twins service instance URI to connect to.</param>
        /// <param name="credential">The <see cref="TokenCredential"/> implementation which will be used to request for the authentication token.</param>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret" language="csharp">
        /// // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
        /// // It attempts to use multiple credential types in an order until it finds a working credential.
        /// TokenCredential tokenCredential = new DefaultAzureCredential();
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
        /// overriding <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Pipeline.md">transport</see>,
        /// enabling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md">diagnostics</see>,
        /// and controlling <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md">retry strategy</see>.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        public DigitalTwinsClient(Uri endpoint, TokenCredential credential, DigitalTwinsClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);

            _objectSerializer = options.Serializer ?? new JsonObjectSerializer();

            options.AddPolicy(new BearerTokenAuthenticationPolicy(credential, GetAuthorizationScopes()), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            string versionString = options.GetVersionString();
            _dtRestClient = new DigitalTwinsRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _dtModelsRestClient = new DigitalTwinModelsRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _eventRoutesRestClient = new EventRoutesRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _queryClient = new QueryRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
            _importJobsRestClient = new ImportJobsRestClient(_clientDiagnostics, _httpPipeline, endpoint, versionString);
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
        /// A strongly typed object type such as <see cref="BasicDigitalTwin"/> can be used as a generic type for <typeparamref name="T"/>
        /// to indicate what type is used to deserialize the response value.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json digital twin and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the digital twin to.</typeparam>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// This sample demonstrates getting and deserializing a digital twin into a custom data type.
        ///
        /// <code snippet="Snippet:DigitalTwinsSampleGetCustomDigitalTwin" language="csharp">
        /// Response&lt;CustomDigitalTwin&gt; getCustomDtResponse = await client.GetDigitalTwinAsync&lt;CustomDigitalTwin&gt;(customDtId);
        /// CustomDigitalTwin customDt = getCustomDtResponse.Value;
        /// Console.WriteLine($&quot;Retrieved and deserialized digital twin {customDt.Id}:\n\t&quot; +
        ///     $&quot;ETag: {customDt.ETag}\n\t&quot; +
        ///     $&quot;ModelId: {customDt.Metadata.ModelId}\n\t&quot; +
        ///     $&quot;Prop1: [{customDt.Prop1}] last updated on {customDt.Metadata.Prop1.LastUpdatedOn}\n\t&quot; +
        ///     $&quot;Prop2: [{customDt.Prop2}] last updated on {customDt.Metadata.Prop2.LastUpdatedOn}\n\t&quot; +
        ///     $&quot;ComponentProp1: [{customDt.Component1.ComponentProp1}] last updated {customDt.Component1.Metadata.ComponentProp1.LastUpdatedOn}\n\t&quot; +
        ///     $&quot;ComponentProp2: [{customDt.Component1.ComponentProp2}] last updated {customDt.Component1.Metadata.ComponentProp2.LastUpdatedOn}&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<T>> GetDigitalTwinAsync<T>(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                // Get the digital twin as a stream object
                Response<Stream> digitalTwinStream = await _dtRestClient
                    .GetByIdAsync(digitalTwinId, null, cancellationToken)
                    .ConfigureAwait(false);

                // Deserialize the stream into the specified type
                T deserializedDigitalTwin = (T)await _objectSerializer
                    .DeserializeAsync(digitalTwinStream, typeof(T), cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a digital twin synchronously.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A strongly typed object type such as <see cref="BasicDigitalTwin"/> can be used as a generic type for <typeparamref name="T"/>
        /// to indicate what type is used to deserialize the response value.
        /// It may also be deserialized into custom digital twin types that extend the <see cref="BasicDigitalTwin"/> with additional
        /// strongly typed properties provided that you know the definition of the retrieved digital twin prior to deserialization.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json digital twin and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the digital twin to.</typeparam>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        public virtual Response<T> GetDigitalTwin<T>(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                // Get the digital twin as a stream object
                Response<Stream> digitalTwinStream = _dtRestClient.GetById(digitalTwinId, null, cancellationToken);

                // Deserialize the stream into the specified type
                T deserializedDigitalTwin = (T)_objectSerializer.Deserialize(digitalTwinStream, typeof(T), cancellationToken);

                return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a digital twin asynchronously. If the provided digital twin Id is already in use, then this will attempt to replace the existing digital twin
        /// with the provided digital twin..
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="ifNoneMatch">
        /// If-None-Match header that makes the request method conditional on a
        /// recipient cache or origin server either not having any current
        /// representation of the target resource.  For more information about
        /// this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC 7232</see>.
        /// Acceptable values are null or <c>"*"</c>.  If ifNonMatch option is null
        /// the service will replace the existing entity with the new entity.
        /// If ifNoneMatch option is <c>"*"</c> (or <see cref="ETag.All"/>) the
        /// service will reject the request if the entity already exists.
        /// An optional ETag to only make the request if the value does not
        /// match on the service.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the digital twin to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateCustomTwin" language="csharp">
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
        ///     },
        /// };
        /// Response&lt;CustomDigitalTwin&gt; createCustomDigitalTwinResponse = await client.CreateOrReplaceDigitalTwinAsync(customDtId, customTwin);
        /// Console.WriteLine($&quot;Created digital twin &apos;{createCustomDigitalTwinResponse.Value.Id}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response<T>> CreateOrReplaceDigitalTwinAsync<T>(
            string digitalTwinId,
            T digitalTwin,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                // Serialize the digital twin object and write it to a stream
                using MemoryStream memoryStream = await WriteToStreamAsync<T>(digitalTwin, _objectSerializer, cancellationToken)
                    .ConfigureAwait(false);

                // Get the response of the digital twin as a stream object
                CreateOrReplaceDigitalTwinOptions options = ifNoneMatch == null
                    ? null
                    : new CreateOrReplaceDigitalTwinOptions { IfNoneMatch = ifNoneMatch.Value.ToString() };
                Response<Stream> digitalTwinStream = await _dtRestClient
                    .AddAsync(digitalTwinId, memoryStream, options, cancellationToken)
                    .ConfigureAwait(false);

                // Deserialize the stream into the specified type
                T deserializedDigitalTwin = (T)await _objectSerializer
                    .DeserializeAsync(digitalTwinStream, typeof(T), cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a digital twin synchronously. If the provided digital twin Id is already in use, then this will attempt to replace the existing digital twin
        /// with the provided digital twin.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="digitalTwin">The application/json digital twin to create.</param>
        /// <param name="ifNoneMatch">
        /// If-None-Match header that makes the request method conditional on a
        /// recipient cache or origin server either not having any current
        /// representation of the target resource.  For more information about
        /// this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC 7232</see>.
        /// Acceptable values are null or <c>"*"</c>.  If ifNonMatch option is null
        /// the service will replace the existing entity with the new entity.
        /// If ifNoneMatch option is <c>"*"</c> (or <see cref="ETag.All"/>) the
        /// service will reject the request if the entity already exists.
        /// An optional ETag to only make the request if the value does not
        /// match on the service.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created application/json digital twin and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the digital twin to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="digitalTwin"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        public virtual Response<T> CreateOrReplaceDigitalTwin<T>(
            string digitalTwinId,
            T digitalTwin,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                // Serialize the digital twin object and write it to a stream
                using MemoryStream memoryStream = WriteToStream<T>(digitalTwin, _objectSerializer, cancellationToken);

                // Get the response of the digital twin as a stream object
                CreateOrReplaceDigitalTwinOptions options = ifNoneMatch == null
                    ? null
                    : new CreateOrReplaceDigitalTwinOptions { IfNoneMatch = ifNoneMatch.Value.ToString() };
                Response<Stream> digitalTwinStream = _dtRestClient.Add(digitalTwinId, memoryStream, options, cancellationToken);

                // Deserialize the stream into the specified type
                T deserializedDigitalTwin = (T)_objectSerializer.Deserialize(digitalTwinStream, typeof(T), cancellationToken);

                return Response.FromValue<T>(deserializedDigitalTwin, digitalTwinStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
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
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteTwin" language="csharp">
        /// await client.DeleteDigitalTwinAsync(digitalTwinId);
        /// Console.WriteLine($&quot;Deleted digital twin &apos;{digitalTwinId}&apos;.&quot;);
        /// </code>
        /// </example>
        public virtual async Task<Response> DeleteDigitalTwinAsync(string digitalTwinId, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                DeleteDigitalTwinOptions options = ifMatch == null
                    ? null
                    : new DeleteDigitalTwinOptions { IfMatch = ifMatch.Value.ToString() };
                return await _dtRestClient.DeleteAsync(digitalTwinId, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to delete.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// To delete a digital twin, any relationships referencing it must be deleted first.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        public virtual Response DeleteDigitalTwin(string digitalTwinId, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                DeleteDigitalTwinOptions options = ifMatch == null
                    ? null
                    : new DeleteDigitalTwinOptions { IfMatch = ifMatch.Value.ToString() };
                return _dtRestClient.Delete(digitalTwinId, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="jsonPatchDocument"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateDigitalTwin(string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual async Task<Response> UpdateDigitalTwinAsync(string digitalTwinId, JsonPatchDocument jsonPatchDocument, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateDigitalTwinOptions options = ifMatch == null
                    ? null
                    : new UpdateDigitalTwinOptions { IfMatch = ifMatch.Value.ToString() };
                return await _dtRestClient
                    .UpdateAsync(digitalTwinId, jsonPatchDocument.ToString(), options, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin to update.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="jsonPatchDocument"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateDigitalTwinAsync(string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual Response UpdateDigitalTwin(string digitalTwinId, JsonPatchDocument jsonPatchDocument, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateDigitalTwin)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateDigitalTwinOptions options = ifMatch == null
                    ? null
                    : new UpdateDigitalTwinOptions { IfMatch = ifMatch.Value.ToString() };
                return _dtRestClient.Update(digitalTwinId, jsonPatchDocument.ToString(), options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a component on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being retrieved.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized object representation of the component corresponding to the provided componentName and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the component to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetComponent" language="csharp">
        /// await client.GetComponentAsync&lt;MyCustomComponent&gt;(basicDtId, SamplesConstants.ComponentName);
        /// Console.WriteLine($&quot;Retrieved component for digital twin &apos;{basicDtId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="GetComponent(string, string, CancellationToken)"/>
        public virtual async Task<Response<T>> GetComponentAsync<T>(string digitalTwinId, string componentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetComponent)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                // Get the component as a stream object
                Response<Stream> componentStream = await _dtRestClient
                    .GetComponentAsync(digitalTwinId, componentName, null, cancellationToken)
                    .ConfigureAwait(false);

                // Deserialize the stream into the specified type
                T deserializedComponent = (T)await _objectSerializer
                    .DeserializeAsync(componentStream, typeof(T), cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue<T>(deserializedComponent, componentStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a component on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being retrieved.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized object representation of the component corresponding to the provided componentName and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the component to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetComponentAsync(string, string, CancellationToken)"/>
        public virtual Response<T> GetComponent<T>(string digitalTwinId, string componentName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetComponent)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelComponentNameKey, componentName);
            scope.Start();

            try
            {
                // Get the component as a stream object
                Response<Stream> componentStream = _dtRestClient.GetComponent(digitalTwinId, componentName, null, cancellationToken);

                // Deserialize the stream into the specified type
                T deserializedComponent = (T)_objectSerializer.Deserialize(componentStream, typeof(T), cancellationToken);

                return Response.FromValue<T>(deserializedComponent, componentStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates properties of a component on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being modified.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// <code snippet="Snippet:DigitalTwinsSampleUpdateComponent" language="csharp">
        /// // Update Component1 by replacing the property ComponentProp1 value,
        /// // using an optional utility to build the payload.
        /// var componentJsonPatchDocument = new JsonPatchDocument();
        /// componentJsonPatchDocument.AppendReplace(&quot;/ComponentProp1&quot;, &quot;Some new value&quot;);
        /// await client.UpdateComponentAsync(basicDtId, &quot;Component1&quot;, componentJsonPatchDocument);
        /// Console.WriteLine($&quot;Updated component for digital twin &apos;{basicDtId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="UpdateComponent(string, string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual async Task<Response> UpdateComponentAsync(
            string digitalTwinId,
            string componentName,
            JsonPatchDocument jsonPatchDocument,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateComponent)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelComponentNameKey, componentName);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateComponentOptions options = ifMatch == null
                    ? null
                    : new UpdateComponentOptions { IfMatch = ifMatch.Value.ToString() };

                return await _dtRestClient
                    .UpdateComponentAsync(
                        digitalTwinId,
                        componentName,
                        jsonPatchDocument.ToString(),
                        options,
                        cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates properties of a component on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The component being modified.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's component.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="UpdateComponentAsync(string, string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual Response UpdateComponent(
            string digitalTwinId,
            string componentName,
            JsonPatchDocument jsonPatchDocument,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateComponent)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelComponentNameKey, componentName);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateComponentOptions options = ifMatch == null
                    ? null
                    : new UpdateComponentOptions { IfMatch = ifMatch.Value.ToString() };
                return _dtRestClient.UpdateComponent(digitalTwinId, componentName, jsonPatchDocument.ToString(), options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all the relationships on a digital twin by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json relationships belonging to the specified digital twin and the HTTP response.</returns>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <remarks>
        /// <para>
        /// Relationships that are returned as part of the pageable list can always be deserialized into an instance of <see cref="BasicRelationship"/>.
        /// You may also deserialize the relationship into custom type that extend the <see cref="BasicRelationship"/>.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
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
        /// <code snippet="Snippet:DigitalTwinsSampleGetAllRelationships" language="csharp">
        /// AsyncPageable&lt;BasicRelationship&gt; relationships = client.GetRelationshipsAsync&lt;BasicRelationship&gt;(&quot;buildingTwinId&quot;);
        /// await foreach (BasicRelationship relationship in relationships)
        /// {
        ///     Console.WriteLine($&quot;Retrieved relationship &apos;{relationship.Id}&apos; with source {relationship.SourceId}&apos; and &quot; +
        ///         $&quot;target {relationship.TargetId}.\n\t&quot; +
        ///         $&quot;Prop1: {relationship.Properties[&quot;Prop1&quot;]}\n\t&quot; +
        ///         $&quot;Prop2: {relationship.Properties[&quot;Prop2&quot;]}&quot;);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="GetRelationships(string, string, CancellationToken)"/>
        public virtual AsyncPageable<T> GetRelationshipsAsync<T>(
            string digitalTwinId,
            string relationshipName = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipNameKey, relationshipName);
            scope.Start();

            try
            {
                if (digitalTwinId == null)
                {
                    throw new ArgumentNullException(nameof(digitalTwinId));
                }

                async Task<Page<T>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<RelationshipCollection<T>> response = await _dtRestClient
                            .ListRelationshipsAsync<T>(digitalTwinId, relationshipName, null, _objectSerializer, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<T>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<RelationshipCollection<T>> response = await _dtRestClient
                            .ListRelationshipsNextPageAsync<T>(nextLink, digitalTwinId, relationshipName, null, _objectSerializer, cancellationToken)
                            .ConfigureAwait(false);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all the relationships on a digital twin by iterating through a collection synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipName">The name of a relationship to filter to. If null, all relationships for the digital twin will be returned.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json relationships belonging to the specified digital twin and the HTTP response.</returns>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipsAsync(string, string, CancellationToken)"/>
        public virtual Pageable<T> GetRelationships<T>(string digitalTwinId, string relationshipName = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipNameKey, relationshipName);
            scope.Start();

            try
            {
                if (digitalTwinId == null)
                {
                    throw new ArgumentNullException(nameof(digitalTwinId));
                }

                Page<T> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<RelationshipCollection<T>> response = _dtRestClient
                            .ListRelationships<T>(digitalTwinId, relationshipName, null, _objectSerializer, cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<T> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<RelationshipCollection<T>> response = _dtRestClient
                            .ListRelationshipsNextPage<T>(nextLink, digitalTwinId, relationshipName, null, _objectSerializer, cancellationToken);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json relationships directed towards the specified digital twin and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetIncomingRelationships" language="csharp">
        /// AsyncPageable&lt;IncomingRelationship&gt; incomingRelationships = client.GetIncomingRelationshipsAsync(&quot;buildingTwinId&quot;);
        ///
        /// await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
        /// {
        ///     Console.WriteLine($&quot;Found an incoming relationship &apos;{incomingRelationship.RelationshipId}&apos; from &apos;{incomingRelationship.SourceId}&apos;.&quot;);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="GetIncomingRelationships(string, CancellationToken)"/>
        public virtual AsyncPageable<IncomingRelationship> GetIncomingRelationshipsAsync(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                async Task<Page<IncomingRelationship>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<IncomingRelationshipCollection> response = await _dtRestClient
                            .ListIncomingRelationshipsAsync(digitalTwinId, null, cancellationToken)
                            .ConfigureAwait(false);
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
                        Response<IncomingRelationshipCollection> response = await _dtRestClient
                            .ListIncomingRelationshipsNextPageAsync(nextLink, digitalTwinId, null, cancellationToken)
                            .ConfigureAwait(false);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all the relationships referencing a digital twin as a target by iterating through a collection synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the target digital twin.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json relationships directed towards the specified digital twin and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetIncomingRelationshipsAsync(string, CancellationToken)"/>
        public virtual Pageable<IncomingRelationship> GetIncomingRelationships(string digitalTwinId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.Start();

            try
            {
                Page<IncomingRelationship> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationships(digitalTwinId, null, cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<IncomingRelationship> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetIncomingRelationships)}");
                    scope.Start();
                    try
                    {
                        Response<IncomingRelationshipCollection> response = _dtRestClient.ListIncomingRelationshipsNextPage(nextLink, digitalTwinId, null, cancellationToken);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json relationship corresponding to the provided relationshipId and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <remarks>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
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
        /// <code snippet="Snippet:DigitalTwinsSampleGetCustomRelationship" language="csharp">
        /// Response&lt;CustomRelationship&gt; getCustomRelationshipResponse = await client.GetRelationshipAsync&lt;CustomRelationship&gt;(
        ///     &quot;floorTwinId&quot;,
        ///     &quot;floorBuildingRelationshipId&quot;);
        /// CustomRelationship getCustomRelationship = getCustomRelationshipResponse.Value;
        /// Console.WriteLine($&quot;Retrieved and deserialized relationship &apos;{getCustomRelationship.Id}&apos; from twin &apos;{getCustomRelationship.SourceId}&apos;.\n\t&quot; +
        ///     $&quot;Prop1: {getCustomRelationship.Prop1}\n\t&quot; +
        ///     $&quot;Prop2: {getCustomRelationship.Prop2}&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="GetRelationship(string, string, CancellationToken)"/>
        public virtual async Task<Response<T>> GetRelationshipAsync<T>(
            string digitalTwinId,
            string relationshipId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                // Get the relationship as a stream object
                Response<Stream> relationshipStream = await _dtRestClient.GetRelationshipByIdAsync(digitalTwinId, relationshipId, null, cancellationToken).ConfigureAwait(false);

                // Deserialize the stream into the specified type
                T deserializedRelationship = (T)await _objectSerializer.DeserializeAsync(relationshipStream, typeof(T), cancellationToken).ConfigureAwait(false);

                return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The deserialized application/json relationship corresponding to the provided relationshipId and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetRelationshipAsync(string, string, CancellationToken)"/>
        public virtual Response<T> GetRelationship<T>(
            string digitalTwinId,
            string relationshipId,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                // Get the relationship as a stream object
                Response<Stream> relationshipStream = _dtRestClient.GetRelationshipById(digitalTwinId, relationshipId, null, cancellationToken);

                // Deserialize the stream into the specified type
                T deserializedRelationship = (T)_objectSerializer.Deserialize(relationshipStream, typeof(T), cancellationToken);

                return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="DeleteRelationship(string, string, ETag?, CancellationToken)"/>
        public virtual async Task<Response> DeleteRelationshipAsync(string digitalTwinId, string relationshipId, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                DeleteRelationshipOptions options = ifMatch != null ?
                new DeleteRelationshipOptions { IfMatch = ifMatch.Value.ToString() } :
                null;
                return await _dtRestClient.DeleteRelationshipAsync(digitalTwinId, relationshipId, options, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteRelationshipAsync(string, string, ETag?, CancellationToken)"/>
        public virtual Response DeleteRelationship(string digitalTwinId, string relationshipId, ETag? ifMatch = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                DeleteRelationshipOptions options = ifMatch == null
                    ? null
                    : new DeleteRelationshipOptions { IfMatch = ifMatch.Value.ToString() };
                return _dtRestClient.DeleteRelationship(digitalTwinId, relationshipId, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a relationship on a digital twin asynchronously. If the provided relationship Id is already in use, this will attempt to replace the
        /// existing relationship with the provided relationship.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship which is being created.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="ifNoneMatch">
        /// If-None-Match header that makes the request method conditional on a
        /// recipient cache or origin server either not having any current
        /// representation of the target resource.  For more information about
        /// this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC 7232</see>.
        /// Acceptable values are null or <c>"*"</c>.  If ifNonMatch option is null
        /// the service will replace the existing entity with the new entity.
        /// If ifNoneMatch option is <c>"*"</c> (or <see cref="ETag.All"/>) the
        /// service will reject the request if the entity already exists.
        /// An optional ETag to only make the request if the value does not
        /// match on the service.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>
        /// <para>
        /// Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateCustomRelationship" language="csharp">
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
        ///     .CreateOrReplaceRelationshipAsync&lt;CustomRelationship&gt;(&quot;floorTwinId&quot;, &quot;floorBuildingRelationshipId&quot;, floorBuildingRelationshipPayload);
        /// Console.WriteLine($&quot;Created a digital twin relationship &apos;{createCustomRelationshipResponse.Value.Id}&apos; &quot; +
        ///     $&quot;from twin &apos;{createCustomRelationshipResponse.Value.SourceId}&apos; to twin &apos;{createCustomRelationshipResponse.Value.TargetId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="CreateOrReplaceRelationship{T}(string, string, T, ETag?, CancellationToken)"/>
        public virtual async Task<Response<T>> CreateOrReplaceRelationshipAsync<T>(
            string digitalTwinId,
            string relationshipId,
            T relationship,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                // Serialize the relationship and write it to a stream
                using MemoryStream memoryStream = await WriteToStreamAsync<T>(relationship, _objectSerializer, cancellationToken)
                    .ConfigureAwait(false);

                // Get the response component as a stream object
                CreateOrReplaceRelationshipOptions options = ifNoneMatch == null
                    ? null
                    : new CreateOrReplaceRelationshipOptions { IfNoneMatch = ifNoneMatch.Value.ToString() };
                Response<Stream> relationshipStream = await _dtRestClient
                    .AddRelationshipAsync(digitalTwinId, relationshipId, memoryStream, options, cancellationToken)
                    .ConfigureAwait(false);

                // Deserialize the stream into the specified type
                T deserializedRelationship = (T)await _objectSerializer
                    .DeserializeAsync(relationshipStream, typeof(T), cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates a relationship on a digital twin synchronously. If the provided relationship Id is already in use, this will attempt to replace the
        /// existing relationship with the provided relationship.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to delete.</param>
        /// <param name="relationship">The application/json relationship to be created.</param>
        /// <param name="ifNoneMatch">
        /// If-None-Match header that makes the request method conditional on a
        /// recipient cache or origin server either not having any current
        /// representation of the target resource.  For more information about
        /// this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC 7232</see>.
        /// Acceptable values are null or <c>"*"</c>.  If ifNonMatch option is null
        /// the service will replace the existing entity with the new entity.
        /// If ifNoneMatch option is <c>"*"</c> (or <see cref="ETag.All"/>) the
        /// service will reject the request if the entity already exists.
        /// An optional ETag to only make the request if the value does not
        /// match on the service.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response{T}"/>.</returns>
        /// <typeparam name="T">The type to deserialize the relationship to.</typeparam>
        /// <remarks>
        /// <para>
        /// Relationships are a one-way link from a source digital twin to another, as described at creation time of the assigned model of the digital twin.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="CreateOrReplaceRelationshipAsync{T}(string, string, T, ETag?, CancellationToken)"/>
        public virtual Response<T> CreateOrReplaceRelationship<T>(
            string digitalTwinId,
            string relationshipId,
            T relationship,
            ETag? ifNoneMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                // Serialize the relationship and write it to a stream
                using MemoryStream memoryStream = WriteToStream<T>(relationship, _objectSerializer, cancellationToken);

                // Get the response relationship as a stream object
                CreateOrReplaceRelationshipOptions options = ifNoneMatch == null
                    ? null
                    : new CreateOrReplaceRelationshipOptions { IfNoneMatch = ifNoneMatch.Value.ToString() };
                Response<Stream> relationshipStream = _dtRestClient.AddRelationship(digitalTwinId, relationshipId, memoryStream, options, cancellationToken);

                // Deserialize the stream into the specified type
                T deserializedRelationship = (T)_objectSerializer.Deserialize(relationshipStream, typeof(T), cancellationToken);

                return Response.FromValue<T>(deserializedRelationship, relationshipStream.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin asynchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateRelationship(string, string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual async Task<Response> UpdateRelationshipAsync(
            string digitalTwinId,
            string relationshipId,
            JsonPatchDocument jsonPatchDocument,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateRelationshipOptions options = ifMatch == null
                    ? null
                    : new UpdateRelationshipOptions { IfMatch = ifMatch.Value.ToString() };
                return await _dtRestClient
                    .UpdateRelationshipAsync(
                        digitalTwinId,
                        relationshipId,
                        jsonPatchDocument.ToString(),
                        options,
                        cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the properties of a relationship on a digital twin synchronously.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the source digital twin.</param>
        /// <param name="relationshipId">The Id of the relationship to be updated.</param>
        /// <param name="jsonPatchDocument">The application/json-patch+json operations to be performed on the specified digital twin's relationship.</param>
        /// <param name="ifMatch">Optional. Only perform the operation if the entity's ETag matches this optional ETag or * (<see cref="ETag.All"/>) is provided.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>. This response object includes an HTTP header that gives you the updated ETag for this resource.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="relationshipId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="UpdateRelationshipAsync(string, string, JsonPatchDocument, ETag?, CancellationToken)"/>
        public virtual Response UpdateRelationship(
            string digitalTwinId,
            string relationshipId,
            JsonPatchDocument jsonPatchDocument,
            ETag? ifMatch = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(UpdateRelationship)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelRelationshipIdKey, relationshipId);
            scope.Start();

            try
            {
                Argument.AssertNotNull(jsonPatchDocument, nameof(jsonPatchDocument));
                UpdateRelationshipOptions options = ifMatch == null
                    ? null
                    : new UpdateRelationshipOptions { IfMatch = ifMatch.Value.ToString() };
                return _dtRestClient.UpdateRelationship(digitalTwinId, relationshipId, jsonPatchDocument.ToString(), options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the list of models by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json models and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModels" language="csharp">
        /// AsyncPageable&lt;DigitalTwinsModelData&gt; allModels = client.GetModelsAsync();
        /// await foreach (DigitalTwinsModelData model in allModels)
        /// {
        ///     Console.WriteLine($&quot;Retrieved model &apos;{model.Id}&apos;, &quot; +
        ///         $&quot;display name &apos;{model.LanguageDisplayNames[&quot;en&quot;]}&apos;, &quot; +
        ///         $&quot;uploaded on &apos;{model.UploadedOn}&apos;, &quot; +
        ///         $&quot;and decommissioned &apos;{model.Decommissioned}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="GetModels(GetModelsOptions, CancellationToken)"/>
        public virtual AsyncPageable<DigitalTwinsModelData> GetModelsAsync(GetModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
            scope.Start();

            try
            {
                async Task<Page<DigitalTwinsModelData>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
                    scope.Start();
                    try
                    {
                        if (options == null)
                        {
                            options = new GetModelsOptions();
                        }

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        options.MaxItemsPerPage = pageSizeHint;

                        Response<PagedDigitalTwinsModelDataCollection> response = await _dtModelsRestClient
                            .ListAsync(options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<DigitalTwinsModelData>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
                    scope.Start();
                    try
                    {
                        if (options == null)
                        {
                            options = new GetModelsOptions();
                        }

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        options.MaxItemsPerPage = pageSizeHint;

                        Response<PagedDigitalTwinsModelDataCollection> response = await _dtModelsRestClient
                            .ListNextPageAsync(nextLink, options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken)
                            .ConfigureAwait(false);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the list of models by iterating through a collection synchronously.
        /// </summary>
        /// <param name="options">The optional parameters for this request. If null, the default option values will be used.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json models and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetModelsAsync(GetModelsOptions, CancellationToken)"/>
        public virtual Pageable<DigitalTwinsModelData> GetModels(GetModelsOptions options = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
            scope.Start();

            try
            {
                Page<DigitalTwinsModelData> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
                    scope.Start();
                    try
                    {
                        Response<PagedDigitalTwinsModelDataCollection> response = _dtModelsRestClient
                            .List(options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<DigitalTwinsModelData> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModels)}");
                    scope.Start();
                    try
                    {
                        Response<PagedDigitalTwinsModelDataCollection> response = _dtModelsRestClient
                            .ListNextPage(nextLink, options?.DependenciesFor, options?.IncludeModelDefinition, options, cancellationToken);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a model, including the model metadata and the model definition asynchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetModel" language="csharp">
        /// Response&lt;DigitalTwinsModelData&gt; sampleModelResponse = await client.GetModelAsync(sampleModelId);
        /// Console.WriteLine($&quot;Retrieved model &apos;{sampleModelResponse.Value.Id}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="GetModel(string, CancellationToken)"/>
        public virtual async Task<Response<DigitalTwinsModelData>> GetModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                // The GetModel API will include the model definition in its response by default.
                return await _dtModelsRestClient.GetByIdAsync(modelId, IncludeModelDefinition, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a model, including the model metadata and the model definition synchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json model and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetModelAsync(string, CancellationToken)"/>
        public virtual Response<DigitalTwinsModelData> GetModel(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                // The GetModel API will include the model definition in its response by default.
                return _dtModelsRestClient.GetById(modelId, IncludeModelDefinition, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Decommissions a model asynchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// When a model is decommissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decommissioned, it may not be recommissioned.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDecommisionModel" language="csharp">
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
        /// <seealso cref="DecommissionModel(string, CancellationToken)"/>
        public virtual async Task<Response> DecommissionModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DecommissionModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                return await _dtModelsRestClient
                    .UpdateAsync(modelId, ModelsConstants.DecommissionModelOperationList, null, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Decommissions a model synchronously.
        /// </summary>
        /// <param name="modelId">The Id of the model to decommission.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// <para>
        /// When a model is decommissioned, new digital twins will no longer be able to be defined by this model.
        /// However, existing digital twins may continue to use this model.
        /// Once a model is decommissioned, it may not be recommissioned.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DecommissionModelAsync(string, CancellationToken)"/>
        public virtual Response DecommissionModel(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DecommissionModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                return _dtModelsRestClient.Update(modelId, ModelsConstants.DecommissionModelOperationList, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates one or many models asynchronously.
        /// </summary>
        /// <param name="dtdlModels">The set of models conforming to Digital Twins Definition Language (DTDL) v2 to create. Each string corresponds to exactly one model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the HTTP response <see cref="Response{T}"/>.</returns>
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
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models">Understand twin models in Azure Digital Twins.</see>
        /// </remarks>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateModels" language="csharp">
        /// await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
        /// Console.WriteLine($&quot;Created models &apos;{componentModelId}&apos; and &apos;{sampleModelId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="CreateModels(IEnumerable{string}, CancellationToken)"/>
        public virtual async Task<Response<DigitalTwinsModelData[]>> CreateModelsAsync(IEnumerable<string> dtdlModels, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateModels)}");
            scope.Start();

            try
            {
                Response<IReadOnlyList<DigitalTwinsModelData>> response = await _dtModelsRestClient
                    .AddAsync(dtdlModels, null, cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(response.Value.ToArray(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates one or many models synchronously.
        /// </summary>
        /// <param name="dtdlModels">The set of models conforming to Digital Twins Definition Language (DTDL) v2 to create. Each string corresponds to exactly one model.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created models and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// <para>
        /// Bulk model creation is useful when several models have references to each other.
        /// It simplifies creation for the client because otherwise the models would have to be created in a very specific order.
        /// The service evaluates all models to ensure all references are satisfied, and then accepts or rejects the set.
        /// So using this method, model creation is transactional.
        /// </para>
        /// <para>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models">Understand twin models in Azure Digital Twins.</see>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="CreateModelsAsync(IEnumerable{string}, CancellationToken)"/>
        public virtual Response<DigitalTwinsModelData[]> CreateModels(IEnumerable<string> dtdlModels, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateModels)}");
            scope.Start();

            try
            {
                Response<IReadOnlyList<DigitalTwinsModelData>> response = _dtModelsRestClient.Add(dtdlModels, null, cancellationToken);
                return Response.FromValue(response.Value.ToArray(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a model asynchronously.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
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
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteModel" language="csharp">
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
        /// <seealso cref="DeleteModel(string, CancellationToken)"/>
        public virtual async Task<Response> DeleteModelAsync(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                return await _dtModelsRestClient.DeleteAsync(modelId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a model synchronously.
        /// </summary>
        /// <param name="modelId"> The id for the model. The id is globally unique and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
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
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </para>
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="modelId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteModelAsync(string, CancellationToken)"/>
        public virtual Response DeleteModel(string modelId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteModel)}");
            scope.AddAttribute(OTelModelIdKey, modelId);
            scope.Start();

            try
            {
                return _dtModelsRestClient.Delete(modelId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all import jobs.
        /// Status codes:
        /// * 200 OK
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ImportJob> GetImportJobsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJobs)}");
            scope.Start();

            try
            {
                async Task<Page<ImportJob>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJobs)}");
                    scope.Start();
                    try
                    {
                        var options = new ImportJobsListOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<ImportJobCollection> response = await _importJobsRestClient
                            .ListAsync(options, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<ImportJob>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJobs)}");
                    scope.Start();
                    try
                    {
                        var options = new ImportJobsListOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<ImportJobCollection> response = await _importJobsRestClient
                            .ListNextPageAsync(nextLink, options, cancellationToken)
                            .ConfigureAwait(false);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all import jobs.
        /// Status codes:
        /// * 200 OK
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ImportJob> GetImportJobs(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJobs)}");
            scope.Start();

            try
            {
                Page<ImportJob> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJobs)}");
                    scope.Start();
                    try
                    {
                        var options = new ImportJobsListOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<ImportJobCollection> response = _importJobsRestClient.List(options, cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<ImportJob> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
                    scope.Start();

                    var options = new ImportJobsListOptions
                    {
                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        MaxItemsPerPage = pageSizeHint
                    };

                    try
                    {
                        Response<ImportJobCollection> response = _importJobsRestClient.ListNextPage(nextLink, options, cancellationToken);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an import job.
        /// Status codes:
        /// * 201 Created
        /// * 400 Bad Request
        ///   * JobLimitReached - The maximum number of import jobs allowed has been reached.
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="importJob"> The import job being added. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="importJob"/> is null. </exception>
        public virtual async Task<Response<ImportJob>> ImportGraphAsync(string jobId, ImportJob importJob, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(ImportGraph)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return await _importJobsRestClient.AddAsync(jobId, importJob, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an import job.
        /// Status codes:
        /// * 201 Created
        /// * 400 Bad Request
        ///   * JobLimitReached - The maximum number of import jobs allowed has been reached.
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="importJob"> The import job being added. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="importJob"/> is null. </exception>
        public virtual Response<ImportJob> ImportGraph(string jobId, ImportJob importJob, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(ImportGraph)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return _importJobsRestClient.Add(jobId, importJob, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an import job.
        /// Status codes:
        /// * 200 OK
        /// * 404 Not Found
        ///   * ImportJobNotFound - The import job was not found.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual async Task<Response<ImportJob>> GetImportJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return await _importJobsRestClient.GetByIdAsync(jobId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an import job.
        /// Status codes:
        /// * 200 OK
        /// * 404 Not Found
        ///   * ImportJobNotFound - The import job was not found.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual Response<ImportJob> GetImportJob(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return _importJobsRestClient.GetById(jobId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an import job.
        /// Status codes:
        /// * 204 No Content
        /// * 400 Bad Request
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual async Task<Response> DeleteImportJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return await _importJobsRestClient.DeleteAsync(jobId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an import job.
        /// Status codes:
        /// * 204 No Content
        /// * 400 Bad Request
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual Response DeleteImportJob(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return _importJobsRestClient.Delete(jobId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancels an import job.
        /// Status codes:
        /// * 200 Request Accepted
        /// * 400 Bad Request
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual async Task<Response<ImportJob>> CancelImportJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CancelImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return await _importJobsRestClient.CancelAsync(jobId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Cancels an import job.
        /// Status codes:
        /// * 200 Request Accepted
        /// * 400 Bad Request
        ///   * ValidationFailed - The import job request is not valid.
        /// </summary>
        /// <param name="jobId"> The id for the import job. The id is unique within the service and case sensitive. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public virtual Response<ImportJob> CancelImportJob(string jobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CancelImportJob)}");
            scope.AddAttribute(OTelJobIdKey, jobId);
            scope.Start();

            try
            {
                return _importJobsRestClient.Cancel(jobId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries for digital twins by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of query results.</returns>
        /// <typeparam name="T">The type to deserialize the result to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// Note that there may be a delay between before changes in your instance are reflected in queries.
        /// For more details on query limitations, see
        /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/how-to-query-graph#query-limitations">Query limitations</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleQueryTwins" language="csharp">
        /// // This code snippet demonstrates the simplest way to iterate over the digital twin results, where paging
        /// // happens under the covers.
        /// AsyncPageable&lt;BasicDigitalTwin&gt; asyncPageableResponse = client.QueryAsync&lt;BasicDigitalTwin&gt;(&quot;SELECT * FROM digitaltwins&quot;);
        ///
        /// // Iterate over the twin instances in the pageable response.
        /// // The &quot;await&quot; keyword here is required because new pages will be fetched when necessary,
        /// // which involves a request to the service.
        /// await foreach (BasicDigitalTwin twin in asyncPageableResponse)
        /// {
        ///     Console.WriteLine($&quot;Found digital twin &apos;{twin.Id}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="Query(string, CancellationToken)"/>
        public virtual AsyncPageable<T> QueryAsync<T>(string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
            scope.AddAttribute(OTeQueryKey, query);
            scope.Start();

            try
            {
                // Note: pageSizeHint is not supported as a parameter in the service for query API, so ignoring it.
                // Cannot remove the parameter as the function signature in Azure.Core helper needs it.
                async Task<Page<T>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var querySpecification = new QuerySpecification
                        {
                            Query = query
                        };

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        var options = new QueryOptions
                        {
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<QueryResult<T>> response = await _queryClient
                            .QueryTwinsAsync<T>(
                                querySpecification,
                                options,
                                _objectSerializer,
                                cancellationToken)
                            .ConfigureAwait(false);

                        return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<T>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var querySpecification = new QuerySpecification
                        {
                            ContinuationToken = nextLink
                        };

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        var options = new QueryOptions
                        {
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<QueryResult<T>> response = await _queryClient
                            .QueryTwinsAsync<T>(
                                querySpecification,
                                options,
                                _objectSerializer,
                                cancellationToken)
                            .ConfigureAwait(false);

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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Queries for digital twins by iterating through a collection synchronously.
        /// </summary>
        /// <param name="query">The query string, in SQL-like syntax.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of query results.</returns>
        /// <typeparam name="T">The type to deserialize the result to.</typeparam>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// Note that there may be a delay between before changes in your instance are reflected in queries.
        /// For more details on query limitations, see
        /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/how-to-query-graph#query-limitations">Query limitations</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// A basic query for all digital twins: SELECT * FROM digitalTwins.
        /// </example>
        /// <seealso cref="QueryAsync(string, CancellationToken)"/>
        public virtual Pageable<T> Query<T>(string query, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
            scope.AddAttribute(OTeQueryKey, query);
            scope.Start();

            try
            {
                // Note: pageSizeHint is not supported as a parameter in the service for query API, so ignoring it.
                // Cannot remove the parameter as the function signature in Azure.Core helper needs it.
                Page<T> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var querySpecification = new QuerySpecification
                        {
                            Query = query
                        };

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        var options = new QueryOptions
                        {
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<QueryResult<T>> response = _queryClient
                            .QueryTwins<T>(
                                querySpecification,
                                options,
                                _objectSerializer,
                                cancellationToken);

                        return Page.FromValues(response.Value.Value, response.Value.ContinuationToken, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<T> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(Query)}");
                    scope.Start();
                    try
                    {
                        var querySpecification = new QuerySpecification
                        {
                            ContinuationToken = nextLink
                        };

                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        var options = new QueryOptions
                        {
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<QueryResult<T>> response = _queryClient.QueryTwins<T>(
                            querySpecification,
                            options,
                            _objectSerializer,
                            cancellationToken);

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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>.
        /// Lists the event routes in a digital twins instance by iterating through a collection asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="AsyncPageable{T}"/> of application/json event routes and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleGetEventRoutes" language="csharp">
        /// AsyncPageable&lt;DigitalTwinsEventRoute&gt; response = client.GetEventRoutesAsync();
        /// await foreach (DigitalTwinsEventRoute er in response)
        /// {
        ///     Console.WriteLine($&quot;Event route &apos;{er.Id}&apos;, endpoint name &apos;{er.EndpointName}&apos;&quot;);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="GetEventRoutesAsync(CancellationToken)"/>
        public virtual AsyncPageable<DigitalTwinsEventRoute> GetEventRoutesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
            scope.Start();

            try
            {
                async Task<Page<DigitalTwinsEventRoute>> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
                    scope.Start();
                    try
                    {
                        var options = new GetDigitalTwinsEventRoutesOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<DigitalTwinsEventRouteCollection> response = await _eventRoutesRestClient
                            .ListAsync(options, cancellationToken)
                            .ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                async Task<Page<DigitalTwinsEventRoute>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
                    scope.Start();
                    try
                    {
                        var options = new GetDigitalTwinsEventRoutesOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<DigitalTwinsEventRouteCollection> response = await _eventRoutesRestClient
                            .ListNextPageAsync(nextLink, options, cancellationToken)
                            .ConfigureAwait(false);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>.
        /// Lists the event routes in a digital twins instance by iterating through a collection synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The pageable list <see cref="Pageable{T}"/> of application/json event routes and the HTTP response.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <seealso cref="GetEventRoutesAsync(CancellationToken)"/>
        public virtual Pageable<DigitalTwinsEventRoute> GetEventRoutes(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
            scope.Start();

            try
            {
                Page<DigitalTwinsEventRoute> FirstPageFunc(int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
                    scope.Start();
                    try
                    {
                        var options = new GetDigitalTwinsEventRoutesOptions
                        {
                            // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                            MaxItemsPerPage = pageSizeHint
                        };

                        Response<DigitalTwinsEventRouteCollection> response = _eventRoutesRestClient.List(options, cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception ex)
                    {
                        scope.Failed(ex);
                        throw;
                    }
                }

                Page<DigitalTwinsEventRoute> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoutes)}");
                    scope.Start();

                    var options = new GetDigitalTwinsEventRoutesOptions
                    {
                        // Page size hint is only specified by AsPages() methods, so we add it here manually since the user can't set it on the options object directly
                        MaxItemsPerPage = pageSizeHint
                    };

                    try
                    {
                        Response<DigitalTwinsEventRouteCollection> response = _eventRoutesRestClient.ListNextPage(nextLink, options, cancellationToken);
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
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets an event route by Id asynchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetEventRoute(string, CancellationToken)"/>
        public virtual async Task<Response<DigitalTwinsEventRoute>> GetEventRouteAsync(string eventRouteId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return await _eventRoutesRestClient.GetByIdAsync(eventRouteId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets an event route by Id synchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The application/json event routes and the HTTP response <see cref="Response{T}"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="GetEventRouteAsync(string, CancellationToken)"/>
        public virtual Response<DigitalTwinsEventRoute> GetEventRoute(string eventRouteId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(GetEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return _eventRoutesRestClient.GetById(eventRouteId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an event route asynchronously. If the provided event route Id is already in use, then this will attempt to replace the existing
        /// event route with the provided event route.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleCreateEventRoute" language="csharp">
        /// string eventFilter = &quot;$eventType = &apos;DigitalTwinTelemetryMessages&apos; or $eventType = &apos;DigitalTwinLifecycleNotification&apos;&quot;;
        /// var eventRoute = new DigitalTwinsEventRoute(eventhubEndpointName, eventFilter);
        ///
        /// await client.CreateOrReplaceEventRouteAsync(_eventRouteId, eventRoute);
        /// Console.WriteLine($&quot;Created event route &apos;{_eventRouteId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="CreateOrReplaceEventRoute(string, DigitalTwinsEventRoute, CancellationToken)"/>
        public virtual async Task<Response> CreateOrReplaceEventRouteAsync(string eventRouteId, DigitalTwinsEventRoute eventRoute, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return await _eventRoutesRestClient.AddAsync(eventRouteId, eventRoute, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an event route synchronously. If the provided event route Id is already in use, then this will attempt to replace the existing
        /// event route with the provided event route.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to create.</param>
        /// <param name="eventRoute">The event route data containing the endpoint and optional filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="CreateOrReplaceEventRouteAsync(string, DigitalTwinsEventRoute, CancellationToken)"/>
        public virtual Response CreateOrReplaceEventRoute(string eventRouteId, DigitalTwinsEventRoute eventRoute, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(CreateOrReplaceEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return _eventRoutesRestClient.Add(eventRouteId, eventRoute, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an event route asynchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSampleDeleteEventRoute" language="csharp">
        /// await client.DeleteEventRouteAsync(_eventRouteId);
        /// Console.WriteLine($&quot;Deleted event route &apos;{_eventRouteId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="DeleteEventRouteAsync(string, CancellationToken)"/>
        public virtual async Task<Response> DeleteEventRouteAsync(string eventRouteId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return await _eventRoutesRestClient.DeleteAsync(eventRouteId, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes an event route synchronously.
        /// </summary>
        /// <param name="eventRouteId">The Id of the event route to delete.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="eventRouteId"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="DeleteEventRouteAsync(string, CancellationToken)"/>
        public virtual Response DeleteEventRoute(string eventRouteId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(DeleteEventRoute)}");
            scope.AddAttribute(OTelEventRouteIdKey, eventRouteId);
            scope.Start();

            try
            {
                return _eventRoutesRestClient.Delete(eventRouteId, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Publishes telemetry from a digital twin asynchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="DigitalTwinsEventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random GUID if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="timestamp">An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSamplePublishTelemetry" language="csharp">
        /// // construct your json telemetry payload by hand.
        /// await client.PublishTelemetryAsync(twinId, Guid.NewGuid().ToString(), &quot;{\&quot;Telemetry1\&quot;: 5}&quot;);
        /// Console.WriteLine($&quot;Published telemetry message to twin &apos;{twinId}&apos;.&quot;);
        /// </code>
        /// </example>
        /// <seealso cref="PublishTelemetry(string, string, string, DateTimeOffset?, CancellationToken)"/>
        public virtual async Task<Response> PublishTelemetryAsync(
            string digitalTwinId,
            string messageId,
            string payload,
            DateTimeOffset? timestamp = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(PublishTelemetry)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelMessageIdKey, messageId);
            scope.Start();

            try
            {
                if (string.IsNullOrEmpty(messageId))
                {
                    //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                    messageId = Guid.NewGuid().ToString();
                }

                var options = new PublishTelemetryOptions();
                if (timestamp != null)
                {
                    options.TimeStamp = timestamp.Value;
                }

                return await _dtRestClient
                    .SendTelemetryAsync(digitalTwinId, messageId, payload, options, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Publishes telemetry from a digital twin synchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="DigitalTwinsEventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random GUID if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="timestamp">An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishTelemetryAsync(string, string, string, DateTimeOffset?, CancellationToken)"/>
        public virtual Response PublishTelemetry(
            string digitalTwinId,
            string messageId,
            string payload,
            DateTimeOffset? timestamp = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(PublishTelemetry)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelMessageIdKey, messageId);
            scope.Start();

            try
            {
                if (string.IsNullOrEmpty(messageId))
                {
                    //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                    messageId = Guid.NewGuid().ToString();
                }

                var options = new PublishTelemetryOptions();
                if (timestamp != null)
                {
                    options.TimeStamp = timestamp.Value;
                }

                return _dtRestClient.SendTelemetry(digitalTwinId, messageId, payload, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component asynchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="DigitalTwinsEventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random GUID if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="timestamp">An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <example>
        /// <code snippet="Snippet:DigitalTwinsSamplePublishComponentTelemetry" language="csharp">
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
        /// <seealso cref="PublishComponentTelemetry(string, string, string, string, DateTimeOffset?, CancellationToken)"/>
        public virtual async Task<Response> PublishComponentTelemetryAsync(
            string digitalTwinId,
            string componentName,
            string messageId,
            string payload,
            DateTimeOffset? timestamp = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(PublishComponentTelemetry)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelComponentNameKey, componentName);
            scope.AddAttribute(OTelMessageIdKey, messageId);
            scope.Start();

            try
            {
                if (string.IsNullOrEmpty(messageId))
                {
                    //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                    messageId = Guid.NewGuid().ToString();
                }

                var options = new PublishComponentTelemetryOptions();
                if (timestamp != null)
                {
                    options.TimeStamp = timestamp.Value;
                }

                return await _dtRestClient
                    .SendComponentTelemetryAsync(digitalTwinId, componentName, messageId, payload, options, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Publishes telemetry from a digital twin's component synchronously.
        /// The result is then consumed by one or many destination endpoints (subscribers) defined under <see cref="DigitalTwinsEventRoute"/>.
        /// These event routes need to be set before publishing a telemetry message, in order for the telemetry message to be consumed.
        /// </summary>
        /// <param name="digitalTwinId">The Id of the digital twin.</param>
        /// <param name="componentName">The name of the DTDL component.</param>
        /// <param name="messageId">A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages. Defaults to a random GUID if argument is null.</param>
        /// <param name="payload">The application/json telemetry payload to be sent.</param>
        /// <param name="timestamp">An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response <see cref="Response"/>.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <exception cref="RequestFailedException">
        /// The exception that captures the errors from the service. Check the <see cref="RequestFailedException.ErrorCode"/> and <see cref="RequestFailedException.Status"/> properties for more details.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// The exception is thrown when <paramref name="digitalTwinId"/> or <paramref name="componentName"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <seealso cref="PublishComponentTelemetryAsync(string, string, string, string, DateTimeOffset?, CancellationToken)"/>
        public virtual Response PublishComponentTelemetry(
            string digitalTwinId,
            string componentName,
            string messageId,
            string payload,
            DateTimeOffset? timestamp = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DigitalTwinsClient)}.{nameof(PublishComponentTelemetry)}");
            scope.AddAttribute(OTelTwinIdKey, digitalTwinId);
            scope.AddAttribute(OTelComponentNameKey, componentName);
            scope.AddAttribute(OTelMessageIdKey, messageId);
            scope.Start();

            try
            {
                if (string.IsNullOrEmpty(messageId))
                {
                    //MessageId is a mandatory parameter, but our convenience layer makes it optional by having a default value
                    messageId = Guid.NewGuid().ToString();
                }

                var options = new PublishComponentTelemetryOptions();
                if (timestamp != null)
                {
                    options.TimeStamp = timestamp.Value;
                }

                return _dtRestClient.SendComponentTelemetry(digitalTwinId, componentName, messageId, payload, options, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the scope for authentication/authorization policy.
        /// </summary>
        /// <returns>List of scopes for the specified endpoint.</returns>
        internal static string[] GetAuthorizationScopes() => s_adtDefaultScopes;
    }
}
