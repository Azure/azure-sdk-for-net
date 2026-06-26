// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Unknown polymorphic fallback classes are synthesized by the generator and have no TypeSpec symbols to decorate directly.
    // Map the generated fallback back to the GA name so PersistableModelProxyAttribute stays compatible.
    [CodeGenType("UnknownMachineLearningDatastoreCredentials")]
    internal partial class UnknownDatastoreCredentials { }
}
