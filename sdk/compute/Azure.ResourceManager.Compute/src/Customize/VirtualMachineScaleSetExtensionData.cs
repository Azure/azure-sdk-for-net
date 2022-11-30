// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    // this piece of customized code adds back the ability to set name of this class in its constructor
    public partial class VirtualMachineScaleSetExtensionData
    {
        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        public VirtualMachineScaleSetExtensionData(string name) : base(default, name, default, default)
        {
            // we should make sure that we call everything inside the no parameter constructor. Otherwise the list in this model is not initialized and we will get exceptions when serializing it.
            ProvisionAfterExtensions = new ChangeTrackingList<string>();
        }
    }
}
