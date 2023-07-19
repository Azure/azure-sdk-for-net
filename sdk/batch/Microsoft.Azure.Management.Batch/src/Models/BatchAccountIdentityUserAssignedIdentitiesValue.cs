using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Batch.Models
{
    [Obsolete("Please use UserAssignedIdentities instead.")]
    public class BatchAccountIdentityUserAssignedIdentitiesValue : UserAssignedIdentities
    {
        public BatchAccountIdentityUserAssignedIdentitiesValue(string principalId = default(string), string clientId = default(string))
        : base(principalId, clientId)
        {
        }
    }
}
