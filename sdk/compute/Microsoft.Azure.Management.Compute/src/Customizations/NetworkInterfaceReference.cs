using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class NetworkInterfaceReference : SubResource
    {
        public NetworkInterfaceReference(string id = default(string), bool? primary = default(bool?), string deleteOption = default(string))
            : base(id)
        {
            Primary = primary;
            DeleteOption = deleteOption;
            CustomInit();
        }
    }
}
