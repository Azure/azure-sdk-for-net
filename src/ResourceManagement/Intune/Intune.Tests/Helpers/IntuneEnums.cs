// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    /// <summary>
    /// Enums used primarily for policy creation/update operations
    /// </summary>
    /// <summary>
    /// The platforms supported
    /// </summary>
    public enum PlatformType
    {
        iOS,
        Android,
        Windows,
        None
    }

    /// <summary>
    /// The application sharing options
    /// </summary>
    public enum AppSharingType
    {
        none,
        policyManagedApps,
        allApps
    }

    /// <summary>
    /// Defines choices
    /// </summary>
    public enum ChoiceType
    {
        required,
        notRequired
    }

    /// <summary>
    /// Types of clipboard sharing levels
    /// </summary>
    public enum ClipboardSharingLevelType
    {
        blocked,
        policyManagedApps,
        policyManagedAppsWithPasteIn,
        allApps
    }

    /// <summary>
    /// Filtering types
    /// </summary>
    public enum FilterType
    {
        allow,
        block
    }

    /// <summary>
    /// Option types.
    /// </summary>
    public enum OptionType
    {
        enable,
        disable
    }

    /// <summary>
    /// Types of device locking available..
    /// </summary>
    public enum DeviceLockType
    {
        deviceLocked,
        deviceLockedExceptFilesOpen,
        afterDeviceRestart,
        useDeviceSettings
    }
}
