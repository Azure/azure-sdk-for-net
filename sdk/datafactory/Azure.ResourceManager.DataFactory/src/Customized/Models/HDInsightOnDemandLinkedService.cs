// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 and
    // https://github.com/Azure/azure-sdk-for-net/issues/59852 :
    // Identity-aliased Azure.Core.Expressions.DataFactory members are dropped from the generated public
    // surface (#59298) and the emitter no longer emits the public constructor for these flattened types
    // (#59852). This partial restores the GA properties (routed through TypeProperties) and the public ctor.
    // TODO: remove once the generator restores both (#59298, #59852).
    public partial class HDInsightOnDemandLinkedService
    {
        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactorySecret ClusterPassword
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.ClusterPassword;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                TypeProperties.ClusterPassword = value;
            }
        }

        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactorySecret ClusterSshPassword
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.ClusterSshPassword;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                TypeProperties.ClusterSshPassword = value;
            }
        }

        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactoryLinkedServiceReference HcatalogLinkedServiceName
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.HcatalogLinkedServiceName;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                TypeProperties.HcatalogLinkedServiceName = value;
            }
        }

        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactoryLinkedServiceReference LinkedServiceName
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.LinkedServiceName;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                TypeProperties.LinkedServiceName = value;
            }
        }

        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public DataFactorySecret ServicePrincipalKey
        {
            get
            {
                return TypeProperties is null ? default : TypeProperties.ServicePrincipalKey;
            }
            set
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                TypeProperties.ServicePrincipalKey = value;
            }
        }

        /// <summary> Property restored as workaround for issues #59298 and #59852. </summary>
        public IList<DataFactoryLinkedServiceReference> AdditionalLinkedServiceNames
        {
            get
            {
                if (TypeProperties is null)
                {
                    TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties();
                }
                return TypeProperties.AdditionalLinkedServiceNames;
            }
        }

        /// <summary> Initializes a new instance restored as workaround for issues #59298 and #59852. </summary>
        public HDInsightOnDemandLinkedService(DataFactoryElement<int> clusterSize, DataFactoryElement<string> timeToLiveExpression, DataFactoryElement<string> version, DataFactoryLinkedServiceReference linkedServiceName, DataFactoryElement<string> hostSubscriptionId, DataFactoryElement<string> tenant, DataFactoryElement<string> clusterResourceGroup) : base("HDInsightOnDemand")
        {
            TypeProperties = new HDInsightOnDemandLinkedServiceTypeProperties(clusterSize, timeToLiveExpression, version, linkedServiceName, hostSubscriptionId, tenant, clusterResourceGroup);
        }
    }
}
