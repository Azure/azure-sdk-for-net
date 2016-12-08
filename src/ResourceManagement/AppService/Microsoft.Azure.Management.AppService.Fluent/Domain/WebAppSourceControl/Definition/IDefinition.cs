// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;

    /// <summary>
    /// The entirety of a web app source control definition.
    /// </summary>
    public interface IDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithAttach<ParentT>,
        IGitHubWithAttach<ParentT>,
        IWithRepositoryType<ParentT>,
        IWithBranch<ParentT>,
        IWithGitHubBranch<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the web app source control definition that binds to a GitHub account.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the web app source control definition
    /// can be attached to the parent web app definition using WithAttach.attach().
    /// </summary>
    public interface IGitHubWithAttach<ParentT>  :
        IWithAttach<ParentT>,
        IWithGitHubAccessToken<ParentT>
    {
    }

    /// <summary>
    /// A web app source control definition allowing GitHub access token to be specified.
    /// </summary>
    public interface IWithGitHubAccessToken<ParentT> 
    {
        /// <summary>
        /// Specifies the GitHub personal access token. You can acquire one from
        /// https://github.com/settings/tokens.
        /// </summary>
        /// <param name="personalAccessToken">The personal access token from GitHub.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IGitHubWithAttach<ParentT> WithGitHubAccessToken(string personalAccessToken);
    }

    /// <summary>
    /// A web app source control definition allowing repository type to be specified.
    /// </summary>
    public interface IWithRepositoryType<ParentT> 
    {
        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Mercurial repository.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IWithBranch<ParentT> WithPublicMercurialRepository(string url);

        /// <summary>
        /// Specifies the repository to be a public external repository, either Git or Mercurial.
        /// Continuous integration will not be turned on.
        /// </summary>
        /// <param name="url">The url of the Git repository.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IWithBranch<ParentT> WithPublicGitRepository(string url);

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="organization">The user name or organization name the GitHub repository belongs to, e.g. Azure.</param>
        /// <param name="repository">The name of the repository, e.g. azure-sdk-for-java.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IWithGitHubBranch<ParentT> WithContinuouslyIntegratedGitHubRepository(string organization, string repository);

        /// <summary>
        /// Specifies the repository to be a GitHub repository. Continuous integration
        /// will be turned on.
        /// This repository can be either public or private, but your GitHub access token
        /// must have enough privileges to add a webhook to the repository.
        /// </summary>
        /// <param name="url">The URL pointing to the repository, e.g. https://github.com/Azure/azure-sdk-for-java.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IWithGitHubBranch<ParentT> WithContinuouslyIntegratedGitHubRepository(string url);
    }

    /// <summary>
    /// The final stage of the web app source control definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the web app source control definition
    /// can be attached to the parent web app definition using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// A web app source control definition allowing branch to be specified.
    /// </summary>
    public interface IWithGitHubBranch<ParentT> 
    {
        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IGitHubWithAttach<ParentT> WithBranch(string branch);
    }

    /// <summary>
    /// A web app source control definition allowing branch to be specified.
    /// </summary>
    public interface IWithBranch<ParentT> 
    {
        /// <summary>
        /// Specifies the branch in the repository to use.
        /// </summary>
        /// <param name="branch">The branch to use.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.Definition.IWithAttach<ParentT> WithBranch(string branch);
    }

    /// <summary>
    /// The first stage of a web app source control definition as part of a definition of a web app.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithRepositoryType<ParentT>
    {
    }
}