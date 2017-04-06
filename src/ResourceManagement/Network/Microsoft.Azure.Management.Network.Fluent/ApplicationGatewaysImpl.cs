// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for ApplicationGateways.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5c0ltcGw=
    internal partial class ApplicationGatewaysImpl :
        TopLevelModifiableResources<IApplicationGateway, ApplicationGatewayImpl, ApplicationGatewayInner, IApplicationGatewaysOperations, INetworkManager>,
        IApplicationGateways
    {

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:7CF698D4F4194C8BBD98455A92E17A2C
        public ApplicationGatewayImpl Define(string name)
        {
            return WrapModel(name).WithSize(ApplicationGatewaySkuName.StandardSmall).WithInstanceCount(1);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<ApplicationGatewayInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        protected override async Task<IPage<ApplicationGatewayInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected override async Task<IPage<ApplicationGatewayInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:DB7CDF51E063E00F632236B9A1581DD7:A55F357967E86E32E70097D1F0B4D25E
        internal ApplicationGatewaysImpl(INetworkManager networkManager)
            : base(networkManager.Inner.ApplicationGateways, networkManager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        protected override async Task<IPage<ApplicationGatewayInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected override async Task<IPage<ApplicationGatewayInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:4FD24066BFA6ACCBA6BCD17F67645E2A
        protected override ApplicationGatewayImpl WrapModel(string name)
        {
            var inner = new ApplicationGatewayInner();
            return new ApplicationGatewayImpl(name, inner, Manager);
        }

        ///GENMHASH:0982709B48CC855164CE982B2642C391:0AF033C117570F9A4027C0D7C3ECFFC7
        protected override IApplicationGateway WrapModel(ApplicationGatewayInner inner)
        {
            return (inner == null) ? null : new ApplicationGatewayImpl(inner.Name, inner, Manager);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:82305CFD5D0BD7F2FA9F4436265D03D0:F9A1E97A70112A4A49A03B59721E6617
        public async Task<IEnumerable<string>> StartAsync(IList<string> applicationGatewayResourceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (applicationGatewayResourceIds == null) {
                return null;
            }

            var taskList = applicationGatewayResourceIds.Select(id =>
                Inner.StartAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id),
                    cancellationToken)).ToList();

            await Task.WhenAll(taskList);

            /* This is not quite right, as ideally only those app gateways should be returned that are successully started,
             * but it's not clear how/if this info can be obtained efficiently from Azure, since Azure returns Task and not Task<boolean>
             * or something that would wrap the result. So for now, we return what we got from the user. */
            return applicationGatewayResourceIds;
        }

        ///GENMHASH:465EAFA55FBC23E6B69A144903076AAA:1A8F4C33E4BFDA27D148D802CC25ABA5
        public Task<IEnumerable<string>> StartAsync(string[] applicationGatewayResourceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            return StartAsync(new List<string>(applicationGatewayResourceIds), cancellationToken);
        }

        ///GENMHASH:E217C4EC39C1A76872F837147063FF5F:9D433B2BAB5DD6A39691B9BC531D775A
        public void Start(params string[] applicationGatewayResourceIds)
        {
            if (applicationGatewayResourceIds != null)
            {
                StartAsync(applicationGatewayResourceIds).Wait();
            }
        }

        ///GENMHASH:41BB8BF7DF1D81A3B9ECC9E2D17E50EF:4B314BAEE0153BC215406EBCECE4B8B3
        public void Start(IList<string> applicationGatewayResourceIds)
        {
            if (applicationGatewayResourceIds != null)
            {
                StartAsync(applicationGatewayResourceIds).Wait();
            }
        }

        ///GENMHASH:D762A9F00C94F129D479DB22360B94B9:595B92642216D6FCA6CCF6168EC51669
        public async Task<IEnumerable<string>> StopAsync(IList<string> applicationGatewayResourceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (applicationGatewayResourceIds == null) {
                return null;
            }

            var taskList = applicationGatewayResourceIds.Select(id =>
                Inner.StopAsync(
                    ResourceUtils.GroupFromResourceId(id),
                    ResourceUtils.NameFromResourceId(id),
                    cancellationToken)).ToList();

            await Task.WhenAll(taskList);

            /* This is not quite right, as ideally only those app gateways should be returned that are successfully stopped,
             * but it's not clear how/if this info can be obtained efficiently from Azure, since Azure returns Task and not Task<boolean>
             * or something that would wrap the result. So for now, we return what we got from the user. */
            return applicationGatewayResourceIds;
        }

        ///GENMHASH:528CA70A66941735D1100C464F41CC35:7924FB650D294BDB37539F9310A675A7
        public Task<IEnumerable<string>> StopAsync(string[] applicationGatewayResourceIds, CancellationToken cancellationToken = default(CancellationToken))
        {
            return StopAsync(new List<string>(applicationGatewayResourceIds), cancellationToken);
        }

        ///GENMHASH:C5B3134260871F3418B5AEF1F464309A:DCE259536A134606D748E7F3C69FBA49
        public void Stop(IList<string> applicationGatewayResourceIds)
        {
            if (applicationGatewayResourceIds != null)
            {
                StopAsync(applicationGatewayResourceIds).Wait();
            }
        }

        ///GENMHASH:81B214376E2392D28CDA334CD85C2C30:427672B5869F43826258D87B677BEC87
        public void Stop(params string[] applicationGatewayResourceIds)
        {
            if (applicationGatewayResourceIds != null)
            {
                StopAsync(applicationGatewayResourceIds).Wait();
            }
        }
    }
}
