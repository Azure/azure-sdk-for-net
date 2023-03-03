// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Models;

// Custom code to support custom datetime format for the 2 properties startDateTime and expirationDateTime
// Here is an issue https://github.com/Azure/autorest.csharp/issues/3184 to track if codegen can support custom datetime format in the furture.

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// A class representing the MaintenanceConfiguration data model.
    /// Maintenance configuration record type
    /// </summary>
    public partial class MaintenanceConfigurationData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of MaintenanceConfigurationData. </summary>
        /// <param name="location"> The location. </param>
        public MaintenanceConfigurationData(AzureLocation location) : base(location)
        {
            ExtensionProperties = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of MaintenanceConfigurationData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="namespace"> Gets or sets namespace of the resource. </param>
        /// <param name="extensionProperties"> Gets or sets extensionProperties of the maintenanceConfiguration. </param>
        /// <param name="maintenanceScope"> Gets or sets maintenanceScope of the configuration. </param>
        /// <param name="visibility"> Gets or sets the visibility of the configuration. The default value is &apos;Custom&apos;. </param>
        /// <param name="startOn"> Effective start date of the maintenance window in YYYY-MM-DD hh:mm format. The start date can be set to either the current date or future date. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. </param>
        /// <param name="expireOn"> Effective expiration date of the maintenance window in YYYY-MM-DD hh:mm format. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. Expiration date must be set to a future date. If not provided, it will be set to the maximum datetime 9999-12-31 23:59:59. </param>
        /// <param name="duration"> Duration of the maintenance window in HH:mm format. If not provided, default value will be used based on maintenance scope provided. Example: 05:00. </param>
        /// <param name="timeZone"> Name of the timezone. List of timezones can be obtained by executing [System.TimeZoneInfo]::GetSystemTimeZones() in PowerShell. Example: Pacific Standard Time, UTC, W. Europe Standard Time, Korea Standard Time, Cen. Australia Standard Time. </param>
        /// <param name="recurEvery"> Rate at which a Maintenance window is expected to recur. The rate can be expressed as daily, weekly, or monthly schedules. Daily schedule are formatted as recurEvery: [Frequency as integer][&apos;Day(s)&apos;]. If no frequency is provided, the default frequency is 1. Daily schedule examples are recurEvery: Day, recurEvery: 3Days.  Weekly schedule are formatted as recurEvery: [Frequency as integer][&apos;Week(s)&apos;] [Optional comma separated list of weekdays Monday-Sunday]. Weekly schedule examples are recurEvery: 3Weeks, recurEvery: Week Saturday,Sunday. Monthly schedules are formatted as [Frequency as integer][&apos;Month(s)&apos;] [Comma separated list of month days] or [Frequency as integer][&apos;Month(s)&apos;] [Week of Month (First, Second, Third, Fourth, Last)] [Weekday Monday-Sunday]. Monthly schedule examples are recurEvery: Month, recurEvery: 2Months, recurEvery: Month day23,day24, recurEvery: Month Last Sunday, recurEvery: Month Fourth Monday. </param>
        internal MaintenanceConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string @namespace, IDictionary<string, string> extensionProperties, MaintenanceScope? maintenanceScope, MaintenanceConfigurationVisibility? visibility, DateTimeOffset? startOn, DateTimeOffset? expireOn, TimeSpan? duration, string timeZone, string recurEvery) : base(id, name, resourceType, systemData, tags, location)
        {
            Namespace = @namespace;
            ExtensionProperties = extensionProperties;
            MaintenanceScope = maintenanceScope;
            Visibility = visibility;
            StartOn = startOn;
            ExpireOn = expireOn;
            Duration = duration;
            TimeZone = timeZone;
            RecurEvery = recurEvery;
        }

        /// <summary> Gets or sets namespace of the resource. </summary>
        public string Namespace { get; set; }
        /// <summary> Gets or sets extensionProperties of the maintenanceConfiguration. </summary>
        public IDictionary<string, string> ExtensionProperties { get; }
        /// <summary> Gets or sets maintenanceScope of the configuration. </summary>
        public MaintenanceScope? MaintenanceScope { get; set; }
        /// <summary> Gets or sets the visibility of the configuration. The default value is &apos;Custom&apos;. </summary>
        public MaintenanceConfigurationVisibility? Visibility { get; set; }
        /// <summary> Effective start date of the maintenance window in YYYY-MM-DD hh:mm format. The start date can be set to either the current date or future date. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. </summary>
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Effective expiration date of the maintenance window in YYYY-MM-DD hh:mm format. The window will be created in the time zone provided and adjusted to daylight savings according to that time zone. Expiration date must be set to a future date. If not provided, it will be set to the maximum datetime 9999-12-31 23:59:59. </summary>
        public DateTimeOffset? ExpireOn { get; set; }
        /// <summary> Duration of the maintenance window in HH:mm format. If not provided, default value will be used based on maintenance scope provided. Example: 05:00. </summary>
        public TimeSpan? Duration { get; set; }
        /// <summary> Name of the timezone. List of timezones can be obtained by executing [System.TimeZoneInfo]::GetSystemTimeZones() in PowerShell. Example: Pacific Standard Time, UTC, W. Europe Standard Time, Korea Standard Time, Cen. Australia Standard Time. </summary>
        public string TimeZone { get; set; }
        /// <summary> Rate at which a Maintenance window is expected to recur. The rate can be expressed as daily, weekly, or monthly schedules. Daily schedule are formatted as recurEvery: [Frequency as integer][&apos;Day(s)&apos;]. If no frequency is provided, the default frequency is 1. Daily schedule examples are recurEvery: Day, recurEvery: 3Days.  Weekly schedule are formatted as recurEvery: [Frequency as integer][&apos;Week(s)&apos;] [Optional comma separated list of weekdays Monday-Sunday]. Weekly schedule examples are recurEvery: 3Weeks, recurEvery: Week Saturday,Sunday. Monthly schedules are formatted as [Frequency as integer][&apos;Month(s)&apos;] [Comma separated list of month days] or [Frequency as integer][&apos;Month(s)&apos;] [Week of Month (First, Second, Third, Fourth, Last)] [Weekday Monday-Sunday]. Monthly schedule examples are recurEvery: Month, recurEvery: 2Months, recurEvery: Month day23,day24, recurEvery: Month Last Sunday, recurEvery: Month Fourth Monday. </summary>
        public string RecurEvery { get; set; }
    }
}
