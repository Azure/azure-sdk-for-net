// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterResourceGroupResource
    {
        [ForwardsClientCalls]
        public virtual Response<ResourceGroupSecurityAlertResource> GetResourceGroupSecurityAlert(AzureLocation ascLocation, string alertName, CancellationToken cancellationToken = default(CancellationToken))
            => GetResourceGroupSecurityAlert(ascLocation.ToString(), alertName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<ResourceGroupSecurityAlertResource>> GetResourceGroupSecurityAlertAsync(AzureLocation ascLocation, string alertName, CancellationToken cancellationToken = default(CancellationToken))
            => GetResourceGroupSecurityAlertAsync(ascLocation.ToString(), alertName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Response<ResourceGroupSecurityTaskResource> GetResourceGroupSecurityTask(AzureLocation ascLocation, string taskName, CancellationToken cancellationToken = default(CancellationToken))
            => GetResourceGroupSecurityTask(ascLocation.ToString(), taskName, cancellationToken);

        [ForwardsClientCalls]
        public virtual Task<Response<ResourceGroupSecurityTaskResource>> GetResourceGroupSecurityTaskAsync(AzureLocation ascLocation, string taskName, CancellationToken cancellationToken = default(CancellationToken))
            => GetResourceGroupSecurityTaskAsync(ascLocation.ToString(), taskName, cancellationToken);
    }
}
