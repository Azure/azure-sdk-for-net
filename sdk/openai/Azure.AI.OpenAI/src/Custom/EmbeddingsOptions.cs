// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
// Suppress the parameterized constructor that only receives the input strings in favor of a custom
// parameterized constructor that receives the deployment name as well.

[CodeGenSuppress("EmbeddingsOptions", typeof(IEnumerable<string>))]
public partial class EmbeddingsOptions
{
    // CUSTOM CODE NOTE:
    // Add custom doc comment.

    /// <summary>
    /// The deployment name to use for an embeddings request.
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

    /// <summary> Initializes a new instance of <see cref="EmbeddingsOptions"/>. </summary>
    /// <param name="deploymentName"> The deployment name to use for an embeddings request. </param>
    /// <param name="input">
    /// Input texts to get embeddings for, encoded as a an array of strings.
    /// Each input must not exceed 2048 tokens in length.
    ///
    /// Unless you are embedding code, we suggest replacing newlines (\n) in your input with a single space,
    /// as we have observed inferior results when newlines are present.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="deploymentName"/> or <paramref name="input"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="deploymentName"/> is an empty string.
    /// </exception>
    public EmbeddingsOptions(string deploymentName, IEnumerable<string> input)
    {
        Argument.AssertNotNullOrEmpty(deploymentName, nameof(deploymentName));
        Argument.AssertNotNull(input, nameof(input));

        DeploymentName = deploymentName;
        Input = input.ToList();
    }

    // CUSTOM CODE NOTE:
    // Add a public default constructor to allow for an "init" pattern using property setters.

    /// <summary> Initializes a new instance of <see cref="EmbeddingsOptions"/>. </summary>
    public EmbeddingsOptions()
    {
        Input = new ChangeTrackingList<string>();
    }

    // CUSTOM CODE NOTE:
    // As an optimization, this library will represent the data via a mechanism independent of the wire encoding
    // format.

    internal EmbeddingEncodingFormat? EncodingFormat { get; set; }
}
