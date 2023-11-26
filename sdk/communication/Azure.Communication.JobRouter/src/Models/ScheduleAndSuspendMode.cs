// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ScheduleAndSuspendMode : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ScheduleAndSuspendMode. </summary>
        /// <param name="scheduleAt"> Requested schedule time. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scheduleAt"/> is null. </exception>
        public ScheduleAndSuspendMode(DateTimeOffset scheduleAt) : this(JobMatchingModeKind.ScheduleAndSuspend, new Dictionary<string, BinaryData>(), scheduleAt)
        {
            Argument.AssertNotNull(scheduleAt, nameof(scheduleAt));
        }

        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ScheduleAt))
            {
                writer.WritePropertyName("scheduleAt"u8);
                writer.WriteStringValue(ScheduleAt, "O");
            }

            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());

            writer.WriteEndObject();
        }
    }
}
