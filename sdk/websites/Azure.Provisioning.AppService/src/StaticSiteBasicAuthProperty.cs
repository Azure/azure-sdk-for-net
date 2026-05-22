// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.AppService;

public partial class StaticSiteBasicAuthProperty
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        "default";
}
