// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of a connection string on a web app.
    /// </summary>
    public interface IConnectionString : IBeta
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