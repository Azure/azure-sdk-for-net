// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using WebAppSourceControl.Definition;
    using WebAppSourceControl.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Threading;

    /// <summary>
    /// Implementation for WebAppSourceControl and its create and update interfaces.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the parent web app.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwU291cmNlQ29udHJvbEltcGw=
    internal partial class WebAppSourceControlImpl<FluentT,FluentImplT>  :
        IndexableWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner>,
        IWebAppSourceControl,
        WebAppSourceControl.Definition.IDefinition<WebAppBase.Definition.IWithCreate<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>
    {
        private WebAppBaseImpl<FluentT,FluentImplT> parent;
        private WebSiteManagementClient serviceClient;
        private string githubAccessToken;
        ///GENMHASH:8560BA43F3FC1809A8347C8CFFC2AB2F:E56B546ECAC80146D9588C9F1C5FB326
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithPublicMercurialRepository(string url)
        {
            //$ Inner.WithIsManualIntegration(true).WithIsMercurial(false).WithRepoUrl(url);
            //$ return this;

            return this;
        }

        ///GENMHASH:489A5D0E881E754C1D9F60FEF7B0689C:E56B546ECAC80146D9588C9F1C5FB326
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithPublicGitRepository(string url)
        {
            //$ Inner.WithIsManualIntegration(true).WithIsMercurial(false).WithRepoUrl(url);
            //$ return this;

            return this;
        }

        ///GENMHASH:41AFD2B5AA5DD5D065E6012F1607BD83:B14BB884235CB948F2D5AA27CF2B5F0F
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SourceControlInner> RegisterGithubAccessTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ if (githubAccessToken == null) {
            //$ return Observable.Just(null);
            //$ }
            //$ return serviceClient.UpdateSourceControlAsync("Github", new SourceControlInner().WithToken(githubAccessToken));
            //$ }

            return null;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:F9159053EE75683F7DC604A5FCBB8F04
        public IWebAppBase<object> Parent
        {
            get
            {
                return (IWebAppBase<object>) parent;
            }
        }

        ///GENMHASH:DBC91E274023CE112BF5317D36B0BDC3:08D6495FD781CCB57E524CE9B1EDE729
        internal WebAppSourceControlImpl(SiteSourceControlInner inner, WebAppBaseImpl<FluentT,FluentImplT> parent, WebSiteManagementClient serviceClient)
            : base(inner)
        {
            //$ super(inner);
            //$ this.parent = parent;
            //$ this.serviceClient = serviceClient;
            //$ }

        }

        ///GENMHASH:A969DD4C3B042B64471282EF52C2AAFC:E8E2064A7FA83CBF5A4805C096AA480A
        public RepositoryType RepositoryType
        {
            get
            {
                //$ if (Inner.IsMercurial() == null) {
                //$ return null;
                //$ } else {
                //$ return Inner.IsMercurial() ? RepositoryType.MERCURIAL : RepositoryType.GIT;
                //$ }

                return RepositoryType.Git;
            }
        }

        ///GENMHASH:AF58AEB1DD43D38B7FEDF266F4F40886:63F15AB00FF6315055DD4FFBCA6BE2EC
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithContinuouslyIntegratedGitHubRepository(string organization, string repository)
        {
            //$ return withContinuouslyIntegratedGitHubRepository(String.Format("https://github.Com/%s/%s", organization, repository));

            return this;
        }

        ///GENMHASH:0C78E8B87A63ADE33197F0E5CE8ADEEB:706F1A261DEEA5DA1355959E128EE429
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithContinuouslyIntegratedGitHubRepository(string url)
        {
            //$ Inner.WithRepoUrl(url).WithIsMercurial(false).WithIsManualIntegration(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:D9A07C41F30265FB0B22114C79299AA2
        public FluentImplT Attach()
        {
            //$ parent().WithSourceControl(this);
            //$ return parent();

            return default(FluentImplT);
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public string Name
        {
            get
            {
                //$ return Inner.Name();

                return null;
            }
        }

        ///GENMHASH:6CECB92A6E1723D6D85C5FF61B416390:33B07A666FC63EB34DFBDC8EFC5DAE19
        public string Branch
        {
            get
            {
                //$ return Inner.Branch();

                return null;
            }
        }

        ///GENMHASH:6FF9D187D15743E6B37112ED927543E0:CD51E6CABA14878E3D216EA87F75B1C1
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithBranch(string branch)
        {
            //$ Inner.WithBranch(branch);
            //$ return this;

            return this;
        }

        ///GENMHASH:5491A63323E88C98233DBEBA408F079E:DE140C96DE9D6AB410A97DC3737C1F8D
        public WebAppSourceControlImpl<FluentT,FluentImplT> WithGitHubAccessToken(string personalAccessToken)
        {
            //$ this.githubAccessToken = personalAccessToken;
            //$ return this;

            return this;
        }

        ///GENMHASH:F0154AC08DE1AD091546C5ED9FAAEEFE:B9274408285FE2FE7DD2F983FE0886BD
        public string RepositoryUrl
        {
            get
            {
                //$ return Inner.RepoUrl();

                return null;
            }
        }

        ///GENMHASH:2A9EA38BA2AA82D8543F96DA50B4E478:F4FA256BED6B51B88372DFCB49483171
        public bool IsManualIntegration
        {
            get
            {
                //$ return Utils.ToPrimitiveBoolean(Inner.IsManualIntegration());

                return false;
            }
        }

        ///GENMHASH:DC747255ED0989636955C16E2E14FF35:D09C105522DF27F96AFF650A22E6A4CB
        public bool DeploymentRollbackEnabled
        {
            get
            {
                //$ return Utils.ToPrimitiveBoolean(Inner.DeploymentRollbackEnabled());

                return false;
            }
        }
    }
}