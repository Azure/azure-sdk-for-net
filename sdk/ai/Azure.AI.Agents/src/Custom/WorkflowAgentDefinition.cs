// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Agents;

[CodeGenType("WorkflowDefinition")]
public partial class WorkflowAgentDefinition
{
    [CodeGenMember("Trigger")]
    public BinaryData TriggerBytes { get; set; }
}
