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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Components
{
    using System.Runtime.Serialization;

    /// <summary>
    /// All components that are installed on a cluster derive from this class.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace)]
    [KnownType(typeof(MapReduceComponent))]
    [KnownType(typeof(HBaseComponent))]
    [KnownType(typeof(HdfsComponent))]
    [KnownType(typeof(HiveComponent))]
    [KnownType(typeof(OozieComponent))]
    [KnownType(typeof(YarnComponent))]
    [KnownType(typeof(GatewayComponent))]
    [KnownType(typeof(HadoopCoreComponent))]
    [KnownType(typeof(ZookeeperComponent))]
    [KnownType(typeof(StormComponent))]
    [KnownType(typeof(SparkComponent))]
    [KnownType(typeof(DashboardComponent))]
    [KnownType(typeof(CustomActionComponent))]
    internal abstract class ClusterComponent : RestDataContract
    {
        [DataMember]
        public string FriendlyName { get; set; }
    }
}
