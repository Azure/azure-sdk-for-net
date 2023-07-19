// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Azure.DigitalTwins.Core.Tests
{
    public class SimpleNewtonsoftDtModel
    {
        [JsonProperty(DigitalTwinsJsonPropertyNames.DigitalTwinId)]
        public string Id { get; set; }
    }
}
