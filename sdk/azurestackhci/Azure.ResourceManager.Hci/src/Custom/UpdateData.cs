// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A class representing the Update data model.
    /// Update details
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UpdateData"/>. </summary>
        public UpdateData()
        {
            Prerequisites = new ChangeTrackingList<UpdatePrerequisite>();
            ComponentVersions = new ChangeTrackingList<HciPackageVersionInfo>();
            HealthCheckResult = new ChangeTrackingList<HciPrecheckResult>();
        }

        /// <summary> Initializes a new instance of <see cref="UpdateData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of the Updates proxy resource. </param>
        /// <param name="installedOn"> Date that the update was installed. </param>
        /// <param name="description"> Description of the update. </param>
        /// <param name="state"> State of the update as it relates to this stamp. </param>
        /// <param name="prerequisites"> If update State is HasPrerequisite, this property contains an array of objects describing prerequisite updates before installing this update. Otherwise, it is empty. </param>
        /// <param name="componentVersions"> An array of component versions for a Solution Bundle update, and an empty array otherwise.  </param>
        /// <param name="rebootRequired"></param>
        /// <param name="healthState"> Overall health state for update-specific health checks. </param>
        /// <param name="healthCheckResult"> An array of PrecheckResult objects. </param>
        /// <param name="healthCheckOn"> Last time the package-specific checks were run. </param>
        /// <param name="packagePath"> Path where the update package is available. </param>
        /// <param name="packageSizeInMb"> Size of the package. This value is a combination of the size from update metadata and size of the payload that results from the live scan operation for OS update content. </param>
        /// <param name="displayName"> Display name of the Update. </param>
        /// <param name="version"> Version of the update. </param>
        /// <param name="publisher"> Publisher of the update package. </param>
        /// <param name="releaseLink"> Link to release notes for the update. </param>
        /// <param name="availabilityType"> Indicates the way the update content can be downloaded. </param>
        /// <param name="packageType"> Customer-visible type of the update. </param>
        /// <param name="additionalProperties"> Extensible KV pairs serialized as a string. This is currently used to report the stamp OEM family and hardware model information when an update is flagged as Invalid for the stamp based on OEM type. </param>
        /// <param name="progressPercentage"> Progress percentage of ongoing operation. Currently this property is only valid when the update is in the Downloading state, where it maps to how much of the update content has been downloaded. </param>
        /// <param name="notifyMessage"> Brief message with instructions for updates of AvailabilityType Notify. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UpdateData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, AzureLocation? location, HciProvisioningState? provisioningState, DateTimeOffset? installedOn, string description, HciUpdateState? state, IList<UpdatePrerequisite> prerequisites, IList<HciPackageVersionInfo> componentVersions, HciNodeRebootRequirement? rebootRequired, HciHealthState? healthState, IList<HciPrecheckResult> healthCheckResult, DateTimeOffset? healthCheckOn, string packagePath, float? packageSizeInMb, string displayName, string version, string publisher, string releaseLink, HciAvailabilityType? availabilityType, string packageType, string additionalProperties, float? progressPercentage, string notifyMessage, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            ProvisioningState = provisioningState;
            InstalledOn = installedOn;
            Description = description;
            State = state;
            Prerequisites = prerequisites;
            ComponentVersions = componentVersions;
            RebootRequired = rebootRequired;
            HealthState = healthState;
            HealthCheckResult = healthCheckResult;
            HealthCheckOn = healthCheckOn;
            PackagePath = packagePath;
            PackageSizeInMb = packageSizeInMb;
            DisplayName = displayName;
            Version = version;
            Publisher = publisher;
            ReleaseLink = releaseLink;
            AvailabilityType = availabilityType;
            PackageType = packageType;
            AdditionalProperties = additionalProperties;
            ProgressPercentage = progressPercentage;
            NotifyMessage = notifyMessage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal UpdateData(HciClusterUpdateData data) : base(data.Id, data.Name, data.ResourceType, data.SystemData)
        {
            Location = data.Location;
            ProvisioningState = data.ProvisioningState;
            InstalledOn = data.InstalledOn;
            Description = data.Description;
            State = data.State;
            Prerequisites = new ChangeTrackingList<UpdatePrerequisite>();
            foreach (var element in data.Prerequisites)
            {
                Prerequisites.Add(new UpdatePrerequisite(element));
            }
            ComponentVersions = data.ComponentVersions;
            RebootRequired = data.RebootRequired;
            HealthState = data.HealthState;
            HealthCheckResult = data.HealthCheckResult;
            HealthCheckOn = data.HealthCheckOn;
            PackagePath = data.PackagePath;
            PackageSizeInMb = data.PackageSizeInMb;
            DisplayName = data.DisplayName;
            Version = data.Version;
            Publisher = data.Publisher;
            ReleaseLink = data.ReleaseLink;
            AvailabilityType = data.AvailabilityType;
            PackageType = data.PackageType;
            AdditionalProperties = data.AdditionalProperties;
            ProgressPercentage = data.ProgressPercentage;
            NotifyMessage = data.NotifyMessage;
            _serializedAdditionalRawData = null;
        }

        internal HciClusterUpdateData ToHciClusterUpdateData()
        {
            var prerequisites = new ChangeTrackingList<HciClusterUpdatePrerequisite>();
            foreach (var element in Prerequisites)
            {
                prerequisites.Add(element.ToHciClusterUpdatePrerequisite());
            }
            HciClusterUpdateData data = new HciClusterUpdateData(Id, Name, ResourceType, SystemData,
                Location,
                ProvisioningState,
                InstalledOn,
                Description,
                default,
                State,
                prerequisites,
                ComponentVersions,
                RebootRequired,
                HealthState,
                HealthCheckResult,
                HealthCheckOn,
                PackagePath,
                PackageSizeInMb,
                DisplayName,
                Version,
                Publisher,
                ReleaseLink,
                AvailabilityType,
                PackageType,
                AdditionalProperties,
                ProgressPercentage,
                NotifyMessage,
                _serializedAdditionalRawData
            );

            return data;
        }

        /// <summary> The geo-location where the resource lives. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> Provisioning state of the Updates proxy resource. </summary>
        public HciProvisioningState? ProvisioningState { get; }
        /// <summary> Date that the update was installed. </summary>
        public DateTimeOffset? InstalledOn { get; set; }
        /// <summary> Description of the update. </summary>
        public string Description { get; set; }
        /// <summary> State of the update as it relates to this stamp. </summary>
        public HciUpdateState? State { get; set; }
        /// <summary> If update State is HasPrerequisite, this property contains an array of objects describing prerequisite updates before installing this update. Otherwise, it is empty. </summary>
        public IList<UpdatePrerequisite> Prerequisites { get; }
        /// <summary> An array of component versions for a Solution Bundle update, and an empty array otherwise.  </summary>
        public IList<HciPackageVersionInfo> ComponentVersions { get; }
        /// <summary> Gets or sets the reboot required. </summary>
        public HciNodeRebootRequirement? RebootRequired { get; set; }
        /// <summary> Overall health state for update-specific health checks. </summary>
        public HciHealthState? HealthState { get; set; }
        /// <summary> An array of PrecheckResult objects. </summary>
        public IList<HciPrecheckResult> HealthCheckResult { get; }
        /// <summary> Last time the package-specific checks were run. </summary>
        public DateTimeOffset? HealthCheckOn { get; set; }
        /// <summary> Path where the update package is available. </summary>
        public string PackagePath { get; set; }
        /// <summary> Size of the package. This value is a combination of the size from update metadata and size of the payload that results from the live scan operation for OS update content. </summary>
        public float? PackageSizeInMb { get; set; }
        /// <summary> Display name of the Update. </summary>
        public string DisplayName { get; set; }
        /// <summary> Version of the update. </summary>
        public string Version { get; set; }
        /// <summary> Publisher of the update package. </summary>
        public string Publisher { get; set; }
        /// <summary> Link to release notes for the update. </summary>
        public string ReleaseLink { get; set; }
        /// <summary> Indicates the way the update content can be downloaded. </summary>
        public HciAvailabilityType? AvailabilityType { get; set; }
        /// <summary> Customer-visible type of the update. </summary>
        public string PackageType { get; set; }
        /// <summary> Extensible KV pairs serialized as a string. This is currently used to report the stamp OEM family and hardware model information when an update is flagged as Invalid for the stamp based on OEM type. </summary>
        public string AdditionalProperties { get; set; }
        /// <summary> Progress percentage of ongoing operation. Currently this property is only valid when the update is in the Downloading state, where it maps to how much of the update content has been downloaded. </summary>
        public float? ProgressPercentage { get; set; }
        /// <summary> Brief message with instructions for updates of AvailabilityType Notify. </summary>
        public string NotifyMessage { get; set; }
    }
}
