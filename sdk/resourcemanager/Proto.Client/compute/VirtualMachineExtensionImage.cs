using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Proto.Compute
{
    /// <summary>
    /// Class representing a VirtualMachine along with the instance operations that can be performed on it.
    /// </summary>
    public class VirtualMachineExtensionImage : VirtualMachineExtensionImageOperation
    {
        /// <summary>
        /// Gets the data representing this VirtualMachine.
        /// </summary>
        public VirtualMachineExtensionImageData Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachine"/> class.
        /// </summary>
        /// <param name="operations"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineExtensionImage(ResourceOperationsBase operations, VirtualMachineExtensionImageData resource)
            : base(operations, resource.Id)
        {
            Data = resource;
        }
    }
}
