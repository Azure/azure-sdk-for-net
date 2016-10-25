// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Rest.ClientRuntime.Tests.Resources
{
    [JsonObject("dateTest")]
    public class DateTestObject
    {
        [JsonProperty("d")]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime Date { get; set; }

        [JsonProperty("dt")]
        public DateTime DateTime { get; set; }

        [JsonProperty("dn")]
        public DateTime? DateNullable { get; set; }

        [JsonProperty("dtn")]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTime? DateTimeNullable { get; set; }
        
        [JsonProperty("dtoc")]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTimeOffset DateTimeOffsetWithConverter { get; set; }
        
        [JsonProperty("dtonc")]
        [JsonConverter(typeof(DateJsonConverter))]
        public DateTimeOffset? DateTimeOffsetNullableWithConverter { get; set; }

        [JsonProperty("dto")]
        public DateTimeOffset DateTimeOffset { get; set; }

        [JsonProperty("dton")]
        public DateTimeOffset? DateTimeOffsetNullable { get; set; }
    }
}
