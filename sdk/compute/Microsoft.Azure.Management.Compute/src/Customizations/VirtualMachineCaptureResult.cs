using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Models
{
    public partial class VirtualMachineCaptureResult : SubResource
    {
        public VirtualMachineCaptureResult(string id = default(string), string schema = default(string), string contentVersion = default(string), object parameters = default(object), IList<object> resources = default(IList<object>))
            : base(id)
        {
            Schema = schema;
            ContentVersion = contentVersion;
            Parameters = parameters;
            Resources = resources;
            CustomInit();
        }
    }
}