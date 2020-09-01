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
        private const string IfMatchHeaderKey = "If-Match";

        internal HttpMessage CreateAddRequest(string id, string twin)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json; charset=utf-8");
            request.Content = new StringRequestContent(twin);
            return message;
        }

        internal async Task<Response<string>> AddAsync(string id, string twin, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateAddRequest(id, twin);
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

        internal Response<string> Add(string id, string twin, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateAddRequest(id, twin);
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

        internal async Task<Response<string>> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetByIdRequest(id);
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

        internal Response<string> GetById(string id, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.GetById");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetByIdRequest(id);
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

        internal async Task<Response<string>> UpdateAsync(string id, string patchDocument, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateRequest(id, patchDocument, ifMatch);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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

        internal Response<string> Update(string id, string patchDocument, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateRequest(id, patchDocument, ifMatch);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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

        internal async Task<Response<string>> GetRelationshipByIdAsync(string id, string relationshipId, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateGetRelationshipByIdRequest(id, relationshipId);
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

        internal Response<string> GetRelationshipById(string id, string relationshipId, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateGetRelationshipByIdRequest(id, relationshipId);
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

        internal async Task<Response<string>> AddRelationshipAsync(string id, string relationshipId, string relationship = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateAddRelationshipRequest(id, relationshipId, relationship);
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

        internal Response<string> AddRelationship(string id, string relationshipId, string relationship = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateAddRelationshipRequest(id, relationshipId, relationship);
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

        internal async Task<Response> UpdateRelationshipAsync(string id, string relationshipId, string patchDocument = null, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, ifMatch);
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

        internal Response UpdateRelationship(string id, string relationshipId, string patchDocument = null, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateRelationshipRequest(id, relationshipId, patchDocument, ifMatch);
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

        internal async Task<Response<string>> GetComponentAsync(string id, string componentPath, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateGetComponentRequest(id, componentPath);
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

        internal Response<string> GetComponent(string id, string componentPath, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateGetComponentRequest(id, componentPath);
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

        internal async Task<Response<string>> UpdateComponentAsync(string id, string componentPath, string patchDocument = null, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, ifMatch);
                await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 202:
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

        internal Response<string> UpdateComponent(string id, string componentPath, string patchDocument = null, string ifMatch = null, CancellationToken cancellationToken = default)
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
                using HttpMessage message = CreateUpdateComponentRequest(id, componentPath, patchDocument, ifMatch);
                _pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 202:
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

        internal async Task<Response> SendTelemetryAsync(string id, string dtId, string telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (dtId == null)
            {
                throw new ArgumentNullException(nameof(dtId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendTelemetryRequest(id, dtId, telemetry, dtTimestamp);
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

        internal Response SendTelemetry(string id, string dtId, string telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (dtId == null)
            {
                throw new ArgumentNullException(nameof(dtId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendTelemetryRequest(id, dtId, telemetry, dtTimestamp);
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

        internal async Task<Response> SendComponentTelemetryAsync(string id, string componentPath, string dtId, string telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }
            if (dtId == null)
            {
                throw new ArgumentNullException(nameof(dtId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendComponentTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, dtId, telemetry, dtTimestamp);
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

        internal Response SendComponentTelemetry(string id, string componentPath, string dtId, string telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (componentPath == null)
            {
                throw new ArgumentNullException(nameof(componentPath));
            }
            if (dtId == null)
            {
                throw new ArgumentNullException(nameof(dtId));
            }
            if (telemetry == null)
            {
                throw new ArgumentNullException(nameof(telemetry));
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("DigitalTwinsClient.SendComponentTelemetry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendComponentTelemetryRequest(id, componentPath, dtId, telemetry, dtTimestamp);
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

        internal HttpMessage CreateUpdateRequest(string id, string patchDocument, string ifMatch = null)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", apiVersion, true);
            if (ifMatch != null)
            {
                request.Headers.Add(IfMatchHeaderKey, ifMatch);
            }
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json; charset=utf-8");
            request.Headers.Add("Accept", "application/json");
            request.Content = new StringRequestContent(patchDocument);
            return message;
        }

        private HttpMessage CreateAddRelationshipRequest(string id, string relationshipId, string relationship)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json; charset=utf-8");
            request.Headers.Add("Accept", "application/json");
            if (relationship != null)
            {
                request.Content = new StringRequestContent(relationship);
            }
            return message;
        }

        private HttpMessage CreateUpdateRelationshipRequest(string id, string relationshipId, string patchDocument, string ifMatch = null)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/relationships/", false);
            uri.AppendPath(relationshipId, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json-patch+json; charset=utf-8");
            request.Headers.Add("Accept", "application/json");
            if (patchDocument != null)
            {
                request.Content = new StringRequestContent(patchDocument);
            }
            if (ifMatch != null)
            {
                request.Headers.Add(IfMatchHeaderKey, ifMatch);
            }
            return message;
        }

        private HttpMessage CreateUpdateComponentRequest(string id, string componentPath, string patchDocument, string ifMatch = null)
        {
            HttpMessage message = _pipeline.CreateMessage();
            Request request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/digitaltwins/", false);
            uri.AppendPath(id, true);
            uri.AppendPath("/components/", false);
            uri.AppendPath(componentPath, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Content-Type", "application/json-patch+json; charset=utf-8");
            request.Headers.Add("Accept", "application/json");
            if (ifMatch != null)
            {
                request.Headers.Add(IfMatchHeaderKey, ifMatch);
            }
            if (patchDocument != null)
            {
                request.Content = new StringRequestContent(patchDocument);
            }
            return message;
        }

        private HttpMessage CreateSendTelemetryRequest(string id, string dtId, string telemetry, string dtTimestamp)
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
            request.Headers.Add("dt-id", dtId);
            if (dtTimestamp != null)
            {
                request.Headers.Add("dt-timestamp", dtTimestamp);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            if (telemetry != null)
            {
                request.Content = new StringRequestContent(telemetry);
            }
            return message;
        }

        private HttpMessage CreateSendComponentTelemetryRequest(string id, string componentPath, string dtId, string telemetry, string dtTimestamp)
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
            request.Headers.Add("dt-id", dtId);
            if (dtTimestamp != null)
            {
                request.Headers.Add("dt-timestamp", dtTimestamp);
            }
            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Accept", "application/json");
            if (telemetry != null)
            {
                request.Content = new StringRequestContent(telemetry);
            }
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
        private object AddAsync(string id, object twin, CancellationToken cancellationToken = default) => null;

        private Response<object> Add(string id, object twin, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object UpdateAsync(string id, IEnumerable<object> patchDocument, string ifMatch = null, CancellationToken cancellationToken = default) => null;

        private Response Update(string id, IEnumerable<object> patchDocument, string ifMatch = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response<object>>. Changing to object to allow returning null.
        private object AddRelationshipAsync(string id, string relationshipId, object relationship = null, CancellationToken cancellationToken = default) => null;

        private Response<object> AddRelationship(string id, string relationshipId, object relationship = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object UpdateRelationshipAsync(string id, string relationshipId, string ifMatch = null, IEnumerable<object> patchDocument = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateRelationship(string id, string relationshipId, string ifMatch = null, IEnumerable<object> patchDocument = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object UpdateComponentAsync(string id, string componentPath, string ifMatch = null, IEnumerable<object> patchDocument = null, CancellationToken cancellationToken = default) => null;

        private Response UpdateComponent(string id, string componentPath, string ifMatch = null, IEnumerable<object> patchDocument = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private object SendTelemetryAsync(string id, string dtId, object telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default) => null;

        private Response SendTelemetry(string id, string dtId, object telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default) => null;

        // Original return type is Task<Response>. Changing to object to allow returning null.
        private Task<Response> SendComponentTelemetryAsync(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default) => null;

        private Response SendComponentTelemetry(string id, string componentPath, string dtId, object telemetry, string dtTimestamp = null, CancellationToken cancellationToken = default) => null;

        private HttpMessage CreateAddRequest(string id, object twin) => null;

#pragma warning restore CA1801, IDE0051, IDE0060 // Remove unused parameter
        #endregion
    }
}
