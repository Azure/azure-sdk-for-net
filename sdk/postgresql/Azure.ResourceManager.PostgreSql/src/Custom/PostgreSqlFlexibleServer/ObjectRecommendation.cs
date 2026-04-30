// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class ObjectRecommendation
    {
        private DateTimeOffset? _initialRecommendedOnOverride;
        private bool _initialRecommendedOnSet;
        private DateTimeOffset? _lastRecommendedOnOverride;
        private bool _lastRecommendedOnSet;
        private int? _timesRecommendedOverride;
        private bool _timesRecommendedSet;
        private string _recommendationReasonOverride;
        private bool _recommendationReasonSet;
        private string _currentStateOverride;
        private bool _currentStateSet;
        private PostgreSqlFlexibleServerRecommendationType? _recommendationTypeOverride;
        private bool _recommendationTypeSet;
        private ObjectRecommendationImplementationDetails _implementationDetailsOverride;
        private bool _implementationDetailsSet;
        private ObjectRecommendationAnalyzedWorkload _analyzedWorkloadOverride;
        private bool _analyzedWorkloadSet;

        /// <summary> Creation time (UTC) of this recommendation. </summary>
        [WirePath("properties.initialRecommendedTime")]
        public DateTimeOffset? InitialRecommendedOn
        {
            get => _initialRecommendedOnSet ? _initialRecommendedOnOverride : (Properties is null ? default : Properties.InitialRecommendedOn);
            set { _initialRecommendedOnOverride = value; _initialRecommendedOnSet = true; }
        }

        /// <summary> Last time (UTC) that this recommendation was produced. </summary>
        [WirePath("properties.lastRecommendedTime")]
        public DateTimeOffset? LastRecommendedOn
        {
            get => _lastRecommendedOnSet ? _lastRecommendedOnOverride : (Properties is null ? default : Properties.LastRecommendedOn);
            set { _lastRecommendedOnOverride = value; _lastRecommendedOnSet = true; }
        }

        /// <summary> Number of times this recommendation has been produced. </summary>
        [WirePath("properties.timesRecommended")]
        public int? TimesRecommended
        {
            get => _timesRecommendedSet ? _timesRecommendedOverride : (Properties is null ? default : Properties.TimesRecommended);
            set { _timesRecommendedOverride = value; _timesRecommendedSet = true; }
        }

        /// <summary> Reason for this recommendation. </summary>
        [WirePath("properties.recommendationReason")]
        public string RecommendationReason
        {
            get => _recommendationReasonSet ? _recommendationReasonOverride : (Properties is null ? default : Properties.RecommendationReason);
            set { _recommendationReasonOverride = value; _recommendationReasonSet = true; }
        }

        /// <summary> Current state. </summary>
        [WirePath("properties.currentState")]
        public string CurrentState
        {
            get => _currentStateSet ? _currentStateOverride : (Properties is null ? default : Properties.CurrentState);
            set { _currentStateOverride = value; _currentStateSet = true; }
        }

        /// <summary> Type for this recommendation. </summary>
        [WirePath("properties.recommendationType")]
        public PostgreSqlFlexibleServerRecommendationType? RecommendationType
        {
            get => _recommendationTypeSet ? _recommendationTypeOverride : (Properties is null ? default : Properties.RecommendationType);
            set { _recommendationTypeOverride = value; _recommendationTypeSet = true; }
        }

        /// <summary> Implementation details for the recommended action. </summary>
        [WirePath("properties.implementationDetails")]
        public ObjectRecommendationImplementationDetails ImplementationDetails
        {
            get => _implementationDetailsSet ? _implementationDetailsOverride : (Properties is null ? default : Properties.ImplementationDetails);
            set { _implementationDetailsOverride = value; _implementationDetailsSet = true; }
        }

        /// <summary> Workload information for the recommended action. </summary>
        [WirePath("properties.analyzedWorkload")]
        public ObjectRecommendationAnalyzedWorkload AnalyzedWorkload
        {
            get => _analyzedWorkloadSet ? _analyzedWorkloadOverride : (Properties is null ? default : Properties.AnalyzedWorkload);
            set { _analyzedWorkloadOverride = value; _analyzedWorkloadSet = true; }
        }
    }
}
