// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class IngestionResponsePolicy : HttpPipelineSynchronousPolicy
    {
        public override void OnReceivedResponse(HttpMessage message)
        {
            base.OnReceivedResponse(message);

            int itemsAccepted;

            if (message.TryGetProperty("TelemetryItems", out var telemetryItems))
            {
                itemsAccepted = ParseResponse(message, (IEnumerable<TelemetryItem>)telemetryItems);
            }
            else
            {
                itemsAccepted = ParseResponse(message);
            }

            message.SetProperty("ItemsAccepted", itemsAccepted);
        }

        internal static int ParseResponse(HttpMessage message, IEnumerable<TelemetryItem> telemetryItems)
        {
            var httpStatus = message?.Response?.Status;
            int itemsAccepted = 0;

            switch (httpStatus)
            {
                case ResponseStatusCodes.Success:
                    itemsAccepted = telemetryItems.Count();
                    break;
                case ResponseStatusCodes.PartialSuccess:
                    // Parse retry-after header
                    // Send Failed Messages To Storage
                    break;
                case ResponseStatusCodes.RequestTimeout:
                case ResponseStatusCodes.ResponseCodeTooManyRequests:
                case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    // Parse retry-after header
                    // Send Messages To Storage
                    break;
                case ResponseStatusCodes.InternalServerError:
                case ResponseStatusCodes.BadGateway:
                case ResponseStatusCodes.ServiceUnavailable:
                case ResponseStatusCodes.GatewayTimeout:
                    // Send Messages To Storage
                    break;
                case null: // UnknownNetworkError
                    // No HttpMessage. Send TelemetryItems To Storage
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
