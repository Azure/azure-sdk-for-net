// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed PolicyErrors as IReadOnlyList<ExchangePolicyError>. The new
// generator emits IList<T> for the inner ExchangePolicyErrors envelope; this shim restores
// the GA read-only collection surface.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("PolicyErrors")]
    public partial class CalculateExchangeResultProperties
    {
        public IReadOnlyList<ExchangePolicyError> PolicyErrors
        {
            get
            {
                return PolicyResult is null ? default : (IReadOnlyList<ExchangePolicyError>)PolicyResult.PolicyErrors;
            }
        }
    }
}
