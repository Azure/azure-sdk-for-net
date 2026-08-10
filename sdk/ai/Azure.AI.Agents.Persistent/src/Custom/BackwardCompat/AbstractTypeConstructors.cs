// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Backward-compat shims: restore protected constructors that existed in the GA 1.0.0 contract.
// The new emitter uses private protected constructors with a type discriminator parameter;
// these shims provide the parameterless protected constructors consumers may depend on.
// [CodeGenSuppress] is used to suppress the generated private protected parameterless ctors
// so we can replace them with protected ones.

// This file intentionally groups the small backward-compatibility partial declarations for many
// types; splitting them into one file per type would obscure that they are a single cohesive shim.
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("MessageContent")]
    public abstract partial class MessageContent
    {
        /// <summary> Initializes a new instance of the <see cref="MessageContent"/> class for deserialization. </summary>
        protected MessageContent() : this((string)null) { }
    }

    [CodeGenSuppress("MessageInputContentBlock")]
    public abstract partial class MessageInputContentBlock
    {
        /// <summary> Initializes a new instance of the <see cref="MessageInputContentBlock"/> class for deserialization. </summary>
        protected MessageInputContentBlock() : this(default(MessageBlockType)) { }
    }

    [CodeGenSuppress("OpenApiAuthDetails")]
    public abstract partial class OpenApiAuthDetails
    {
        /// <summary> Initializes a new instance of the <see cref="OpenApiAuthDetails"/> class for deserialization. </summary>
        protected OpenApiAuthDetails() : this(default(OpenApiAuthType)) { }
    }

    [CodeGenSuppress("RequiredAction")]
    public abstract partial class RequiredAction
    {
        /// <summary> Initializes a new instance of the <see cref="RequiredAction"/> class for deserialization. </summary>
        protected RequiredAction() : this((string)null) { }
    }

    [CodeGenSuppress("RequiredToolCall")]
    public abstract partial class RequiredToolCall
    {
        /// <summary> Initializes a new instance of the <see cref="RequiredToolCall"/> class for deserialization. </summary>
        protected RequiredToolCall() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepCodeInterpreterToolCallOutput")]
    public abstract partial class RunStepCodeInterpreterToolCallOutput
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepCodeInterpreterToolCallOutput"/> class for deserialization. </summary>
        protected RunStepCodeInterpreterToolCallOutput() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepDeltaDetail")]
    public abstract partial class RunStepDeltaDetail
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepDeltaDetail"/> class for deserialization. </summary>
        protected RunStepDeltaDetail() : this((string)null) { }
    }

    [CodeGenSuppress("RunStepDetails")]
    public abstract partial class RunStepDetails
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepDetails"/> class for deserialization. </summary>
        protected RunStepDetails() : this(default(RunStepType)) { }
    }

    [CodeGenSuppress("ToolDefinition")]
    public abstract partial class ToolDefinition
    {
        /// <summary> Initializes a new instance of the <see cref="ToolDefinition"/> class for deserialization. </summary>
        protected ToolDefinition() : this((string)null) { }
    }

    [CodeGenSuppress("VectorStoreChunkingStrategy")]
    public abstract partial class VectorStoreChunkingStrategy
    {
        /// <summary> Initializes a new instance of the <see cref="VectorStoreChunkingStrategy"/> class for deserialization. </summary>
        protected VectorStoreChunkingStrategy() : this(default(VectorStoreChunkingStrategyRequestType)) { }
    }

    [CodeGenSuppress("VectorStoreChunkingStrategyResponse")]
    public abstract partial class VectorStoreChunkingStrategyResponse
    {
        /// <summary> Initializes a new instance of the <see cref="VectorStoreChunkingStrategyResponse"/> class for deserialization. </summary>
        protected VectorStoreChunkingStrategyResponse() : this(default(VectorStoreChunkingStrategyResponseType)) { }
    }

    // Types below already have correct protected constructors in the generated code
    // but needed backward-compat overloads with fewer parameters.

    public abstract partial class MessageDeltaContent
    {
        /// <summary> Initializes a new instance of the <see cref="MessageDeltaContent"/> class. </summary>
        /// <param name="index"> The index of the content part in the message. </param>
        protected MessageDeltaContent(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageDeltaTextAnnotation
    {
        /// <summary> Initializes a new instance of the <see cref="MessageDeltaTextAnnotation"/> class. </summary>
        /// <param name="index"> The index of the annotation in the text content. </param>
        protected MessageDeltaTextAnnotation(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageTextAnnotation
    {
        /// <summary> Initializes a new instance of the <see cref="MessageTextAnnotation"/> class. </summary>
        /// <param name="text"> The text in the message content that should be replaced. </param>
        protected MessageTextAnnotation(string text) : this((string)null, text) { }
    }

    public abstract partial class RunStepDeltaCodeInterpreterOutput
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepDeltaCodeInterpreterOutput"/> class. </summary>
        /// <param name="index"> The index of the output in the tool call outputs list. </param>
        protected RunStepDeltaCodeInterpreterOutput(int index) : this(index, (string)null) { }
    }

    public abstract partial class RunStepDeltaToolCall
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepDeltaToolCall"/> class. </summary>
        /// <param name="index"> The index of the tool call in the tool calls list. </param>
        /// <param name="id"> The identifier of the tool call. </param>
        protected RunStepDeltaToolCall(int index, string id) : this(index, id, (string)null) { }
    }

    public abstract partial class RunStepToolCall
    {
        /// <summary> Initializes a new instance of the <see cref="RunStepToolCall"/> class. </summary>
        /// <param name="id"> The identifier of the tool call. </param>
        protected RunStepToolCall(string id) : this((string)null, id) { }
    }
}
