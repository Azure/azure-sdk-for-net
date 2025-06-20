// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Compute.Batch
{
    /// <summary> Parameters for updating an Azure Batch Job Schedule. </summary>
    public partial class BatchJobScheduleUpdateOptions
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

        /// <summary> Initializes a new instance of <see cref="BatchJobScheduleUpdateOptions"/>. </summary>
        public BatchJobScheduleUpdateOptions()
        {
            Metadata = new ChangeTrackingList<BatchMetadataItem>();
        }

        /// <summary> Initializes a new instance of <see cref="BatchJobScheduleUpdateOptions"/>. </summary>
        /// <param name="schedule"> The schedule according to which Jobs will be created. All times are fixed respective to UTC and are not impacted by daylight saving time. If you do not specify this element, the existing schedule is left unchanged. </param>
        /// <param name="jobSpecification"> The details of the Jobs to be created on this schedule. Updates affect only Jobs that are started after the update has taken place. Any currently active Job continues with the older specification. </param>
        /// <param name="metadata"> A list of name-value pairs associated with the Job Schedule as metadata. If you do not specify this element, existing metadata is left unchanged. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BatchJobScheduleUpdateOptions(BatchJobScheduleConfiguration schedule, BatchJobSpecification jobSpecification, IList<BatchMetadataItem> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Schedule = schedule;
            JobSpecification = jobSpecification;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The schedule according to which Jobs will be created. All times are fixed respective to UTC and are not impacted by daylight saving time. If you do not specify this element, the existing schedule is left unchanged. </summary>
        public BatchJobScheduleConfiguration Schedule { get; set; }
        /// <summary> The details of the Jobs to be created on this schedule. Updates affect only Jobs that are started after the update has taken place. Any currently active Job continues with the older specification. </summary>
        public BatchJobSpecification JobSpecification { get; set; }
        /// <summary> A list of name-value pairs associated with the Job Schedule as metadata. If you do not specify this element, existing metadata is left unchanged. </summary>
        public IList<BatchMetadataItem> Metadata { get; }
    }
}
