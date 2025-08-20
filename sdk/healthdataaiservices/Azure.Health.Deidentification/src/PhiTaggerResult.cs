// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Health.Deidentification
{
    public partial class PhiTaggerResult
    {
        /// <summary> List of entities detected in the input. </summary>
        public IReadOnlyList<PhiEntity> Entities { get; }
    }
}
