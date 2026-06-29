// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Kusto;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Kusto.Models
{
    // GA had a public parameterless constructor,
    // but the generator emits the parameterless ctor as internal (deserialization-only) and only
    // a public (value) ctor. Suppress the generated internal parameterless ctor and provide the public one.
    public partial class CalloutPoliciesList
    {
        /// <summary> Initializes a new instance of <see cref="CalloutPoliciesList"/>. </summary>
        public CalloutPoliciesList()
        {
            Value = new ChangeTrackingList<KustoCalloutPolicy>();
        }
    }
}
