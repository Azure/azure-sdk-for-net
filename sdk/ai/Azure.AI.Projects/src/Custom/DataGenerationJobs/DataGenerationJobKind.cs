// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects
{
    /// <summary> The supported data generation job types. </summary>
    [Experimental("AAIP001")]
    public readonly partial struct DataGenerationJobKind : IEquatable<DataGenerationJobKind>
    {
    }
}
