// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: old API used UnknownRecurrence as PersistableModelProxy target.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    [Obsolete("The AlertProcessingRule types have been removed from this package and will be shipped in a separate package in a future release.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownRecurrence : AlertProcessingRuleRecurrence
    {
    }
}
