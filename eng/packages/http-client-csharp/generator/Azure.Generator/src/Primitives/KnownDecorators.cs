// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Generator.Primitives
{
    internal class KnownDecorators
    {
        public const string ArmResourceOperations = "Azure.ResourceManager.@armResourceOperations";
        public const string ArmResourceRead = "Azure.ResourceManager.@armResourceRead";
        public const string ArmProviderNamespace = "Azure.ResourceManager.@armProviderNamespace";
        public const string Singleton= "Azure.ResourceManager.@singleton";
        public const string ResourceMetadata = "Azure.ClientGenerator.Core.@resourceSchema";
        public const string ResourceModel = "resourceModel";
    }
}
