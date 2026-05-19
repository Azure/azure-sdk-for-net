// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Reservations.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations
{
    // Justification: GA exposed QuotaRequestDetailData.QuotaRequestValue as
    // IReadOnlyList<SubContent>. The new generator emits IList<SubContent> via the flattened
    // QuotaRequestProperties; this shim restores the read-only collection surface.
    [CodeGenSuppress("QuotaRequestValue")]
    public partial class QuotaRequestDetailData
    {
        public IReadOnlyList<SubContent> QuotaRequestValue
        {
            get
            {
                return Properties is null ? default : (IReadOnlyList<SubContent>)Properties.QuotaRequestValue;
            }
        }
    }
}
