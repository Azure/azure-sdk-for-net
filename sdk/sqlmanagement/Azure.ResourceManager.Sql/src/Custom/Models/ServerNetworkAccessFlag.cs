// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct ServerNetworkAccessFlag
    {
        /// <summary> SecuredByPerimeter. </summary>
        public static ServerNetworkAccessFlag SecuredByPerimeter { get; } = new ServerNetworkAccessFlag("SecuredByPerimeter");
    }
}
