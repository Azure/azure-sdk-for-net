/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Deployment.Definition
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Resource.Core.GroupableResource.Definition;
    using Core;

    /// <summary>
    /// The first stage of deployment definition.
    /// </summary>
    public interface IBlank  :
        IWithGroup
    {
    }
    /// <summary>
    /// A deployment definition allowing the deployment mode to be specified.
    /// </summary>
    public interface IWithMode 
    {
        /// <summary>
        /// Specifies the deployment mode.
        /// </summary>
        /// <param name="mode">mode the mode of the deployment</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithCreate WithMode (DeploymentMode mode);

    }
    /// <summary>
    /// A deployment definition with sufficient inputs to create a new
    /// deployment in the cloud, but exposing additional optional inputs to specify.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<IDeployment>
    {
        IDeployment BeginCreate();

    }
    /// <summary>
    /// Container interface for all the deployment definitions.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithGroup,
        IWithTemplate,
        IWithParameters,
        IWithMode,
        IWithCreate
    {
    }
    /// <summary>
    /// A deployment definition allowing resource group to be specified.
    /// </summary>
    public interface IWithGroup  :
        IWithExistingResourceGroup<IWithTemplate>
    {
        /// <summary>
        /// Creates a new resource group to put the deployment in.
        /// </summary>
        /// <param name="name">name the name of the new group</param>
        /// <param name="region">region the region to create the resource group in</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithTemplate WithNewResourceGroup (string name, Region region);

        /// <summary>
        /// Creates a new resource group to put the resource in, based on the definition specified.
        /// </summary>
        /// <param name="groupDefinition">groupDefinition a creatable definition for a new resource group</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithTemplate WithNewResourceGroup (ICreatable<IResourceGroup> groupDefinition);

    }
    /// <summary>
    /// A deployment definition allowing the parameters to be specified.
    /// </summary>
    public interface IWithParameters 
    {
        /// <summary>
        /// Specifies the parameters as a Java object.
        /// </summary>
        /// <param name="parameters">parameters the Java object</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithMode WithParameters (object parameters);

        /// <summary>
        /// Specifies the parameters as a JSON string.
        /// </summary>
        /// <param name="parametersJson">parametersJson the JSON string</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithMode WithParameters (string parametersJson);

        /// <summary>
        /// Specifies the parameters as a URL.
        /// </summary>
        /// <param name="uri">uri the location of the remote parameters file</param>
        /// <param name="contentVersion">contentVersion the version of the parameters file</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithMode WithParametersLink (string uri, string contentVersion);

    }
    /// <summary>
    /// A deployment definition allowing the template to be specified.
    /// </summary>
    public interface IWithTemplate 
    {
        /// <summary>
        /// Specifies the template as a Java object.
        /// </summary>
        /// <param name="template">template the Java object</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithParameters WithTemplate (object template);

        /// <summary>
        /// Specifies the template as a JSON string.
        /// </summary>
        /// <param name="templateJson">templateJson the JSON string</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithParameters WithTemplate (string templateJson);

        /// <summary>
        /// Specifies the template as a URL.
        /// </summary>
        /// <param name="uri">uri the location of the remote template file</param>
        /// <param name="contentVersion">contentVersion the version of the template file</param>
        /// <returns>the next stage of the deployment definition</returns>
        IWithParameters WithTemplateLink (string uri, string contentVersion);

    }
}