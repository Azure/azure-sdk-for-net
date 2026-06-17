// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Reservations.Models
{
    // Justification: GA exposed PolicyErrors as IReadOnlyList<ExchangePolicyError>. The new
    // generator emits IList<T> for the inner ExchangePolicyErrors envelope; this shim restores
    // the GA read-only collection surface.
    public partial class ExchangeResultProperties
    {
        /// <summary> Exchange Policy errors. </summary>
        public IReadOnlyList<ExchangePolicyError> PolicyErrors
        {
            get
            {
                return PolicyResult?.PolicyErrors as IReadOnlyList<ExchangePolicyError>;
            }
        }
    }
}
