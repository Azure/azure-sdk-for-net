// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Process Thread Information. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ProcessThreadInfo : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="ProcessThreadInfo"/>. </summary>
        public ProcessThreadInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ProcessThreadInfo"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identifier"> Site extension ID. </param>
        /// <param name="href"> HRef URI. </param>
        /// <param name="process"> Process URI. </param>
        /// <param name="startAddress"> Start address. </param>
        /// <param name="currentPriority"> Current thread priority. </param>
        /// <param name="priorityLevel"> Thread priority level. </param>
        /// <param name="basePriority"> Base priority. </param>
        /// <param name="startOn"> Start time. </param>
        /// <param name="totalProcessorTime"> Total processor time. </param>
        /// <param name="userProcessorTime"> User processor time. </param>
        /// <param name="state"> Thread state. </param>
        /// <param name="waitReason"> Wait reason. </param>
        /// <param name="kind"> Kind of resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ProcessThreadInfo(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? identifier, string href, string process, string startAddress, int? currentPriority, string priorityLevel, int? basePriority, DateTimeOffset? startOn, string totalProcessorTime, string userProcessorTime, string state, string waitReason, string kind, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Identifier = identifier;
            Href = href;
            Process = process;
            StartAddress = startAddress;
            CurrentPriority = currentPriority;
            PriorityLevel = priorityLevel;
            BasePriority = basePriority;
            StartOn = startOn;
            TotalProcessorTime = totalProcessorTime;
            UserProcessorTime = userProcessorTime;
            State = state;
            WaitReason = waitReason;
            Kind = kind;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ProcessThreadInfo"/>. </summary>
        /// <param name="webAppProcessThreadInfo"> The instance of WebAppProcessThreadInfo. </param>
        internal ProcessThreadInfo(WebAppProcessThreadInfo webAppProcessThreadInfo)
        {
            Identifier = webAppProcessThreadInfo.Properties.Id;
            Href = webAppProcessThreadInfo.Properties.Href.AbsolutePath;
            Process = default;
            StartAddress = default;
            CurrentPriority = default;
            PriorityLevel = default;
            BasePriority = default;
            StartOn = default;
            TotalProcessorTime = default;
            UserProcessorTime = default;
            State = webAppProcessThreadInfo.Properties.State;
            WaitReason = default;
            Kind = default;
            _serializedAdditionalRawData = default;
        }

        /// <summary> Site extension ID. </summary>
        [WirePath("properties.identifier")]
        public int? Identifier { get; }
        /// <summary> HRef URI. </summary>
        [WirePath("properties.href")]
        public string Href { get; set; }
        /// <summary> Process URI. </summary>
        [WirePath("properties.process")]
        public string Process { get; set; }
        /// <summary> Start address. </summary>
        [WirePath("properties.start_address")]
        public string StartAddress { get; set; }
        /// <summary> Current thread priority. </summary>
        [WirePath("properties.current_priority")]
        public int? CurrentPriority { get; set; }
        /// <summary> Thread priority level. </summary>
        [WirePath("properties.priority_level")]
        public string PriorityLevel { get; set; }
        /// <summary> Base priority. </summary>
        [WirePath("properties.base_priority")]
        public int? BasePriority { get; set; }
        /// <summary> Start time. </summary>
        [WirePath("properties.start_time")]
        public DateTimeOffset? StartOn { get; set; }
        /// <summary> Total processor time. </summary>
        [WirePath("properties.total_processor_time")]
        public string TotalProcessorTime { get; set; }
        /// <summary> User processor time. </summary>
        [WirePath("properties.user_processor_time")]
        public string UserProcessorTime { get; set; }
        /// <summary> Thread state. </summary>
        [WirePath("properties.state")]
        public string State { get; set; }
        /// <summary> Wait reason. </summary>
        [WirePath("properties.wait_reason")]
        public string WaitReason { get; set; }
        /// <summary> Kind of resource. </summary>
        [WirePath("kind")]
        public string Kind { get; set; }
    }
}
