using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    public class VirtualMachineExtensionImageOperation : CustomKeyResourceOperationsBase<SubscriptionResourceIdentifier, VirtualMachineExtensionImage>
    {
        /// <summary>
        /// Gets the resource type definition for a virtual machine.
        /// </summary>
        public static readonly IReadOnlyList<ResourceType> AllValidResourceTypes = new List<ResourceType>
        {
            "Microsoft.Compute/Locations/Publishers/ArtifactTypes/Types",
            "Microsoft.Compute/Locations/Publishers/ArtifactTypes/Types/Versions",
        };

    /// <summary>
    /// Initializes a new instance of the <see cref="VirtualMachineScaleSetOperations"/> class.
    /// </summary>
    /// <param name="parentResourceOperations"> The client parameters to use in these operations. </param>
    /// <param name="id"> Id of the extension image. </param>
    internal VirtualMachineExtensionImageOperation(ResourceOperationsBase parentResourceOperations, SubscriptionResourceIdentifier id)
            : base(parentResourceOperations, id)
        {
        }

        /// <summary>
        /// Gets the valid resource type.
        /// </summary>
        protected override ResourceType ValidResourceType { get; }

        /// <summary>
        /// Verify that the input resource Id is a valid container for this type.
        /// </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        /// <exception cref="InvalidOperationException"> Resource identifier is not a valid type for this container. </exception>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (!AllValidResourceTypes.Contains(identifier.ResourceType))
                throw new InvalidOperationException($"{identifier.ResourceType} is not a valid container for {Id.ResourceType}");
        }

        public virtual ArmResponse<VirtualMachineExtensionImage> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ArmResponse<VirtualMachineExtensionImage>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get details for this resource from the service or can be overriden to provide a cached instance.
        /// </summary>
        /// <returns> A <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        protected virtual VirtualMachineExtensionImageOperation GetResource(CancellationToken cancellationToken = default)
        {
            return Get(cancellationToken).Value;
        }

        /// <summary>
        /// Get details for this resource from the service or can be overriden to provide a cached instance.
        /// </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A <see cref="Task"/> that on completion returns a <see cref="ArmResponse{TOperations}"/> operation for this resource. </returns>
        protected virtual async Task<VirtualMachineExtensionImageOperation> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return (await GetAsync(cancellationToken).ConfigureAwait(false)).Value;
        }
    }
}
