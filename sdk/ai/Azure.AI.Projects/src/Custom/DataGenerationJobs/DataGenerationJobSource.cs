// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects
{
    /// <summary>
    /// The base source model for data generation jobs.
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="PromptDataGenerationJobSource"/>, <see cref="AgentDataGenerationJobSource"/>, <see cref="TracesDataGenerationJobSource"/>, <see cref="DatasetDataGenerationJobSource"/>, and <see cref="FileDataGenerationJobSource"/>.
    /// </summary>
    [Experimental("AAIP001")]
    public abstract partial class DataGenerationJobSource
    {
    }
}
