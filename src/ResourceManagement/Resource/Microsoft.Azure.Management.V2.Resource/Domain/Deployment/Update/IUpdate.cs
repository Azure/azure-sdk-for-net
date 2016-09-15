/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Deployment.Update
{

    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;

    /// <summary>
    /// Grouping of all the deployment updates stages.
    /// </summary>
    public interface IUpdateStages 
    {
    }
    /// <summary>
    /// A deployment update allowing to change the deployment mode.
    /// </summary>
    public interface IWithMode 
    {
        /// <summary>
        /// Specifies the deployment mode.
        /// </summary>
        /// <param name="mode">mode the mode of the deployment</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithMode (DeploymentMode mode);

    }
    /// <summary>
    /// The template for a deployment update operation, containing all the settings that
    /// can be modified.
    /// <p>
    /// Call {@link Update#apply()} to apply the changes to the deployment in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<IDeployment>,
        IWithTemplate,
        IWithParameters,
        IWithMode
    {
    }
    /// <summary>
    /// A deployment update allowing to change the parameters.
    /// </summary>
    public interface IWithParameters 
    {
        /// <summary>
        /// Specifies the parameters as a Java object.
        /// </summary>
        /// <param name="parameters">parameters the Java object</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithParameters (object parameters);

        /// <summary>
        /// Specifies the parameters as a JSON string.
        /// </summary>
        /// <param name="parametersJson">parametersJson the JSON string</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithParameters (string parametersJson);

        /// <summary>
        /// Specifies the parameters as a URL.
        /// </summary>
        /// <param name="uri">uri the location of the remote parameters file</param>
        /// <param name="contentVersion">contentVersion the version of the parameters file</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithParametersLink (string uri, string contentVersion);

    }
    /// <summary>
    /// A deployment update allowing to change the template.
    /// </summary>
    public interface IWithTemplate 
    {
        /// <summary>
        /// Specifies the template as a Java object.
        /// </summary>
        /// <param name="template">template the Java object</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithTemplate (object template);

        /// <summary>
        /// Specifies the template as a JSON string.
        /// </summary>
        /// <param name="templateJson">templateJson the JSON string</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithTemplate (string templateJson);

        /// <summary>
        /// Specifies the template as a URL.
        /// </summary>
        /// <param name="uri">uri the location of the remote template file</param>
        /// <param name="contentVersion">contentVersion the version of the template file</param>
        /// <returns>the next stage of the deployment update</returns>
        IUpdate WithTemplateLink (string uri, string contentVersion);

    }
}