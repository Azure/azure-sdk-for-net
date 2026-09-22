// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MultiServiceSharedModels.Combined.Mocking
{
    // Shorten the generated type and file name to keep the repository path within the Windows
    // 260-character limit. This follows the customization pattern used by the service-group fixture.
    [CodeGenType("MockableMultiServiceSharedModelsCombinedResourceGroupResource")]
    public partial class MockableMultiServiceSharedModelsResourceGroupResource
    {
    }
}
