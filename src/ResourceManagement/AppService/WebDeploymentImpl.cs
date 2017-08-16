// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.WebDeployment.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of WebDeployment.
    /// </summary>
    /// <typeparam name="FluentT">The fluent interface, web app, function app, or deployment slot.</typeparam>
    /// <typeparam name="FluentImplT">The implementation class for FluentT.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uV2ViRGVwbG95bWVudEltcGw=
    internal partial class WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>  :
        Executable<Microsoft.Azure.Management.AppService.Fluent.IWebDeployment>,
        IWebDeployment,
        IDefinition
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>
    {
        private WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent;
        private MSDeployInner request;
        private MSDeployStatusInner result;

        IWebAppBase IHasParent<IWebAppBase>.Parent => throw new NotImplementedException();

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IWebAppBase Parent()
        {
            return parent;
        }

        ///GENMHASH:4F0D740E9E59D0D4200100B1E5043A8C:82E3C68D55C51B0D4FAD431C149BC6B0
        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithPackageUri(string packageUri)
        {
            request.AddOnPackages = new List<MSDeployCore>();
            request.AddOnPackages.Add(new MSDeployCore
            {
                PackageUri = packageUri
            });
            return this;
        }

        ///GENMHASH:F2F03BAF07D6A9996C68EAB76C58AB34:E421C8724A6BB9EF3A6CD3B542BE755F
        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithSetParametersXmlFile(string fileUri)
        {
            request.SetParametersXmlFileUri = fileUri;
            return this;
        }

        ///GENMHASH:3144537BD6A278A87EA02D472D16E90E:2629FF96BE4E0E1338A320296353D369
        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithAddOnPackage(string packageUri)
        {
            request.AddOnPackages.Add(new MSDeployCore
            {
                PackageUri = packageUri
            });
            return this;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:6DE5F99ABF2A46D2506D498C0AFBD12C
        public DateTime StartTime()
        {
            return result.StartTime ?? DateTime.MinValue;
        }

        ///GENMHASH:1B9199BB67565D6E00DD683ADFA81CF1:F8976BBC028E6D69345A1C5BFC0F0AE3
        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithExistingDeploymentsDeleted(bool deleteExisting)
        {
            if (deleteExisting)
            {
                MSDeployCore first = request.AddOnPackages[0];
                request.AddOnPackages.RemoveAt(0);
                request.PackageUri = first.PackageUri;
            }
            return this;
        }

        ///GENMHASH:37F0EAAC4459C2DE9AC7F41386E587DB:8429FB58ED891A2C18541AAECC30A0D4
        public string Deployer()
        {
            return result.Deployer;
        }

        ///GENMHASH:3C1909F3137E91E93C57B90768BECD1A:51918A08538F03EA730DAAC0786E9C7E
        public DateTime EndTime()
        {
            return result.EndTime ?? DateTime.MinValue;
        }

        ///GENMHASH:B64F0B705C1970A57BCEB34522A005DA:56F87C785CA4EB155CEA2862A9A8B5E6
        internal  WebDeploymentImpl(WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent)
        {
            this.parent = parent;
            this.request = new MSDeployInner();
        }

        ///GENMHASH:62FD3F1E0B9C473874BFF937B2C71CB1:AA7D7DD93FF83392246A2094116D5AC2
        public bool Complete()
        {
            return result.Complete ?? false;
        }

        ///GENMHASH:82C6F929AFC9733BD4A7D3D5A7990EA7:F40F866E9E31D5AF7F638D8D0682FD5F
        public WebDeploymentImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithSetParameter(string name, string value)
        {
            if (request.SetParameters == null)
            {
                request.SetParameters = new Dictionary<string, string>();
            }
            request.SetParameters.Add(name, value);
            return this;
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:6D1DA538A0FC3ED9DF2CF3CEBF1B6FCB
        public override async Task<Microsoft.Azure.Management.AppService.Fluent.IWebDeployment> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            result = await parent.CreateMSDeploy(request, cancellationToken);
            return this;
        }
    }
}