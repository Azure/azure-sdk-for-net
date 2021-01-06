using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Common
{
    public enum NodePlacementPolicyType
    {
        /// <summary>
        /// All nodes in the pool will be allocated in the same region.
        /// </summary>
        Regional,
        /// <summary>
        /// Nodes in the pool will be spread across different availability
        /// zones with best effort balancing.
        /// </summary>
        Zonal
    }
}
