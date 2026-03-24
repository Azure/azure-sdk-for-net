// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Agents.Persistent;

// Backward-compat shims: protected constructors that existed in version 1.0.0.
// The new generator uses private protected constructors, which makes these types
// effectively sealed to external consumers. Adding protected constructors restores
// the ability for external types to derive from them.

/// <summary> An abstract representation of a single item of thread message content. </summary>
[CodeGenSuppress("MessageContent")]
public abstract partial class MessageContent
{
    /// <summary> Initializes a new instance of <see cref="MessageContent"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MessageContent() : this(default(string))
    {
    }
}

/// <summary> The abstract base representation of a partial streamed message content. </summary>
public abstract partial class MessageDeltaContent
{
    /// <summary> Initializes a new instance of <see cref="MessageDeltaContent"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MessageDeltaContent(int index) : this(index, default)
    {
    }
}

/// <summary> The abstract base representation of a streamed text content annotation. </summary>
public abstract partial class MessageDeltaTextAnnotation
{
    /// <summary> Initializes a new instance of <see cref="MessageDeltaTextAnnotation"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MessageDeltaTextAnnotation(int index) : this(index, default)
    {
    }
}

/// <summary> An abstract representation of a single block of message input content. </summary>
[CodeGenSuppress("MessageInputContentBlock")]
public abstract partial class MessageInputContentBlock
{
    /// <summary> Initializes a new instance of <see cref="MessageInputContentBlock"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MessageInputContentBlock() : this(default(MessageBlockType))
    {
    }
}

/// <summary> An abstract representation of an annotation to text thread message content. </summary>
public abstract partial class MessageTextAnnotation
{
    /// <summary> Initializes a new instance of <see cref="MessageTextAnnotation"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected MessageTextAnnotation(string text) : this(default, text)
    {
    }
}

/// <summary> An abstract representation of authentication details for an OpenAPI tool definition. </summary>
[CodeGenSuppress("OpenApiAuthDetails")]
public abstract partial class OpenApiAuthDetails
{
    /// <summary> Initializes a new instance of <see cref="OpenApiAuthDetails"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected OpenApiAuthDetails() : this(default(OpenApiAuthType))
    {
    }
}

/// <summary> An abstract representation of a required action for a thread run to continue. </summary>
[CodeGenSuppress("RequiredAction")]
public abstract partial class RequiredAction
{
    /// <summary> Initializes a new instance of <see cref="RequiredAction"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RequiredAction() : this(default(string))
    {
    }
}

/// <summary> An abstract representation of code interpreter tool call output. </summary>
[CodeGenSuppress("RunStepCodeInterpreterToolCallOutput")]
public abstract partial class RunStepCodeInterpreterToolCallOutput
{
    /// <summary> Initializes a new instance of <see cref="RunStepCodeInterpreterToolCallOutput"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepCodeInterpreterToolCallOutput() : this(default(string))
    {
    }
}

/// <summary> An abstract representation of a streaming code interpreter tool call output. </summary>
public abstract partial class RunStepDeltaCodeInterpreterOutput
{
    /// <summary> Initializes a new instance of <see cref="RunStepDeltaCodeInterpreterOutput"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepDeltaCodeInterpreterOutput(int index) : this(index, default)
    {
    }
}

/// <summary> An abstract representation of the details for a run step delta. </summary>
[CodeGenSuppress("RunStepDeltaDetail")]
public abstract partial class RunStepDeltaDetail
{
    /// <summary> Initializes a new instance of <see cref="RunStepDeltaDetail"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepDeltaDetail() : this(default(string))
    {
    }
}

/// <summary> An abstract representation of a tool call within a streaming run step. </summary>
public abstract partial class RunStepDeltaToolCall
{
    /// <summary> Initializes a new instance of <see cref="RunStepDeltaToolCall"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepDeltaToolCall(int index, string id) : this(index, id, default)
    {
    }
}

/// <summary> An abstract representation of the details for a run step. </summary>
[CodeGenSuppress("RunStepDetails")]
public abstract partial class RunStepDetails
{
    /// <summary> Initializes a new instance of <see cref="RunStepDetails"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepDetails() : this(default(RunStepType))
    {
    }
}

/// <summary> An abstract representation of a tool call within a run step. </summary>
public abstract partial class RunStepToolCall
{
    /// <summary> Initializes a new instance of <see cref="RunStepToolCall"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected RunStepToolCall(string id) : this(default, id)
    {
    }
}

/// <summary> An abstract representation of an input tool definition for an agent. </summary>
[CodeGenSuppress("ToolDefinition")]
public abstract partial class ToolDefinition
{
    /// <summary> Initializes a new instance of <see cref="ToolDefinition"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected ToolDefinition() : this(default(string))
    {
    }
}

/// <summary> An abstract representation of a vector store chunking strategy. </summary>
[CodeGenSuppress("VectorStoreChunkingStrategy")]
public abstract partial class VectorStoreChunkingStrategy
{
    /// <summary> Initializes a new instance of <see cref="VectorStoreChunkingStrategy"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected VectorStoreChunkingStrategy() : this(default(VectorStoreChunkingStrategyRequestType))
    {
    }
}

/// <summary> An abstract representation of a vector store chunking strategy response. </summary>
[CodeGenSuppress("VectorStoreChunkingStrategyResponse")]
public abstract partial class VectorStoreChunkingStrategyResponse
{
    /// <summary> Initializes a new instance of <see cref="VectorStoreChunkingStrategyResponse"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected VectorStoreChunkingStrategyResponse() : this(default(VectorStoreChunkingStrategyResponseType))
    {
    }
}
