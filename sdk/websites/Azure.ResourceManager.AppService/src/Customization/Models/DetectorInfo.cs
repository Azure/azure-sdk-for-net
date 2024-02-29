// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class DetectorInfo
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by AnalysisTypeString", false)]
        public IReadOnlyList<string> AnalysisType { get; }
    }
}
