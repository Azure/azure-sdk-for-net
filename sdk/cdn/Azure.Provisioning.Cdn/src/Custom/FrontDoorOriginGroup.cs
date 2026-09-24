// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Cdn;

public partial class FrontDoorOriginGroup
{
    // The service constraint is documented but absent from TypeSpec/OpenAPI; see https://github.com/Azure/azure-sdk-for-net/issues/63274.
    /// <inheritdoc />
    public override ResourceNameRequirements GetResourceNameRequirements() =>
        new(1, 50, ResourceNameCharacters.LowercaseLetters | ResourceNameCharacters.UppercaseLetters | ResourceNameCharacters.Numbers | ResourceNameCharacters.Hyphen);
}
