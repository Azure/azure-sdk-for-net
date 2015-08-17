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
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class StorageAccountCredentials
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Container { get; set; }
    }

    public class AlternativeEnvironment
    {
        public string Endpoint { get; set; }
        public string Namespace { get; set; }
        public Guid SubscriptionId { get; set; }
    }

    public class MetastoreCredentials
    {
        public string Description { get; set; }
        public string SqlServer { get; set; }
        public string Database { get; set; }
    }

    public class ResourceProviderProperty
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class KnownCluster
    {
        public string Cluster { get; set; }
        public string DnsName { get; set; }
        public string Version { get; set; }
    }

    public enum EnvironmentType
    {
        Production,
        Current,
        Next,
        DogFood
    }

    public class CreationDetails
    {
        public string Location { get; set; }

        public StorageAccountCredentials DefaultStorageAccount { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public StorageAccountCredentials[] AdditionalStorageAccounts { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public MetastoreCredentials[] HiveStores { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public MetastoreCredentials[] OozieStores { get; set; }
    }

    [Serializable]
    public class AzureTestCredentials
    {
        public string CredentialsName { get; set; }
        public Guid SubscriptionId { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public ResourceProviderProperty[] ResourceProviderProperties { get; set; }
        public string Certificate { get; set; }
        public string InvalidCertificate { get; set; }
        public string AzureUserName { get; set; }
        public string AzurePassword { get; set; }
        public string HadoopUserName { get; set; }
        public string Endpoint { get; set; }
        public string CloudServiceName { get; set; }
        public string AccessToken { get; set; }

        public KnownCluster WellKnownCluster { get; set; }
        public EnvironmentType EnvironmentType { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays",
            Justification = "Needed for serialization to work correctly. [tgs]")]
        public CreationDetails[] Environments { get; set; }
    }
}
