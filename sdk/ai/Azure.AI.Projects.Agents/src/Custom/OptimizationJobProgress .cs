// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects.Agents;

public partial class OptimizationJobProgress
{
    [CodeGenMember("ElapsedSeconds")]
    internal double ElapsedSecondsInternal { get;}

    /// <summary> Wall-clock time elapsed in seconds since the job began executing. </summary>
    public TimeSpan ElapsedSeconds { get => TimeSpan.FromSeconds(ElapsedSecondsInternal); }
}
