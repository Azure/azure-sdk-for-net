// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    //[CodeGenSuppress("AssignedDeploymentResource", typeof(AzureLocation))]
    //[CodeGenSuppress("AssignedDeploymentResource", typeof(ResourceIdentifier), typeof(AzureLocation), typeof(IDictionary<string, BinaryData>))]
    public partial class AssignedDeploymentResource
    {
        /// <summary> The resource ID. </summary>
        public ResourceIdentifier ResourceId { get; }

        /// <summary> The resource region. </summary>
        public AzureLocation Region { get; }

        /// <summary> Initializes a new instance of <see cref="AssignedDeploymentResource"/>. </summary>
        /// <param name="region"> The resource region. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="region"/> is null. </exception>
        internal AssignedDeploymentResource(string region)
        {
            Argument.AssertNotNull(region, nameof(region));

            Region = new AzureLocation(region);
        }

        /// <summary> Initializes a new instance of <see cref="AssignedDeploymentResource"/>. </summary>
        /// <param name="resourceId"> The resource ID. </param>
        /// <param name="region"> The resource region. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AssignedDeploymentResource(string resourceId, string region, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ResourceId = new ResourceIdentifier(resourceId);
            Region = new AzureLocation(region);
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
