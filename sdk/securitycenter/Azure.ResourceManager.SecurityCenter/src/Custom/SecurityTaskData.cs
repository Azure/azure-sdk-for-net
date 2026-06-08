// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [CodeGenSuppress("SecurityTaskData")]
    [CodeGenSuppress("SecurityTaskParameters")]
    public partial class SecurityTaskData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityTaskData"/>. </summary>
        public SecurityTaskData()
        {
        }

        /// <summary> Changing set of properties, depending on the task type that is derived from the name field. </summary>
        public SecurityTaskProperties SecurityTaskParameters
        {
            get => Properties is null ? default : Properties.SecurityTaskParameters;
            // Compatibility shim: the legacy flattened property had a public setter, but the TypeSpec
            // backing model is read-only. Preserve the API shape without silently mutating nothing.
            set => throw new InvalidOperationException($"{nameof(SecurityTaskParameters)} is read-only.");
        }
    }
}
