// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
// Suppress the parameterized constructor that only receives the messages in favor of a custom
// parameterized constructor that receives the deployment name as well.

[CodeGenSuppress("ChatCompletionsOptions", typeof(IEnumerable<ChatRequestMessage>))]
[CodeGenSerialization(nameof(TokenSelectionBiases), SerializationValueHook = nameof(SerializeTokenSelectionBiases), DeserializationValueHook = nameof(DeserializeTokenSelectionBiases))]
public partial class ChatCompletionsOptions
{
    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets or sets the number of choices that should be generated per provided prompt.
    ///     Has a valid range of 1 to 128.
    /// </summary>
    /// <remarks>
    ///     Because this parameter generates many completions, it can quickly consume your token quota. Use
    ///     carefully and ensure reasonable settings for <see cref="MaxTokens"/> and <see cref="StopSequences"/>.
    ///
    ///     <see cref="ChoiceCount"/> is equivalent to 'n' in the REST request schema.
    /// </remarks>
    public int? ChoiceCount { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    /// The deployment name to use for a chat completions request.
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
    public string DeploymentName { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets or sets a value that influences the probability of generated tokens appearing based on their
    ///     cumulative frequency in generated text.
    ///     Has a valid range of -2.0 to 2.0.
    /// </summary>
    /// <remarks>
    ///     Positive values will make tokens less likely to appear as their frequency increases and decrease the
    ///     model's likelihood of repeating the same statements verbatim.
    /// </remarks>
    public float? FrequencyPenalty { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary> Gets the maximum number of tokens to generate. Has minimum of 0. </summary>
    /// <remarks>
    ///     <see cref="MaxTokens"/> is equivalent to 'max_tokens' in the REST request schema.
    /// </remarks>
    public int? MaxTokens { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets or set a an alternative value to <see cref="Temperature"/>, called nucleus sampling, that causes
    ///     the model to consider the results of the tokens with <see cref="NucleusSamplingFactor"/> probability
    ///     mass.
    /// </summary>
    /// <remarks>
    ///     As an example, a value of 0.1 will cause only the tokens comprising the top 10% of probability mass to
    ///     be considered.
    ///
    ///     It is not recommended to modify <see cref="Temperature"/> and <see cref="NucleusSamplingFactor"/>
    ///     for the same chat completions request as the interaction of these two settings is difficult to predict.
    ///
    ///     <see cref="NucleusSamplingFactor"/> is equivalent to 'top_p' in the REST request schema.
    /// </remarks>
    public float? NucleusSamplingFactor { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets or sets a value that influences the probability of generated tokens appearing based on their
    ///     existing presence in generated text.
    ///     Has a valid range of -2.0 to 2.0.
    /// </summary>
    /// <remarks>
    ///     Positive values will make tokens less likely to appear when they already exist and increase the
    ///     model's likelihood to output new topics.
    /// </remarks>
    public float? PresencePenalty { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets a list of textual sequences that will end completions generation.
    ///     A maximum of four stop sequences are allowed.
    /// </summary>
    /// <remarks>
    ///     <see cref="StopSequences"/> is equivalent to 'stop' in the REST request schema.
    /// </remarks>
    public IList<string> StopSequences { get; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    ///     Gets or sets the sampling temperature to use that controls the apparent creativity of generated
    ///     completions.
    ///     Has a valid range of 0.0 to 2.0 and defaults to 1.0 if not otherwise specified.
    /// </summary>
    /// <remarks>
    ///     Higher values will make output more random while lower values will make results more focused and
    ///     deterministic.
    ///
    ///     It is not recommended to modify <see cref="Temperature"/> and <see cref="NucleusSamplingFactor"/>
    ///     for the same chat completions request as the interaction of these two settings is difficult to predict.
    /// </remarks>
    public float? Temperature { get; set; }

    // CUSTOM CODE NOTE:
    // - Add custom serialization hook.
    // - Add custom doc comment.

    /// <summary>
    ///     Gets a dictionary of modifications to the likelihood of specified GPT tokens appearing in a chat completions
    ///     result. Maps token IDs to associated bias scores from -100 to 100, with minimum and maximum values
    ///     corresponding to a ban or exclusive selection of that token, respectively.
    /// </summary>
    /// <remarks>
    ///     Token IDs are computed via external tokenizer tools.
    ///     The exact effect of specific bias values varies per model.
    ///
    ///     <see cref="TokenSelectionBiases"/> is equivalent to 'logit_bias' in the REST request schema.
    /// </remarks>
    public IDictionary<int, int> TokenSelectionBiases { get; }

    /// <summary> A list of functions the model may generate JSON inputs for. </summary>
    public IList<FunctionDefinition> Functions { get; }

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

    /// <summary>
    /// If specified, the model will configure which of the provided tools it can use for the chat completions response.
    /// </summary>
    public ChatCompletionsToolChoice ToolChoice { get; set; }

    internal AzureChatEnhancementConfiguration Enhancements { get; set; }

    // CUSTOM CODE NOTE:
    //  Retaining the generated "ToolChoice" as a renamed, internal property facilitates the change of type of
    //  ToolChoice to the custom abstraction seen above.

    [CodeGenMember("ToolChoice")]
    internal BinaryData InternalSuppressedToolChoice { get; set; }

    // CUSTOM CODE NOTE: the following properties are forward declared here as internal as their behavior is
    //                      otherwise handled in the custom implementation.
    internal IList<AzureChatExtensionConfiguration> InternalAzureExtensionsDataSources { get; set; }

    // CUSTOM CODE NOTE:
    // Mark the `stream` property as internal. This functionality will be handled by unique method
    // signatures for the different request types (i.e. streaming versus non-streaming methods).

    internal bool? InternalShouldStreamResponse { get; set; }

    // CUSTOM CODE NOTE:
    // Add a parameterized constructor that receives the deployment name as a parameter in addition
    // to the other required properties.

    /// <summary> Initializes a new instance of <see cref="ChatCompletionsOptions"/>. </summary>
    /// <param name="deploymentName"> The deployment name to use for a chat completions request. </param>
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
    public ChatCompletionsOptions(string deploymentName, IEnumerable<ChatRequestMessage> messages)
    {
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(messages, nameof(messages));

        DeploymentName = deploymentName;
        Messages = messages.ToList();
        Functions = new ChangeTrackingList<FunctionDefinition>();
        TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
        StopSequences = new ChangeTrackingList<string>();
        InternalAzureExtensionsDataSources = new ChangeTrackingList<AzureChatExtensionConfiguration>();
        Tools = new ChangeTrackingList<ChatCompletionsToolDefinition>();
    }

    // CUSTOM CODE NOTE:
    // Add a public default constructor to allow for an "init" pattern using property setters.

    /// <summary> Initializes a new instance of <see cref="ChatCompletionsOptions"/>. </summary>
    public ChatCompletionsOptions()
    {
        Messages = new ChangeTrackingList<ChatRequestMessage>();
        Functions = new ChangeTrackingList<FunctionDefinition>();
        TokenSelectionBiases = new ChangeTrackingDictionary<int, int>();
        StopSequences = new ChangeTrackingList<string>();
        InternalAzureExtensionsDataSources = new ChangeTrackingList<AzureChatExtensionConfiguration>();
        Tools = new ChangeTrackingList<ChatCompletionsToolDefinition>();
    }

    // CUSTOM CODE NOTE:
    // Implement custom serialization code for the `logit_bias` property to serialize it as a
    // IDictionary<string, int> instead of a IDictionary<int, int>.

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SerializeTokenSelectionBiases(Utf8JsonWriter writer)
    {
        writer.WriteStartObject();
        foreach (var item in TokenSelectionBiases)
        {
            writer.WritePropertyName(item.Key.ToString());
            writer.WriteNumberValue(item.Value);
        }
        writer.WriteEndObject();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DeserializeTokenSelectionBiases(JsonProperty property, ref IDictionary<int, int> tokenSelectionBiases)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            return;
        }
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (var property0 in property.Value.EnumerateObject())
        {
            dictionary.Add(int.Parse(property0.Name), property0.Value.GetInt32());
        }
        tokenSelectionBiases = dictionary;
    }
}
