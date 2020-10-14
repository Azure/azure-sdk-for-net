// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
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

        internal HttpMessage CreateAddRequest(string id, string twin, CreateDigitalTwinOptions digitalTwinsAddOptions)
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
            if (digitalTwinsAddOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsAddOptions.Traceparent);
            }
            if (digitalTwinsAddOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsAddOptions.Tracestate);
            }
            request.Headers.Add("If-None-Match", "*");
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            var content = new StringRequestContent(twin);
            request.Content = content;
            return message;
        }

        internal async Task<Response<string>> AddAsync(string id, string twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default)
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
                    case 202:
                        {
                            string value = default;
                            using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
                    case 201:
                        return Response.FromValue<string>(null, message.Response);

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

        internal Response<string> Add(string id, string twin, CreateDigitalTwinOptions digitalTwinsAddOptions = null, CancellationToken cancellationToken = default)
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
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                    case 202:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
                    case 201:
                        return Response.FromValue<string>(null, message.Response);

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

        internal async Task<Response<string>> GetByIdAsync(string id, GetDigitalTwinOptions digitalTwinsGetByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetByIdRequest(id, digitalTwinsGetByIdOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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

        internal Response<string> GetById(string id, GetDigitalTwinOptions digitalTwinsGetByIdOptions = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetByIdRequest(id, digitalTwinsGetByIdOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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

        internal async Task<Response<string>> GetRelationshipByIdAsync(
            string id,
            string relationshipId,
            GetRelationshipOptions digitalTwinsGetRelationshipByIdOptions = null,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetRelationshipById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRelationshipByIdRequest(id, relationshipId, digitalTwinsGetRelationshipByIdOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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

        internal Response<string> GetRelationshipById(
            string id,
            string relationshipId,
            GetRelationshipOptions digitalTwinsGetRelationshipByIdOptions = null,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetRelationshipById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRelationshipByIdRequest(id, relationshipId, digitalTwinsGetRelationshipByIdOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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

        internal async Task<Response<string>> AddRelationshipAsync(
            string id,
            string relationshipId,
            string relationship,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.AddRelationship");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddRelationshipRequest(id, relationshipId, relationship, digitalTwinsAddRelationshipOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
                    case 204:
                        return Response.FromValue<string>(null, message.Response);

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

        internal Response<string> AddRelationship(
            string id,
            string relationshipId,
            string relationship,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.AddRelationship");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAddRelationshipRequest(id, relationshipId, relationship, digitalTwinsAddRelationshipOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
                    case 204:
                        return Response.FromValue<string>(null, message.Response);

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

        internal async Task<Response<string>> GetComponentAsync(
            string id,
            string componentPath,
            GetComponentOptions digitalTwinsGetComponentOptions = null,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetComponent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComponentRequest(id, componentPath, digitalTwinsGetComponentOptions);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using JsonDocument document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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

        internal Response<string> GetComponent(
            string id,
            string componentPath,
            GetComponentOptions digitalTwinsGetComponentOptions = null,
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetComponent");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetComponentRequest(id, componentPath, digitalTwinsGetComponentOptions);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            string value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = document.RootElement.GetRawText();
                            return Response.FromValue(value, message.Response);
                        }
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
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsUpdateOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsUpdateOptions.Traceparent);
            }
            if (digitalTwinsUpdateOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsUpdateOptions.Tracestate);
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
            string relationship,
            CreateRelationshipOptions digitalTwinsAddRelationshipOptions)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (digitalTwinsAddRelationshipOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsAddRelationshipOptions.Traceparent);
            }
            if (digitalTwinsAddRelationshipOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsAddRelationshipOptions.Tracestate);
            }
            request.Headers.Add("If-None-Match", "*");
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(relationship);
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
            if (digitalTwinsUpdateRelationshipOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsUpdateRelationshipOptions.Traceparent);
            }
            if (digitalTwinsUpdateRelationshipOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsUpdateRelationshipOptions.Tracestate);
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
            if (digitalTwinsUpdateComponentOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsUpdateComponentOptions.Traceparent);
            }
            if (digitalTwinsUpdateComponentOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsUpdateComponentOptions.Tracestate);
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
            if (digitalTwinsSendTelemetryOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsSendTelemetryOptions.Traceparent);
            }
            if (digitalTwinsSendTelemetryOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsSendTelemetryOptions.Tracestate);
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
            if (digitalTwinsSendComponentTelemetryOptions?.Traceparent != null)
            {
                request.Headers.Add("traceparent", digitalTwinsSendComponentTelemetryOptions.Traceparent);
            }
            if (digitalTwinsSendComponentTelemetryOptions?.Tracestate != null)
            {
                request.Headers.Add("tracestate", digitalTwinsSendComponentTelemetryOptions.Tracestate);
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
