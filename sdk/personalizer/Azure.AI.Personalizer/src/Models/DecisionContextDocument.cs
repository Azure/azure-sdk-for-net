// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context Document. </summary>
    public class DecisionContextDocument
    {
        /// <summary>
        /// Supply _tag for online evaluation (VW/EvalOperation.cs)
        /// </summary>
        [JsonProperty("_tag", NullValueHandling = NullValueHandling.Ignore)]
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// Provide source set feature.
        /// </summary>
        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
        public DecisionContextDocumentSource Source { get; set; }

        /// <summary>
        /// Generic json features.
        /// </summary>
        [JsonProperty("j", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<string> JSON { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Keep as float[] arrays to improve marshalling speed.
        /// </summary>
        [JsonProperty("f", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, float[]> FloatFeatures { get; }

        /// <summary>
        /// Slot ID.
        /// </summary>
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        public string SlotId { get; set; }

        /// <summary>
        /// Generic slot json features.
        /// </summary>
        [JsonProperty("sj", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
        public List<string> SlotJson { get; }
    }
}
