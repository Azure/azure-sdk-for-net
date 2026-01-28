// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Converters
{
    /// <summary>
    /// Provides helper methods for Human-In-The-Loop (HITL) processing.
    /// </summary>
    public static class HumanInTheLoopHelper
    {
        private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;

        /// <summary>
        /// Convert a HITL request to an ItemResource
        /// </summary>
        /// <param name="content">The FunctionApprovalRequestContent to convert.</param>
        /// <param name="id">The ID for the resource.</param>
        /// <param name="createdBy">Optional information about the creator of the item.</param>
        /// <returns>An ItemResource representing the HITL request.</returns>
        public static FunctionToolCallItemResource ToHumanInTheLoopFunctionCallItemResource(
            this FunctionApprovalRequestContent content,
            string id,
            CreatedBy? createdBy = null)
        {
            return new FunctionToolCallItemResource(
                type: ItemType.FunctionCall,
                id: id,
                createdBy: createdBy,
                serializedAdditionalRawData: null,
                status: FunctionToolCallItemResourceStatus.InProgress,
                callId: content.FunctionCall.CallId,
                name: ResponsesExtensions.HumanInTheLoopFunctionName,
                arguments: JsonSerializer.Serialize(content.FunctionCall, Json)
                );
        }
    }
}
