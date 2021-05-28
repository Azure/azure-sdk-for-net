// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the subscription data model.
    /// </summary>
    public partial class FeatureData : Resource<SubscriptionResourceIdentifier>
    {
        /// <summary> Initializes a new instance of <see cref="FeatureData"/> class. </summary>
        internal FeatureData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FeatureData"/> class. </summary>
        /// <param name="name"> The name of the feature. </param>
        /// <param name="properties"> Properties of the previewed feature. </param>
        /// <param name="id"> The resource ID of the feature. </param>
        /// <param name="resourceType"> The resource type of the feature. </param>
        internal FeatureData(string name, FeatureProperties properties, string id, string resourceType = "Microsoft.Features/providers/features") : base(id, name, resourceType)
        {
            Properties = properties;
        }

        /// <summary>
        /// Gets the Id of the Subscription.
        /// </summary>
        public FeatureProperties Properties { get; }
    }
}
