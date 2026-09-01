// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using OpenAI;

namespace Azure.AI.Projects.Agents;

public partial class VoiceResponse
{
    // The base VoiceResponseBase-derived contract already declares these
    // members and is where the values are actually populated during deserialization (the wire
    // property names collide with the ones re-declared directly on this model, so the generated
    // constructor parameters below are never populated from JSON). The setters exist only so the
    // generated constructors compile; reads always defer to the correctly-populated base value.

    /// <summary> The unique id of the response. </summary>
    public new string Id
    {
        get => base.Id;
        private set { }
    }

    /// <summary> The id of the conversation this response belongs to. </summary>
    public new string ConversationId
    {
        get => base.ConversationId;
        private set { }
    }

    /// <summary> The output modalities used for the response, e.g. `["text", "audio"]`. Audio output always includes a text transcript. </summary>
    public new IList<VoiceResponseBaseOutputModality> OutputModalities
    {
        get => base.OutputModalities;
        private set { }
    }
}
