// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents the require_approval configuration for an MCP server.
    /// Can be either a simple approval type ("never"/"always") applied to all tools,
    /// or a per-tool configuration specifying which tools always/never require approval.
    /// </summary>
    public partial class RequireApprovalOption
    {
        /// <summary>
        /// The approval type applied to all tools (e.g. "never" or "always").
        /// </summary>
        public MCPApprovalType? ApprovalType { get; }

        /// <summary>
        /// List of tool names that always require approval.
        /// Used in the per-tool approval configuration.
        /// </summary>
        public IList<string> AlwaysRequireApproval { get; }

        /// <summary>
        /// List of tool names that never require approval.
        /// Used in the per-tool approval configuration.
        /// </summary>
        public IList<string> NeverRequireApproval { get; }

        /// <summary>
        /// Creates an option that applies a single approval type to all tools.
        /// </summary>
        /// <param name="approvalType">The approval type ("never" or "always").</param>
        public RequireApprovalOption(MCPApprovalType approvalType)
        {
            ApprovalType = approvalType;
        }

        /// <summary>
        /// Creates a per-tool approval configuration.
        /// </summary>
        /// <param name="alwaysRequireApproval">Tool names that always require approval.</param>
        /// <param name="neverRequireApproval">Tool names that never require approval.</param>
        public RequireApprovalOption(IList<string> alwaysRequireApproval = null, IList<string> neverRequireApproval = null)
        {
            AlwaysRequireApproval = alwaysRequireApproval;
            NeverRequireApproval = neverRequireApproval;
        }

        internal RequireApprovalOption() { }

        /// <summary>
        /// Implicitly converts an <see cref="MCPApprovalType"/> to a <see cref="RequireApprovalOption"/>.
        /// </summary>
        /// <param name="approvalType">The approval type.</param>
        public static implicit operator RequireApprovalOption(MCPApprovalType approvalType)
            => new(approvalType);
    }
}
