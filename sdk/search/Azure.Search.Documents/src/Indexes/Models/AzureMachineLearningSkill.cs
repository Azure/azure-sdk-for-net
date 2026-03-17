// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary>
    /// <see href="https://docs.microsoft.com/azure/search/cognitive-search-aml-skill">AzureMachineLearningSkill</see> allows you to extend AI enrichment with a
    /// custom <see href="https://docs.microsoft.com/azure/machine-learning/overview-what-is-azure-machine-learning">Azure Machine Learning</see> (AML) model.
    /// <para>Once an AML model is <see href="https://docs.microsoft.com/azure/machine-learning/concept-azure-machine-learning-architecture#workspace">trained and deployed</see>,
    /// an AML skill integrates it into AI enrichment.</para>
    /// </summary>
    public partial class AzureMachineLearningSkill : SearchIndexerSkill
    {
        /// <summary> The scoring URI of the AML service to which the JSON payload will be sent. Only the https URI scheme is allowed. </summary>
        public Uri ScoringUri { get; set; }

        /// <summary> The key for the AML service. </summary>
        public string AuthenticationKey { get; set; }

        /// <summary> The Azure Resource Manager resource ID of the AML service. </summary>
        public ResourceIdentifier ResourceId { get; set; }

        /// <summary> The region the AML service is deployed in. </summary>
        public AzureLocation? Location { get; set; }

        /// <summary> The degree of parallelism to use for the AML skill. </summary>
        public int? DegreeOfParallelism { get; set; }

        /// <summary> The timeout for the AML skill. </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMachineLearningSkill"/> class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill.</param>
        /// <param name="scoringUri">The scoring URI of the AML service to which the JSON payload will be sent. Only the https URI scheme is allowed.</param>
        /// <param name="authenticationKey">The key for the AML service.</param>
        public AzureMachineLearningSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, Uri scoringUri, string authenticationKey = default) :
            base("#Microsoft.Skills.Custom.AmlSkill", inputs, outputs)
        {
            ScoringUri = scoringUri ?? throw new ArgumentNullException(nameof(scoringUri));
            AuthenticationKey = authenticationKey;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMachineLearningSkill"/> class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill.</param>
        /// <param name="resourceId">The Azure Resource Manager resource Id of the AML service.
        /// It should be in the format subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.MachineLearningServices/workspaces/{workspace-name}/services/{service_name}.</param>
        /// <param name="location">The region the AML service is deployed in.</param>
        public AzureMachineLearningSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, ResourceIdentifier resourceId, AzureLocation? location = default) :
            base("#Microsoft.Skills.Custom.AmlSkill", inputs, outputs)
        {
            ResourceId = resourceId ?? throw new ArgumentNullException(nameof(resourceId));
            Location = location;
        }
    }
}
