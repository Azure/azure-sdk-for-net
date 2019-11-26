namespace StorSimple1200Series.Tests
{
    using System.Reflection;
    using System.Runtime.Serialization;

    /// <summary>
    /// This class is the data contract for converting vault credential file which customers passes during 
    /// registration to object 
    /// </summary>
    [DataContract]
    public class VaultCredentials
    {
        public override string ToString()
        {
            string tmp = string.Empty;
            foreach (var propertyInfo in this.GetType().GetProperties())
            {
                tmp += string.Format("{0}:{1} ", propertyInfo.Name, propertyInfo.GetValue(this));
            }

            return tmp;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the key name for SubscriptionId entry.
        /// </summary>
        [DataMember(Order = 0, IsRequired = true)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceType entry.
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceName entry.
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for ManagementCert entry.
        /// </summary>
        [DataMember(Order = 3, IsRequired = true)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the vault.
        /// </summary>
        [DataMember(Order = 4, IsRequired = true)]
        public long? ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the AAD Authority.
        /// </summary>
        [DataMember(Order = 5, IsRequired = true)]
        public string AadAuthority { get; set; }

        /// <summary>
        /// Gets or sets AadAudience
        /// </summary>
        [DataMember(Order = 6, IsRequired = true)]
        public string AadAudience { get; set; }

        /// <summary>
        /// Gets or sets the AAD Tenant Id.
        /// </summary>
        [DataMember(Order = 7, IsRequired = true)]
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets the Service Principal Client Id.
        /// </summary>
        [DataMember(Order = 8, IsRequired = true)]
        public string ServicePrincipalClientId { get; set; }

        /// <summary>
        /// Gets or sets the Azure Management Endpoint Audience.
        /// </summary>
        [DataMember(Order = 9, IsRequired = true)]
        public string AzureManagementEndpointAudience { get; set; }

        /// <summary>
        /// Gets or sets the ProviderNamespace.
        /// </summary>
        [DataMember(Order = 10, IsRequired = true)]
        public string ProviderNamespace { get; set; }

        /// <summary>
        /// Gets or sets the Resource Group.
        /// </summary>
        [DataMember(Order = 11, IsRequired = true)]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the Location.
        /// </summary>
        [DataMember(Order = 12, IsRequired = true)]
        public string ServiceDataIntegrityKey { get; set; }
        #endregion
    }
}
