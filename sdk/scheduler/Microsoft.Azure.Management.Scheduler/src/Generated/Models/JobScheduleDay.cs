// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobScheduleDay.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobScheduleDay
    {
        [EnumMember(Value = "Monday")]
        Monday,
        [EnumMember(Value = "Tuesday")]
        Tuesday,
        [EnumMember(Value = "Wednesday")]
        Wednesday,
        [EnumMember(Value = "Thursday")]
        Thursday,
        [EnumMember(Value = "Friday")]
        Friday,
        [EnumMember(Value = "Saturday")]
        Saturday,
        [EnumMember(Value = "Sunday")]
        Sunday
    }
}
