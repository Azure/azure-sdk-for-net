// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.Json;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

namespace Azure.AI.AgentServer.AgentFramework.Converters
{
    /// <summary>
    /// Provides helper methods for Human-In-The-Loop (HITL) processing.
    /// </summary>
    public static class HumanInTheLoopExtentions
    {
        private static readonly JsonSerializerOptions Json = JsonExtensions.DefaultJsonSerializerOptions;

        private static readonly HashSet<string> ApprovalTerms = new(StringComparer.OrdinalIgnoreCase)
        {
            "yes",
            "true",
            "approve",
            "approved",
            "allow",
            "accept",
            "accepted",
            "ok",
            "okay",
            "confirm",
            "confirmed"
        };

        private static readonly HashSet<string> DenialTerms = new(StringComparer.OrdinalIgnoreCase)
        {
            "no",
            "false",
            "deny",
            "denied",
            "denie",
            "reject",
            "rejected",
            "decline",
            "declined",
            "refuse",
            "refused",
            "cancel",
            "cancelled"
        };

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
                callId: content.Id,
                name: ResponsesExtensions.HumanInTheLoopFunctionName,
                arguments: JsonSerializer.Serialize(content.FunctionCall, Json)
                );
        }

        /// <summary>
        /// Convert a MCP HITL request to an ItemResource
        /// </summary>
        /// <param name="content">MCP Tool approval request</param>
        /// <param name="id">The ID for the resource.</param>
        /// <param name="createdBy">Optional information about the creator of the item.</param>
        /// <returns>An ItemResource representing the HITL request.</returns>
        public static FunctionToolCallItemResource ToHumanInTheLoopFunctionCallItemResource(
            this McpServerToolApprovalRequestContent content,
            string id,
            CreatedBy? createdBy = null)
        {
            return new FunctionToolCallItemResource(
                type: ItemType.FunctionCall,
                id: id,
                createdBy: createdBy,
                serializedAdditionalRawData: null,
                status: FunctionToolCallItemResourceStatus.InProgress,
                callId: content.Id,
                name: ResponsesExtensions.HumanInTheLoopFunctionName,
                arguments: JsonSerializer.Serialize(content.ToolCall, Json)
                );
        }

        /// <summary>
        /// Filter FunctionApprovalRequestContents from an AgentThread's pending user input requests.
        /// </summary>
        /// <param name="agentThread">Thread messages of the conversation.</param>
        /// <returns>A dictionary with function call_id and FunctionApprovalRequests that are pending for approval.</returns>
        public static async Task<Dictionary<string, UserInputRequestContent>> GetPendingUserInputRequestContents(
            this AgentThread agentThread)
        {
            var res = new Dictionary<string, UserInputRequestContent>();
            if (agentThread == null || agentThread is not ChatClientAgentThread)
            {
                return res;
            }
            var chatClientAgentThread = (ChatClientAgentThread)agentThread;
            if (chatClientAgentThread.MessageStore == null)
            {
                return res;
            }

            var messages = await chatClientAgentThread.MessageStore.GetMessagesAsync().ConfigureAwait(false);
            foreach (var message in messages)
            {
                foreach (var content in message.Contents)
                {
                    if (content is UserInputRequestContent userRequestContent)
                    {
                        res[userRequestContent.Id] = userRequestContent;
                    }
                    else if (content is UserInputResponseContent userInputResponseContent)
                    {
                        // Remove the UserInputRequestContent that has been responded to
                        res.Remove(userInputResponseContent.Id);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Validate a HITL response and convert it to a ChatMessage
        /// </summary>
        /// <param name="request">CreateResponse request payload</param>
        /// <param name="pendingRequests">Dictionary of pending function approval requests</param>
        /// <returns>A ChatMessage representing the validated HITL response.</returns>
        public static List<ChatMessage>? ValidateAndConvertResponse(
            this CreateResponseRequest request,
            Dictionary<string, UserInputRequestContent>? pendingRequests)
        {
            if (pendingRequests == null || pendingRequests.Count == 0)
            {
                return null;
            }
            var items = request.Input.ToObject<IList<ItemParam>>();
            if (items == null || items.Count == 0)
            {
                return null;
            }
            var content = new List<AIContent>();
            foreach (var item in items)
            {
                if (item is FunctionToolCallOutputItemParam funcCallOutputItem)
                {
                    if (funcCallOutputItem.CallId != null &&
                        pendingRequests.TryGetValue(funcCallOutputItem.CallId, out var userInputRequest))
                    {
                        if (userInputRequest is FunctionApprovalRequestContent functionApprovalRequest)
                        {
                            var response = funcCallOutputItem.ConvertFunctionCallApprovalResponse(functionApprovalRequest);
                            if (response != null)
                            {
                                content.Add(response);
                                continue;
                            }
                        }
                        else if (userInputRequest is McpServerToolApprovalRequestContent mcpToolApprovalRequest)
                        {
                            var response = funcCallOutputItem.ConvertMcpToolApprovalResponse(mcpToolApprovalRequest);
                            if (response != null)
                            {
                                content.Add(response);
                                continue;
                            }
                        }
                        // It is not a FunctionApprovalRequestContent or parsing result failed
                        var functionCallOutput = new FunctionResultContent(userInputRequest.Id, funcCallOutputItem.Output);
                        content.Add(functionCallOutput);
                    }
                }
            }
            if (content.Count > 0)
            {
                return new List<ChatMessage> { new ChatMessage(ChatRole.User, content) };
            }
            return null;
        }

        /// <summary>
        /// Converts a function call output item and request content into an approval response content if parsing
        /// is successful; otherwise, returns null.
        /// </summary>
        /// <param name="funcCallOutputItem">function call output item parameter from user</param>
        /// <param name="requestContent">FunctionApprovalRequestContent that requesting input</param>
        /// <returns>FunctionApprovalResponseContent if the user input is parsed successfully. otherwise, null</returns>
        private static FunctionApprovalResponseContent? ConvertFunctionCallApprovalResponse(
                 this FunctionToolCallOutputItemParam funcCallOutputItem, FunctionApprovalRequestContent requestContent)
        {
            var parsed = TryParseApprovalResponse(funcCallOutputItem?.Output, out var approvalResult);
            if (parsed)
            {
                return requestContent.CreateResponse(approvalResult);
            }
            return null;
        }

        /// <summary>
        /// Converts a function tool call output item and request content into an approval response content if parsing
        /// is successful; otherwise, returns null.
        /// </summary>
        /// <param name="funcCallOutputItem">The function tool call output item to parse.</param>
        /// <param name="requestContent">The original approval request content.</param>
        /// <returns>An approval response content if parsing succeeds; otherwise, null.</returns>
        private static McpServerToolApprovalResponseContent? ConvertMcpToolApprovalResponse(
            this FunctionToolCallOutputItemParam funcCallOutputItem, McpServerToolApprovalRequestContent requestContent)
        {
            var parsed = TryParseApprovalResponse(funcCallOutputItem?.Output, out var approvalResult);
            if (parsed)
            {
                return requestContent.CreateResponse(approvalResult);
            }
            return null;
        }

        /// <summary>
        /// Tries to parse an input string to determine if it represents an approval or denial.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="isApproved">True if the input represents approval; false if it represents denial.</param>
        /// <returns>True if parsing was successful; false otherwise.</returns>
        public static bool TryParseApprovalResponse(string? input, out bool isApproved)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                isApproved = false;
                return true;
            }
            if (bool.TryParse(input, out isApproved))
            {
                return true;
            }

            // Normalize the input by trimming whitespace and removing trailing punctuation
            var normalized = input.Trim().TrimEnd('.', '!', '?');

            // Check approval terms first
            if (ApprovalTerms.Contains(normalized))
            {
                isApproved = true;
                return true;
            }

            // Check denial terms
            if (DenialTerms.Contains(normalized))
            {
                isApproved = false;
                return true;
            }

            // Unable to parse
            isApproved = false;
            return false;
        }
    }
}
