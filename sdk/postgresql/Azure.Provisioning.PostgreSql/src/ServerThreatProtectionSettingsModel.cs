// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.PostgreSql;

public partial class ServerThreatProtectionSettingsModel
{
    private partial BicepValue<string> GetNameDefaultValue() =>
        "Default";
}
