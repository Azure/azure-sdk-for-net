// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("JobMatchingMode")]
    [CodeGenSuppress("JobMatchingMode")]
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class JobMatchingMode
    {
        /// <summary> Gets or sets the mode type. </summary>
        public JobMatchModeType? ModeType { get; internal set; }

        /// <summary>
        /// Constructor for QueueAndMatchMode.
        /// </summary>
        /// <param name="queueAndMatchMode"></param>
        public JobMatchingMode(QueueAndMatchMode queueAndMatchMode)
            : this(JobMatchModeType.QueueAndMatchMode, new Dictionary<string, object>(), null, null)
        {
            QueueAndMatchMode = queueAndMatchMode;
        }

        /// <summary>
        /// Constructor for ScheduleAndSuspendMode.
        /// </summary>
        /// <param name="scheduleAndSuspendMode"></param>
        public JobMatchingMode(ScheduleAndSuspendMode scheduleAndSuspendMode)
            : this(JobMatchModeType.ScheduleAndSuspendMode, null, scheduleAndSuspendMode, null)
        {
        }

        /// <summary>
        /// Constructor for SuspendMode.
        /// </summary>
        /// <param name="suspendMode"></param>
        public JobMatchingMode(SuspendMode suspendMode)
            : this(JobMatchModeType.SuspendMode, null, null, new Dictionary<string, object>())
        {
            SuspendMode = suspendMode;
        }

        /// <summary> Any object. </summary>
        public QueueAndMatchMode QueueAndMatchMode { get; internal set; }

        [CodeGenMember("QueueAndMatchMode")]
        internal object _queueAndMatchMode {
            get
            {
                return QueueAndMatchMode != null ? new Dictionary<string, object>() : null;
            }
            set
            {
                QueueAndMatchMode = value != null ? new QueueAndMatchMode() : null;
            }
        }

        /// <summary> Any object. </summary>
        public SuspendMode SuspendMode { get; internal set; }

        [CodeGenMember("SuspendMode")]
        internal object _suspendMode
        {
            get
            {
                return SuspendMode != null ? new Dictionary<string, object>() : null;
            }
            set
            {
                SuspendMode = value != null ? new SuspendMode() : null;
            }
        }

        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ModeType))
            {
                writer.WritePropertyName("modeType"u8);
                writer.WriteStringValue(ModeType.Value.ToString());
            }
            if (Optional.IsDefined(_queueAndMatchMode))
            {
                writer.WritePropertyName("queueAndMatchMode"u8);
                writer.WriteObjectValue(_queueAndMatchMode);
            }
            else
            {
                writer.WritePropertyName("queueAndMatchMode"u8);
                writer.WriteNullValue();
            }

            if (Optional.IsDefined(ScheduleAndSuspendMode))
            {
                writer.WritePropertyName("scheduleAndSuspendMode"u8);
                writer.WriteObjectValue(ScheduleAndSuspendMode);
            }
            else
            {
                writer.WritePropertyName("scheduleAndSuspendMode"u8);
                writer.WriteNullValue();
            }

            if (Optional.IsDefined(_suspendMode))
            {
                writer.WritePropertyName("suspendMode"u8);
                writer.WriteObjectValue(_suspendMode);
            }
            else
            {
                writer.WritePropertyName("suspendMode"u8);
                writer.WriteNullValue();
            }
            writer.WriteEndObject();
        }
    }
}
