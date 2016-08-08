using System.Linq;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    public static class ResourceUtils
    {
        public static string ExtractFromResourceId(string id, string identifier)
        {
            if (id == null || identifier == null)
            {
                return null;
            }

            identifier = identifier.ToLower();
            return id.Split('/')
                .SkipWhile(part => !part.ToLower().Equals(identifier))
                .Skip(1)
                .FirstOrDefault();
        }

        public static string GroupFromResourceId(string id)
        {
            return ExtractFromResourceId(id, "resourceGroups");
        }

        public static string ResourceProviderFromResourceId(string id)
        {
            return ExtractFromResourceId(id, "providers");
        }

        public static string NameFromResourceId(string id)
        {
            return id.Split('/').Last();
        }

        public static string ResourceTypeFromResourceId(string id)
        {
            return id.Split('/')
                .Reverse()
                .Skip(1)
                .Take(1)
                .FirstOrDefault();
        }

        public static string ParentResourcePathFromResourceId(string id)
        {
            string parent = id.Replace("/" + ResourceTypeFromResourceId(id) + "/" + NameFromResourceId(id) + "/", "");
            return ExtractFromResourceId(parent, ResourceProviderFromResourceId(parent));
        }
    }
}
