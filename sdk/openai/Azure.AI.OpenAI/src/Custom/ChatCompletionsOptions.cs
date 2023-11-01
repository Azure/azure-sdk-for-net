// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("ChatCompletionsOptions", typeof(IEnumerable<ChatMessage>))]
    public partial class ChatCompletionsOptions
    {
        /// <inheritdoc cref="CompletionsOptions.ChoicesPerPrompt"/>
        public int? ChoiceCount { get; set; }

        /// <summary>
        /// Gets or sets the deployment name to use for a chat completions request.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When making a request against Azure OpenAI, this should be the customizable name of the "model deployment"
        /// (example: my-gpt4-deployment) and not the name of the model itself (example: gpt-4).
        /// </para>
        /// <para>
        /// When using non-Azure OpenAI, this corresponds to "model" in the request options and should use the
        /// appropriate name of the model (example: gpt-4).
        /// </para>
        /// </remarks>
        [CodeGenMember("InternalNonAzureModelName")]
        public string DeploymentName { get; set; }

        /// <inheritdoc cref="CompletionsOptions.FrequencyPenalty"/>
        public float? FrequencyPenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.MaxTokens"/>
        public int? MaxTokens { get; set; }

        /// <inheritdoc cref="CompletionsOptions.NucleusSamplingFactor"/>
        public float? NucleusSamplingFactor { get; set; }

        /// <inheritdoc cref="CompletionsOptions.PresencePenalty"/>
        public float? PresencePenalty { get; set; }

        /// <inheritdoc cref="CompletionsOptions.StopSequences"/>
        public IList<string> StopSequences { get; }

        /// <inheritdoc cref="CompletionsOptions.Temperature"/>
        public float? Temperature { get; set; }

        /// <inheritdoc cref="CompletionsOptions.TokenSelectionBiases"/>
        public IDictionary<int, int> TokenSelectionBiases { get; }

        /// <inheritdoc cref="CompletionsOptions.User"/>
        public string User { get; set; }

        /// <summary> A list of functions the model may generate JSON inputs for. </summary>
        public IList<FunctionDefinition> Functions { get; set; }

        /// <summary>
        /// Controls how the model will use provided Functions.
        /// </summary>
        /// <remarks>
        ///     <list type="bullet">
        ///     <item>
        ///         Providing a custom <see cref="FunctionDefinition"/> will request that the model limit its
        ///         completions to function calls for that function.
        ///     </item>
        ///     <item>
        ///         <see cref="FunctionDefinition.Auto"/> represents the default behavior and will allow the model
        ///         to freely select between issuing a standard completions response or a call to any provided
        ///         function.
        ///     </item>
        ///     <item>
        ///         <see cref="FunctionDefinition.None"/> will request that the model only issue standard
        ///         completions responses, irrespective of provided functions. Note that the function definitions
        ///         provided may still influence the completions content.
        ///     </item>
        ///     </list>
        /// </remarks>
        public FunctionDefinition FunctionCall { get; set; }

        /// <summary>
        /// Gets or sets the additional configuration details to use for Azure OpenAI chat completions extensions.
        /// </summary>
        /// <remarks>
        /// These extensions are specific to Azure OpenAI and require use of the Azure OpenAI service.
        /// </remarks>
        public AzureChatExtensionsOptions AzureExtensionsOptions { get; set; }

        // CUSTOM CODE NOTE: the following properties are forward declared here as internal as their behavior is
        //                      otherwise handled in the custom implementation.
        internal IList<AzureChatExtensionConfiguration> InternalAzureExtensionsDataSources { get; set; }
        internal bool? InternalShouldStreamResponse { get; set; }
        internal IDictionary<string, int> InternalStringKeyedTokenSelectionBiases { get; }

        /// <summary> Initializes a new instance of ChatCompletionsOptions. </summary>
        /// <param name="deploymentName"> The deployment name to use for chat completions. </param>
        /// <param name="messages">
        /// The collection of context messages associated with this chat completions request.
        /// Typical usage begins with a chat message for the System role that provides instructions for
        /// the behavior of the assistant, followed by alternating messages between the User and
        /// Assistant roles.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="deploymentName"/> or <paramref name="messages"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="deploymentName"/> is an empty string.
        /// </exception>
        public ChatCompletionsOptions(string deploymentName, IEnumerable<ChatMessage> messages) : this()
        {
            Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
            Argument.AssertNotNull(messages, nameof(messages));

            DeploymentName = deploymentName;

            foreach (ChatMessage chatMessage in messages)
            {
                Messages.Add(chatMessage);
            }
        }

        /// <summary> Initializes a new instance of ChatCompletionsOptions. </summary>
        public ChatCompletionsOptions()
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
            Messages = new ChangeTrackingList<ChatMessage>();
            TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
            InternalStringKeyedTokenSelectionBiases = new ChangeTrackingDictionary<string, int>();
            StopSequences = new ChangeTrackingList<string>();
            Functions = new ChangeTrackingList<FunctionDefinition>();
            InternalAzureExtensionsDataSources = new ChangeTrackingList<AzureChatExtensionConfiguration>();
            AzureExtensionsOptions = null;
        }
    }
}
