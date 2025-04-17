// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//#nullable disable

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Azure.AI.Projects.OneDP;
//using Azure.Core;
//using Azure.Core.Pipeline;

//namespace Azure.AI.Projects
//{
//    /// <summary> The Agents sub-client. </summary>
//    [CodeGenClient("Agents")]
//    public partial class AgentsClient
//    {
//        /// <summary>
//        /// Creates a new agent with the specified display name, model ID, and instructions.
//        /// </summary>
//        /// <param name="displayName">The display name of the agent.</param>
//        /// <param name="modelId">The model ID to use for the agent.</param>
//        /// <param name="instructions">The instructions for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the created agent.</returns>
//        public virtual Response<Agent> CreateAgent(string displayName, string modelId, string instructions, CancellationToken cancellationToken = default)
//        {
//            // Create AgentConfigurationOptions
//            var agentConfigurationOptions = new AgentConfigurationOptions
//            {
//                AgentModel = new AzureAgentModel(modelId),
//                Instructions = instructions
//            };

//            // Create AgentCreationOptions
//            var agentCreationOptions = new AgentCreationOptions(displayName, agentConfigurationOptions);

//            // Call the existing CreateAgent method
//            return CreateAgent(agentCreationOptions, cancellationToken);
//        }

//        /// <summary>
//        /// Asynchronously creates a new agent with the specified display name, model ID, and instructions.
//        /// </summary>
//        /// <param name="displayName">The display name of the agent.</param>
//        /// <param name="modelId">The model ID to use for the agent.</param>
//        /// <param name="instructions">The instructions for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the created agent.</returns>
//        public virtual async Task<Response<Agent>> CreateAgentAsync(string displayName, string modelId, string instructions, CancellationToken cancellationToken = default)
//        {
//            // Create AgentConfigurationOptions
//            var agentConfigurationOptions = new AgentConfigurationOptions
//            {
//                AgentModel = new AzureAgentModel(modelId),
//                Instructions = instructions
//            };

//            // Create AgentCreationOptions
//            var agentCreationOptions = new AgentCreationOptions(displayName, agentConfigurationOptions);

//            // Call the existing CreateAgentAsync method
//            return await CreateAgentAsync(agentCreationOptions, cancellationToken).ConfigureAwait(false);
//        }

//        /// <summary>
//        /// Runs an agent with the specified model ID, instructions, and message.
//        /// </summary>
//        /// <param name="modelId">The model ID to use for the agent.</param>
//        /// <param name="instructions">The instructions for the agent.</param>
//        /// <param name="message">The input message for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the run result.</returns>
//        public virtual Response<Run> Run(string modelId, string instructions, string message, CancellationToken cancellationToken = default)
//        {
//            // Create AgentConfigurationOptions
//            var agentConfigurationOptions = new AgentConfigurationOptions
//            {
//                AgentModel = new AzureAgentModel(modelId),
//                Instructions = instructions
//            };

//            // Create RunInputs
//            var inputMessages = new List<ChatMessage>
//            {
//                new UserMessage(new List<AIContent>
//                {
//                    new TextContent(message)
//                })
//            };
//            var runInputs = new RunInputs(inputMessages);

//            // Call the existing Run method
//            return Run(agentConfigurationOptions, runInputs, cancellationToken);
//        }

//        /// <summary>
//        /// Asynchronously runs an agent with the specified model ID, instructions, and message.
//        /// </summary>
//        /// <param name="modelId">The model ID to use for the agent.</param>
//        /// <param name="instructions">The instructions for the agent.</param>
//        /// <param name="message">The input message for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the run result.</returns>
//        public virtual async Task<Response<Run>> RunAsync(string modelId, string instructions, string message, CancellationToken cancellationToken = default)
//        {
//            // Create AgentConfigurationOptions
//            var agentConfigurationOptions = new AgentConfigurationOptions
//            {
//                AgentModel = new AzureAgentModel(modelId),
//                Instructions = instructions
//            };

//            // Create RunInputs
//            var inputMessages = new List<ChatMessage>
//            {
//                new UserMessage(new List<AIContent>
//                {
//                    new TextContent(message)
//                })
//            };
//            var runInputs = new RunInputs(inputMessages);

//            // Call the existing RunAsync method
//            return await RunAsync(agentConfigurationOptions, runInputs, cancellationToken).ConfigureAwait(false);
//        }

//        /// <summary>
//        /// Runs an agent with the specified agent ID and message.
//        /// </summary>
//        /// <param name="agentId">The ID of the agent to use for the run.</param>
//        /// <param name="message">The input message for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the run result.</returns>
//        public virtual Response<Run> Run(string agentId, string message, CancellationToken cancellationToken = default)
//        {
//            // Create RunInputs
//            var inputMessages = new List<ChatMessage>
//            {
//                new UserMessage(new List<AIContent>
//                {
//                    new TextContent(message)
//                })
//            };
//            var runInputs = new RunInputs(agentId, inputMessages, null, null, null, null, null);

//            // Call the existing Run method
//            return Run(new AgentConfigurationOptions(), runInputs, cancellationToken);
//        }

//        /// <summary>
//        /// Asynchronously runs an agent with the specified agent ID and message.
//        /// </summary>
//        /// <param name="agentId">The ID of the agent to use for the run.</param>
//        /// <param name="message">The input message for the agent.</param>
//        /// <param name="cancellationToken">The cancellation token to use.</param>
//        /// <returns>The response containing the run result.</returns>
//        public virtual async Task<Response<Run>> RunAsync(string agentId, string message, CancellationToken cancellationToken = default)
//        {
//            // Create RunInputs
//            var inputMessages = new List<ChatMessage>
//            {
//                new UserMessage(new List<AIContent>
//                {
//                    new TextContent(message)
//                })
//            };
//            var runInputs = new RunInputs(agentId, inputMessages, null, null, null, null, null);

//            // Call the existing RunAsync method
//            return await RunAsync(new AgentConfigurationOptions(), runInputs, cancellationToken).ConfigureAwait(false);
//        }
//    }
//}
