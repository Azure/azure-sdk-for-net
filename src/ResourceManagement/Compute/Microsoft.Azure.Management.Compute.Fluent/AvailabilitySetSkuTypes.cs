// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// Defines values for AvailabilitySetSkuTypes.
    /// </summary>
    public class AvailabilitySetSkuTypes : ExpandableStringEnum<AvailabilitySetSkuTypes>
    {
        public static readonly AvailabilitySetSkuTypes Aligned = Parse("Aligned");
        public static readonly AvailabilitySetSkuTypes Classic = Parse("Classic");
    }
}
