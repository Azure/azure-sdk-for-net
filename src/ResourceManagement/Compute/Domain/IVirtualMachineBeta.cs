// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine.
    /// </summary>
    public interface IVirtualMachineBeta  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Gets true if boot diagnostics is enabled for the virtual machine.
        /// </summary>
        bool IsBootDiagnosticsEnabled { get; }

        /// <summary>
        /// Gets the storage blob endpoint uri if boot diagnostics is enabled for the virtual machine.
        /// </summary>
        string BootDiagnosticsStorageUri { get; }
    }
}