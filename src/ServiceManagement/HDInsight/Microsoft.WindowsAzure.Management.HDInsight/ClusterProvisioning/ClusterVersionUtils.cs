namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ClusterVersionUtils
    {
        public const string HwxVersionSuffix = @"-hwx-trunk";

        public static string TryGetVersionNumber(string version)
        {
            if (version.EndsWith(HwxVersionSuffix))
            {
                return version.Replace(HwxVersionSuffix, string.Empty);
            }
            return version;
        }
    }
}
