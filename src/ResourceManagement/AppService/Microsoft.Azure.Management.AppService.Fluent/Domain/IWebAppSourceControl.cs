// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A web app source control in a web app.
    /// </summary>
    public interface IWebAppSourceControl  :
        IHasInner<Models.SiteSourceControlInner>,
        IChildResource<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>
    {
        /// <summary>
        /// Gets mercurial or Git repository type.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RepositoryType? RepositoryType { get; }

        /// <summary>
        /// Gets the name of the branch to use for deployment.
        /// </summary>
        string Branch { get; }

        /// <summary>
        /// Gets the repository or source control url.
        /// </summary>
        string RepositoryUrl { get; }

        /// <summary>
        /// Gets whether to do manual or continuous integration.
        /// </summary>
        bool IsManualIntegration { get; }

        /// <summary>
        /// Gets whether deployment rollback is enabled.
        /// </summary>
        bool DeploymentRollbackEnabled { get; }
    }
}