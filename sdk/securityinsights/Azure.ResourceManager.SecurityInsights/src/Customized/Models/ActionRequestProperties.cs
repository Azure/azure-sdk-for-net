// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // The outer flattened TriggerUri setter needs the inner property to be mutable as well.
    [CodeGenSuppress("TriggerUri")]
    internal partial class ActionRequestProperties
    {
        /// <summary> Logic App Callback URL for this specific workflow. </summary>
        [WirePath("triggerUri")]
        public Uri TriggerUri { get; set; }
    }
}
