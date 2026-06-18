// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("IotSecurityAggregatedRecommendationData")]
    [CodeGenSuppress("RecommendationName")]
    public partial class IotSecurityAggregatedRecommendationData
    {
        private bool _isRecommendationNameDefined;
        private string _recommendationName;

        // Preserve the legacy public constructor for mocking.
        /// <summary> Initializes a new instance of <see cref="IotSecurityAggregatedRecommendationData"/>. </summary>
        public IotSecurityAggregatedRecommendationData()
        {
            Properties = new IoTSecurityAggregatedRecommendationProperties();
            Tags = new ChangeTrackingDictionary<string, string>();
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Name of the recommendation. </summary>
        public string RecommendationName
        {
            get => _isRecommendationNameDefined ? _recommendationName : Properties is null ? default : Properties.RecommendationName;
            // Compatibility shim: the legacy flattened property had a public setter, but the TypeSpec
            // backing model is read-only. Preserve the API shape for mocking.
            set
            {
                _recommendationName = value;
                _isRecommendationNameDefined = true;
            }
        }
    }
}
