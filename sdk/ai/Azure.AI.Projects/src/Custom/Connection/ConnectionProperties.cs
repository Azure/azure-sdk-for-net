// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Projects
{
    [CodeGenModel("InternalConnectionProperties")]
    public abstract partial class ConnectionProperties
    {
        /// <summary> Authentication type of the connection target. </summary>
        public AuthenticationType AuthType { get; set; }
    }
}
