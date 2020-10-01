// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core.Serialization
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The ModelProperties dictionary on <see cref="ComponentMetadata"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A writable property is one that the service may request a change for from the device.
    /// </para>
    /// <para>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </para>
    /// </remarks>
    public class WritableProperty
    {
        /// <summary>
        /// The desired value.
        /// </summary>
        [JsonPropertyName("desiredValue")]
        public object DesiredValue { get; set; }

        /// <summary>
        /// The version of the property with the specified desired value.
        /// </summary>
        [JsonPropertyName("desiredVersion")]
        public int DesiredVersion { get; set; }

        /// <summary>
        /// The version of the reported property value.
        /// </summary>
        [JsonPropertyName("ackVersion")]
        public int AckVersion { get; set; }

        /// <summary>
        /// The response code of the property update request, usually an HTTP Status Code (e.g. 200).
        /// </summary>
        [JsonPropertyName("ackCode")]
        public int AckCode { get; set; }

        /// <summary>
        /// The message response of the property update request.
        /// </summary>
        [JsonPropertyName("ackDescription")]
        public string AckDescription { get; set; }
    }
}
