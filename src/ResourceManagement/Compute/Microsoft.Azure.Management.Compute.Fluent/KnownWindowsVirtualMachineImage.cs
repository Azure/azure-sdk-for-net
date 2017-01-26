// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public enum KnownWindowsVirtualMachineImage
    {
        [EnumName("MicrosoftWindowsServer WindowsServer 2008-R2-SP1")]
        WindowsServer2008R2_SP1,
        [EnumName("MicrosoftWindowsServer WindowsServer 2012-Datacenter")]
        WindowsServer2012Datacenter,
        [EnumName("MicrosoftWindowsServer WindowsServer 2012-R2-Datacenter")]
        WindowsServer2012R2Datacenter,
        [EnumName("MicrosoftWindowsServer WindowsServer 2016-Technical-Preview-with-Containers")]
        WindowsServer2016TechnicalPreviewWithContainers,
        [EnumName("MicrosoftWindowsServer WindowsServer Windows-Server-Technical-Preview")]
        WindowsServerTechnicalPreview
    }
}
