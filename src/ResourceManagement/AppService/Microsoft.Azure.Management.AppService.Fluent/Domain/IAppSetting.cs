// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// An immutable client-side representation of an app setting on a web app.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IAppSetting 
    {
        /// <summary>
        /// Gets if the setting sticks to the slot during a swap.
        /// </summary>
        bool Sticky { get; }

        /// <summary>
        /// Gets the value of the setting.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets the key of the setting.
        /// </summary>
        string Key { get; }
    }
}