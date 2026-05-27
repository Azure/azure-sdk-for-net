// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Backward-compat shims: restore protected constructors that existed in the GA 1.0.0 contract.
// The new emitter uses private protected constructors with a type discriminator parameter;
// these shims provide the parameterless protected constructors consumers may depend on.
// [CodeGenSuppress] is used to suppress the generated private protected parameterless ctors
// so we can replace them with protected ones.

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("MessageContent")]
    public abstract partial class MessageContent
    {
        protected MessageContent() : this((string)null) { }
    }

    [CodeGenSuppress("MessageInputContentBlock")]
    public abstract partial class MessageInputContentBlock
    {
        protected MessageInputContentBlock() : this(default(MessageBlockType)) { }
    }

    [CodeGenSuppress("OpenApiAuthDetails")]
    public abstract partial class OpenApiAuthDetails
    {
        protected OpenApiAuthDetails() : this(default(OpenApiAuthType)) { }
    }

    [CodeGenSuppress("RequiredAction")]
    public abstract partial class RequiredAction
    {
        protected RequiredAction() : this((string)null) { }
    }

    [CodeGenSuppress("RequiredToolCall")]
    public abstract partial class RequiredToolCall
    {
        protected RequiredToolCall() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepCodeInterpreterToolCallOutput")]
    public abstract partial class RunStepCodeInterpreterToolCallOutput
    {
        protected RunStepCodeInterpreterToolCallOutput() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepDeltaDetail")]
    public abstract partial class RunStepDeltaDetail
    {
        protected RunStepDeltaDetail() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepDetails")]
    public abstract partial class RunStepDetails
    {
        protected RunStepDetails() : this(default(RunStepType)) { }
    }

    [CodeGenSuppress("ToolDefinition")]
    public abstract partial class ToolDefinition
    {
        protected ToolDefinition() : this((string)null) { }
    }

    [CodeGenSuppress("VectorStoreChunkingStrategy")]
    public abstract partial class VectorStoreChunkingStrategy
    {
        protected VectorStoreChunkingStrategy() : this(default(VectorStoreChunkingStrategyRequestType)) { }
    }

    [CodeGenSuppress("VectorStoreChunkingStrategyResponse")]
    public abstract partial class VectorStoreChunkingStrategyResponse
    {
        protected VectorStoreChunkingStrategyResponse() : this(default(VectorStoreChunkingStrategyResponseType)) { }
    }

    // Types below already have correct protected constructors in the generated code
    // but needed backward-compat overloads with fewer parameters.

    public abstract partial class MessageDeltaContent
    {
        protected MessageDeltaContent(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageDeltaTextAnnotation
    {
        protected MessageDeltaTextAnnotation(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageTextAnnotation
    {
        protected MessageTextAnnotation(string text) : this((string)null, text) { }
    }

    public abstract partial class RunStepDeltaCodeInterpreterOutput
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) : this(index, (string)null) { }
    }

    public abstract partial class RunStepDeltaToolCall
    {
        protected RunStepDeltaToolCall(int index, string id) : this(index, id, (string)null) { }
    }

    public abstract partial class RunStepToolCall
    {
        protected RunStepToolCall(string id) : this((string)null, id) { }
    }
}
