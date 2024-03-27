// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using System;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
// Suppress the parameterized constructor that only receives the audio text and the voice in favor of a custom
// parameterized constructor that receives the deployment name as well.
[CodeGenSuppress("SpeechGenerationOptions", typeof(string), typeof(SpeechVoice))]
public partial class SpeechGenerationOptions
{
    // CUSTOM CODE NOTE:
    // Add setter to these properties to allow for an "init" pattern when using the public
    // default constructor.

    /// <summary>
    /// The text to generate audio for. The maximum length is 4096 characters.
    /// </summary>
    public string Input { get; set; }

    /// <summary>
    /// The voice to use for text-to-speech.
    /// </summary>
    public SpeechVoice Voice { get; set; }

    /// <summary>
    /// The audio output format for the spoken text. By default, the MP3 format will be used.
    /// </summary>
    public SpeechGenerationResponseFormat? ResponseFormat { get; set; }

    /// <summary>
    /// The speed of speech for generated audio. Values are valid in the range from 0.25 to 4.0, with 1.0 the
    /// default and higher values corresponding to faster speech.
    /// </summary>
    public float? Speed { get; set; }

    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    /// The deployment name to use for text-to-speech.
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
    // Add a parameterized constructor that receives the deployment name as a parameter in addition
    // to the other required properties.

    /// <summary> Initializes a new instance of <see cref="SpeechGenerationOptions"/>. </summary>
    /// <param name="deploymentName"> The deployment name to use for text-to-speech. </param>
    /// <param name="input"> The text to generate audio for. The maximum length is 4096 characters. </param>
    /// <param name="voice"> The voice to use for text-to-speech. </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="deploymentName"/> or <paramref name="input"/> or <paramref name="voice"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="deploymentName"/> is an empty string.
    /// </exception>
    public SpeechGenerationOptions(string deploymentName, string input, SpeechVoice voice)
    {
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(input, nameof(input));
        Argument.AssertNotNull(voice, nameof(voice));

        DeploymentName = deploymentName;
        Input = input;
        Voice = voice;
    }

    // CUSTOM CODE NOTE:
    // Add a public default constructor to allow for an "init" pattern using property setters.

    /// <summary> Initializes a new instance of <see cref="SpeechGenerationOptions"/>. </summary>
    public SpeechGenerationOptions()
    { }
}
