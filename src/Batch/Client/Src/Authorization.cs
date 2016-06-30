using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Authorization levels available for enforcement of restrictions.
    /// </summary>
    [Flags]
    internal enum AuthorizationLevel { User = 0, Admin = 1}
}
