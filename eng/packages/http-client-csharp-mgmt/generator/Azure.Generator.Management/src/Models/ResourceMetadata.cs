// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Models
{
    internal class ResourceMetadata
    {
        public ResourceMetadata(string resourceType, InputModelType resourceModel, InputClient resourceClient, bool isSingleton, ResourceScope resourceScope)
        {
            ResourceType = resourceType;
            ResourceModel = resourceModel;
            ResourceClient = resourceClient;
            IsSingleton = isSingleton;
            ResourceScope = resourceScope;
        }

        public string ResourceType { get; init; }

        public InputModelType ResourceModel { get; init; }

        public InputClient ResourceClient { get; init; }

        public bool IsSingleton { get; init; }

        public ResourceScope ResourceScope { get; init; }
    }
}
