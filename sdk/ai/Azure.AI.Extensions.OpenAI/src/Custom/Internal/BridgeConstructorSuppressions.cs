// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Internal;

[CodeGenSuppress(nameof(OutputItemLocalShellToolCall))]
[CodeGenSuppress(nameof(OutputItemLocalShellToolCall), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(OutputItemLocalShellToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemLocalShellToolCall
{
    internal OutputItemLocalShellToolCall() : base("local_shell_call")
    {
    }

    internal OutputItemLocalShellToolCall(ResponseItemKind type, string id, AgentReference agentReference, string responseId, string itemId, string callId, OutputItemLocalShellToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        ItemId = itemId;
        CallId = callId;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(OutputItemLocalShellToolCallOutput))]
[CodeGenSuppress(nameof(OutputItemLocalShellToolCallOutput), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(OutputItemLocalShellToolCallOutputStatus?), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemLocalShellToolCallOutput
{
    internal OutputItemLocalShellToolCallOutput() : base("local_shell_call_output")
    {
    }

    internal OutputItemLocalShellToolCallOutput(ResponseItemKind type, string id, AgentReference agentReference, string responseId, string itemId, string output, OutputItemLocalShellToolCallOutputStatus? status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        ItemId = itemId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(OutputItemCompactionBody))]
[CodeGenSuppress(nameof(OutputItemCompactionBody), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemCompactionBody
{
    internal OutputItemCompactionBody() : base("compaction")
    {
    }

    internal OutputItemCompactionBody(ResponseItemKind type, string id, AgentReference agentReference, string responseId, string itemId, string encryptedContent, string createdBy, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        ItemId = itemId;
        EncryptedContent = encryptedContent;
        CreatedBy = createdBy;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
