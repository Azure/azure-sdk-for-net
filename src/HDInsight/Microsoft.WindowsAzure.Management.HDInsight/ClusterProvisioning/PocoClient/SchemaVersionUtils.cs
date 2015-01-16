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
                {3, "CAPABILITY_FEATURE_CLUSTERS_CONTRACT_3_SDK"}
            };

        public static string GetSchemaVersion(List<string> capabilities)
        {
            var subscriptionVersions = GetSchemaVersionsForSubscription(capabilities);
            var sdkVersions = SupportedSchemaVersions.Keys.ToList();
            var intersection = subscriptionVersions.Intersect(sdkVersions);
            return String.Format(CultureInfo.CurrentCulture, "{0}.0", intersection.Max());
        }

        public static List<int> GetSchemaVersionsForSubscription(List<string> capabilities)
        {
            //The first two schema versions follow the old regex, and versions 3 on follow the new one.
            string clustersCapability;
            SupportedSchemaVersions.TryGetValue(2, out clustersCapability);

            if (capabilities == null)
            {
                throw new ArgumentNullException("capabilities");
            }

            var matchesOld = capabilities.Select(s => ClustersContractCapabilityRegexOld.Match(s)).Where(match => match.Success).ToList();
            if (matchesOld.Count == 0)
            {
                throw new NotSupportedException(
                    String.Format(CultureInfo.CurrentCulture, "This subscription is not enabled for the clusters contract. The capability {0} is missing.", clustersCapability));
            }

            var schemaVersions = matchesOld.Select(m => Int32.Parse(m.Groups[1].Value, CultureInfo.CurrentCulture)).ToList();

            var matchesNew = capabilities.Select(s => ClustersContractCapabilityRegex.Match(s)).Where(match => match.Success).ToList();
            if (matchesNew.Count != 0)
            {
                schemaVersions.AddRange(
                    matchesNew.Select(m => Int32.Parse(m.Groups[1].Value, CultureInfo.CurrentCulture)).ToList());
            }
            
            if (!schemaVersions.Any())
            {
                throw new NotSupportedException(
                    String.Format(CultureInfo.CurrentCulture, "This subscription is not enabled for the clusters contract. The capability {0} is missing.", clustersCapability));
            }

            return schemaVersions;
        }

        public static List<int> GetSchemaVersionsIntersection(List<int> subscriptionVersions, List<int> sdkVersions)
        {
            var intersection = subscriptionVersions.Intersect(sdkVersions).ToList();
            return intersection;
        }

        public static void EnsureSchemaVersionSupportsResize(List<string> capabilities, bool canUseClustersContract)
        {
            string clustersCapability;
            SupportedSchemaVersions.TryGetValue(1, out clustersCapability);
            if (!canUseClustersContract)
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
