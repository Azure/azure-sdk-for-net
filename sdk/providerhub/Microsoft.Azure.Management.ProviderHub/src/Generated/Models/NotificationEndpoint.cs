// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ProviderHub.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class NotificationEndpoint
    {
        /// <summary>
        /// Initializes a new instance of the NotificationEndpoint class.
        /// </summary>
        public NotificationEndpoint()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NotificationEndpoint class.
        /// </summary>
        public NotificationEndpoint(string notificationDestination = default(string), IList<string> locations = default(IList<string>))
        {
            NotificationDestination = notificationDestination;
            Locations = locations;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "notificationDestination")]
        public string NotificationDestination { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "locations")]
        public IList<string> Locations { get; set; }

    }
}
