using System;

namespace Microsoft.Cloud.Media.SDK.Client
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification="Bug 26829"), Flags]
    public enum ContentKeyCreationOptions
    {
        StorageEncryption = 0x0,
        CommonEncryption = 0x1
    }
}
