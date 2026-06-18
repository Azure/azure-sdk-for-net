// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sql.Models
{
    public readonly partial struct ServerNetworkAccessFlag
    {
        private const string SecuredByPerimeterValue = "SecuredByPerimeter";

        /// <summary> SecuredByPerimeter. </summary>
        public static ServerNetworkAccessFlag SecuredByPerimeter { get; } = new ServerNetworkAccessFlag(SecuredByPerimeterValue);
    }
}
