using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class DeletedKeyItem
    {
        /// <summary>
        /// The identifier of the deleted key object. This is used to recover the key.
        /// </summary>
        public DeletedKeyIdentifier RecoveryIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(RecoveryId))
                    return new DeletedKeyIdentifier(RecoveryId);
                else
                    return null;
            }
        }
    }
}
