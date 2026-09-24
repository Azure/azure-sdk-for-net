// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.Apps.Sandbox
{
    public partial class SandboxGroupSandbox
    {
        /// <summary>
        /// Gets the opaque sandbox identifier associated with this client.
        /// </summary>
        public virtual string Id => _id;
    }
}
