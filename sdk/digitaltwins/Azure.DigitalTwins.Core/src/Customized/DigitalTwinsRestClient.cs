// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    // Declaring this class here will make it so that we can force its methods to use strings instead of
    // objects for json inputs/return values
    internal partial class DigitalTwinsRestClient
    {
        private const string DateTimeOffsetFormat = "MM/dd/yy H:mm:ss zzz";

        /// <summary>
        /// Retrieves a digital twin.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="digitalTwinsGetByIdOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public async Task<Response<Stream>> GetByIdAsync(string id, GetDigitalTwinOptions digitalTwinsGetByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using var message = CreateGetByIdRequest(id, digitalTwinsGetByIdOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary>
        /// Retrieves a digital twin.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="digitalTwinsGetByIdOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public Response<Stream> GetById(string id, GetDigitalTwinOptions digitalTwinsGetByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using var message = CreateGetByIdRequest(id, digitalTwinsGetByIdOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary>
        /// Retrieves a relationship between two digital twins.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id or relationship id is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        ///   * RelationshipNotFound - The relationship was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="relationshipId"> The id of the relationship. The id is unique within the digital twin and case sensitive. </param>
        /// <param name="digitalTwinsGetRelationshipByIdOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="relationshipId"/> is null. </exception>
        public async Task<Response<Stream>> GetRelationshipByIdAsync(string id, string relationshipId, GetRelationshipOptions digitalTwinsGetRelationshipByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }

            using var message = CreateGetRelationshipByIdRequest(id, relationshipId, digitalTwinsGetRelationshipByIdOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary>
        /// Retrieves a relationship between two digital twins.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id or relationship id is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        ///   * RelationshipNotFound - The relationship was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="relationshipId"> The id of the relationship. The id is unique within the digital twin and case sensitive. </param>
        /// <param name="digitalTwinsGetRelationshipByIdOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="relationshipId"/> is null. </exception>
        public Response<Stream> GetRelationshipById(string id, string relationshipId, GetRelationshipOptions digitalTwinsGetRelationshipByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }

            using var message = CreateGetRelationshipByIdRequest(id, relationshipId, digitalTwinsGetRelationshipByIdOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary>
        /// Retrieves a component from a digital twin.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id or component path is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        ///   * ComponentNotFound - The component path was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="componentPath"> The name of the DTDL component. </param>
        /// <param name="digitalTwinsGetComponentOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="componentPath"/> is null. </exception>
        public async Task<Response<Stream>> GetComponentAsync(string id, string componentPath, GetComponentOptions digitalTwinsGetComponentOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }

            using var message = CreateGetComponentRequest(id, componentPath, digitalTwinsGetComponentOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary>
        /// Retrieves a component from a digital twin.
        /// Status codes:
        /// * 200 OK
        /// * 400 Bad Request
        ///   * InvalidArgument - The digital twin id or component path is invalid.
        /// * 404 Not Found
        ///   * DigitalTwinNotFound - The digital twin was not found.
        ///   * ComponentNotFound - The component path was not found.
        /// </summary>
        /// <param name="id"> The id of the digital twin. The id is unique within the service and case sensitive. </param>
        /// <param name="componentPath"> The name of the DTDL component. </param>
        /// <param name="digitalTwinsGetComponentOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="componentPath"/> is null. </exception>
        public Response<Stream> GetComponent(string id, string componentPath, GetComponentOptions digitalTwinsGetComponentOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }

            using var message = CreateGetComponentRequest(id, componentPath, digitalTwinsGetComponentOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        var value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateAddRequest(string id, Stream twin, CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsAddOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsAddOptions.TraceParent);
            }
            if (digitalTwinsAddOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsAddOptions.TraceState);
            }
            if (digitalTwinsAddOptions?.IfNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", digitalTwinsAddOptions.IfNoneMatch);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            var content = RequestContent.Create(twin);
            request.Content = content;
            return message;
        }

        internal async Task<Response<Stream>> AddAsync(
            string id,
            Stream twin,
            CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (twin == null)
            {
                throw new ArgumentNullException(nameof(twin));
            }

            using HttpMessage message = CreateAddRequest(id, twin, digitalTwinsAddOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Stream value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                case 202:
                    return Response.FromValue<Stream>(null, message.Response);

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response<Stream> Add(
            string id,
            Stream twin,
            CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (twin == null)
            {
                throw new ArgumentNullException(nameof(twin));
            }

            using HttpMessage message = CreateAddRequest(id, twin, digitalTwinsAddOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Stream value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                case 202:
                    return Response.FromValue<Stream>(null, message.Response);

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response> UpdateAsync(
            string id,
            string patchDocument,
            UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchDocument == null)
            {
                throw new ArgumentNullException(nameof(patchDocument));
            }

            using HttpMessage message = CreateUpdateRequest(id, patchDocument, digitalTwinsUpdateOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response Update(
            string id,
            string patchDocument,
            UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (patchDocument == null)
            {
                throw new ArgumentNullException(nameof(patchDocument));
            }

            using HttpMessage message = CreateUpdateRequest(id, patchDocument, digitalTwinsUpdateOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response<Stream>> AddRelationshipAsync(
            string id,
            string relationshipId,
            Stream relationship,
            CreateOrReplaceRelationshipOptions digitalTwinsAddRelationshipOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }
            if (relationship == null)
            {
                throw new ArgumentNullException(nameof(relationship));
            }

            using HttpMessage message = CreateAddRelationshipRequest(id, relationshipId, relationship, digitalTwinsAddRelationshipOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Stream value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        public Response<Stream> AddRelationship(
            string id,
            string relationshipId,
            Stream relationship,
            CreateOrReplaceRelationshipOptions digitalTwinsAddRelationshipOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }
            if (relationship == null)
            {
                throw new ArgumentNullException(nameof(relationship));
            }

            using var message = CreateAddRelationshipRequest(id, relationshipId, relationship, digitalTwinsAddRelationshipOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Stream value = message.ExtractResponseContent();
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response> UpdateRelationshipAsync(
            string id,
            string relationshipId,
            string patchDocument,
            UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }

            using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, digitalTwinsUpdateRelationshipOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            return message.Response.Status switch
            {
                204 => message.Response,
                _ => throw new RequestFailedException(message.Response),
            };
        }

        internal Response UpdateRelationship(
            string id,
            string relationshipId,
            string patchDocument,
            UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (relationshipId == null)
            {
                throw new ArgumentNullException(nameof(relationshipId));
            }

            using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, digitalTwinsUpdateRelationshipOptions);
            _pipeline.Send(message, cancellationToken);
            return message.Response.Status switch
            {
                204 => message.Response,
                _ => throw new RequestFailedException(message.Response),
            };
        }

        internal async Task<Response> UpdateComponentAsync(
            string id,
            string componentPath,
            string patchDocument,
            UpdateComponentOptions digitalTwinsUpdateComponentOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }

            using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, digitalTwinsUpdateComponentOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response UpdateComponent(
            string id,
            string componentPath,
            string patchDocument,
            UpdateComponentOptions digitalTwinsUpdateComponentOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }

            using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, digitalTwinsUpdateComponentOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response> SendTelemetryAsync(
            string id,
            string messageId,
            string telemetry,
            PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using HttpMessage message = CreateSendTelemetryRequest(id, messageId, telemetry, digitalTwinsSendTelemetryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response SendTelemetry(
            string id,
            string messageId,
            string telemetry,
            PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using HttpMessage message = CreateSendTelemetryRequest(id, messageId, telemetry, digitalTwinsSendTelemetryOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response> SendComponentTelemetryAsync(
            string id,
            string componentPath,
            string messageId,
            string telemetry,
            PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, messageId, telemetry, digitalTwinsSendComponentTelemetryOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response SendComponentTelemetry(
            string id,
            string componentPath,
            string messageId,
            string telemetry,
            PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, messageId, telemetry, digitalTwinsSendComponentTelemetryOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 204:
                    return message.Response;

                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response<RelationshipCollection<T>>> ListRelationshipsAsync<T>(
            string id,
            string relationshipName = null,
            GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateListRelationshipsRequest(id, relationshipName, digitalTwinsListRelationshipsOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        RelationshipCollection<T> value = RelationshipCollection<T>.DeserializeRelationshipCollection(document.RootElement, objectSerializer);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal async Task<Response<RelationshipCollection<T>>> ListRelationshipsNextPageAsync<T>(
            string nextLink,
            string id,
            string relationshipName = null,
            GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateListRelationshipsNextPageRequest(nextLink, id, relationshipName, digitalTwinsListRelationshipsOptions);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        RelationshipCollection<T> value = RelationshipCollection<T>.DeserializeRelationshipCollection(document.RootElement, objectSerializer);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response<RelationshipCollection<T>> ListRelationships<T>(
            string id,
            string relationshipName = null,
            GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateListRelationshipsRequest(id, relationshipName, digitalTwinsListRelationshipsOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using JsonDocument document = JsonDocument.Parse(message.Response.ContentStream);
                        RelationshipCollection<T> value = RelationshipCollection<T>.DeserializeRelationshipCollection(document.RootElement, objectSerializer);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal Response<RelationshipCollection<T>> ListRelationshipsNextPage<T>(
            string nextLink,
            string id,
            string relationshipName = null,
            GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null,
            ObjectSerializer objectSerializer = null,
            CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (objectSerializer == null)
            {
                throw new ArgumentNullException(nameof(objectSerializer));
            }

            using HttpMessage message = CreateListRelationshipsNextPageRequest(nextLink, id, relationshipName, digitalTwinsListRelationshipsOptions);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using JsonDocument document = JsonDocument.Parse(message.Response.ContentStream);
                        RelationshipCollection<T> value = RelationshipCollection<T>.DeserializeRelationshipCollection(document.RootElement, objectSerializer);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        private HttpMessage CreateUpdateRequest(
            string id,
            string patchDocument,
            UpdateDigitalTwinOptions digitalTwinsUpdateOptions)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Patch;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsUpdateOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsUpdateOptions.TraceParent);
            }
            if (digitalTwinsUpdateOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsUpdateOptions.TraceState);
            }
            if (digitalTwinsUpdateOptions?.IfMatch != null)
            {
                request.Headers.Add("If-Match", digitalTwinsUpdateOptions.IfMatch);
            }
            request.Headers.Add("Content-Type", "application/json-patch+json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(patchDocument);
            return message;
        }

        private HttpMessage CreateAddRelationshipRequest(
            string id,
            string relationshipId,
            Stream relationship,
            CreateOrReplaceRelationshipOptions digitalTwinsAddRelationshipOptions)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Put;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsAddRelationshipOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsAddRelationshipOptions.TraceParent);
            }
            if (digitalTwinsAddRelationshipOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsAddRelationshipOptions.TraceState);
            }
            if (digitalTwinsAddRelationshipOptions?.IfNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", digitalTwinsAddRelationshipOptions.IfNoneMatch);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = RequestContent.Create(relationship);
            return message;
        }

        private HttpMessage CreateUpdateRelationshipRequest(
            string id,
            string relationshipId,
            string patchDocument,
            UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsUpdateRelationshipOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsUpdateRelationshipOptions.TraceParent);
            }
            if (digitalTwinsUpdateRelationshipOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsUpdateRelationshipOptions.TraceState);
            }
            if (digitalTwinsUpdateRelationshipOptions?.IfMatch != null)
            {
                request.Headers.Add("If-Match", digitalTwinsUpdateRelationshipOptions.IfMatch);
            }
            request.Headers.Add("Content-Type", "application/json-patch+json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(patchDocument);
            return message;
        }

        private HttpMessage CreateUpdateComponentRequest(
            string id,
            string componentPath,
            string patchDocument,
            UpdateComponentOptions digitalTwinsUpdateComponentOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/components/", false);
            uri.AppendPath(componentPath, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsUpdateComponentOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsUpdateComponentOptions.TraceParent);
            }
            if (digitalTwinsUpdateComponentOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsUpdateComponentOptions.TraceState);
            }
            if (digitalTwinsUpdateComponentOptions?.IfMatch != null)
            {
                request.Headers.Add("If-Match", digitalTwinsUpdateComponentOptions.IfMatch);
            }
            request.Headers.Add("Content-Type", "application/json-patch+json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(patchDocument);
            return message;
        }

        private HttpMessage CreateSendTelemetryRequest(
            string id,
            string messageId,
            string telemetry,
            PublishTelemetryOptions digitalTwinsSendTelemetryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/telemetry", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsSendTelemetryOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsSendTelemetryOptions.TraceParent);
            }
            if (digitalTwinsSendTelemetryOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsSendTelemetryOptions.TraceState);
            }
            request.Headers.Add("Message-Id", messageId);
            if (digitalTwinsSendTelemetryOptions?.TimeStamp != null)
            {
                request.Headers.Add("Telemetry-Source-Time", TypeFormatters.ToString(digitalTwinsSendTelemetryOptions.TimeStamp, DateTimeOffsetFormat));
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(telemetry);
            return message;
        }

        private HttpMessage CreateSendComponentTelemetryRequest(
            string id,
            string componentPath,
            string messageId,
            string telemetry,
            PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/components/", false);
            uri.AppendPath(componentPath, true);
            uri.AppendPath("/telemetry", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsSendComponentTelemetryOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsSendComponentTelemetryOptions.TraceParent);
            }
            if (digitalTwinsSendComponentTelemetryOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsSendComponentTelemetryOptions.TraceState);
            }
            request.Headers.Add("Message-Id", messageId);
            if (digitalTwinsSendComponentTelemetryOptions?.TimeStamp != null)
            {
                request.Headers.Add("Telemetry-Source-Time", TypeFormatters.ToString(digitalTwinsSendComponentTelemetryOptions.TimeStamp, DateTimeOffsetFormat));
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(telemetry);
            return message;
        }

        #region null overrides

        // The following methods are only declared so that autorest does not create these functions in the generated code.
        // For methods that we need to override, when the parameter list is the same, autorest knows not to generate them again.
        // When the parameter list changes, autorest generates the methods again.
        // As such, these methods are declared here and made private, while the public method is declared above, too.
        // These methods should never be called.

#pragma warning disable CA1801, IDE0051, IDE0060, CA1822 // Remove unused parameter

        // Original return type is Task<Response<object>>. Changing to object to allow returning null.
        private object AddAsync(string id, object twin, CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<object> Add(string id, object twin, CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object UpdateAsync(string id, IEnumerable<object> patchDocument, UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null, CancellationToken cancellationToken = default) => null;

        private Response Update(string id, IEnumerable<object> patchDocument, UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response<object>>. Changing to object to allow returning null.
        private object AddRelationshipAsync(string id, string relationshipId, object relationship = null, CreateOrReplaceRelationshipOptions digitalTwinsAddRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<object> AddRelationship(string id, string relationshipId, object relationship = null, CreateOrReplaceRelationshipOptions digitalTwinsAddRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> UpdateRelationshipAsync(string id, string relationshipId, IEnumerable<object> patchDocument, UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateRelationship(string id, string relationshipId, IEnumerable<object> patchDocument, UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        private Task<Response<RelationshipCollection>> ListRelationshipsAsync(string id, string relationshipName = null, GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<RelationshipCollection> ListRelationships(string id, string relationshipName = null, GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null, CancellationToken cancellationToken = default) => null;

        private Task<Response<RelationshipCollection>> ListRelationshipsNextPageAsync(string nextLink, string id, string relationshipName = null, GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<RelationshipCollection> ListRelationshipsNextPage(string nextLink, string id, string relationshipName = null, GetRelationshipsOptions digitalTwinsListRelationshipsOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> UpdateComponentAsync(string id, string componentPath, IEnumerable<object> patchDocument, UpdateComponentOptions digitalTwinsUpdateComponentOptions = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateComponent(string id, string componentPath, IEnumerable<object> patchDocument, UpdateComponentOptions digitalTwinsUpdateComponentOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object SendTelemetryAsync(string id, string dtId, object telemetry, string dtTimestamp = null, PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private Response SendTelemetry(string id, string dtId, object telemetry, string dtTimestamp = null, PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> SendComponentTelemetryAsync(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private Response SendComponentTelemetry(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private HttpMessage CreateAddRequest(string id, object twin, CreateOrReplaceDigitalTwinOptions digitalTwinsAddOptions = null) => null;

#pragma warning restore CA1801, IDE0051, IDE0060 // Remove unused parameter

        #endregion null overrides
    }
}
