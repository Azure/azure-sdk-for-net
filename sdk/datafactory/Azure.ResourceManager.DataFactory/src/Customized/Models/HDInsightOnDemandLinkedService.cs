// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
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
        public IList<DataFactoryLinkedServiceReference> AdditionalLinkedServiceNames { get; set; }
    }
}
