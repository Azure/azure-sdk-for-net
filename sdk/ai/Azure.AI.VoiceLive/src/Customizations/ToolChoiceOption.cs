// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents constraints placed on tool calls made by the model.
    /// </summary>
    public partial class ToolChoiceOption
    {
        /// <summary>
        /// The name of a single function the model is allowed to call.
        /// </summary>
        public string FunctionName { get; }

        /// <summary>
        /// Constraint applied to the ability of the model to call tools.
        /// </summary>
        public ToolChoiceLiteral? ToolCallConstraint { get; }

        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="toolChoiceLiteral"></param>
        public ToolChoiceOption(ToolChoiceLiteral toolChoiceLiteral)
        {
            ToolCallConstraint = toolChoiceLiteral;
        }

        /// <summary>
        /// Creates an options class with single tool name.
        /// </summary>
        /// <param name="stringValue"></param>
        public ToolChoiceOption(string stringValue)
        {
            FunctionName = stringValue;
        }

        internal ToolChoiceOption() { }

        /// <summary>
        /// Creates a ToolChoiceOption class from an integer value.
        /// </summary>
        /// <param name="name">The name of the tool to be called.</param>
        public static implicit operator ToolChoiceOption(string name)
            => new(name);

        /// <summary>
        /// Creates a ToolChoiceOption class from an integer value.
        /// </summary>
        /// <param name="literal">Literal describing the tool constraints</param>
        public static implicit operator ToolChoiceOption(ToolChoiceLiteral literal)
            => new(literal);
    }
}
