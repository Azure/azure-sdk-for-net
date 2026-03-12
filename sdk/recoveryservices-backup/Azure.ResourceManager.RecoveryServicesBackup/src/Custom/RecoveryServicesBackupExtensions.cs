// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.RecoveryServicesBackup.Mocking;
using Azure.ResourceManager.RecoveryServicesBackup.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.RecoveryServicesBackup
{
    // Suppress duplicate GetAllAsync/GetAll extension methods with (ResourceGroupResource, string, string, string, CancellationToken)
    [CodeGenSuppress("GetAllAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    // Suppress duplicate GetAsync/Get extension methods with (ResourceGroupResource, string, string, CancellationToken)
    [CodeGenSuppress("GetAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    // Suppress duplicate GetAllAsync/GetAll extension methods with (ResourceGroupResource, string, string, CancellationToken)
    [CodeGenSuppress("GetAllAsync", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(ResourceGroupResource), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class RecoveryServicesBackupExtensions
    {
    }
}
