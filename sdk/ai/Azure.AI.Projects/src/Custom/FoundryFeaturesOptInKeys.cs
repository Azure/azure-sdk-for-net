// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Projects
{
    // This file was added here to introduce breaking change by removing
    // AgentInsightsV1Preview. The next version of a typespec does not contain
    // this flag. This file needs to be removed after the Azure.AI.Projects
    // v. 3.0.0 will be released and the code should be re generated using
    // the latest typespes. This will result in correct generated file, which will not introduce
    // breaking changes post 3.0.0.
    /// <summary></summary>
    public enum FoundryFeaturesOptInKeys
    {
        /// <summary> EvaluationsV1Preview. </summary>
        EvaluationsV1Preview,
        /// <summary> SchedulesV1Preview. </summary>
        SchedulesV1Preview,
        /// <summary> RedTeamsV1Preview. </summary>
        RedTeamsV1Preview,
        /// <summary> InsightsV1Preview. </summary>
        InsightsV1Preview,
        /// <summary> MemoryStoresV1Preview. </summary>
        MemoryStoresV1Preview,
        /// <summary> RoutinesV2Preview. </summary>
        RoutinesV2Preview,
        /// <summary> SkillsV1Preview. </summary>
        SkillsV1Preview,
        /// <summary> DataGenerationJobsV1Preview. </summary>
        DataGenerationJobsV1Preview,
        /// <summary> ModelsV1Preview. </summary>
        ModelsV1Preview,
        /// <summary> ModelRouterControlsV1Preview. </summary>
        ModelRouterControlsV1Preview,
        /// <summary> FinetuningSessionsV1Preview. </summary>
        FinetuningSessionsV1Preview
    }
}
