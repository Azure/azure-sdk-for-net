// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Represents an Azure geography region where supported resource providers live.
    /// </summary>
    public partial class LocationExpanded
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
        {
            Metadata = metadata;
            Id = id;
            ResourceIdentifier subId = new ResourceIdentifier(id);
            SubscriptionId = subscriptionId ?? subId.SubscriptionId;
            RegionalDisplayName = regionalDisplayName;
            Name = name;
            DisplayName = displayName;
        }

        /// <summary> Gets a location name consisting of only lowercase characters without white spaces or any separation character between words, e.g. "westus". </summary>
        public string Name { get; private set; }

        /// <summary> Gets a location display name consisting of titlecase words or alphanumeric characters separated by whitespaces, e.g. "West US". </summary>
        public string DisplayName { get; private set; }

        /// <summary> Metadata of the location, such as lat/long, paired region, and others. </summary>
        public LocationMetadata Metadata { get; }

        /// <summary> Id of the Location. </summary>
        public string Id { get; }

        /// <summary> SubscriptionId the Location is under. </summary>
        public string SubscriptionId { get; }

        /// <summary> The display name of the location and its region. </summary>
        public string RegionalDisplayName { get; }
    }
}
