// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Job stages. </summary>
    public partial class DataBoxJobStage
    {
        /// <summary> Time for the job stage in UTC ISO 8601 format. </summary>
        /// without it code generator will rename StageTime to StageOn causing breaking change
        [Microsoft.TypeSpec.Generator.Customizations.CodeGenMember("StageOn")]
        public DateTimeOffset? StageTime { get; }
    }
}
