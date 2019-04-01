// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

namespace Microsoft.Azure.EventGrid.Tests
{
    class ContosoItemSentEventData
    {
        [JsonProperty(PropertyName = "shippingInfo")]
        public ShippingInfo ShippingInfo { get; set; }
    }

    class ShippingInfo
    {
        [JsonProperty(PropertyName = "shippingType")]
        public string ShippingType { get; set; }

        [JsonProperty(PropertyName = "shipmentId")]
        public string ShipmentId { get; set; }
    }

    [JsonObject("Drone")]
    class DroneShippingInfo : ShippingInfo
    {
        [JsonProperty(PropertyName = "droneId")]
        public string DroneId { get; set; }
    }

    [JsonObject("Rocket")]
    class RocketShippingInfo : ShippingInfo
    {
        [JsonProperty(PropertyName = "rocketNumber")]
        public int RocketNumber { get; set; }
    }
}
