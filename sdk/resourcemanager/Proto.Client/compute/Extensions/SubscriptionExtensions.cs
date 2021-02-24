using Azure;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Adapters;
using Azure.ResourceManager.Core.Resources;
using System.Threading;

namespace Proto.Compute
{
    /// <summary>
    /// Extension methods for convenient access on SubscriptionOperations in a client
    /// </summary>
    public static class SubscriptionExtensions
    {
        #region Virtual Machine List Operations
        /// <summary>
        /// Lists the VirtualMachines for this SubscriptionOperations.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<VirtualMachine> ListVirtualMachines(this SubscriptionOperations subscription)
        {
            ComputeManagementClient computeClient = GetComputeClient(subscription);
            var vmOperations = computeClient.VirtualMachines;
            var result = vmOperations.ListAll();
            return new PhWrappingPageable<Azure.ResourceManager.Compute.Models.VirtualMachine, VirtualMachine>(
                result,
                s => new VirtualMachine(subscription, new VirtualMachineData(s)));
        }

        private static ComputeManagementClient GetComputeClient(SubscriptionOperations subscription)
        {
            return new ComputeManagementClient(
                subscription.BaseUri,
                subscription.Id.Subscription,
                subscription.Credential,
                subscription.ClientOptions.Convert<ComputeManagementClientOptions>());
        }

        /// <summary>
        /// Lists the VirtualMachines for this SubscriptionOperations.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<VirtualMachine> ListVirtualMachinesAsync(this SubscriptionOperations subscription)
        {
            var vmOperations = GetComputeClient(subscription).VirtualMachines;
            var result = vmOperations.ListAllAsync();
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Compute.Models.VirtualMachine, VirtualMachine>(
                result,
                s => new VirtualMachine(subscription, new VirtualMachineData(s)));
        }

        /// <summary>
        /// Filters the list of VMs for a SubscriptionOperations represented as generic resources.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<GenericResource> ListVirtualMachinesByName(this SubscriptionOperations subscription, string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContext(subscription, filters, top, cancellationToken);
        }

        /// <summary>
        /// Filters the list of VMs for a SubscriptionOperations represented as generic resources.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <param name="filter"> The string to filter the list. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<GenericResource> ListVirtualMachinesByNameAsync(this SubscriptionOperations subscription, string filter, int? top = null, CancellationToken cancellationToken = default)
        {
            ResourceFilterCollection filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
            filters.SubstringFilter = filter;
            return ResourceListOperations.ListAtContextAsync(subscription, filters, top, cancellationToken);
        }
        #endregion

        #region AvailabilitySet List Operations
        /// <summary>
        /// Lists the AvailabilitySets for this SubscriptionOperations.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> A collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static Pageable<AvailabilitySet> ListAvailabilitySets(this SubscriptionOperations subscription)
        {
            ComputeManagementClient computeClient = GetComputeClient(subscription);
            var availabilitySetOperations = computeClient.AvailabilitySets;
            var result = availabilitySetOperations.ListBySubscription();
            return new PhWrappingPageable<Azure.ResourceManager.Compute.Models.AvailabilitySet, AvailabilitySet>(
                result,
                s => new AvailabilitySet(subscription, new AvailabilitySetData(s)));
        }

        /// <summary>
        /// Lists the AvailabilitySets for this SubscriptionOperations.
        /// </summary>
        /// <param name="subscription"> The <see cref="SubscriptionOperations" /> instance the method will execute against. </param>
        /// <returns> An async collection of resource operations that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<AvailabilitySet> ListAvailabilitySetsAsync(this SubscriptionOperations subscription)
        {
            ComputeManagementClient computeClient = GetComputeClient(subscription);
            var availabilitySetOperations = computeClient.AvailabilitySets;
            var result = availabilitySetOperations.ListBySubscriptionAsync();
            return new PhWrappingAsyncPageable<Azure.ResourceManager.Compute.Models.AvailabilitySet, AvailabilitySet>(
                result,
                s => new AvailabilitySet(subscription, new AvailabilitySetData(s)));
        }
        #endregion
    }
}
