// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Internal;

[CodeGenSuppress(nameof(OutputItemLocalShellToolCall))]
[CodeGenSuppress(nameof(OutputItemLocalShellToolCall), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(LocalShellExecAction), typeof(InputItemLocalShellToolCallStatus), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemLocalShellToolCall
{
    internal OutputItemLocalShellToolCall() : base("local_shell_call")
    {
    }
}

[CodeGenSuppress(nameof(OutputItemLocalShellToolCallOutput))]
[CodeGenSuppress(nameof(OutputItemLocalShellToolCallOutput), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(InputItemLocalShellToolCallOutputStatus?), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemLocalShellToolCallOutput
{
    internal OutputItemLocalShellToolCallOutput() : base("local_shell_call_output")
    {
    }

    internal OutputItemLocalShellToolCallOutput(ResponseItemKind type, string id, AgentReference agentReference, string responseId, string output, InputItemLocalShellToolCallOutputStatus? status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}

[CodeGenSuppress(nameof(OutputItemCompactionBody))]
[CodeGenSuppress(nameof(OutputItemCompactionBody), typeof(ResponseItemKind), typeof(string), typeof(AgentReference), typeof(string), typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>))]
public partial class OutputItemCompactionBody
{
    internal OutputItemCompactionBody() : base("compaction")
    {
    }

    internal OutputItemCompactionBody(ResponseItemKind type, string id, AgentReference agentReference, string responseId, string encryptedContent, string createdBy, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(type)
    {
        EncryptedContent = encryptedContent;
        CreatedBy = createdBy;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
