// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// The approval required for the tool.
    /// </summary>
    public partial class WebIQPreviewToolRequireApprovalChoice
    {
        /// <summary>
        /// The approval choice.
        /// </summary>
        public string ApprovalString { get; }

        /// <summary>
        /// Constraint applied to the ability of the model to call tools.
        /// </summary>
        [Experimental("OPENAI001")]
        public global::OpenAI.Responses.McpToolCallApprovalPolicy ApprovalPolicy { get; }

        /// <summary>
        /// Creates an options class with a fixed number of tokens.
        /// </summary>
        /// <param name="approvalPolicy">The approval policy for the tool.</param>
        [Experimental("OPENAI001")]
        public WebIQPreviewToolRequireApprovalChoice(global::OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy)
        {
            ApprovalPolicy = approvalPolicy;
        }

        /// <summary>
        /// Creates an options class with single tool name.
        /// </summary>
        /// <param name="approvalChoice">The approval choice for the tool.</param>
        public WebIQPreviewToolRequireApprovalChoice(string approvalChoice)
        {
            ApprovalString = approvalChoice;
        }

        internal WebIQPreviewToolRequireApprovalChoice() { }

        /// <summary>
        /// Creates a ToolChoiceOption class from an integer value.
        /// </summary>
        /// <param name="approvalChoice">The approval choice for the tool.</param>
        public static implicit operator WebIQPreviewToolRequireApprovalChoice(string approvalChoice)
            => new(approvalChoice);

        /// <summary>
        /// Creates a WebIQPreviewToolRequireApprovalChoice class from an integer value.
        /// </summary>
        /// <param name="approvalPolicy">The approval policy for the tool.</param>
        [Experimental("OPENAI001")]
#pragma warning disable OPENAI001
        public static implicit operator WebIQPreviewToolRequireApprovalChoice(global::OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy)
            => new(approvalPolicy);
#pragma warning restore OPENAI001
    }
}
