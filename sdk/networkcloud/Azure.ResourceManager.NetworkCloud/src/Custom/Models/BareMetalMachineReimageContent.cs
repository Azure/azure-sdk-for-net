// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    /// <summary> BareMetalMachineReimageContent represents the body of the request to reimage a bare metal machine. </summary>
    /// <remarks>
    /// This class is renamed from the TypeSpec-generated name "BareMetalMachineReimageParameters" to "BareMetalMachineReimageContent"
    /// to comply with Azure SDK management plane naming conventions, which require request body types for POST/action operations
    /// to use the "*Content" suffix instead of "*Parameters".
    /// </remarks>
    [CodeGenType("BareMetalMachineReimageParameters")]
    public partial class BareMetalMachineReimageContent
    {
    }
}
