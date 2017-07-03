// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    internal partial class WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> 
    {
        /// <summary>
        /// Specifies the GitHub personal access token. You can acquire one from
        /// https://github.com/settings/tokens.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token from GitHub.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithGitHubAccessToken<WebAppBase.Update.IUpdate<FluentT>>.WithGitHubAccessToken(string personalAccessToken)
        {
            return this.WithGitHubAccessToken(personalAccessToken) as WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the GitHub personal access token. You can acquire one from
        /// https://github.com/settings/tokens.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token from GitHub.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IGitHubWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithGitHubAccessToken<WebAppBase.Definition.IWithCreate<FluentT>>.WithGitHubAccessToken(string personalAccessToken)
        {
            return this.WithGitHubAccessToken(personalAccessToken) as WebAppSourceControl.Definition.IGitHubWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppBase Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.AppService.Fluent.IWebAppBase;
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Update.IUpdate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<WebAppBase.Update.IUpdate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<WebAppBase.Definition.IWithCreate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<WebAppBase.Update.IUpdate<FluentT>>.WithBranch(string branch)
        {
            return this.WithBranch(branch) as WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IGitHubWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithGitHubBranch<WebAppBase.Definition.IWithCreate<FluentT>>.WithBranch(string branch)
        {
            return this.WithBranch(branch) as WebAppSourceControl.Definition.IGitHubWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Gets the name of the branch to use for deployment.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl.Branch
        {
            get
            {
                return this.Branch();
            }
        }

        /// <summary>
        /// Gets whether to do manual or continuous integration.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl.IsManualIntegration
        {
            get
            {
                return this.IsManualIntegration();
            }
        }

        /// <summary>
        /// Gets the repository or source control url.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl.RepositoryUrl
        {
            get
            {
                return this.RepositoryUrl();
            }
        }

        /// <summary>
        /// Gets whether deployment rollback is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl.DeploymentRollbackEnabled
        {
            get
            {
                return this.DeploymentRollbackEnabled();
            }
        }

        /// <summary>
        /// Gets mercurial or Git repository type.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RepositoryType? Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl.RepositoryType
        {
            get
            {
                return this.RepositoryType();
            }
        }

        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithBranch<WebAppBase.Update.IUpdate<FluentT>>.WithBranch(string branch)
        {
            return this.WithBranch(branch) as WebAppSourceControl.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithBranch<WebAppBase.Definition.IWithCreate<FluentT>>.WithBranch(string branch)
        {
            return this.WithBranch(branch) as WebAppSourceControl.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Mercurial repository.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IWithBranch<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithRepositoryType<WebAppBase.Update.IUpdate<FluentT>>.WithPublicMercurialRepository(string url)
        {
            return this.WithPublicMercurialRepository(url) as WebAppSourceControl.UpdateDefinition.IWithBranch<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="organization">The user name or organization name the GitHub repository belongs to, e.g. Azure.</param>
        /// <param name="repository">The name of the repository, e.g. azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithRepositoryType<WebAppBase.Update.IUpdate<FluentT>>.WithContinuouslyIntegratedGitHubRepository(string organization, string repository)
        {
            return this.WithContinuouslyIntegratedGitHubRepository(organization, repository) as WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="url">The URL pointing to the repository, e.g. https://github.com/Azure/azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithRepositoryType<WebAppBase.Update.IUpdate<FluentT>>.WithContinuouslyIntegratedGitHubRepository(string url)
        {
            return this.WithContinuouslyIntegratedGitHubRepository(url) as WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Git repository.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.UpdateDefinition.IWithBranch<WebAppBase.Update.IUpdate<FluentT>> WebAppSourceControl.UpdateDefinition.IWithRepositoryType<WebAppBase.Update.IUpdate<FluentT>>.WithPublicGitRepository(string url)
        {
            return this.WithPublicGitRepository(url) as WebAppSourceControl.UpdateDefinition.IWithBranch<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Mercurial repository.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IWithBranch<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithRepositoryType<WebAppBase.Definition.IWithCreate<FluentT>>.WithPublicMercurialRepository(string url)
        {
            return this.WithPublicMercurialRepository(url) as WebAppSourceControl.Definition.IWithBranch<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="organization">The user name or organization name the GitHub repository belongs to, e.g. Azure.</param>
        /// <param name="repository">The name of the repository, e.g. azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IWithGitHubBranch<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithRepositoryType<WebAppBase.Definition.IWithCreate<FluentT>>.WithContinuouslyIntegratedGitHubRepository(string organization, string repository)
        {
            return this.WithContinuouslyIntegratedGitHubRepository(organization, repository) as WebAppSourceControl.Definition.IWithGitHubBranch<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="url">The URL pointing to the repository, e.g. https://github.com/Azure/azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IWithGitHubBranch<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithRepositoryType<WebAppBase.Definition.IWithCreate<FluentT>>.WithContinuouslyIntegratedGitHubRepository(string url)
        {
            return this.WithContinuouslyIntegratedGitHubRepository(url) as WebAppSourceControl.Definition.IWithGitHubBranch<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Git repository.</param>
        /// <return>The next stage of the definition.</return>
        WebAppSourceControl.Definition.IWithBranch<WebAppBase.Definition.IWithCreate<FluentT>> WebAppSourceControl.Definition.IWithRepositoryType<WebAppBase.Definition.IWithCreate<FluentT>>.WithPublicGitRepository(string url)
        {
            return this.WithPublicGitRepository(url) as WebAppSourceControl.Definition.IWithBranch<WebAppBase.Definition.IWithCreate<FluentT>>;
        }
    }
}