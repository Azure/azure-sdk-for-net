namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.VersionFinder;
    using Microsoft.WindowsAzure.Management.HDInsight.Contracts.Iaas.Jan2015;

    internal class PayloadConverterIaasClusters
    {
        /// <summary>
        /// Converts user supplied cluster create parameters to IaasCluster type as understood by the Resource Provider.
        /// </summary>
        /// <param name="clusterCreateParameters">User supplied cluster create parameters.</param>
        /// <param name="userSubscriptionId">User's subscription Id.</param>
        /// <returns>An Instance of IaasCluster</returns>
        public static IaasCluster ConvertToIaasCluster(ClusterCreateParameters clusterCreateParameters, string userSubscriptionId)
        {
            if (clusterCreateParameters == null)
            {
                throw new ArgumentNullException("clusterCreateParameters");
            }

            if (String.IsNullOrEmpty(userSubscriptionId))
            {
                throw new ArgumentNullException("userSubscriptionId");
            }

            var correlationId = Guid.NewGuid().ToString();

            var iaasCluster = new IaasCluster()
            {
                Id = clusterCreateParameters.Name,
                Location = clusterCreateParameters.Location,
                ApiVersion = "1.0",
                UserSubscriptionId = userSubscriptionId,
                UserTags = new Dictionary<string, string>(),
                HdiVersion = clusterCreateParameters.Version,
                DeploymentDocuments = new Dictionary<string, string>()
                {
                    {IaasClusterDocumentTypes.EmbeddedAmbariConfigurationDocument, GenerateAmbariConfigurationDocument(clusterCreateParameters)},
                    {IaasClusterDocumentTypes.EmbeddedAzureConfigurationDocument, GenerateAzureDocument(clusterCreateParameters)}
                }
            };
                
            return iaasCluster;
        }

        /// <summary>
        /// Creates the rdfe resource input from wire input.
        /// This method wraps what is needed by the RP within a RDFE resource input object.
        /// </summary>
        /// <param name="iaasCluster">The Iaas cluster as needed by the RP.</param>
        /// <param name="schemaVersion">The schema version for the RDFE resource.</param>
        /// <returns>An RDFE Resource input from wire create parameters.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if wireCreateParameters is null.</exception>
        public static RDFEResource CreateRdfeResource(IaasCluster iaasCluster, string schemaVersion)
        {
            if (iaasCluster == null)
            {
                throw new ArgumentNullException("createIaasClusterRequest");
            }

            if (schemaVersion == null)
            {
                throw new ArgumentNullException("schemaVersion");
            }

            var rdfeResource = new RDFEResource 
            { 
                SchemaVersion = schemaVersion,
                IntrinsicSettings = new XmlNode[] { SerializeToXmlNode(iaasCluster) } 
            };

            return rdfeResource;
        }

        /// <summary>
        /// Creates the cluster details from rdfe resource output.
        /// </summary>
        /// <param name="cloudServiceRegion">The cloud service region.</param>
        /// <param name="resource">The resouce output.</param>
        /// <returns>
        /// An instance of ClusterDetails.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if resourceOutput is null.</exception>
        /// <exception cref="System.ArgumentException">Thrown if cloudService region is null or empty.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Microsoft.WindowsAzure.Management.HDInsight.ClusterErrorStatus.#ctor(System.Int32,System.String,System.String)", Justification = "SDK is not localized.")]
        public static ClusterDetails CreateClusterDetailsFromRdfeResourceOutput(string cloudServiceRegion, Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resouceOutput");
            }

            if (string.IsNullOrEmpty(cloudServiceRegion))
            {
                throw new ArgumentException("CloudService region cannot be null or empty.");
            }

            string version = SafeGetValueFromOutputItem(resource.OutputItems, "Version");
            string osType = SafeGetValueFromOutputItem(resource.OutputItems, "OsType");

            var clusterDetails = new ClusterDetails
            {
                Name = resource.Name,
                Version = version,
                StateString = resource.SubState,
                Location = cloudServiceRegion,
            };

            if (!string.IsNullOrEmpty(version))
            {
                clusterDetails.VersionStatus = VersionFinderClient.GetVersionStatus(version);
                clusterDetails.VersionNumber = new PayloadConverter().ConvertStringToVersion(version);
            }
            else
            {
                clusterDetails.VersionNumber = new Version(0, 0);
            }

            //Operation status is populated with failed, then let us mark the state as error
            if (resource.OperationStatus != null && resource.OperationStatus.Result.Equals("Failed", StringComparison.OrdinalIgnoreCase))
            {
                clusterDetails.State = HDInsight.ClusterState.Error;
                string errorType = resource.OperationStatus.Type ?? string.Empty;
                clusterDetails.StateString = HDInsight.ClusterState.Error.ToString();
                if (resource.OperationStatus.Error != null)
                {
                    int httpCode = resource.OperationStatus.Error.HttpCode;
                    string errorMessage = resource.OperationStatus.Error.Message ?? string.Empty;

                    clusterDetails.Error = new ClusterErrorStatus(httpCode,
                        errorMessage,
                        errorType);
                }
                else
                {
                    clusterDetails.Error = new ClusterErrorStatus(0, "Unknown error occurred", errorType);
                }
            }
            else
            {
                HDInsight.ClusterState clusterState;
                if (!Enum.TryParse(resource.SubState, true, out clusterState))
                {
                    clusterState = HDInsight.ClusterState.Unknown;
                }
                clusterDetails.State = clusterState;
            }

            return clusterDetails;
        }

        /// <summary>
        /// Creates the cluster details from get clusters result.
        /// </summary>
        /// <param name="clusterDetailsFromServer">The cluster details from server.</param>
        /// <returns>An instance of ClusterDetails from Cluster.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Complexity is fine.")]
        public static ClusterDetails CreateClusterDetailsFromGetClustersResult(IaasCluster clusterDetailsFromServer)
        {
            if (clusterDetailsFromServer == null)
            {
                throw new ArgumentNullException("clusterDetailsFromServer");
            }

            ClusterDetails clusterDetails = new ClusterDetails();
            clusterDetails.CreatedDate = clusterDetailsFromServer.CreatedDate;
            clusterDetails.Location = clusterDetailsFromServer.Location;
            clusterDetails.Name = clusterDetailsFromServer.Id;
            clusterDetails.Version = clusterDetailsFromServer.HdiVersion;
            clusterDetails.StateString = clusterDetailsFromServer.State.ToString();
            clusterDetails.DeploymentId = clusterDetailsFromServer.TenantId.ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(clusterDetails.Version))
            {
                clusterDetails.VersionNumber = new PayloadConverter().ConvertStringToVersion(clusterDetails.Version);
                clusterDetails.VersionStatus = VersionFinderClient.GetVersionStatus(clusterDetails.Version);
            }
            else
            {
                clusterDetails.VersionNumber = new Version(0, 0);
            }

            // TODO: Determine this from the documents?
            clusterDetails.ClusterType = ClusterType.Hadoop;

            // This code will only run for IaasCluster which only supports Linux today
            // We would need to put this information in one of the documents at some point
            clusterDetails.ClusterOSType = OSType.Linux;

            if (clusterDetailsFromServer.Errors != null && clusterDetailsFromServer.Errors.Any())
            {
                //Populate error details with the most recent one. These occur if the deployment workflow errors out
                clusterDetails.Error = new ClusterErrorStatus(0, clusterDetailsFromServer.Errors.First().ErrorDescription ?? string.Empty, string.Empty);
            }

            AzureCsmDocumentManager azureCsmDocumentManager = new AzureCsmDocumentManager(clusterDetailsFromServer.DeploymentDocuments[IaasClusterDocumentTypes.EmbeddedAzureConfigurationDocument]);
            AmbariConfigurationDocumentManager ambariConfigurationDocumentManager = new AmbariConfigurationDocumentManager(clusterDetailsFromServer.DeploymentDocuments[IaasClusterDocumentTypes.EmbeddedAmbariConfigurationDocument]);

            // Populate user name, passowrd, and server address information
            // TODO: remove hardcoding
            clusterDetails.ConnectionUrl = String.Format("http://{0}.cloudapp.net/", clusterDetails.Name);
            clusterDetails.HttpUserName = "admin";
            clusterDetails.HttpPassword = ambariConfigurationDocumentManager.GetPassword();

            clusterDetails.DefaultStorageAccount = ambariConfigurationDocumentManager.GetDefaultStorageAccount();

            // Populate additional Storage Accounts
            clusterDetails.AdditionalStorageAccounts = ambariConfigurationDocumentManager.GetAdditionalStorageAccounts();

            // Populate Data Node Count
            clusterDetails.ClusterSizeInNodes = azureCsmDocumentManager.GetWorkerNodeCount();

            return clusterDetails;
        }

        #region Private methods

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

        private static string SerializeToXml<T>(T o)
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var ms = new MemoryStream())
            {
                ser.WriteObject(ms, o);
                ms.Seek(0, SeekOrigin.Begin);
                return new StreamReader(ms).ReadToEnd();
            }
        }

        private static XmlNode SerializeToXmlNode<T>(T o)
        {
            var objAsXml = SerializeToXml(o);
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.DtdProcessing = DtdProcessing.Prohibit;
            using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(objAsXml), readerSettings))
            {
                doc.Load(reader);
            }
            return doc.DocumentElement;
        }

        private static string SafeGetValueFromOutputItem(IEnumerable<OutputItem> itemlist, string itemKey)
        {
            if (itemlist == null)
            {
                return string.Empty;
            }
            var item = itemlist.SingleOrDefault(o => o.Key.Equals(itemKey, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                return string.Empty;
            }
            return item.Value;
        }

        private static string GenerateAzureDocument(ClusterCreateParameters clusterCreateParameters)
        {
            if (clusterCreateParameters == null)
            {
                throw new ArgumentNullException("clusterCreateParameters");
            }

            string document = VersionToDocumentMapper.GetDocument(IaasClusterDocumentTypes.EmbeddedAzureConfigurationDocument, clusterCreateParameters.Version);
            AzureCsmDocumentManager azureCsmDocumentManager = new AzureCsmDocumentManager(document);

            // Set basic cluster parameters
            azureCsmDocumentManager.SetDnsName(clusterCreateParameters.Name);
            azureCsmDocumentManager.SetLocation(clusterCreateParameters.Location);
            azureCsmDocumentManager.SetWorkerNodeCount(clusterCreateParameters.ClusterSizeInNodes);

            // Set SSH parameters
            if (!String.IsNullOrEmpty(clusterCreateParameters.SshUserName))
            {
                var x509cert = GetOpenSshCertificate(clusterCreateParameters.SshPublicKey, String.Format("CN={0}", clusterCreateParameters.Name));
                azureCsmDocumentManager.SetSshProfile(clusterCreateParameters.SshUserName, x509cert);
            }
            
            return azureCsmDocumentManager.Document;
        }

        private static string GenerateAmbariConfigurationDocument(ClusterCreateParameters clusterCreateParameters)
        {
            if (clusterCreateParameters == null)
            {
                throw new ArgumentNullException("clusterCreateParameters");
            }

            string document = VersionToDocumentMapper.GetDocument(IaasClusterDocumentTypes.EmbeddedAmbariConfigurationDocument, clusterCreateParameters.Version);
            AmbariConfigurationDocumentManager ambariConfigurationManager = new AmbariConfigurationDocumentManager(document);

            // Set password
            ambariConfigurationManager.SetPassword(clusterCreateParameters.Password);

            // Set default storage account information
            ambariConfigurationManager.RemoveStorageAccountEntries();
            ambariConfigurationManager.SetDefaultStorageAccount(clusterCreateParameters.DefaultStorageContainer, clusterCreateParameters.DefaultStorageAccountName, clusterCreateParameters.DefaultStorageAccountKey);

            // Set additional storage accounts
            foreach (var storageAccount in clusterCreateParameters.AdditionalStorageAccounts)
            {
                ambariConfigurationManager.SetAdditionalStorageAccount(storageAccount.Name, storageAccount.Key);
            }

            // Set user specified Hadoop configurations
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.CoreConfigurationKeyName, clusterCreateParameters.CoreConfiguration);
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.HdfsConfigurationKeyName, clusterCreateParameters.HdfsConfiguration);
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.YarnConfigurationKeyName, clusterCreateParameters.YarnConfiguration);
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.HiveConfigurationKeyName, clusterCreateParameters.HiveConfiguration.ConfigurationCollection);
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.OozieConfigurationKeyName, clusterCreateParameters.OozieConfiguration.ConfigurationCollection);
            ambariConfigurationManager.SetCustomConfigurations(AmbariConfigurationDocumentManager.MapredConfigurationKeyName, clusterCreateParameters.MapReduceConfiguration.ConfigurationCollection);

            return ambariConfigurationManager.Document;

        }

        private static X509Certificate2 GetOpenSshCertificate(string openSshPublicKey, string subject)
        {
            var sshHelper = new OpenSshToX509CertificateHelper();
            var certContent = sshHelper.ConvertOpenSshPublicKeyToX509Cert(openSshPublicKey, subject);

            byte[] x509CertContentInBytes = new byte[certContent.Length * sizeof(char)];
            Buffer.BlockCopy(certContent.ToCharArray(), 0, x509CertContentInBytes, 0, x509CertContentInBytes.Length);
            return new X509Certificate2(x509CertContentInBytes);
        }

        #endregion

    }
}