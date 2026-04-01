// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat shims: restore protected constructors that existed in the GA 1.0.0 contract.
// The new emitter uses private protected constructors; these shims maintain API compatibility.

namespace Azure.AI.Agents.Persistent
{
    // MessageContent — protected ctor provided by changing Generated serialization ctor from internal to protected.
    // MessageInputContentBlock — same.
    // OpenApiAuthDetails — same.
    // RequiredAction — same.
    // RunStepCodeInterpreterToolCallOutput — same.
    // RunStepDeltaDetail — same.

    public abstract partial class MessageDeltaContent
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected MessageDeltaContent(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageDeltaTextAnnotation
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected MessageDeltaTextAnnotation(int index) : this(index, (string)null) { }
    }

    public abstract partial class MessageTextAnnotation
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected MessageTextAnnotation(string text) : this((string)null, text) { }
    }

    public abstract partial class RunStepDeltaCodeInterpreterOutput
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected RunStepDeltaCodeInterpreterOutput(int index) : this(index, (string)null) { }
    }

    public abstract partial class RunStepDeltaToolCall
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected RunStepDeltaToolCall(int index, string id) : this(index, id, (string)null) { }
    }

    public abstract partial class RunStepDetails
    {
        // protected ctor provided by changing Generated serialization ctor from internal to protected.
    }

    public abstract partial class RunStepToolCall
    {
        /// <summary> Backward-compat protected constructor. </summary>
        protected RunStepToolCall(string id) : this((string)null, id) { }
    }

    public abstract partial class ToolDefinition
    {
        // protected ctor provided by changing Generated serialization ctor from internal to protected.
    }

    public abstract partial class VectorStoreChunkingStrategy
    {
        // protected ctor provided by changing Generated serialization ctor from internal to protected.
    }

    public abstract partial class VectorStoreChunkingStrategyResponse
    {
        // protected ctor provided by changing Generated serialization ctor from internal to protected.
    }
}
