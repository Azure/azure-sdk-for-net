// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat shim for the GA name. Deserialization is delegated to the base
    // type NetAppVolumeExportPolicyRule. This shim is excluded from the IJsonModel /
    // IPersistableModel pattern check (see ModelReaderWriterImplementationValidation.Exception.cs)
    // because adding IJsonModel<ExportPolicyRule> would recurse infinitely through the base
    // type's ModelReaderWriter.Write(this, ...) dispatch (runtime type is the shim).
    /// <summary> Volume export policy rule (legacy alias of <see cref="NetAppVolumeExportPolicyRule"/>). </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExportPolicyRule : NetAppVolumeExportPolicyRule
    {
    }
}
