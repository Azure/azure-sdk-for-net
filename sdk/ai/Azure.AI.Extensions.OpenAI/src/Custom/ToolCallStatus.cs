// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary> The status of a tool call. </summary>{
    [CodeGenType("ToolCallStatus")]
    public enum ToolCallStatus
    {
        /// <summary> InProgress. </summary>
        InProgress,
        /// <summary> Completed. </summary>
        Completed,
        /// <summary> Incomplete. </summary>
        Incomplete,
        /// <summary> Failed. </summary>
        Failed
    }
}
