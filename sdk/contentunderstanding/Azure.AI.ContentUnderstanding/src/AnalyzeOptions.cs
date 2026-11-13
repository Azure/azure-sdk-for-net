// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Options for analysis operations that take <see cref="AnalysisInput"/> values,
    /// including the analyzer and request settings.
    /// </summary>
    public class AnalyzeOptions
    {
        /// <summary> Initializes a new instance of <see cref="AnalyzeOptions"/>. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="inputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string. </exception>
        public AnalyzeOptions(string analyzerId, IEnumerable<AnalysisInput> inputs)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(inputs, nameof(inputs));

            AnalyzerId = analyzerId;
            Inputs = inputs.ToList();
            ModelDeployments = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Gets the unique identifier of the analyzer. </summary>
        public string AnalyzerId { get; }

        /// <summary> Gets the inputs to analyze. </summary>
        public IList<AnalysisInput> Inputs { get; }

        /// <summary>
        /// Gets or sets the override mapping of model names to deployments.
        /// Ex. { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </summary>
        public IDictionary<string, string> ModelDeployments { get; set; }

        /// <summary>
        /// Gets or sets whether input exceeding the service's processable-unit limit should be
        /// truncated and returned as a partial result with a warning instead of failing.
        /// When omitted, the analyzer's configured value applies.
        /// </summary>
        public bool? AllowInputTruncation { get; set; }

        /// <summary>
        /// Gets or sets the location where the data may be processed.
        /// </summary>
        public ProcessingLocation? ProcessingLocation { get; set; }
    }
}
