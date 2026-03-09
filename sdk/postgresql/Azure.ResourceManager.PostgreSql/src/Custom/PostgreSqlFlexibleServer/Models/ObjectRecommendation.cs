// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("AnalyzedWorkload")]
    [CodeGenSuppress("CurrentState")]
    [CodeGenSuppress("ImplementationDetails")]
    [CodeGenSuppress("InitialRecommendedOn")]
    [CodeGenSuppress("LastRecommendedOn")]
    [CodeGenSuppress("RecommendationReason")]
    [CodeGenSuppress("RecommendationType")]
    [CodeGenSuppress("TimesRecommended")]
    public partial class ObjectRecommendation
    {
        /// <summary> Creation time (UTC) of this recommendation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.initialRecommendedTime")]
        public DateTimeOffset? InitialRecommendedOn
        {
            get => Properties?.InitialRecommendedOn;
            set { }
        }

        /// <summary> Last time (UTC) that this recommendation was produced. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.lastRecommendedTime")]
        public DateTimeOffset? LastRecommendedOn
        {
            get => Properties?.LastRecommendedOn;
            set { }
        }

        /// <summary> Number of times this recommendation has been produced. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.timesRecommended")]
        public int? TimesRecommended
        {
            get => Properties?.TimesRecommended;
            set { }
        }

        /// <summary> Reason for this recommendation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.recommendationReason")]
        public string RecommendationReason
        {
            get => Properties?.RecommendationReason;
            set { }
        }

        /// <summary> Current state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.currentState")]
        public string CurrentState
        {
            get => Properties?.CurrentState;
            set { }
        }

        /// <summary> Type for this recommendation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.recommendationType")]
        public PostgreSqlFlexibleServerRecommendationType? RecommendationType
        {
            get => Properties?.RecommendationType;
            set { }
        }

        /// <summary> Implementation details for the recommended action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.implementationDetails")]
        public ObjectRecommendationImplementationDetails ImplementationDetails
        {
            get => Properties?.ImplementationDetails;
            set { }
        }

        /// <summary> Workload information for the recommended action. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.analyzedWorkload")]
        public ObjectRecommendationAnalyzedWorkload AnalyzedWorkload
        {
            get => Properties?.AnalyzedWorkload;
            set { }
        }
    }
}
