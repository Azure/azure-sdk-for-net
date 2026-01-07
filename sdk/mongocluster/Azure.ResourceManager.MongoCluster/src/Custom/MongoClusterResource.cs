// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MongoCluster.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MongoCluster
{
    /// <summary>
    /// A class representing a MongoCluster along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MongoClusterResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource"/> using the GetMongoClusters method.
    /// </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByParent", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByParentAsync", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByMongoCluster", typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetByMongoClusterAsync", typeof(CancellationToken))]
    public partial class MongoClusterResource : ArmResource
    {
    }
}
