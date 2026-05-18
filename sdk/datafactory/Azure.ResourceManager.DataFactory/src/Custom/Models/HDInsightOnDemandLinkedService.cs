// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization added as a workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298
// The TypeSpec @@alternateType identity-aliasing on SecretBase / LinkedServiceReference / SecureString
// causes properties whose type is one of those externally-aliased models to be silently dropped during
// code generation. This partial restores the public API surface so that downstream consumers continue
// to compile. Wire serialization for the restored members is NOT preserved here (the generator fix in
// https://github.com/Azure/azure-sdk-for-net/issues/59298 is required for full round-trip).

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    public partial class HDInsightOnDemandLinkedService
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret ClusterPassword { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret ClusterSshPassword { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryLinkedServiceReference HcatalogLinkedServiceName { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryLinkedServiceReference LinkedServiceName { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret ServicePrincipalKey { get; set; }

        /// <summary> Initializes a new instance restored as workaround for issue #59298. </summary>
        public HDInsightOnDemandLinkedService(DataFactoryElement<int> clusterSize, DataFactoryElement<string> timeToLiveExpression, DataFactoryElement<string> version, DataFactoryLinkedServiceReference linkedServiceName, DataFactoryElement<string> hostSubscriptionId, DataFactoryElement<string> tenant, DataFactoryElement<string> clusterResourceGroup)
            : this(clusterSize, timeToLiveExpression, version, hostSubscriptionId, tenant, clusterResourceGroup)
        {
            LinkedServiceName = linkedServiceName;
        }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public IList<DataFactoryLinkedServiceReference> AdditionalLinkedServiceNames { get; } = new List<DataFactoryLinkedServiceReference>();
    }
}
