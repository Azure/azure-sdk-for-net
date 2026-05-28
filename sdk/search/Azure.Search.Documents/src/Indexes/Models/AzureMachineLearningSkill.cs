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
    public partial class AzureMachineLearningSkill
    {
        /// <summary>The key for the Azure Machine Learning service. This is required for key-based authentication.</summary>
        [CodeGenMember("AuthenticationKey")]
        public string AuthenticationKey { get; }

        /// <summary>The scoring URI of the Azure Machine Learning service to which the JSON payload will be sent.
        /// This is required when using no authentication or key-based authentication.
        /// <para>Only the https URI scheme is allowed.</para>
        /// </summary>
        [CodeGenMember("ScoringUri")]
        public Uri ScoringUri { get; }

        [CodeGenMember("ResourceId")]
        internal string RawResourceId
        {
            get => ResourceId?.ToString();
            set => ResourceId = (value == null) ? null : new ResourceIdentifier(value);
        }

        /// <summary>The <see href="https://docs.microsoft.com/dotnet/api/azure.core.resourceidentifier">Azure Resource Manager resource ID</see> of the Azure Machine Learning service.
        /// This is required for token-based authentication.
        /// <para>It should be in the format "subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.MachineLearningServices/workspaces/{workspace-name}/services/{service_name}".</para>
        /// </summary>
        public ResourceIdentifier ResourceId { get; private set; }

        [CodeGenMember("Region")]
        internal string RawLocation
        {
            get => Location?.ToString();
            set => Location = (value == null) ? default : new AzureLocation(value);
        }

        /// <summary> The <see href="https://docs.microsoft.com/dotnet/api/azure.core.azurelocation">region</see> the Azure Machine Learning service is deployed in.
        /// This is optional for token-based authentication.
        /// </summary>
        public AzureLocation? Location { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMachineLearningSkill"/> class.
        /// </summary>
        /// <param name="inputs">Inputs of the skills could be a column in the source data set, or the output of an upstream skill.</param>
        /// <param name="outputs">The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill.</param>
        /// <param name="authenticationKey">The key for the AML service.</param>
        /// <param name="scoringUri">The scoring URI of the AML service to which the JSON payload will be sent. Only the https URI scheme is allowed.</param>
        public AzureMachineLearningSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, Uri scoringUri, string authenticationKey = default) :
            this(inputs, outputs)
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
            this(inputs, outputs)
        {
            ResourceId = resourceId ?? throw new ArgumentNullException(nameof(resourceId));
            Location = location;
        }

        /// <summary> Initializes a new instance of AmlSkill. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        internal AzureMachineLearningSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }
            if (outputs == null)
            {
                throw new ArgumentNullException(nameof(outputs));
            }

            ODataType = "#Microsoft.Skills.Custom.AmlSkill";
        }
    }
}
