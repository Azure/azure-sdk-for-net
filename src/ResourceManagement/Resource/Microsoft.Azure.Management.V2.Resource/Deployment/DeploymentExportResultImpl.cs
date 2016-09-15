using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Newtonsoft.Json;
using System;

namespace Microsoft.Azure.Management.V2.Resource
{
    internal class DeploymentExportResultImpl :
        Wrapper<DeploymentExportResultInner>,
        IDeploymentExportResult
    {

        internal DeploymentExportResultImpl(DeploymentExportResultInner innerModel) : base(innerModel)
        {
        }

        public object Template
        {
            get
            {
                return Inner.Template;
            }
        }

        public string TemplateAsJson
        {
            get
            {
                return JsonConvert.SerializeObject(Template);
            }
        }
    }
}
