/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource.ResourceGroup.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core;

    /// <summary>
    /// Grouping of all the resource group update stages.
    /// </summary>
    public interface IUpdateStages 
    {
    }
    /// <summary>
    /// An immutable client-side representation of an Azure resource group.
    /// </summary>
    public interface IResourceGroup  :
        IIndexable,
        IResource,
        IRefreshable<IResourceGroup>,
        IWrapper<ResourceGroupInner>,
        IUpdatable<IUpdate>
    {
        /// <returns>the name of the resource group</returns>
        new string Name { get; }

        /// <returns>the provisioning state of the resource group</returns>
        string ProvisioningState { get; }

        /// <summary>
        /// Captures the specified resource group as a template.
        /// </summary>
        /// <param name="options">options the export options</param>
        /// <returns>the exported template result</returns>
        IResourceGroupExportResult ExportTemplate (ResourceGroupExportTemplateOptions options);

    }
    public interface IDefinitionStages 
    {
    }
}