// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A resource Id representing the root of the resource hierarchy.
    /// </summary>
    public sealed class RootResourceIdentifier : ResourceIdentifier
    {
        internal RootResourceIdentifier()
            : base(ResourceType.RootResourceType, string.Empty)
        {
        }

        internal override string ToResourceString()
        {
            return string.Empty;
        }

        /// <inheritdoc/>
        public override bool TryGetParent(out ResourceIdentifier containerId)
        {
            containerId = default(ResourceIdentifier);
            return false;
        }
    }
}
