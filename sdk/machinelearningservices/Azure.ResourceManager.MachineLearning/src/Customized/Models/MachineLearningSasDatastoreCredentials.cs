// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Backward-compat shim for the previous public secrets constructor/property.
    [CodeGenSuppress("MachineLearningSasDatastoreCredentials", typeof(MachineLearningSasDatastoreSecrets))]
    public partial class MachineLearningSasDatastoreCredentials
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningSasDatastoreCredentials"/>. </summary>
        public MachineLearningSasDatastoreCredentials(MachineLearningSasDatastoreSecrets secrets) : base()
        {
            Secrets = secrets;
        }

        /// <summary> Storage container secrets. </summary>
        [CodeGenMember("Secrets")]
        [WirePath("secrets")]
        public MachineLearningSasDatastoreSecrets Secrets { get; set; }
    }
}
