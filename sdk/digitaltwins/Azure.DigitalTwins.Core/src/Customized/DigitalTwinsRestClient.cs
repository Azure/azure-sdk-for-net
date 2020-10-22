// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.DigitalTwins.Core
{
    // Declaring this class here will make it so that we can force its methods to use strings instead of
    // objects for json inputs/return values
    internal partial class DigitalTwinsRestClient
    {
        private const string DateTimeOffsetFormat = "MM/dd/yy H:mm:ss zzz";

        internal HttpMessage CreateAddRequest(string id, Stream twin, CreateDigitalTwinOptions digitalTwinsAddOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsAddOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsAddOptions.TraceParent);
            }
            if (digitalTwinsAddOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsAddOptions.TraceState);
            }
            request.Headers.Add("If-None-Match", "*");
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            var content = RequestContent.Create(twin);
            request.Content = content;
            return message;
        }

        internal async Task<Response<Stream>> AddAsync(
            string id,
            Stream twin,
            CreateDigitalTwinOptions digitalTwinsAddOptions = null,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.Add");
            scope.Start();
            try
            {
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
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal Response<Stream> Add(string id, Stream twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default)
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
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.Update");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRequest(id, patchDocument, digitalTwinsUpdateOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                    case 204:
                        return message.Response;

                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.Update");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRequest(id, patchDocument, digitalTwinsUpdateOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                    case 204:
                        return message.Response;

                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal async Task<Response<Stream>> AddRelationshipAsync(
            string id,
            string relationshipId,
            Stream relationship,
            CreateRelationshipOptions digitalTwinsAddRelationshipOptions = null,
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        public Response<Stream> AddRelationship(
            string id,
            string relationshipId,
            Stream relationship,
            CreateRelationshipOptions digitalTwinsAddRelationshipOptions = null,
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
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.UpdateRelationship");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, digitalTwinsUpdateRelationshipOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return message.Response.Status switch
                {
                    204 => message.Response,
                    _ => throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.UpdateRelationship");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, digitalTwinsUpdateRelationshipOptions);
                _pipeline.Send(message, cancellationToken);
                return message.Response.Status switch
                {
                    204 => message.Response,
                    _ => throw _clientDiagnostics.CreateRequestFailedException(message.Response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.UpdateComponent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, digitalTwinsUpdateComponentOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
                    case 204:
                        return message.Response;

                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.UpdateComponent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, digitalTwinsUpdateComponentOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
                    case 204:
                        return message.Response;

                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendTelemetryRequest(id, messageId, telemetry, digitalTwinsSendTelemetryOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;

                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendTelemetryRequest(id, messageId, telemetry, digitalTwinsSendTelemetryOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;

                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendComponentTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, messageId, telemetry, digitalTwinsSendComponentTelemetryOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;

                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendComponentTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, messageId, telemetry, digitalTwinsSendComponentTelemetryOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;

                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
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
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
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
                    CreateRelationshipOptions digitalTwinsAddRelationshipOptions)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Put;
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsAddRelationshipOptions?.TraceParent != null)
            {
                request.Headers.Add("TraceParent", digitalTwinsAddRelationshipOptions.TraceParent);
            }
            if (digitalTwinsAddRelationshipOptions?.TraceState != null)
            {
                request.Headers.Add("TraceState", digitalTwinsAddRelationshipOptions.TraceState);
            }
            request.Headers.Add("If-None-Match", "*");
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
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", apiVersion, true);
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
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/components/", false);
            uri.AppendPath(componentPath, true);
            uri.AppendQuery("api-version", apiVersion, true);
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
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/telemetry", false);
            uri.AppendQuery("api-version", apiVersion, true);
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
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/components/", false);
            uri.AppendPath(componentPath, true);
            uri.AppendPath("/telemetry", false);
            uri.AppendQuery("api-version", apiVersion, true);
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

#pragma warning disable CA1801, IDE0051, IDE0060 // Remove unused parameter

        // Original return type is Task<Response<object>>. Changing to object to allow returning null.
        private object AddAsync(string id, object twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<object> Add(string id, object twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object UpdateAsync(string id, IEnumerable<object> patchDocument, UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null, CancellationToken cancellationToken = default) => null;

        private Response Update(string id, IEnumerable<object> patchDocument, UpdateDigitalTwinOptions digitalTwinsUpdateOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response<object>>. Changing to object to allow returning null.
        private object AddRelationshipAsync(string id, string relationshipId, object relationship = null, CreateRelationshipOptions digitalTwinsAddRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        private Response<object> AddRelationship(string id, string relationshipId, object relationship = null, CreateRelationshipOptions digitalTwinsAddRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> UpdateRelationshipAsync(string id, string relationshipId, IEnumerable<object> patchDocument, UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateRelationship(string id, string relationshipId, IEnumerable<object> patchDocument, UpdateRelationshipOptions digitalTwinsUpdateRelationshipOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> UpdateComponentAsync(string id, string componentPath, IEnumerable<object> patchDocument, UpdateComponentOptions digitalTwinsUpdateComponentOptions = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateComponent(string id, string componentPath, IEnumerable<object> patchDocument, UpdateComponentOptions digitalTwinsUpdateComponentOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object SendTelemetryAsync(string id, string dtId, object telemetry, string dtTimestamp = null, PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private Response SendTelemetry(string id, string dtId, object telemetry, string dtTimestamp = null, PublishTelemetryOptions digitalTwinsSendTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> SendComponentTelemetryAsync(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private Response SendComponentTelemetry(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, PublishComponentTelemetryOptions digitalTwinsSendComponentTelemetryOptions = null, CancellationToken cancellationToken = default) => null;

        private HttpMessage CreateAddRequest(string id, object twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null) => null;

#pragma warning restore CA1801, IDE0051, IDE0060 // Remove unused parameter

        #endregion null overrides
    }
}
