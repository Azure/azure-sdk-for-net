using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// Service Principal that is used to get an OAuth2 token 
    /// </summary>
    public class ServicePrincipal : Principal
    {
        /// <summary>
        /// Gets Application principal id of the service principal 
        /// </summary>
        public Guid AppPrincipalId { get; private set; }

        /// <summary>
        /// Gets client certificate associated with service principal
        /// </summary>
        public string ClientCertificate { get; private set; }

        /// <summary>
        /// Gets client certificate password associated with service principal
        /// </summary>
        public string ClientCertificatePassword { get; private set; }

        /// <summary>
        /// Gets AAD tenant uri of the service principal
        /// </summary>
        public Uri AADTenantId { get; private set; }

        /// <summary>
        /// Gets Resource uri of the service principal
        /// </summary>
        public Uri ResourceUri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ServicePrincipal class.
        /// </summary>
        /// <param name="appPrincipalId">Application principal id of the service principal.</param>
        /// <param name="clientCertificateFileName">client certificate file name associated with service principal.</param>
        /// <param name="clientCertificatePassword">client certificate password associated with service principal.</param>
        /// <param name="aadTenantId">AAD tenant uri of the service principal</param>
        public ServicePrincipal(Guid appPrincipalId, Uri aadTenantId, string clientCertificateFileName, string clientCertificatePassword)
        {
            if (appPrincipalId == Guid.Empty)
                throw new ArgumentException("Input cannot be empty", "appPrincipalId");

            if (aadTenantId == null)
                throw new ArgumentNullException("aadTenantId");
            
            if (string.IsNullOrEmpty(clientCertificateFileName))
                throw new ArgumentException("Input cannot be null or empty", "clientCertificateFileName");

            if (!File.Exists(clientCertificateFileName))
                throw new ArgumentException("File doesn't exist", clientCertificateFileName);

            //validate certificate
            X509Certificate2 clientCertificate = null;
            byte[] certBytes = File.ReadAllBytes(clientCertificateFileName);
            try
            {
                clientCertificate = new X509Certificate2();
                clientCertificate.Import(certBytes, clientCertificatePassword,
                    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Certificate", clientCertificateFileName);
            }

            this.AppPrincipalId = appPrincipalId;
            this.AADTenantId = aadTenantId;
            this.ClientCertificate = Convert.ToBase64String(certBytes);
            this.ClientCertificatePassword = clientCertificatePassword;

            //Resource Uri of data lake 
            this.ResourceUri = new Uri("https://management.core.windows.net/");
        }
    }
}
