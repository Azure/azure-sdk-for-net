// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
