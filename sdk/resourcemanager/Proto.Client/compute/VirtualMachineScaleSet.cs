using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// Class representing a VirtualMachineScaleSet along with the instance operations that can be performed on it.
    /// </summary>
    public class VirtualMachineScaleSet : VirtualMachineScaleSetOperations
    {
        /// <summary>
        /// Gets the data representing this VirtualMachineScaleSet.
        /// </summary>
        public VirtualMachineScaleSetData Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineScaleSet"/> class.
        /// </summary>
        /// <param name="operations"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSet(ResourceOperationsBase operations, VirtualMachineScaleSetData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <inheritdoc />
        protected override VirtualMachineScaleSet GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachineScaleSet> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
