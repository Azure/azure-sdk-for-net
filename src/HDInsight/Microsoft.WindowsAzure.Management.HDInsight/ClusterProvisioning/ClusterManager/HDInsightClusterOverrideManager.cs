// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.ClusterManager
{
    using System;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    internal class HDInsightClusterOverrideManager : IHDInsightClusterOverrideManager
    {
        private Dictionary<Type, Tuple<IVersionFinderClientFactory, IHDInsightManagementRestUriBuilderFactory, IPayloadConverter>> handlers =
            new Dictionary<Type, Tuple<IVersionFinderClientFactory, IHDInsightManagementRestUriBuilderFactory, IPayloadConverter>>();
        
        public void AddOverride<T>(IVersionFinderClientFactory versionFinderFactory,
                                   IHDInsightManagementRestUriBuilderFactory uriBuilderFactory,
                                   IPayloadConverter payloadConverter) where T : IHDInsightSubscriptionCredentials
        {
            this.handlers[typeof(T)] =
                new Tuple<IVersionFinderClientFactory, IHDInsightManagementRestUriBuilderFactory, IPayloadConverter>(
                    versionFinderFactory, uriBuilderFactory, payloadConverter);
        }

        public HDInsightOverrideHandlers GetHandlers<T>(T credentials, IAbstractionContext cancellationToken, bool ignoreSslErrors) where T : IHDInsightSubscriptionCredentials
        {
            if (credentials.IsNull())
            {
                throw new ArgumentNullException("credentials");
            }
            var type = this.FindSupportedType(credentials.GetType());
            if (type.IsNull())
            {
                throw new NotSupportedException("The credential system supplied is not supported.");
            }
            var tuple = this.handlers[type];
            return new HDInsightOverrideHandlers(tuple.Item1.Create(credentials, cancellationToken, ignoreSslErrors), tuple.Item2.Create(credentials), tuple.Item3);
        }

        private Type FindSupportedType(Type initial)
        {
            var type = initial;
            while (!this.handlers.ContainsKey(type))
            {
                type = type.BaseType;
                if (type.IsNull() || ReferenceEquals(type, typeof(object)))
                {
                    break;
                }
            }
            return type;
        }
    }
}
