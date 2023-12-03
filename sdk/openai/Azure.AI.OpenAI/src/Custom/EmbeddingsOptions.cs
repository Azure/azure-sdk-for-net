// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    [CodeGenSuppress("EmbeddingsOptions", typeof(IEnumerable<string>))]
    public partial class EmbeddingsOptions
    {
        /// <summary>
        /// Gets or sets the deployment name to use for an embeddings request.
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

        /// <summary>
        /// Input texts to get embeddings for, encoded as a an array of strings.
        /// Each input must not exceed 2048 tokens in length.
        ///
        /// Unless you are embedding code, we suggest replacing newlines (\n) in your input with a single space,
        /// as we have observed inferior results when newlines are present.
        /// </summary>
        public IList<string> Input { get; set; } = new ChangeTrackingList<string>();

        /// <summary>
        /// Creates a new instance of <see cref="EmbeddingsOptions"/>.
        /// </summary>
        /// <param name="deploymentName"> The deployment name to use for embeddings. </param>
        /// <param name="input"> The collection of inputs to run an embeddings operation across. </param>
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

        /// <summary>
        /// Creates a new instance of <see cref="EmbeddingsOptions"/>.
        /// </summary>
        public EmbeddingsOptions()
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
        }
    }
}
