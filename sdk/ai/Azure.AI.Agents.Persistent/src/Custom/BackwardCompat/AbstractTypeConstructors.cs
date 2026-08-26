// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Backward-compat shims: restore constructors from the GA 1.0.0 contract that the current generator
// does not produce - the RequiredToolCall parameterless ctor and the reduced-arity ctors below.
// (Parameterless ctors on the other abstract types are now restored by the generator's Model
// Constructors back-compat, so their shims were removed.)

// This file intentionally groups the small backward-compatibility partial declarations for many
// types; splitting them into one file per type would obscure that they are a single cohesive shim.
#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.AI.Agents.Persistent
{
    [CodeGenSuppress("RequiredToolCall")]
    public abstract partial class RequiredToolCall
    {
        /// <summary> Initializes a new instance of the <see cref="RequiredToolCall"/> class for deserialization. </summary>
        protected RequiredToolCall() : this((string)null) { }
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
