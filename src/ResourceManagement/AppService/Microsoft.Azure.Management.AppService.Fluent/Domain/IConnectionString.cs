// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of a connection string on a web app.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IConnectionString 
    {
        /// <summary>
        /// Gets if the connection string sticks to the slot during a swap.
        /// </summary>
        bool Sticky { get; }

        /// <summary>
        /// Gets the key of the setting.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the value of the connection string.
        /// </summary>
        string Value { get; }

        /// <summary>
        /// Gets the type of the connection string.
        /// </summary>
        Models.ConnectionStringType Type { get; }
    }
}