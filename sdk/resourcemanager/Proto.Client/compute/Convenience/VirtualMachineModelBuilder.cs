using Azure.ResourceManager.Core;
using System;

namespace Proto.Compute.Convenience
{
    /// <summary>
    /// A class representing a builder object to help create a virtual machine.
    /// </summary>
    public class VirtualMachineModelBuilder : VirtualMachineModelBuilderBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualMachineModelBuilder"/> class.
        /// </summary>
        /// <param name="containerOperations"> The container to create the virtual machine in. </param>
        /// <param name="vm"> The data model representing the virtual machine to create. </param>
        public VirtualMachineModelBuilder(VirtualMachineContainer containerOperations, VirtualMachineData vm): base(containerOperations, vm)
        {
            // TODO: GENERATOR Update Builder after models are incorporated in generated models
            // _model.Name = vmName;
            //_model = new VirtualMachine(location);
        }

        /// <summary>
        /// Attaches a disk to the virtual machine to be created.
        /// </summary>
        /// <param name="azureEntity"> The disk to attach. </param>
        /// <returns> An instance of <see cref="VirtualMachineModelBuilder"/> </returns>
        public VirtualMachineModelBuilderBase AttachDataDisk(TrackedResource<ResourceGroupResourceIdentifier> azureEntity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override VirtualMachineModelBuilderBase UseWindowsImage(string adminUser, string password)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override VirtualMachineModelBuilderBase UseLinuxImage(string adminUser, string password)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override VirtualMachineModelBuilderBase RequiredNetworkInterface(ResourceIdentifier nicResourceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override VirtualMachineModelBuilderBase RequiredAvalabilitySet(ResourceIdentifier asetResourceId)
        {
            throw new NotImplementedException();
        }
    }
}
