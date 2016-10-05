// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.Resource.Fluent
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
                return JsonConvert.SerializeObject(Template);
            }
        }
    }
}
