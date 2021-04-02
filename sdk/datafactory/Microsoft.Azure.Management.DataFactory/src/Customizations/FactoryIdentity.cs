using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class FactoryIdentity
    {
        /// <summary>
        /// Initializes a new instance of the FactoryIdentity class.
        /// </summary>
        /// <param name="principalId">The principal id of the identity.</param>
        /// <param name="tenantId">The client tenant id of the
        /// identity.</param>
        /// <param name="userAssignedIdentities">List of user assigned
        /// identities for the factory.</param>
        public FactoryIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), IDictionary<string, object> userAssignedIdentities = default(IDictionary<string, object>))
        {
            Type = FactoryIdentityType.SystemAssigned;
            PrincipalId = principalId;
            TenantId = tenantId;
            UserAssignedIdentities = userAssignedIdentities;
            CustomInit();
        }
    }
}
