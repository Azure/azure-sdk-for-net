using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Media.Models
{
    /// <summary>
    /// A Media Services account.
    /// </summary>
    public partial class MediaService : TrackedResource
    {
        /// <summary>
        /// Initializes a new instance of the MediaService class.
        /// </summary>
        /// <param name="location">The geo-location where the resource
        /// lives</param>
        /// <param name="id">Fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</param>
        /// <param name="name">The name of the resource</param>
        /// <param name="type">The type of the resource. E.g.
        /// "Microsoft.Compute/virtualMachines" or
        /// "Microsoft.Storage/storageAccounts"</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="mediaServiceId">The Media Services account ID.</param>
        /// <param name="storageAccounts">The storage accounts for this
        /// resource.</param>
        /// <param name="storageAuthentication">Possible values include:
        /// 'System', 'ManagedIdentity'</param>
        /// <param name="encryption">The account encryption properties.</param>
        /// <param name="identity">The Managed Identity for the Media Services
        /// account.</param>
        /// <param name="systemData">The system metadata relating to this
        /// resource.</param>
        /// <param name="keyDelivery">The Key Delivery properties for Media Services account.</param>
        public MediaService(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), System.Guid mediaServiceId = default(System.Guid), IList<StorageAccount> storageAccounts = default(IList<StorageAccount>), StorageAuthentication? storageAuthentication = default(StorageAuthentication?), AccountEncryption encryption = default(AccountEncryption), MediaServiceIdentity identity = default(MediaServiceIdentity), SystemData systemData = default(SystemData), KeyDelivery keyDelivery = default(KeyDelivery))
            : base(location, id, name, type, tags)
        {
            MediaServiceId = mediaServiceId;
            StorageAccounts = storageAccounts;
            StorageAuthentication = storageAuthentication;
            Encryption = encryption;
            KeyDelivery = keyDelivery;
            Identity = identity;
            SystemData = systemData;
            CustomInit();
        }
    }
}
