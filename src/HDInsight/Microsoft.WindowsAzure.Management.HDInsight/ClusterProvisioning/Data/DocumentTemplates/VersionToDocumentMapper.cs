namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015;

    /// <summary>
    /// Maps cluster versions to corresponding documents
    /// </summary>
    internal static class VersionToDocumentMapper
    {
        private static Dictionary<string, string> supportedVersions;
        private const string locationOfCommonDocuments = "Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.DocumentTemplates.Common";
        private const string azureCsmDocumentName = "hadoop-azure.json";
        private const string ambariBluprintDocumentName = "hadoop-blueprint.json";
        private const string ambariConfigurationDocumentName = "hadoop-configuration.json";

        public static string GetDocument(string documentType, string clusterVersion)
        {
            if (String.IsNullOrEmpty(documentType))
            {
                throw new ArgumentException("documentType");
            }

            if (String.IsNullOrEmpty(clusterVersion))
            {
                throw new ArgumentException("clusterVersion");
            }

            string documentName;

            Version version = new Version(clusterVersion);
            string twoPartVersion = String.Format("{0}.{1}", version.Major, version.Minor);

            if (!SupportedVersions.ContainsKey(twoPartVersion))
            {
                throw new NotSupportedException(String.Format("No documents available for the specified cluster version {0}", clusterVersion.ToString()));
            }

            string locationOfVersionedDocuments = SupportedVersions[twoPartVersion];
            switch (documentType)
            {
                case IaasClusterDocumentTypes.EmbeddedAzureConfigurationDocument:
                {
                    documentName = String.Format("{0}.{1}", locationOfCommonDocuments, azureCsmDocumentName);
                    break;
                }
                case IaasClusterDocumentTypes.EmbeddedAmbariBlueprintDocument:
                {
                    documentName = String.Format("{0}.{1}", locationOfVersionedDocuments, ambariBluprintDocumentName);
                    break;
                }
                case IaasClusterDocumentTypes.EmbeddedAmbariConfigurationDocument:
                {
                    documentName = String.Format("{0}.{1}", locationOfVersionedDocuments, ambariConfigurationDocumentName);
                    break;
                }
                default:
                {
                    throw new InvalidOperationException(String.Format("Specified document type {0} is invalid.", documentType));
                }
            }

            return ReadEmbeddedResource(documentName);
        }

        private static Dictionary<string, string> SupportedVersions
        {
            get
            {
                if (supportedVersions == null)
                {
                    supportedVersions = new Dictionary<string, string>();

                    supportedVersions.Add("3.2", "Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.DocumentTemplates._3._2");
                }

                return supportedVersions;
            }
        }

        private static string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            String result = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }
}
