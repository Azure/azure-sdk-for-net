// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Core
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

        /// <summary> Metadata of the location, such as lat/long, paired region, and others. </summary>
        public LocationMetadata Metadata { get; }

        /// <summary> Id of the Location. </summary>
        public string Id { get; }

        /// <summary> SubscriptionId the Location is under. </summary>
        public string SubscriptionId { get; }

        /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="metadata"> Metadata of the location, such as lat/long, paired region, and others. </param>
        /// <param name="id"></param>
        /// <param name="subscriptionId"></param>
        internal LocationExpanded(LocationMetadata metadata, string id, string subscriptionId)
        {
            Metadata = metadata;
            Id = id;
            SubscriptionId = subscriptionId;
        }
    }
}
