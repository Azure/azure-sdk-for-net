// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            return new SelfHelpSolutionMetadata(id, name, resourceType, systemData, default, null);
        }

        /// <summary> Solution replacement maps. </summary>
        /// <param name="webResults"> Solution AzureKB results. </param>
        /// <param name="diagnostics"> Solution diagnostics results. </param>
        /// <param name="troubleshooters"> Solutions Troubleshooters. </param>
        /// <param name="metricsBasedCharts"> Solution metrics based charts. </param>
        /// <param name="videos"> Video solutions, which have the power to engage the customer by stimulating their senses. </param>
        /// <param name="videoGroups"> Group of Videos. </param>
        /// <returns> A new <see cref="Models.SolutionReplacementMaps"/> instance for mocking. </returns>
        public static SolutionReplacementMaps SolutionReplacementMaps(IEnumerable<KBWebResult> webResults = default, IEnumerable<SolutionsDiagnostic> diagnostics = default, IEnumerable<SolutionsTroubleshooters> troubleshooters = default, IEnumerable<MetricsBasedChart> metricsBasedCharts = default, IEnumerable<SelfHelpVideo> videos = default, IEnumerable<VideoGroupDetail> videoGroups = default)
        {
            webResults ??= new ChangeTrackingList<KBWebResult>();
            diagnostics ??= new ChangeTrackingList<SolutionsDiagnostic>();
            troubleshooters ??= new ChangeTrackingList<SolutionsTroubleshooters>();
            metricsBasedCharts ??= new ChangeTrackingList<MetricsBasedChart>();
            videos ??= new ChangeTrackingList<SelfHelpVideo>();
            videoGroups ??= new ChangeTrackingList<VideoGroupDetail>();

            return new SolutionReplacementMaps(
                webResults.ToList(),
                diagnostics.ToList(),
                troubleshooters.ToList(),
                metricsBasedCharts.ToList(),
                videos.ToList(),
                videoGroups.ToList(),
                additionalBinaryDataProperties: null);
        }
        /// <summary> Solution replacement maps. </summary>
        /// <param name="webResults"> Solution AzureKB results. </param>
        /// <param name="videos"> Video solutions, which have the power to engage the customer by stimulating their senses. </param>
        /// <param name="videoGroups"> Group of Videos. </param>
        /// <returns> A new <see cref="Models.ReplacementMapsResult"/> instance for mocking. </returns>
        public static ReplacementMapsResult ReplacementMapsResult(IEnumerable<KBWebResult> webResults = default, IEnumerable<SelfHelpVideo> videos = default, IEnumerable<VideoGroupDetail> videoGroups = default)
        {
            webResults ??= new ChangeTrackingList<KBWebResult>();
            videos ??= new ChangeTrackingList<SelfHelpVideo>();
            videoGroups ??= new ChangeTrackingList<VideoGroupDetail>();

            return new ReplacementMapsResult(webResults.ToList(), videos.ToList(), videoGroups.ToList(), additionalBinaryDataProperties: null);
        }
    }
}
