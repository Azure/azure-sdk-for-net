// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects
{
    /// <summary>
    /// Options for managing data generation jobs.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="SimpleQnADataGenerationJobOptions"/>, <see cref="TracesDataGenerationJobOptions"/>, and <see cref="ToolUseFineTuningDataGenerationJobOptions"/>.
    /// </summary>
    [Experimental("AAIP001")]
    public abstract partial class DataGenerationJobOptions
    {
    }
}
