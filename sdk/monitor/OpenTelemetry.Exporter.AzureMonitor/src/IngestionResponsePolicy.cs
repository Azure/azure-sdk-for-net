// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor
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
                case 200:
                    itemsAccepted = telemetryItems.Count();
                    break;
                case 400:
                case 429:
                case 439:
                    // Parse retry-after header
                    // Send Messages To Storage
                    break;
                case 500:
                case 502:
                case 503:
                case 504:
                    // Send Messages To Storage
                    break;
                case 206:
                    // Parse retry-after header
                    // Send Failed Messages To Storage
                    break;
                case null:
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
                case 200:
                    itemsAccepted = GetItemsAccepted(message);
                    break;
                case 429:
                case 439:
                case 500:
                case 502:
                case 503:
                case 504:
                case null:
                    itemsAccepted = 0;
                    // Request body is already in storage. No need to store again.
                    break;
                case 206:
                    // Send Failed Messages To Storage
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