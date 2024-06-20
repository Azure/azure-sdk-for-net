// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    internal class ModuleResource
    {
        public Resource Resource { get; }

        public ModuleConstruct? Scope { get; }

        public ModuleResource(Resource resource, ModuleConstruct? scope)
        {
            Resource = resource;
            Scope = scope;
        }
    }
}
