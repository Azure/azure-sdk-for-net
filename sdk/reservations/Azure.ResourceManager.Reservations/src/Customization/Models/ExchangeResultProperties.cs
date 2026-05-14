// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Justification: GA exposed PolicyErrors as IReadOnlyList<ExchangePolicyError>. See the
// CalculateExchangeResultProperties customization for the matching pattern.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS1591

namespace Azure.ResourceManager.Reservations.Models
{
    [CodeGenSuppress("PolicyErrors")]
    public partial class ExchangeResultProperties
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
