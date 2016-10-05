// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Resource
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Fluent.Resource.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure deployment template export result.
    /// </summary>
    public interface IDeploymentExportResult  :
        IWrapper<DeploymentExportResultInner>
    {
        /// <returns>the template content</returns>
        object Template { get; }

        /// <returns>the template content as a JSON string</returns>
        string TemplateAsJson { get; }

    }
}