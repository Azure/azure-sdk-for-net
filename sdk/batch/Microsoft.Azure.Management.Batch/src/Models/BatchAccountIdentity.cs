using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Batch.Models
{
    public partial class BatchAccountIdentity
    {
        public BatchAccountIdentity(ResourceIdentityType type, IDictionary<string, UserAssignedIdentities> userAssignedIdentities)
        : this(type, default(string), default(string), userAssignedIdentities)
        {
        }

        [Obsolete("Please use BatchAccountIdentity(ResourceIdentityType type, IDictionary<string, UserAssignedIdentities> userAssignedIdentities) instead.")]
        public BatchAccountIdentity(ResourceIdentityType type, IDictionary<string, BatchAccountIdentityUserAssignedIdentitiesValue> userAssignedIdentities)
        : this(type, default(string), default(string), userAssignedIdentities.ToDictionary(k => k.Key, v => (UserAssignedIdentities)v.Value))
        {
            // This constructor exists for legacy support. Do not add anything here.
        }
    }
}
