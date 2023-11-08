// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class DirectMapRouterRule : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of DirectMapRouterRule. </summary>
        public DirectMapRouterRule()
        {
            Kind = "direct-map-rule";
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            writer.WriteEndObject();
        }
    }
}
