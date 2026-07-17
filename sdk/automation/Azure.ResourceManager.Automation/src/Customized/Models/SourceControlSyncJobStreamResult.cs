// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // GA exposed Value as IReadOnlyDictionary<string, BinaryData>. The TypeSpec generator now emits
    // IDictionary<string, BinaryData> for the underlying record shape, which is expected; keep the
    // generated mutable properties model and restore the GA read-only wrapper surface in custom code.
    public partial class SourceControlSyncJobStreamResult
    {
        /// <summary> The values of the job stream. </summary>
        [CodeGenMember("Value")]
        public IReadOnlyDictionary<string, BinaryData> Value =>
            Properties?.Value as IReadOnlyDictionary<string, BinaryData>;
    }
}