// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden compatibility shim does not need public docs.

namespace Azure.ResourceManager.SecurityCenter.Models
{
    public partial class SecuritySolution
    {
        public SecuritySolution() { }
        public SecurityFamily? SecurityFamily { get; set; }
        public SecurityFamilyProvisioningState? ProvisioningState { get; set; }
        public string Template { get; set; }
        public string ProtectionStatus { get; set; }
    }
}
