using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class ResourceGroupExportResultImpl :
        Wrapper<ResourceGroupExportResultInner>,
        IResourceGroupExportResult
    {

        public ResourceGroupExportResultImpl(ResourceGroupExportResultInner inner) : base(inner)
        {
        }

        public ResourceManagementErrorWithDetails Error
        {
            get
            {
                return Inner.Error;
            }
        }

        public object Template
        {
            get
            {
                return Inner.Template;
            }
        }

        public string TemplateJson
        {
            get
            {
                return null;
            }
        }
    }
}
