// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Models;

public abstract partial class ResponseStreamEvent
{
    /// <summary> Gets the SequenceNumber. </summary>
    public virtual long SequenceNumber { get; set; }
}
