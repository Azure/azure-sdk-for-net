// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.CloudMachine;

public abstract class CloudMachineFeature
{
    public abstract void AddTo(CloudMachineInfrastructure cm);
}
