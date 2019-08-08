using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Options that allow to configure the management of the request sent to Key Vault
    /// </summary>
    public class CryptographyClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest service version supported by this client library.
        /// For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V7_0;

        /// <summary>
        /// The versions of Azure Key Vault supported by this client
        /// library.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Key Vault API version 7.0.
            /// </summary>
            V7_0 = 0
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }

        /// <summary>
        /// Gets the <see cref="ServiceVersion"/> of the service API used when
        /// making requests. For more information, see
        /// <see href="https://docs.microsoft.com/en-us/rest/api/keyvault/key-vault-versions"/>
        /// </summary>
        public ServiceVersion Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public CryptographyClientOptions(ServiceVersion version = ServiceVersion.V7_0)
        {
            this.Version = version;
        }

        internal string GetVersionString()
        {
            var version = string.Empty;

            switch (this.Version)
            {
                case ServiceVersion.V7_0:
                    version = "7.0";
                    break;

                default:
                    throw new ArgumentException(this.Version.ToString());
            }

            return version;
        }
    }
}
