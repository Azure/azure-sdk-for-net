// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Gets or sets the availability set resource settings. </summary>
    public partial class MoverAvailabilitySetResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of MoverAvailabilitySetResourceSettings. </summary>
        /// <param name="targetResourceName"> Gets or sets the target Resource name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetResourceName"/> is null. </exception>
        public MoverAvailabilitySetResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            Tags = new ChangeTrackingDictionary<string, string>();
            ResourceType = "Microsoft.Compute/availabilitySets";
        }
    }
}
