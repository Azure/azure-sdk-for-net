namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IComputeManagementClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        IAvailabilitySetsOperations AvailabilitySets { get; }

        IVirtualMachineImagesOperations VirtualMachineImages { get; }

        IVirtualMachineExtensionImagesOperations VirtualMachineExtensionImages { get; }

        IVirtualMachineExtensionsOperations VirtualMachineExtensions { get; }

        IUsageOperations Usage { get; }

        IVirtualMachineSizesOperations VirtualMachineSizes { get; }

        IVirtualMachinesOperations VirtualMachines { get; }

        }
}
