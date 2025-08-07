// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SelfHelp.Models
{
    public partial class SelfHelpSolutionMetadata
    {
        /// <summary> Solution Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SolutionId { get; set; }

        /// <summary> Solution Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SolutionType { get; set; }

        /// <summary> A detailed description of solution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Description { get; set; }

        /// <summary> Required parameters for invoking this particular solution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IList<string>> RequiredParameterSets { get; }

        /// <summary> Initializes a new instance of SelfHelpSolutionMetadata. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="solutionId"> Solution Id. </param>
        /// <param name="solutionType"> Solution Type. </param>
        /// <param name="description"> A detailed description of solution. </param>
        /// <param name="requiredParameterSets"> Required parameters for invoking this particular solution. </param>
        /// <param name="solutions"> List of metadata. </param>
        internal SelfHelpSolutionMetadata(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string solutionId, string solutionType, string description, IList<IList<string>> requiredParameterSets, IList<SolutionMetadataProperties> solutions) : base(id, name, resourceType, systemData)
        {
            SolutionId = solutionId;
            SolutionType = solutionType;
            Description = description;
            RequiredParameterSets = requiredParameterSets;
            Solutions = solutions;
        }
    }
}
