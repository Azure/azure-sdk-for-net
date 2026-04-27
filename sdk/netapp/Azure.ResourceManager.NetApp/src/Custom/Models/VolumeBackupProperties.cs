// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Compatibility shim for the former backup properties model name. Deserialization is
    // handled by the base type NetAppVolumeBackupConfiguration; this shim is excluded from
    // the IJsonModel/IPersistableModel pattern check via the ExceptionList in
    // tests/ResourceTests/ModelReaderWriterImplementationValidation.Exception.cs because
    // adding IJsonModel<VolumeBackupProperties> would recurse infinitely through the base
    // type's ModelReaderWriter.Write(this, ...) dispatch (runtime type is the shim).
    /// <summary> Volume Backup Properties (legacy alias of <see cref="NetAppVolumeBackupConfiguration"/>). </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class VolumeBackupProperties : NetAppVolumeBackupConfiguration
    {
    }
}
