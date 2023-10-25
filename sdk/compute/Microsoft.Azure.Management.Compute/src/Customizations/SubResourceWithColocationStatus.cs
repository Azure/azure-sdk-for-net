using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class SubResourceWithColocationStatus : SubResource
    {
        public SubResourceWithColocationStatus(string id = default(string), InstanceViewStatus colocationStatus = default(InstanceViewStatus))
            : base(id)
        {
            ColocationStatus = colocationStatus;
            CustomInit();
        }
    }
}