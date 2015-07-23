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
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;

    internal class VersionFinderClient : IVersionFinderClient
    {
        private const string VersionPrefix = "CAPABILITY_VERSION_";
        private readonly IHDInsightSubscriptionCredentials credentials;
        private readonly IAbstractionContext context;
        private readonly bool ignoreSslErrors;

        public VersionFinderClient(IHDInsightSubscriptionCredentials creds, IAbstractionContext context, bool ignoreSslErrors)
        {
            this.context = context;
            this.ignoreSslErrors = ignoreSslErrors;
            this.credentials = creds;
        }

        // Method = "GET", UriTemplate = "UriTemplate = "{subscriptionId}/resourceproviders/{resourceProviderNamespace}/Properties?resourceType={resourceType}"
        public async Task<Collection<HDInsightVersion>> ListAvailableVersions()
        {
            var client = ServiceLocator.Instance.Locate<IRdfeServiceRestClientFactory>().Create(this.credentials, this.context, this.ignoreSslErrors);

            var capabilities = await client.GetResourceProviderProperties();
            return this.ListAvailableVersions(capabilities);
        }

        public Collection<HDInsightVersion> ListAvailableVersions(IEnumerable<KeyValuePair<string, string>> capabilities)
        {
            if (capabilities.IsNull())
            {
                throw new ArgumentNullException("capabilities");
            }

            return ParseVersions(capabilities);
        }

        internal static Collection<HDInsightVersion> ParseVersions(IEnumerable<KeyValuePair<string, string>> capabilities)
        {
            var supportedVersions = from capability in capabilities
                                    where
                                        capability.Key.StartsWith(VersionPrefix, StringComparison.OrdinalIgnoreCase)
                                    select ParseVersion(capability.Key);

            return new Collection<HDInsightVersion>(supportedVersions.ToList());
        }

        private static HDInsightVersion ParseVersion(string value)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentNullException("value");
            }

            int place = value.IndexOf(VersionPrefix, StringComparison.OrdinalIgnoreCase);
            if (place >= 0)
            {
                value = value.Remove(place, VersionPrefix.Length);
            }

            return new HDInsightVersion() { Version = value, VersionStatus = GetVersionStatus(value) };
        }

        public VersionStatus GetVersionStatus(Version hdinsightClusterVersion)
        {
            return GetVersionStatusInternal(hdinsightClusterVersion);
        }

        internal static VersionStatus GetVersionStatus(string hdinsightClusterVersion)
        {
            return GetVersionStatusInternal(new PayloadConverter().ConvertStringToVersion(hdinsightClusterVersion));
        }

        internal static VersionStatus GetVersionStatusInternal(Version hdinsightClusterVersion)
        {
            hdinsightClusterVersion.ArgumentNotNull("version");
            //version < MinVersion
            if (hdinsightClusterVersion.Major < HDInsightSDKSupportedVersions.MinVersion.Major ||
                (hdinsightClusterVersion.Major == HDInsightSDKSupportedVersions.MinVersion.Major &&
                 hdinsightClusterVersion.Minor < HDInsightSDKSupportedVersions.MinVersion.Minor))
            {
                return VersionStatus.Obsolete;
            }
            //version > MaxVersion
            else if (hdinsightClusterVersion.Major > HDInsightSDKSupportedVersions.MaxVersion.Major ||
                     (hdinsightClusterVersion.Major == HDInsightSDKSupportedVersions.MaxVersion.Major &&
                      hdinsightClusterVersion.Minor > HDInsightSDKSupportedVersions.MaxVersion.Minor))
            {
                return VersionStatus.ToolsUpgradeRequired;
            }

            return VersionStatus.Compatible;
        }
    }
}
