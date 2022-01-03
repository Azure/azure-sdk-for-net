// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Pipeline;

using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Extensions.Storage;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class IngestionResponsePolicy : HttpPipelineSynchronousPolicy
    {
        internal static IPersistentStorage storage;
        public IngestionResponsePolicy(IPersistentStorage persistentStorage)
        {
            storage = persistentStorage;
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            base.OnReceivedResponse(message);

            int itemsAccepted;

            if (message.TryGetProperty("TelemetryItemCount", out var telemetryItems))
            {
                itemsAccepted = ParseResponse(message, (int)telemetryItems);
            }
            else
            {
                itemsAccepted = ParseResponse(message, 0);
            }

            message.SetProperty("ItemsAccepted", itemsAccepted);
        }

        internal static int ParseResponse(HttpMessage message, int telemetryItems)
        {
            var httpStatus = message?.Response?.Status;
            int itemsAccepted = 0;
            int retryInterval = 0;
            byte[] requestContent;

            switch (httpStatus)
            {
                case ResponseStatusCodes.Success:
                    itemsAccepted = telemetryItems == 0 ? GetItemsAccepted(message) : telemetryItems;
                    break;
                case ResponseStatusCodes.PartialSuccess:
                    // Parse retry-after header
                    // Send Failed Messages To Storage
                    {
                        TrackResponse response = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream, default);
                        response = TrackResponse.DeserializeTrackResponse(document.RootElement);
                        requestContent = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                        var partialContent = HttpPipelineHelper.GetPartialContentFromBreeze(response, Encoding.UTF8.GetString(requestContent));
                        retryInterval = HttpPipelineHelper.GetRetryInterval(message);
                        storage.CreateBlob(Encoding.UTF8.GetBytes(partialContent), retryInterval);
                        itemsAccepted = response.ItemsAccepted.GetValueOrDefault();
                    }
                    break;
                case ResponseStatusCodes.RequestTimeout:
                case ResponseStatusCodes.ResponseCodeTooManyRequests:
                case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    // Parse retry-after header
                    // Send Messages To Storage
                    retryInterval = HttpPipelineHelper.GetRetryInterval(message);
                    requestContent = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                    storage.CreateBlob(requestContent, retryInterval);
                    break;
                case ResponseStatusCodes.InternalServerError:
                case ResponseStatusCodes.BadGateway:
                case ResponseStatusCodes.ServiceUnavailable:
                case ResponseStatusCodes.GatewayTimeout:
                    // Send Messages To Storage
                    requestContent = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                    storage.CreateBlob(requestContent, HttpPipelineHelper.MinimumRetryInterval);
                    break;
                case null: // UnknownNetworkError
                    // No HttpMessage. Send TelemetryItems To Storage
                    requestContent = HttpPipelineHelper.GetRequestContent(message.Request.Content);
                    storage.CreateBlob(requestContent, HttpPipelineHelper.MinimumRetryInterval);
                    break;
                default:
                    // Log Non-Retriable Status and don't retry or store;
                    break;
            }

            return itemsAccepted;
        }

        internal static int ParseResponse(HttpMessage message)
        {
            var httpStatus = message?.Response?.Status;
            int itemsAccepted = 0;

            switch (httpStatus)
            {
                case ResponseStatusCodes.Success:
                    itemsAccepted = GetItemsAccepted(message);
                    break;
                case ResponseStatusCodes.PartialSuccess:
                    // Send Failed Messages To Storage
                    break;
                case ResponseStatusCodes.RequestTimeout:
                case ResponseStatusCodes.ResponseCodeTooManyRequests:
                case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                case ResponseStatusCodes.InternalServerError:
                case ResponseStatusCodes.BadGateway:
                case ResponseStatusCodes.ServiceUnavailable:
                case ResponseStatusCodes.GatewayTimeout:
                case null: // UnknownNetworkError
                    itemsAccepted = 0;
                    // Request body is already in storage. No need to store again.
                    break;
                default:
                    // Log Non-Retriable Status and don't retry or store;
                    break;
            }

            return itemsAccepted;
        }

        internal static int GetItemsAccepted(HttpMessage message)
        {
            int itemsAccepted = 0;
            using (JsonDocument document = JsonDocument.Parse(message.Response.ContentStream, default))
            {
                var value = TrackResponse.DeserializeTrackResponse(document.RootElement);
                Response.FromValue(value, message.Response);
                itemsAccepted = value.ItemsAccepted.GetValueOrDefault();
            }

            return itemsAccepted;
        }
    }
}
