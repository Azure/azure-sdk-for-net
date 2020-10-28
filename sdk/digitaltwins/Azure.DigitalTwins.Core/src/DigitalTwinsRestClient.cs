// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    internal partial class DigitalTwinsRestClient
    {
        internal async Task<Response<RelationshipCollection<T>>> ListRelationshipsAsync<T>(string id,
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        internal async Task<Response<RelationshipCollection<T>>> ListRelationshipsNextPageAsync<T>(string nextLink,
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        internal Response<RelationshipCollection<T>> ListRelationships<T>(string id,
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
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal Response<RelationshipCollection<T>> ListRelationshipsNextPage<T>(string nextLink,
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
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
