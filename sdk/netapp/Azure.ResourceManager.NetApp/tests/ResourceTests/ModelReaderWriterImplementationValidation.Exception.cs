// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent",
                // Back-compat subclass shims that derive from the renamed (post-migration) base type.
                // They cannot implement IJsonModel<Self>/IPersistableModel<Self> by delegating to the
                // base because the base's PersistableModelWriteCore calls ModelReaderWriter.Write(this),
                // which dispatches by runtime type back into the shim — causing infinite recursion.
                // Serialization is handled by the base type at its declared property locations.
                "Azure.ResourceManager.NetApp.Models.ExportPolicyRule",
                "Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration",
                "Azure.ResourceManager.NetApp.Models.VolumeGroupVolumeProperties",
            };
        }
    }
}
