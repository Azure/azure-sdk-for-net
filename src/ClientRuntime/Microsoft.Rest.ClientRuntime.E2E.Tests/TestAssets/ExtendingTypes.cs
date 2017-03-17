// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.E2E.Tests.TestAssets
{
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;

    /// <summary>
    /// Class to extend VM class
    /// This class is specifically meant to assign/reinitialize/set protected members
    /// </summary>
    public class MyVm : Microsoft.Azure.Management.Compute.Models.VirtualMachine
    {
        /// <summary>
        /// Constructor for creating MyVm
        /// </summary>
        /// <param name="vm"></param>
        public MyVm(VirtualMachine vm)
            : base(vm.Location, vm.Id, vm.Name, vm.Type, vm.Tags, vm.Plan, vm.HardwareProfile, vm.StorageProfile, vm.OsProfile,
                  vm.NetworkProfile, vm.DiagnosticsProfile, vm.AvailabilitySet, vm.ProvisioningState, vm.InstanceView,
                  vm.LicenseType, vm.VmId, vm.Resources)
        {

        }

        /// <summary>
        /// Method to update protected properties
        /// </summary>
        /// <param name="newVmId"></param>
        public void UpdateVm(string newVmId)
        {
            VmId = newVmId;
        }
    }


    /// <summary>
    /// Extending Compute Client
    /// This client is used to capture Request content sent over wire using user defined delegates
    /// </summary>
    public class MyComputeClient : ComputeManagementClient
    {
        public MyComputeClient(System.Uri baseUri,
            System.Net.Http.HttpClientHandler rootHandler,
            params System.Net.Http.DelegatingHandler[] handlers) : base(baseUri, rootHandler, handlers)
        {

        }

        public MyComputeClient(System.Uri baseUri,
            ServiceClientCredentials credentials,
            params System.Net.Http.DelegatingHandler[] handlers) : base(baseUri, credentials, handlers)
        {

        }

        /// <summary>
        /// Gets Request contet for the request that was sent by the client
        /// </summary>
        /// <returns></returns>
        public string GetRequestContent()
        {
            RecordedDelegatingHandler handle = this.FirstMessageHandler as RecordedDelegatingHandler;
            string cont = handle.RequestContent;
            return cont;
        }
    }
}
