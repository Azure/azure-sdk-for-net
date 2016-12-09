// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// An immutable client-side representation of a connection string on a web app.
    /// </summary>
    public interface IConnectionString 
    {
        bool Sticky { get; }

        string Name { get; }

        string Value { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.ConnectionStringType Type { get; }
    }
}