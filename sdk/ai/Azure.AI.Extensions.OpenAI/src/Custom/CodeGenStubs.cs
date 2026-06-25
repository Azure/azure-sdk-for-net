// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

global using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Extensions.OpenAI;

// Public type renames
[CodeGenType("WorkflowActionOutputItemStatus")] public readonly partial struct AgentWorkflowPreviewActionStatus { }
