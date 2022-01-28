// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class IngestionResponsePolicy : HttpPipelineSynchronousPolicy
    {
        private readonly AzureMonitorTransmitter transmitter;

        public IngestionResponsePolicy(AzureMonitorTransmitter transmitter)
        {
            this.transmitter = transmitter;
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
            base.OnReceivedResponse(message);

            int itemsAccepted;

            if (message.TryGetProperty("TelemetryItemCount", out var telemetryItemCount))
            {
                itemsAccepted = this.ParseResponse(message, (int)telemetryItemCount);
            }
            else
            {
                itemsAccepted = this.ParseResponse(message);
            }

            message.SetProperty("ItemsAccepted", itemsAccepted);
        }

        internal int ParseResponse(HttpMessage message, int telemetryItemCount = 0)
        {
            var httpStatus = message?.Response?.Status;
            int itemsAccepted = 0;

            switch (httpStatus)
            {
                case ResponseStatusCodes.Success:
                    itemsAccepted = telemetryItemCount == 0 ? HttpPipelineHelper.GetItemsAccepted(message) : telemetryItemCount;
                    break;
                case ResponseStatusCodes.PartialSuccess:
                    // Parse retry-after header
                    // Send Failed Messages To Storage
                    itemsAccepted = HttpPipelineHelper.SavePartialTelemetryToStorage(this.transmitter.storage, message);
                    break;
                case ResponseStatusCodes.RequestTimeout:
                case ResponseStatusCodes.ResponseCodeTooManyRequests:
                case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    // Parse retry-after header
                    // Send Messages To Storage
                    HttpPipelineHelper.SaveTelemetryToStorage(this.transmitter.storage, message, true);
                    break;
                case ResponseStatusCodes.InternalServerError:
                case ResponseStatusCodes.BadGateway:
                case ResponseStatusCodes.ServiceUnavailable:
                case ResponseStatusCodes.GatewayTimeout:
                    // Send Messages To Storage
                    HttpPipelineHelper.SaveTelemetryToStorage(this.transmitter.storage, message);
                    break;
                case null: // UnknownNetworkError
                    // No HttpMessage. Send TelemetryItems To Storage
                    HttpPipelineHelper.SaveTelemetryToStorage(this.transmitter.storage, message);
                    break;
                default:
                    // Log Non-Retriable Status and don't retry or store;
                    break;
            }

            return itemsAccepted;
        }
    }
}
