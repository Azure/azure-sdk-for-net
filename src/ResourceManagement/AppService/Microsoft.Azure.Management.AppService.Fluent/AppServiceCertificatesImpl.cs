// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent;

    /// <summary>
    /// The implementation for AppServicePlans.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uQXBwU2VydmljZUNlcnRpZmljYXRlc0ltcGw=
    internal partial class AppServiceCertificatesImpl  :
        GroupableResources<
            IAppServiceCertificate,
            AppServiceCertificateImpl,
            CertificateInner,
            CertificatesOperations,
            AppServiceManager>,
        IAppServiceCertificates
    {
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AppServiceCertificateImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:A19C6C0AD2220AD90153C8EBDA3FD2D2:0FCD47CBCD9128C3D4A03458C5796741
        internal  AppServiceCertificatesImpl(CertificatesOperations innerCollection, AppServiceManager manager)
            : base (innerCollection, manager)
        {
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:437A8ECA353AAE23242BFC82A5066CC3
        public PagedList<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate> ListByGroup(string resourceGroupName)
        {
            //$ return wrapList(innerCollection.ListByResourceGroup(resourceGroupName));

            return null;
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:586E2B084878E8767487234B852D8D20
        public async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return innerCollection.DeleteAsync(groupName, name)
            //$ .Map(new Func1<Object, Void>() {
            //$ @Override
            //$ public Void call(Object o) {
            //$ return null;
            //$ }
            //$ });

            return;
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:AB5235085FE852FA939C192DC80C9EEF
        public async Task<IAppServiceCertificate> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapModel(innerCollection.Get(groupName, name));

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:5AC27B4C4791A2919F43CCB97C0275BA
        protected AppServiceCertificateImpl WrapModel(string name)
        {
            //$ return new AppServiceCertificateImpl(name, new CertificateInner(), innerCollection, myManager);

            return null;
        }

        ///GENMHASH:446794D74A04366F0AA274DF90F28CE3:218BCD2B4CE1C82F271307788818A2EC
        protected AppServiceCertificateImpl WrapModel(CertificateInner inner)
        {
            //$ if (inner == null) {
            //$ return null;
            //$ }
            //$ return new AppServiceCertificateImpl(inner.Name(), inner, innerCollection, myManager);

            return null;
        }
    }
}