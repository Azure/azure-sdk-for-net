// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary>
    /// Compatibility shim for the former export rule model name. Deserialization is handled by the
    /// base type <see cref="NetAppVolumeExportPolicyRule"/>; this shim is excluded from the
    /// IJsonModel/IPersistableModel pattern check via the ExceptionList in
    /// <c>tests/ResourceTests/ModelReaderWriterImplementationValidation.Exception.cs</c>
    /// because adding IJsonModel&lt;ExportPolicyRule&gt; would recurse infinitely through
    /// the base type's <c>ModelReaderWriter.Write(this, …)</c> dispatch (runtime type is the shim).
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExportPolicyRule : NetAppVolumeExportPolicyRule
    {
    }
}
