// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The final stage of the web app source control definition.
    /// At this stage, any remaining optional settings can be specified, or the web app source control definition
    /// can be attached to the parent web app update using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// A web app source control definition allowing branch to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithGitHubBranch<ParentT> 
    {
        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<ParentT> WithBranch(string branch);
    }

    /// <summary>
    /// A web app source control definition allowing repository type to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRepositoryType<ParentT> 
    {
        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Mercurial repository.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithBranch<ParentT> WithPublicMercurialRepository(string url);

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Git repository.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithBranch<ParentT> WithPublicGitRepository(string url);

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="organization">The user name or organization name the GitHub repository belongs to, e.g. Azure.</param>
        /// <param name="repository">The name of the repository, e.g. azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<ParentT> WithContinuouslyIntegratedGitHubRepository(string organization, string repository);

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="url">The URL pointing to the repository, e.g. https://github.com/Azure/azure-sdk-for-java.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<ParentT> WithContinuouslyIntegratedGitHubRepository(string url);
    }

    /// <summary>
    /// A web app source control definition allowing GitHub access token to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithGitHubAccessToken<ParentT> 
    {
        /// <summary>
        /// Specifies the GitHub personal access token. You can acquire one from
        /// https://github.com/settings/tokens.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token from GitHub.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<ParentT> WithGitHubAccessToken(string personalAccessToken);
    }

    /// <summary>
    /// The entirety of a web app source control definition as part of a web app update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IGitHubWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithRepositoryType<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithBranch<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithGitHubBranch<ParentT>
    {
    }

    /// <summary>
    /// A web app source control definition allowing branch to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithBranch<ParentT> 
    {
        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithAttach<ParentT> WithBranch(string branch);
    }

    /// <summary>
    /// The final stage of the web app source control definition that binds to a GitHub account.
    /// At this stage, any remaining optional settings can be specified, or the web app source control definition
    /// can be attached to the parent web app update using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IGitHubWithAttach<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithGitHubAccessToken<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a web app source control definition as part of an update of a web app.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IWithRepositoryType<ParentT>
    {
    }
}