// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// A client-side representation allowing user to deploy to a web app through web deployment (MSDeploy).
    /// </summary>
    public interface IWebDeployment  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.AppService.Fluent.IWebDeployment>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>
    {
        /// <summary>
        /// Gets the start time of the deploy operation.
        /// </summary>
        System.DateTime StartTime { get; }

        /// <summary>
        /// Gets username of the deployer.
        /// </summary>
        string Deployer { get; }

        /// <summary>
        /// Gets the end time of the deploy operation.
        /// </summary>
        System.DateTime EndTime { get; }

        /// <summary>
        /// Gets whether the deployment operation has completed.
        /// </summary>
        bool Complete { get; }
    }
}