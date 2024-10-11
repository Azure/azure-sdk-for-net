// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CloudMachine;

public abstract class CloudMachineFeature
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract void AddTo(CloudMachineInfrastructure cm);
}
