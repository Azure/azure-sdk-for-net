// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: old API used UnknownRecurrence as PersistableModelProxy target.

#nullable disable

#pragma warning disable CS0612, CS0618, CS0619

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownRecurrence : AlertProcessingRuleRecurrence
    {
    }
}

#pragma warning restore CS0612, CS0618, CS0619
