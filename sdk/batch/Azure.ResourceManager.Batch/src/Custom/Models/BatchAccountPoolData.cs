// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Batch
{
    // This custom property is needed because the TypeSpec code generator does not expose
    // DeploymentConfiguration as a public property on BatchAccountPoolData.
    //
    // In the spec (models.tsp), Pool has a nested "properties" bag (PoolProperties) which
    // contains "deploymentConfiguration?: DeploymentConfiguration". The back-compatible.tsp
    // applies @@flattenProperty(Pool.properties) to flatten PoolProperties into the resource
    // data class. However, because DeploymentConfiguration contains only a single property
    // (virtualMachineConfiguration), the generator further flattens it into a convenience
    // property "DeploymentVmConfiguration" on PoolProperties and marks the original
    // DeploymentConfiguration as internal (see PoolProperties.cs line 109).
    //
    // This means the generated BatchAccountPoolData does not expose the full
    // BatchDeploymentConfiguration object. For API backward compatibility with the previous
    // Swagger/AutoRest-generated SDK (which exposed DeploymentConfiguration directly),
    // and to allow users to set the entire deployment configuration rather than only
    // VmConfiguration, this custom partial class re-exposes the property publicly by
    // delegating to the internal Properties.DeploymentConfiguration.
    public partial class BatchAccountPoolData : ResourceData
    {
        /// <summary> Deployment configuration properties. </summary>
        public BatchDeploymentConfiguration DeploymentConfiguration
        {
            get
            {
                return Properties is null ? default : Properties.DeploymentConfiguration;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PoolProperties();
                }
                Properties.DeploymentConfiguration = value;
            }
        }
    }
}
