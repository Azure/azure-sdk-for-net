// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.Attestation
{
    /// <summary>
    /// The TCB baselines available to an attestation provider for an attestation type.
    /// </summary>
    // Makes the generated model public, for GetTcbBaselines, with a read-only list; the generator emits the accessibility declared here.
    [CodeGenType("TcbBaselineResult")]
    public partial class TcbBaselineResult
    {
        /// <summary>
        /// Gets the available TCB baselines.
        /// </summary>
        public IReadOnlyList<TcbBaseline> TcbBaselines { get; }
    }
}
