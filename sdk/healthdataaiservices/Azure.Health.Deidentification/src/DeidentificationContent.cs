// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Health.Deidentification
{
    /// <summary> Request for synchronous De-Identify operation. </summary>
    public partial class DeidentificationContent
    {
        internal StringIndexType StringIndexType { get; } = StringIndexType.Utf16CodeUnit;
    }
}
