using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AzureStack.Management.Network.Admin.Models;

namespace Network.Tests {
    
    class NetworkCommon {

        public static bool CheckBaseResourcesAreSame(Resource expected, Resource found)
        {
            if (expected == null)
            {
                return found == null;
            }
            return expected.Id == found.Id &&
                expected.Location == found.Location &&
                expected.Name == found.Name &&
                expected.Type == found.Type;
        }

        public static bool ValidateBaseResources(Resource resource)
        {
            return resource != null &&
                resource.Id == null &&
                resource.Name != null;
        }
    }
}
