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
    /// A class representing the UpdateRun data model.
    /// Details of an Update run
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="UpdateRunData"/>. </summary>
        public UpdateRunData()
        {
            Steps = new ChangeTrackingList<HciUpdateStep>();
        }

        /// <summary> Initializes a new instance of <see cref="UpdateRunData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of the UpdateRuns proxy resource. </param>
        /// <param name="timeStarted"> Timestamp of the update run was started. </param>
        /// <param name="lastUpdatedOn"> Timestamp of the most recently completed step in the update run. </param>
        /// <param name="duration"> Duration of the update run. </param>
        /// <param name="state"> State of the update run. </param>
        /// <param name="namePropertiesProgressName"> Name of the step. </param>
        /// <param name="description"> More detailed description of the step. </param>
        /// <param name="errorMessage"> Error message, specified if the step is in a failed state. </param>
        /// <param name="status"> Status of the step, bubbled up from the ECE action plan for installation attempts. Values are: 'Success', 'Error', 'InProgress', and 'Unknown status'. </param>
        /// <param name="startTimeUtc"> When the step started, or empty if it has not started executing. </param>
        /// <param name="endTimeUtc"> When the step reached a terminal state. </param>
        /// <param name="lastUpdatedTimeUtc"> Completion time of this step or the last completed sub-step. </param>
        /// <param name="steps"> Recursive model for child steps of this step. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UpdateRunData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, AzureLocation? location, HciProvisioningState? provisioningState, DateTimeOffset? timeStarted, DateTimeOffset? lastUpdatedOn, string duration, UpdateRunPropertiesState? state, string namePropertiesProgressName, string description, string errorMessage, string status, DateTimeOffset? startTimeUtc, DateTimeOffset? endTimeUtc, DateTimeOffset? lastUpdatedTimeUtc, IList<HciUpdateStep> steps, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            ProvisioningState = provisioningState;
            TimeStarted = timeStarted;
            LastUpdatedOn = lastUpdatedOn;
            Duration = duration;
            State = state;
            NamePropertiesProgressName = namePropertiesProgressName;
            Description = description;
            ErrorMessage = errorMessage;
            Status = status;
            StartTimeUtc = startTimeUtc;
            EndTimeUtc = endTimeUtc;
            LastUpdatedTimeUtc = lastUpdatedTimeUtc;
            Steps = steps;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal UpdateRunData(HciClusterUpdateRunData data) : base(data.Id, data.Name, data.ResourceType, data.SystemData)
        {
            Location = data.Location;
            ProvisioningState = data.ProvisioningState;
            TimeStarted = data.TimeStarted;
            LastUpdatedOn = data.LastUpdatedOn;
            Duration = data.Duration;
            State = data.State;
            NamePropertiesProgressName = data.NamePropertiesProgressName;
            Description = data.Description;
            ErrorMessage = data.ErrorMessage;
            Status = data.Status;
            StartTimeUtc = data.StartOn;
            EndTimeUtc = data.EndOn;
            LastUpdatedTimeUtc = data.LastCompletedOn;
            Steps = data.Steps;
            _serializedAdditionalRawData = null;
        }

        internal HciClusterUpdateRunData ToHciClusterUpdateRunData()
        {
            return new HciClusterUpdateRunData(Id, Name, ResourceType, SystemData, Location, ProvisioningState, TimeStarted, LastUpdatedOn, Duration, State, NamePropertiesProgressName, Description,
                ErrorMessage, Status, StartTimeUtc, EndTimeUtc, LastUpdatedTimeUtc, default, Steps, _serializedAdditionalRawData);
        }

        /// <summary> The geo-location where the resource lives. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> Provisioning state of the UpdateRuns proxy resource. </summary>
        public HciProvisioningState? ProvisioningState { get; }
        /// <summary> Timestamp of the update run was started. </summary>
        public DateTimeOffset? TimeStarted { get; set; }
        /// <summary> Timestamp of the most recently completed step in the update run. </summary>
        public DateTimeOffset? LastUpdatedOn { get; set; }
        /// <summary> Duration of the update run. </summary>
        public string Duration { get; set; }
        /// <summary> State of the update run. </summary>
        public UpdateRunPropertiesState? State { get; set; }
        /// <summary> Name of the step. </summary>
        public string NamePropertiesProgressName { get; set; }
        /// <summary> More detailed description of the step. </summary>
        public string Description { get; set; }
        /// <summary> Error message, specified if the step is in a failed state. </summary>
        public string ErrorMessage { get; set; }
        /// <summary> Status of the step, bubbled up from the ECE action plan for installation attempts. Values are: 'Success', 'Error', 'InProgress', and 'Unknown status'. </summary>
        public string Status { get; set; }
        /// <summary> When the step started, or empty if it has not started executing. </summary>
        public DateTimeOffset? StartTimeUtc { get; set; }
        /// <summary> When the step reached a terminal state. </summary>
        public DateTimeOffset? EndTimeUtc { get; set; }
        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        public DateTimeOffset? LastUpdatedTimeUtc { get; set; }
        /// <summary> Recursive model for child steps of this step. </summary>
        public IList<HciUpdateStep> Steps { get; }
    }
}
