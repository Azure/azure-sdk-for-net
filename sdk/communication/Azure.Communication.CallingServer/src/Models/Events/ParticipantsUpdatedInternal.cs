// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The participants updated event internal.
    /// </summary>
    [CodeGenModel("ParticipantsUpdatedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class ParticipantsUpdatedInternal
    {
        /// <summary> Gets the Event type. </summary>
        [CodeGenMember("Type")]
        public AcsEventType EventType { get; }
    }
}
