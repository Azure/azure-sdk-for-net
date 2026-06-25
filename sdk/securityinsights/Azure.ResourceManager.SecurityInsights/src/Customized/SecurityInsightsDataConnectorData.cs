// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights
{
    // Workaround for https://github.com/microsoft/typespec/issues/10996: TypeSpec generation exposes the discriminated base constructor publicly; keep the previously shipped parameterless constructor instead.
    [CodeGenSuppress("SecurityInsightsDataConnectorData")]
    [CodeGenSuppress("SecurityInsightsDataConnectorData", typeof(DataConnectorKind))]
    public partial class SecurityInsightsDataConnectorData
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsDataConnectorData"/>. </summary>
        public SecurityInsightsDataConnectorData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsDataConnectorData"/>. </summary>
        /// <param name="kind"> The kind of the data connector. </param>
        private protected SecurityInsightsDataConnectorData(DataConnectorKind kind)
        {
            Kind = kind;
        }
    }
}