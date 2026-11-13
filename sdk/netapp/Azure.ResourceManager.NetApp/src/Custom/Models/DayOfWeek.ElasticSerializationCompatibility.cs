// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.NetApp.Models
{
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
}
