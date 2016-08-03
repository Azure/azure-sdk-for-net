/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.V2.Resource.Deployment.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using System;
    using Microsoft.Azure.Management.V2.Resource.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure deployment.
    /// </summary>
    public interface IDeployment  :
        IRefreshable<IDeployment>,
        IUpdatable<IUpdate>,
        IWrapper<DeploymentExtendedInner>
    {
        /// <returns>the name of this deployment's resource group</returns>
        string ResourceGroupName { get; }

        /// <returns>the name of the deployment</returns>
        string Name { get; }

        /// <returns>the state of the provisioning process of the resources being deployed</returns>
        string ProvisioningState { get; }

        /// <returns>the correlation ID of the deployment</returns>
        string CorrelationId { get; }

        /// <returns>the timestamp of the template deployment</returns>
        DateTime? Timestamp { get; }

        /// <returns>key/value pairs that represent deployment output</returns>
        object Outputs { get; }

        /// <returns>the list of resource providers needed for the deployment</returns>
        IList<IProvider> Providers { get; }

        /// <returns>the list of deployment dependencies</returns>
        IList<Dependency> Dependencies { get; }

        /// <returns>the template content</returns>
        object Template { get; }

        /// <returns>the URI referencing the template</returns>
        TemplateLink TemplateLink { get; }

        /// <returns>the deployment parameters</returns>
        object Parameters { get; }

        /// <returns>the URI referencing the parameters</returns>
        ParametersLink ParametersLink { get; }

        /// <returns>the deployment mode. Possible values include:</returns>
        /// <returns>'Incremental', 'Complete'.</returns>
        DeploymentMode? Mode { get; }

        /// <returns>the operations related to this deployment</returns>
        IDeploymentOperations DeploymentOperations { get; }

        /// <summary>
        /// Cancel a currently running template deployment.
        /// </summary>
        void Cancel ();

        /// <summary>
        /// Exports a deployment template.
        /// </summary>
        /// <returns>the export result</returns>
        IDeploymentExportResult ExportTemplate { get; }

    }
}