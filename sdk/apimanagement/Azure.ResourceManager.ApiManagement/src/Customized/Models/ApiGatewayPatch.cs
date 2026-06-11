// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement.Models
{
    // MPG generator bug: combining `@@Legacy.hierarchyBuilding(<Patch>, Foundations.ProxyResource)`
    // with a flattened `tags` field emits two `[WirePath("tags")]` attributes on the same
    // property, producing CS0579 (Duplicate 'WirePath' attribute). Suppress the generated
    // `Tags` property and re-declare it once with a single `[WirePath("tags")]`. Tracked at
    // https://github.com/Azure/azure-sdk-for-net/issues/59545.
    [CodeGenSuppress("Tags")]
    public partial class ApiGatewayPatch
    {
        /// <summary> Resource tags. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; }
    }
}
