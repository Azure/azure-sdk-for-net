using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015
{
    /// <summary>
    /// A convenient helper class listing available document type strings
    /// </summary>
    internal static class IaasClusterDocumentTypes
    {
        public const string RemoteAmbariBlueprintDocument = "AmbariBlueprintLink";
        public const string EmbeddedAmbariBlueprintDocument = "AmbariBlueprint";

        public const string RemoteAmbariConfigurationDocument = "AmbariConfigurationLink";
        public const string EmbeddedAmbariConfigurationDocument = "AmbariConfiguration";

        public const string RemoteAzureConfigurationDocument = "CsmDocumentLink";
        public const string EmbeddedAzureConfigurationDocument = "CsmDocument";
    }
}
