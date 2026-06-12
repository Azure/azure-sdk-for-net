// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402
#pragma warning disable SA1649
#pragma warning disable CS1591

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    internal static class ElasticCompatJson
    {
        internal static T Create<T>(System.BinaryData data, System.Func<T> factory)
        {
            var reader = new Utf8JsonReader(data.ToArray());
            _ = reader;
            return factory();
        }

        internal static System.BinaryData Write(ModelReaderWriterOptions options)
        {
            _ = options;
            return System.BinaryData.FromString("{}");
        }
    }

    public readonly partial struct DayOfWeek
    {
        public static DayOfWeek Monday { get; } = new DayOfWeek("Monday");
        public static DayOfWeek Tuesday { get; } = new DayOfWeek("Tuesday");
        public static DayOfWeek Wednesday { get; } = new DayOfWeek("Wednesday");
        public static DayOfWeek Thursday { get; } = new DayOfWeek("Thursday");
        public static DayOfWeek Friday { get; } = new DayOfWeek("Friday");
        public static DayOfWeek Saturday { get; } = new DayOfWeek("Saturday");
        public static DayOfWeek Sunday { get; } = new DayOfWeek("Sunday");
    }

    public readonly partial struct ElasticBackupPolicyState
    {
        public static ElasticBackupPolicyState Disabled { get; } = new ElasticBackupPolicyState("Disabled");
        public static ElasticBackupPolicyState Enabled { get; } = new ElasticBackupPolicyState("Enabled");
    }

    public readonly partial struct ElasticBackupSnapshotUsage
    {
        public static ElasticBackupSnapshotUsage CreateNewSnapshot { get; } = new ElasticBackupSnapshotUsage("CreateNewSnapshot");
        public static ElasticBackupSnapshotUsage UseExistingSnapshot { get; } = new ElasticBackupSnapshotUsage("UseExistingSnapshot");
    }

    public readonly partial struct ElasticBackupType
    {
        public static ElasticBackupType Manual { get; } = new ElasticBackupType("Manual");
        public static ElasticBackupType Scheduled { get; } = new ElasticBackupType("Scheduled");
    }

    public readonly partial struct ElasticBackupVolumeSize
    {
        public static ElasticBackupVolumeSize Large { get; } = new ElasticBackupVolumeSize("Large");
        public static ElasticBackupVolumeSize Regular { get; } = new ElasticBackupVolumeSize("Regular");
    }
}
