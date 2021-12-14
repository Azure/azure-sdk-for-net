// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public partial class LocationExpanded : Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationExpanded"/> class.
        /// </summary>
        protected LocationExpanded()
        {
        }

        /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="name"> The location name. </param>
        /// <param name="displayName"> The display name of the location. </param>
        /// <param name="regionalDisplayName"> The display name of the location and its region. </param>
        /// <param name="metadata"> Metadata of the location, such as lat/long, paired region, and others. </param>
        /// <param name="id"></param>
        /// <param name="subscriptionId"></param>
        internal LocationExpanded(string id, string subscriptionId, string name, string displayName, string regionalDisplayName, LocationMetadata metadata)
            : base(name, displayName, regionalDisplayName)
        {
            Metadata = metadata;
            Id = id;
            ResourceIdentifier subId = new ResourceIdentifier(id);
            SubscriptionId = subscriptionId ?? subId.SubscriptionId;
        }

        /// <summary> Metadata of the location, such as lat/long, paired region, and others. </summary>
        public LocationMetadata Metadata { get; }

        /// <summary> Id of the Location. </summary>
        public string Id { get; }

        /// <summary> SubscriptionId the Location is under. </summary>
        public string SubscriptionId { get; }
    }
}
