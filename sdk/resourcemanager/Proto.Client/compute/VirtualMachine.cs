using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// Class representing a VirtualMachine along with the instance operations that can be performed on it.
    /// </summary>
    public class VirtualMachine : VirtualMachineOperations
    {
        /// <summary>
        /// Gets the data representing this VirtualMachine.
        /// </summary>
        public VirtualMachineData Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachine"/> class.
        /// </summary>
        /// <param name="operations"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachine(ResourceOperationsBase operations, VirtualMachineData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }

        /// <inheritdoc />
        protected override VirtualMachine GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachine> GetResourceAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(this);
        }
    }
}
