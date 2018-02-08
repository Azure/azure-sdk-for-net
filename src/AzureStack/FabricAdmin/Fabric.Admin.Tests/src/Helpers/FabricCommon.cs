using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AzureStack.Management.Fabric.Admin.Models;

namespace Fabric.Tests {
    
    class FabricCommon {

        // TODO: Compare tags
        public static bool ResourceAreSame(Resource expected, Resource found) {
            if (expected == null) return found == null;
            return expected.Id == found.Id &&
                expected.Location == found.Location &&
                expected.Name == found.Name &&
                expected.Type == found.Type;
        }

        public static bool ValidateResource(Resource resource) {
            return resource != null &&
                resource.Id != null &&
                resource.Location != null &&
                resource.Name != null &&
                resource.Type != null;
        }
    }
}
