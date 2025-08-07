// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SelfHelp.Models
{
    public static partial class ArmSelfHelpModelFactory
    {
        /// <summary> Initializes a new instance of SelfHelpSolutionMetadata. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="solutionId"> Solution Id. </param>
        /// <param name="solutionType"> Solution Type. </param>
        /// <param name="description"> A detailed description of solution. </param>
        /// <param name="requiredParameterSets"> Required parameters for invoking this particular solution. </param>
        /// <returns> A new <see cref="Models.SelfHelpSolutionMetadata"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SelfHelpSolutionMetadata SelfHelpSolutionMetadata(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string solutionId, string solutionType, string description, IEnumerable<IList<string>> requiredParameterSets)
        {
            return new SelfHelpSolutionMetadata(id, name, resourceType, systemData, default, serializedAdditionalRawData: null);
        }
    }
}
