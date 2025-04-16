// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> binary hardening analysis result resource. </summary>
    public partial class BinaryHardeningResult
    {
        /// <summary> Initializes a new instance of <see cref="BinaryHardeningResult"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryHardeningResult()
        {
        }
        /// <summary>
        /// The architecture of the binary being reported on.
        /// Serialized Name: BinaryHardeningResource.properties.architecture
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Architecture
        {
            get => ExecutableArchitecture;
            set => ExecutableArchitecture = value;
        }
        /// <summary>
        /// The executable class to indicate 32 or 64 bit.
        /// Serialized Name: BinaryHardeningResource.properties.class
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Class
        {
            get => ExecutableClass.ToString();
            set => ExecutableClass = value;
        }
        /// <summary> NX (no-execute) flag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? NXFlag
        {
            get => SecurityHardeningFeatures?.NoExecute;
            set
            {
                SecurityHardeningFeatures ??= new();
                SecurityHardeningFeatures.NoExecute = value;
            }
        }
        /// <summary> PIE (position independent executable) flag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PieFlag
        {
            get => SecurityHardeningFeatures?.PositionIndependentExecutable;
            set
            {
                SecurityHardeningFeatures ??= new();
                SecurityHardeningFeatures.PositionIndependentExecutable = value;
            }
        }
        /// <summary> RELRO (relocation read-only) flag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? RelroFlag
        {
            get => SecurityHardeningFeatures?.RelocationReadOnly;
            set
            {
                SecurityHardeningFeatures ??= new();
                SecurityHardeningFeatures.RelocationReadOnly = value;
            }
        }
        /// <summary> Canary (stack canaries) flag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? CanaryFlag
        {
            get => SecurityHardeningFeatures?.Canary;
            set
            {
                SecurityHardeningFeatures ??= new();
                SecurityHardeningFeatures.Canary = value;
            }
        }
        /// <summary> Stripped flag. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? StrippedFlag
        {
            get => SecurityHardeningFeatures?.Stripped;
            set
            {
                SecurityHardeningFeatures ??= new();
                SecurityHardeningFeatures.Stripped = value;
            }
        }
    }
}
