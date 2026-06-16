// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.Core;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    /// <summary> Replaces the generated service-defined base with the framework tracked resource base. </summary>
    public partial class CustomBaseTypeInheritedResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="CustomBaseTypeInheritedResourceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public CustomBaseTypeInheritedResourceData(AzureLocation location) : base(location)
        {
        }
    }
}
