using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Batch.Models
{
    public partial class BatchAccountIdentity
    {
        public BatchAccountIdentity(ResourceIdentityType type, string principalId = default(string), string tenantId = default(string), IDictionary<string, BatchAccountIdentityUserAssignedIdentitiesValue> userAssignedIdentities = default(IDictionary<string, BatchAccountIdentityUserAssignedIdentitiesValue>))
        : this(type, principalId, tenantId, userAssignedIdentities as IDictionary<string, UserAssignedIdentities>)
        {
        }
    }
}
