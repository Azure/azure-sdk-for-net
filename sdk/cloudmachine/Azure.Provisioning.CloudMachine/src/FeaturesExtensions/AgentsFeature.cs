// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using System;
using Azure.Projects;

namespace Azure.AI.Agents;

public class AgentsFeature : AzureProjectFeature
{
    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        throw new NotImplementedException();
    }
}
