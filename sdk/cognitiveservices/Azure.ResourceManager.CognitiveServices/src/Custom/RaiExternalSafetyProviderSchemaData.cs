// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.CognitiveServices
{
    public partial class RaiExternalSafetyProviderSchemaData : ResourceData
    {
        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }        // The tags property is read-only in TypeSpec, but this property should be settable for a resource data model. This is a workaround to allow the property to be settable in the generated code while still being read-only in TypeSpec.
    }
}
