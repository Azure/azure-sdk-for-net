// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// The approval required for the tool.
    /// </summary>
    public partial class FabricIQPreviewToolRequireApprovalChoice
{
        /// <summary>
        /// The approval choce.
        /// </summary>
        public string ApprovalString { get; }

        /// <summary>
        /// Constraint applied to the ability of the model to call tools.
        /// </summary>
        public global::OpenAI.Responses.McpToolCallApprovalPolicy ApprovalPolicy { get; }

    /// <summary>
    /// Creates an options class with a fixed number of tokens.
    /// </summary>
    /// <param name="approvalPolicy">The approval policy for the tool.</param>
    public FabricIQPreviewToolRequireApprovalChoice(global::OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy)
        {
            ApprovalPolicy = approvalPolicy;
        }

        /// <summary>
        /// Creates an options class with single tool name.
        /// </summary>
        /// <param name="approvalChoice">The approval choice for the tool.</param>
        public FabricIQPreviewToolRequireApprovalChoice(string approvalChoice)
        {
            ApprovalString = approvalChoice;
        }

        internal FabricIQPreviewToolRequireApprovalChoice() { }

        /// <summary>
        /// Creates a ToolChoiceOption class from an integer value.
        /// </summary>
        /// <param name="approvalChoice">The approval choice for the tool.</param>
        public static implicit operator FabricIQPreviewToolRequireApprovalChoice(string approvalChoice)
            => new(approvalChoice);

        /// <summary>
        /// Creates a FabricIQPreviewToolRequireApprovalChoice class from an integer value.
        /// </summary>
        /// <param name="approvalPolicy">The approval policy for the tool.</param>
        public static implicit operator FabricIQPreviewToolRequireApprovalChoice(global::OpenAI.Responses.McpToolCallApprovalPolicy approvalPolicy)
            => new(approvalPolicy);
    }
}
