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
        /// <summary> Initializes a new instance of SelfHelpDiagnosticInsight. </summary>
        /// <param name="id">
        /// Article id.
        /// Serialized Name: Insight.id
        /// </param>
        /// <param name="title">
        /// This insight's title.
        /// Serialized Name: Insight.title
        /// </param>
        /// <param name="results">
        /// Detailed result content.
        /// Serialized Name: Insight.results
        /// </param>
        /// <param name="insightImportanceLevel">
        /// Importance level of the insight.
        /// Serialized Name: Insight.importanceLevel
        /// </param>
        /// <returns> A new <see cref="Models.SelfHelpDiagnosticInsight"/> instance for mocking. </returns>
        [Obsolete("This function is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SelfHelpDiagnosticInsight SelfHelpDiagnosticInsight(string id = null, string title = null, string results = null, SelfHelpImportanceLevel? insightImportanceLevel = null)
        {
            return new SelfHelpDiagnosticInsight(id, title, results, insightImportanceLevel, serializedAdditionalRawData: null);
        }

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
        public static SelfHelpSolutionMetadata SelfHelpSolutionMetadata(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string solutionId, string solutionType, string description, IEnumerable<IList<string>> requiredParameterSets)
        {
            return new SelfHelpSolutionMetadata(id, name, resourceType, systemData, default, serializedAdditionalRawData: null);
        }
    }
}
