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
        protected static readonly IReadOnlyList<ResourceType> AllValidResourceTypes = new List<ResourceType>
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

        // TODO should we update valid types to be list?
        protected override ResourceType ValidResourceType => AllValidResourceTypes.First();

        /// <summary>
        /// Verify that the input resource Id is a valid container for this type.
        /// </summary>
        /// <param name="identifier"> The input resource Id to check. </param>
        /// <exception cref="InvalidOperationException"> Resource identifier is not a valid type for this container. </exception>
        protected override void Validate(ResourceIdentifier identifier)
        {
            if (!AllValidResourceTypes.Contains(identifier.ResourceType))
                throw new InvalidOperationException($"Invalid resource type {identifier?.ResourceType}.");
        }
    }
}
