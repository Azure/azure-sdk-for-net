// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataProtection.Models
{

    /// <summary>
    /// Defines values for CurrentProtectionState.
    /// </summary>
    public static class CurrentProtectionState
    {
        public const string Invalid = "Invalid";
        public const string NotProtected = "NotProtected";
        public const string ConfiguringProtection = "ConfiguringProtection";
        public const string ProtectionConfigured = "ProtectionConfigured";
        public const string BackupSchedulesSuspended = "BackupSchedulesSuspended";
        public const string RetentionSchedulesSuspended = "RetentionSchedulesSuspended";
        public const string ProtectionStopped = "ProtectionStopped";
        public const string ProtectionError = "ProtectionError";
        public const string ConfiguringProtectionFailed = "ConfiguringProtectionFailed";
        public const string SoftDeleting = "SoftDeleting";
        public const string SoftDeleted = "SoftDeleted";
        public const string UpdatingProtection = "UpdatingProtection";
    }
}
