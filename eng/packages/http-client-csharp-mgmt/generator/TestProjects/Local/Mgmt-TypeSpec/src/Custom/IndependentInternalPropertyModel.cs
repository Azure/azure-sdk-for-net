// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Generator.MgmtTypeSpec.Tests.Models
{
    public partial class IndependentInternalPropertyModel
    {
        // Independent non-wire state, not a backing wrapper produced by flattening.
        internal string InternalState { get; set; }
    }
}