// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Azure.AI.Personalizer
{
    /// <summary> The Decision Context. </summary>
    public class DecisionContext
    {
        /// <summary> The Decision Context. </summary>
        public DecisionContext()
        {
        }

        /// <summary> Initializes a new instance of DecisionContext. </summary>
        /// <param name="rankRequest"> Personalizer Rank Options </param>
        public DecisionContext(PersonalizerRankOptions rankRequest)
        {
            List<string> jsonFeatures = rankRequest.ContextFeatures.Select(f => JsonConvert.SerializeObject(f)).ToList();
            this.SharedFromUrl = jsonFeatures;

            this.Documents = rankRequest.Actions
                .Select(action =>
                {
                    string ids = null;
                    List<string> jsonFeatures = action.Features.Select(f => JsonConvert.SerializeObject(f)).ToList();

                    //if (action.Ids != null)
                    //{
                    //    ids = string.Join(",", action.Ids);
                    //}

                    var doc = new DecisionContextDocument
                    {
                        ID = ids,
                        JSON = jsonFeatures,
                    };

                    //if (action.ActionSet != null && action.ActionSet?.Id != null)
                    //    doc.Source = new DecisionContextDocumentSource
                    //    {
                    //        Set = action.ActionSet.Id.Id,
                    //        Parameter = action.ActionSet.Parameter
                    //    };

                    return doc;
                }).ToArray();

            //this.Slots = decisionRequest.Slots?
            //    .Select(slot => new DecisionContextDocument {
            //        SlotId = slot.Id,
            //        SlotJson = slot.JsonFeatures
            //    }).ToArray();
        }

        /// <summary> Properties from url </summary>
        [JsonProperty("FromUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonRawStringListConverter))]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<string> SharedFromUrl { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary> Properties of documents </summary>
        [JsonProperty("_multi")]
        public DecisionContextDocument[] Documents { get; set; }

        /// <summary> Properties of slots </summary>
        [JsonProperty("_slots", NullValueHandling = NullValueHandling.Ignore)]
        public DecisionContextDocument[] Slots { get; set; }
    }
}
