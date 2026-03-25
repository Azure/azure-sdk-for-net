// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: old API used UnknownAction as PersistableModelProxy target.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AlertsManagement.Models
{
    [Obsolete("This type is no longer supported.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal partial class UnknownAction : AlertProcessingRuleAction
    {
    }
}
