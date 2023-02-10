// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> This customizes how the service calls LUIS Generally Available projects. </summary>
    public partial class LuisCallingOptions
    {
        /// <summary> Initializes a new instance of LuisCallingOptions. </summary>
        public LuisCallingOptions()
        {
        }

        /// <summary> Enable verbose response. </summary>
        public bool? Verbose { get; set; }
        /// <summary> Save log to add in training utterances later. </summary>
        public bool? Log { get; set; }
        /// <summary> Set true to show all intents. </summary>
        public bool? ShowAllIntents { get; set; }
        /// <summary> The timezone offset for the location of the request. </summary>
        public float? TimezoneOffset { get; set; }
        /// <summary> Enable spell checking. </summary>
        public bool? SpellCheck { get; set; }
        /// <summary> The subscription key to use when enabling Bing spell check. </summary>
        public string BingSpellCheckSubscriptionKey { get; set; }
    }
}
