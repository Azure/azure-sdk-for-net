using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Common
{
    public enum PoolIdentityType
    {
        /// <summary>
        /// Batch pool has user assigned identities with it.
        /// </summary>
        UserAssigned,
        /// <summary>
        /// Batch pool has no identity associated with it. Setting `None` in update pool will remove existing identities.
        /// </summary>
        None
    }
}
