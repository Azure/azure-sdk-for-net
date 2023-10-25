// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary>
    /// A class representing the ScalingPlan data model.
    /// Represents a scaling plan definition.
    /// </summary>
    public partial class ScalingPlanData : TrackedResourceData
    {
        private const string DefaultTimeZone = "Central Standard Time";

        /// <summary> Initializes a new instance of ScalingPlanData. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScalingPlanData(AzureLocation location) : base(location)
        {
            TimeZone = DefaultTimeZone;
            Schedules = new ChangeTrackingList<ScalingSchedule>();
            HostPoolReferences = new ChangeTrackingList<ScalingHostPoolReference>();
        }

        /// <summary> HostPool type for desktop. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version", false)]
        public HostPoolType? HostPoolType
        {
            get => ScalingHostPoolType.ToString();
            set => ScalingHostPoolType = value.Value.ToString();
        }
    }
}
