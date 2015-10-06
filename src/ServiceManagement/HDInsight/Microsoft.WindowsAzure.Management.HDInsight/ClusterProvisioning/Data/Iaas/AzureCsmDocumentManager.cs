namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class AzureCsmDocumentManager
    {
        private string azureCsmSpecificationDocument;

        private const string DnsNameParameterTag = "#DnsName";
        private const string LocationParameterTag = "#Location";
        private const string WorkerNodeInstanceCountParameterTag = "#WorkerNodeInstanceCount";
        private const string HeadNodeVMSizeParameterTag = "#HeadNodeVMSize";
        private const string DataNodeVMSizeParameterTag = "#DataNodeVMSize";

        private const string SshUserNameParameterTag = "#SshUsername";
        private const string SshPasswordParameterTag = "#SshPassword";
        private const string SshPasswordAuthDisabledParameterTag = "#IsSshPasswordAuthenticationDisabled";
        private const string CertificateFingerprintParameterTag = "#CertificateFingerPrint";
        private const string PublicKeyPathParameterTag = "#PublicKeyPath";
        private const string SshCertificateDataParameterTag = "#SshCertificateData";

        private const string ResourcesKeyName = "resources";
        private const string ResourceNameKeyName = "name";
        private const string WorkerNodeResourceNameKeyValue = "workernode";
        private const string HeadNodeResourceNameKeyValue = "headnode";
        private const string ResourcePropertiesKeyName = "properties";
        private const string InstanceCountKeyName = "instanceCount";

        public AzureCsmDocumentManager(string azureCsmDocument)
        {
            if (String.IsNullOrEmpty(azureCsmDocument))
            {
                throw new ArgumentException("azureCsmDocument");
            }

            Document = azureCsmDocument;
        }

        public string Document
        {
            get { return this.azureCsmSpecificationDocument; }
            private set { this.azureCsmSpecificationDocument = value; }
        }

        public void SetDnsName(string dnsName)
        {
            if (String.IsNullOrEmpty(dnsName))
            {
                throw new ArgumentException("dnsName");
            }

            Document = Document.Replace(DnsNameParameterTag, JsonHelper.EncodeStringForJson(dnsName));
        }

        public void SetLocation(string location)
        {
            if (String.IsNullOrEmpty(location))
            {
                throw new ArgumentException("location");
            }

            Document = Document.Replace(LocationParameterTag, JsonHelper.EncodeStringForJson(location));
        }

        public void SetSshProfile(string sshUserName, X509Certificate2 x509cert)
        {
            if (String.IsNullOrEmpty(sshUserName))
            {
                throw new ArgumentNullException("sshUserName");
            }

            if (x509cert == null)
            {
                throw new ArgumentNullException("x509cert");
            }


            Document = Document.Replace(SshUserNameParameterTag, JsonHelper.EncodeStringForJson(sshUserName));
            Document = Document.Replace(CertificateFingerprintParameterTag, JsonHelper.EncodeStringForJson(x509cert.Thumbprint));
            Document = Document.Replace(PublicKeyPathParameterTag, JsonHelper.EncodeStringForJson(string.Format("/home/{0}/.ssh/authorized_keys", sshUserName)));
            Document = Document.Replace(SshCertificateDataParameterTag, JsonHelper.EncodeByteArrayForJson(x509cert.GetRawCertData()));
        }

        public void SetSshProfile(string sshUserName, string sshPassword)
        {
            if (String.IsNullOrEmpty(sshUserName))
            {
                throw new ArgumentNullException("sshUserName");
            }

            if (String.IsNullOrEmpty(sshPassword))
            {
                throw new ArgumentNullException("sshPassword");
            }

            Document = Document.Replace(SshUserNameParameterTag, JsonHelper.EncodeStringForJson(sshUserName));
            Document = Document.Replace(SshPasswordParameterTag, JsonHelper.EncodeStringForJson(sshPassword));
        }

        public void SetWorkerNodeCount(int workerNodeCount)
        {
            Document = Document.Replace(WorkerNodeInstanceCountParameterTag, JsonHelper.EncodeStringForJson(workerNodeCount.ToString()));
        }

        public void SetHeadNodeVMSize(string headnodeSize)
        {
            if (String.IsNullOrEmpty(headnodeSize))
            {
                throw new ArgumentException("headnodeSize cannot be null or empty.");
            }

            Document = Document.Replace(HeadNodeVMSizeParameterTag, JsonHelper.EncodeStringForJson(headnodeSize));
        }

        public void SetDataNodeVMSize(string datanodeSize)
        {
            if (String.IsNullOrEmpty(datanodeSize))
            {
                throw new ArgumentException("datanodeSize cannot be null or empty.");
            }

            Document = Document.Replace(DataNodeVMSizeParameterTag, JsonHelper.EncodeStringForJson(datanodeSize));
        }
        public int GetWorkerNodeCount()
        {
            JObject azureConfiguration = JObject.Parse(Document);
            return Int32.Parse((string)azureConfiguration[ResourcesKeyName].Single(r => (string)r[ResourceNameKeyName] == WorkerNodeResourceNameKeyValue)[ResourcePropertiesKeyName][InstanceCountKeyName]);
        }
    }
}
