using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal static class SchemaVersionUtils
    {
        public const string ClustersContractCapabilityPatternOld = @"CAPABILITY_FEATURE_CLUSTERS_CONTRACT_(\d+)_SDK";
        public const string ClustersContractCapabilityPattern = @"^CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_(\d+)_SDK$";

        public static readonly Regex ClustersContractCapabilityRegexOld = new Regex(ClustersContractCapabilityPatternOld, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static readonly Regex ClustersContractCapabilityRegex = new Regex(ClustersContractCapabilityPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static Dictionary<int, string> SupportedSchemaVersions = new Dictionary<int, string>
            {
                {1, "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_1_SDK"},
                {2, "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_2_SDK"},
                {3, "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_VERSION_3_SDK"}
            };

        public static string GetSchemaVersion(List<string> capabilities)
        {
            var subscriptionVersions = GetSchemaVersionsForSubscription(capabilities);
            var sdkVersions = SupportedSchemaVersions.Keys;
            subscriptionVersions.IntersectWith(sdkVersions);
            return subscriptionVersions.Count != 0 ? String.Format(CultureInfo.CurrentCulture, "{0}.0", subscriptionVersions.Max()) : "1.0";
        }

        public static ISet<int> GetSchemaVersionsForSubscription(List<string> capabilities)
        {
            //The first two schema versions follow the old regex, and versions 3 on follow the new one.
            if (capabilities == null)
            {
                throw new ArgumentNullException("capabilities");
            }

            var matchesOld = capabilities.Select(s => ClustersContractCapabilityRegexOld.Match(s)).Where(match => match.Success).ToList();

            var schemaVersions = new HashSet<int>(matchesOld.Select(m => Int32.Parse(m.Groups[1].Value, CultureInfo.CurrentCulture)).ToList());

            var matchesNew = capabilities.Select(s => ClustersContractCapabilityRegex.Match(s)).Where(match => match.Success).ToList();
            if (matchesNew.Count != 0)
            {
                schemaVersions.UnionWith(
                    matchesNew.Select(m => Int32.Parse(m.Groups[1].Value, CultureInfo.CurrentCulture)));
            }

            if (schemaVersions == null || !schemaVersions.Any())
            {
                throw new NotSupportedException("This subscription is not enabled for the clusters contract.");
            }

            return schemaVersions;
        }
        
        public static void EnsureSchemaVersionSupportsResize(List<string> capabilities)
        {
            string clustersCapability;
            SupportedSchemaVersions.TryGetValue(1, out clustersCapability);
            if (!capabilities.Contains(clustersCapability))
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.CurrentCulture, "This subscription is missing the capability {0} and therefore does not support a change cluster size operation.", clustersCapability));
            }

            string resizeCapability;
            SupportedSchemaVersions.TryGetValue(2, out resizeCapability);
            if (!capabilities.Contains(resizeCapability))
            {
                throw new NotSupportedException(
                    string.Format(CultureInfo.CurrentCulture, "This subscription is missing the capability {0} and therefore does not support a change cluster size operation.", resizeCapability));
            }
        }
    }
}
