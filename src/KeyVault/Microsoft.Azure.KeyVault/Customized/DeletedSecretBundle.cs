using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.KeyVault.Models
{
    public partial class DeletedSecretBundle
    {
        /// <summary>
        /// The identifier of the deleted secret object. This is used to recover the secret.
        /// </summary>
        public DeletedSecretIdentifier RecoveryIdentifier
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(RecoveryId))
                    return new DeletedSecretIdentifier(RecoveryId);
                else
                    return null;
            }
        }
    }
}
