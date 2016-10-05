// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Resource.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure deployment template export result.
    /// </summary>
    public interface IResourceGroupExportResult  :
        IWrapper<ResourceGroupExportResultInner>
    {
        /// <returns>the template content</returns>
        object Template { get; }

        /// <returns>the template content as a JSON string</returns>
        string TemplateJson { get; }

        /// <returns>the error, if any.</returns>
        ResourceManagementErrorWithDetails Error { get; }

    }
}