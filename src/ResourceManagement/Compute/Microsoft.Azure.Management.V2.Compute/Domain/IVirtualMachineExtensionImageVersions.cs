/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    /// <summary>
    /// Entry point to virtual machine image extension versions.
    /// </summary>
    public interface IVirtualMachineExtensionImageVersions : ISupportsListing<IVirtualMachineExtensionImageVersion>
    {
    }
}
