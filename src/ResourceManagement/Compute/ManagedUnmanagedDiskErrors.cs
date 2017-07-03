// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    internal partial class ManagedUnmanagedDiskErrors
    {
        public static readonly string VM_Both_Managed_And_Uumanaged_Disk_Not_Allowed = "This virtual machine is based on managed disk(s), both un-managed and managed disk cannot exists together in a virtual machine";
        public static readonly string VMSS_Both_Managed_And_Unmanaged_Disk_Not_Allowed = "This virtual machine scale set is based on managed disk(s), both un-managed and managed cannot exists together in a virtual machine scale set";
        public static readonly string VM_No_Unmanaged_Disk_To_Update = "This virtual machine is based on managed disk(s) and there is no un-managed disk to update";
        public static readonly string VM_No_Managed_Disk_To_Update = "This virtual machine is based on un-managed disk(s) and there is no managed disk to update";
        public static readonly string VMSS_No_Unmanaged_Disk_To_Update = "This virtual machine scale set is based on managed disk(s) and there is no un-managed disk to update";
        public static readonly string VMSS_No_Managed_Disk_To_Update = "This virtual machine scale set is based on un-managed disk(s) and there is no managed disk to update";
        public static readonly string VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed = "This virtual machine is based on un-managed disks (s), both un-managed and managed disk cannot exists together in a virtual machine";
        public static readonly string VMSS_Both_Unmanaged_And_Managed_Disk_Not_Aallowed = "This virtual machine scale set is based on un-managed disk(s), both un-managed and managed cannot exists together in a virtual machine scale set";
    }
}
