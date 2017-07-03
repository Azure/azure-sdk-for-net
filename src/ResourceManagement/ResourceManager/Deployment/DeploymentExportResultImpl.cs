// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Newtonsoft.Json;
using System;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
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
