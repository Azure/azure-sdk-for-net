

namespace Fabric.Tests
{
    using Microsoft.AzureStack.Management.Fabric.Admin.Models;

    class FabricCommon
    {

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
