// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading.Tasks;
    using Models;
    using WebAppBase.Update;
    using WebAppSourceControl.UpdateDefinition;
    using ResourceManager.Fluent.Core;
    using System.Threading;

    /// <summary>
    /// Implementation for WebAppSourceControl and its create and update interfaces.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the parent web app.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViQXBwU291cmNlQ29udHJvbEltcGw=
    internal partial class WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>  :
        IndexableWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.SiteSourceControlInner>,
        IWebAppSourceControl,
        WebAppSourceControl.Definition.IDefinition<WebAppBase.Definition.IWithCreate<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, IUpdate<FluentT>
    {
        private WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent;
        private string githubAccessToken;

        ///GENMHASH:8560BA43F3FC1809A8347C8CFFC2AB2F:153E3E10E3E86D913133A2F022C5C3C5
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithPublicMercurialRepository(string url)
        {
            Inner.IsManualIntegration = true;
            Inner.IsMercurial = true;
            Inner.RepoUrl = url;
            return this;
        }

        ///GENMHASH:489A5D0E881E754C1D9F60FEF7B0689C:E56B546ECAC80146D9588C9F1C5FB326
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithPublicGitRepository(string url)
        {
            Inner.IsManualIntegration = true;
            Inner.IsMercurial = false;
            Inner.RepoUrl = url;
            return this;
        }

        ///GENMHASH:41AFD2B5AA5DD5D065E6012F1607BD83:6ACF74B813BCAD8B41434D3540AE8141
        internal async Task<Microsoft.Azure.Management.AppService.Fluent.Models.SourceControlInner> RegisterGithubAccessTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (githubAccessToken != null)
            {
                return await parent.Manager.Inner.UpdateSourceControlAsync("Github", new SourceControlInner
                {
                    Token = githubAccessToken
                });
            }
            return await Task.FromResult<SourceControlInner>(null);
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:00C6BAC04AF2ED6D87D2C5610E88B001
        public IWebAppBase Parent()
        {
            return parent;
        }

        ///GENMHASH:DBC91E274023CE112BF5317D36B0BDC3:08D6495FD781CCB57E524CE9B1EDE729

        internal WebAppSourceControlImpl(
            SiteSourceControlInner inner,
            WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent)
            : base (inner)
        {
            this.parent = parent;
        }

        ///GENMHASH:A969DD4C3B042B64471282EF52C2AAFC:E8E2064A7FA83CBF5A4805C096AA480A
        public RepositoryType? RepositoryType()
        {
            if (Inner.IsMercurial == null)
            {
                return null;
            }
            return (bool) Inner.IsMercurial ? Fluent.RepositoryType.Mercurial : Fluent.RepositoryType.Git;
        }

        ///GENMHASH:AF58AEB1DD43D38B7FEDF266F4F40886:63F15AB00FF6315055DD4FFBCA6BE2EC
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithContinuouslyIntegratedGitHubRepository(string organization, string repository)
        {
            return WithContinuouslyIntegratedGitHubRepository(string.Format("https://github.Com/{0}/{1}", organization, repository));
        }

        ///GENMHASH:0C78E8B87A63ADE33197F0E5CE8ADEEB:706F1A261DEEA5DA1355959E128EE429
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithContinuouslyIntegratedGitHubRepository(string url)
        {
            Inner.IsManualIntegration = false;
            Inner.IsMercurial = false;
            Inner.RepoUrl = url;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:D9A07C41F30265FB0B22114C79299AA2
        public FluentImplT Attach()
        {
            parent.WithSourceControl(this);
            return parent as FluentImplT;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:6CECB92A6E1723D6D85C5FF61B416390:33B07A666FC63EB34DFBDC8EFC5DAE19
        public string Branch()
        {
            return Inner.Branch;
        }

        ///GENMHASH:6FF9D187D15743E6B37112ED927543E0:CD51E6CABA14878E3D216EA87F75B1C1
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithBranch(string branch)
        {
            Inner.Branch = branch;
            return this;
        }

        ///GENMHASH:5491A63323E88C98233DBEBA408F079E:DE140C96DE9D6AB410A97DC3737C1F8D
        public WebAppSourceControlImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithGitHubAccessToken(string personalAccessToken)
        {
            this.githubAccessToken = personalAccessToken;
            return this;
        }

        ///GENMHASH:F0154AC08DE1AD091546C5ED9FAAEEFE:B9274408285FE2FE7DD2F983FE0886BD
        public string RepositoryUrl()
        {
            return Inner.RepoUrl;
        }

        ///GENMHASH:2A9EA38BA2AA82D8543F96DA50B4E478:F4FA256BED6B51B88372DFCB49483171
        public bool IsManualIntegration()
        {
            return Inner.IsManualIntegration ?? true;
        }

        ///GENMHASH:DC747255ED0989636955C16E2E14FF35:D09C105522DF27F96AFF650A22E6A4CB
        public bool DeploymentRollbackEnabled()
        {
            return Inner.DeploymentRollbackEnabled ?? false;
        }

    }
}
