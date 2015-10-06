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
namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources
{
    using System;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2014.Resources.CredentialBackedResources;

    /// <summary>
    /// All Resources inherit from this class.
    /// </summary>
    [DataContract(Namespace = Constants.HdInsightManagementNamespace, IsReference = true)]
    [KnownType("GetTypes")]
    internal abstract class AbstractResource : RestDataContract
    {
        public static Type[] GetTypes()
        {
            return new Type[]
                {
                    typeof(BlobContainerResource),
                    typeof(BlobContainerCredentialBackedResource),
                    typeof(SqlAzureDatabaseResource),
                    typeof(SqlAzureDatabaseCredentialBackedResource),
                    typeof(VirtualNetworkResource),
                    typeof(VirtualNetworkCredentialBackedResource),
                };
        }
    }
}
