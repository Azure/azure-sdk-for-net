// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

[assembly:CodeGenSuppressType("CreatedByType")]
[assembly:CodeGenSuppressType("PolicyAssignmentIdentityType")]
[assembly:CodeGenSuppressType("PolicyAssignmentIdentityTypeExtensions")]
namespace Azure.ResourceManager.Resources.Models
{
    public partial class LocationExpanded
    {
        /// <summary>
        /// Convert LocationExpanded into a Location object.
        /// </summary>
        /// <param name="location"> The location to convert. </param>
        public static implicit operator AzureLocation(LocationExpanded location)
        {
            return new AzureLocation(location.Name, location.DisplayName);
        }

                /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="id"> The fully qualified ID of the location. For example, /subscriptions/00000000-0000-0000-0000-000000000000/locations/westus. </param>
        /// <param name="subscriptionId"> The subscription ID. </param>
        /// <param name="name"> The location name. </param>
        /// <param name="type"> The location type. </param>
        /// <param name="displayName"> The display name of the location. </param>
        /// <param name="regionalDisplayName"> The display name of the location and its region. </param>
        /// <param name="metadata"> Metadata of the location, such as lat/long, paired region, and others. </param>
        internal LocationExpanded(string id, string subscriptionId, string name, LocationType? type, string displayName, string regionalDisplayName, LocationMetadata metadata)
        {
            Id = id;
            ResourceIdentifier subId = new ResourceIdentifier(id);
            SubscriptionId = subscriptionId ?? subId.SubscriptionId;
            Name = name;
            Type = type;
            DisplayName = displayName;
            RegionalDisplayName = regionalDisplayName;
            Metadata = metadata;
        }
    }
}
