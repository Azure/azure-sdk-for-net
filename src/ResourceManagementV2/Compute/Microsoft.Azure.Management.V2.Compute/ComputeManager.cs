using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.RestClient;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.V2.Compute
{
    public class ComputeManager : IComputeManager
    {
        private ComputeManagementClient client;
        private VirtualMachines virtualMachines;

        public ComputeManager(RestClient restClient, string subscriptionId)
        {
            client = new ComputeManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            if (restClient.RetryPolicy != null)
            {
                client.SetRetryPolicy(restClient.RetryPolicy);
            }
            client.SubscriptionId = subscriptionId;
        }

        public VirtualMachines VirtualMachines
        {
            get
            {
                if (virtualMachines == null)
                {
                    virtualMachines = new VirtualMachinesImpl(this, client.VirtualMachines);
                }
                return virtualMachines;
            }
        }
    }

    public interface IComputeManager
    {
        VirtualMachines VirtualMachines { get; }
    }

    public interface VirtualMachines
    {
        IPage<VirtualMachine> list();
    }

    class VirtualMachinesImpl : VirtualMachines
    {
        IComputeManager computeManager;
        IVirtualMachinesOperations virtualMachineOperations;

        public VirtualMachinesImpl(IComputeManager computeManager, IVirtualMachinesOperations virtualMachineOperations)
        {
            this.computeManager = computeManager;
            this.virtualMachineOperations = virtualMachineOperations;
        }

        public IPage<VirtualMachine> list()
        {
            return virtualMachineOperations.ListAll();
        }
    }
}
