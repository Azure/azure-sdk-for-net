using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{

    public partial class DiskEncryptionSetParameters : SubResource
    {
        public DiskEncryptionSetParameters(string id = default(string))
            : base(id)
        {
            CustomInit();
        }
    }
}
