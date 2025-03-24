// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Management.Primitives
{
    internal class KnownDecorators
    {
        public const string ArmResourceOperations = "Azure.ResourceManager.@armResourceOperations";
        public const string ArmResourceRead = "Azure.ResourceManager.@armResourceRead";
        public const string ArmProviderNamespace = "Azure.ResourceManager.@armProviderNamespace";
        public const string ResourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";
        public const string ArmResourceInternal = "Azure.ResourceManager.Private.@armResourceInternal";

        public const string ResourceModel = "resourceModel";
        public const string ResourceType = "resourceType";
        public const string IsSingleton = "isSingleton";
    }
}
