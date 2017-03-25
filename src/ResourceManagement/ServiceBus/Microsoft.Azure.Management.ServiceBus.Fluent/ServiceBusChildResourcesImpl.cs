// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Rest;
    using System.Collections.Generic;

    /// <summary>
    /// Base class for Service Bus child entities.
    /// Note: When we refactor 'IndependentChildResourcesImpl', move features of this type
    /// to 'IndependentChildResourcesImpl' and remove this type.
    /// </summary>
    /// <typeparam name="">The model interface type.</typeparam>
    /// <typeparam name="Impl">The model interface implementation.</typeparam>
    /// <typeparam name="Inner">The inner model.</typeparam>
    /// <typeparam name="InnerCollection">The inner collection.</typeparam>
    /// <typeparam name="Manager">The manager.</typeparam>
    /// <typeparam name="Parent">The parent model interface type.</typeparam>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c0NoaWxkUmVzb3VyY2VzSW1wbA==
    internal abstract partial class ServiceBusChildResourcesImpl<T,ImplT,InnerT,InnerCollectionT,ManagerT,ParentT>  :
        IndependentChildResourcesImpl<T,ImplT,InnerT,InnerCollectionT,ManagerT,ParentT>,
        ISupportsGettingByNameAsync<T>,
        ISupportsListingAsync<T>,
        ISupportsDeletingByName
    {
        ///GENMHASH:C091A12D2E54DEE92C5C0A51885174ED:0FCD47CBCD9128C3D4A03458C5796741
        protected  ServiceBusChildResourcesImpl(InnerCollectionT innerCollection, ManagerT manager)
        {
            //$ super(innerCollection, manager);
            //$ }

        }

        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:6B6D1D91AC2FCE3076EBD61D0DB099CF
        public T GetByName(string name)
        {
            //$ return getByNameAsync(name).ToBlocking().Last();

            return default(T);
        }

        ///GENMHASH:E9B29531317DB55DAD4ECD9DCD4DFFA8:27E486AB74A10242FF421C0798DDC450
        protected abstract PagedList<InnerT> ListInner();

        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:16F094D018A7AB696812573A607E81FE
        public async Task<T> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return getInnerByNameAsync(name)
            //$ .Map(new Func1<InnerT, T>() {
            //$ @Override
            //$ public T call(InnerT inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            //$ deleteByNameAsync(name).Await();

        }

        ///GENMHASH:AD2F63EB9B7A81CCDA7E3A349748EDF7:27E486AB74A10242FF421C0798DDC450
        protected abstract async Task<InnerT> GetInnerByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:62AC18170621D435D75BBABCA42E2D03:27E486AB74A10242FF421C0798DDC450
        protected abstract async Task<Microsoft.Rest.ServiceResponse<Microsoft.Azure.IPage<InnerT>>> ListInnerAsync(CancellationToken cancellationToken = default(CancellationToken));

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:874C7A8E3CDF988B4BDA901B0FE62ABD
        public PagedList<T> List()
        {
            //$ return this.WrapList(this.ListInner());

            return null;
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:6D81E2BE86238E003E85FF2EEC7A9A1C
        public async Task<T> ListAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.ListInnerAsync()
            //$ .FlatMap(new Func1<ServiceResponse<Page<InnerT>>, Observable<T>>() {
            //$ @Override
            //$ public Observable<T> call(ServiceResponse<Page<InnerT>> r) {
            //$ return Observable.From(r.Body().Items()).Map(new Func1<InnerT, T>() {
            //$ @Override
            //$ public T call(InnerT inner) {
            //$ return wrapModel(inner);
            //$ }
            //$ });
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:D3FBF3E757A0D33222555A7D439A3F12:A13124E7BC21C819368C8CFA9F3DBE5F
        public async Task<string> DeleteByNameAsync(IList<string> names, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ List<Observable<String>> items = new ArrayList<>();
            //$ for ( String name : names) {
            //$ items.Add(this.DeleteByNameAsync(name).<String>toObservable().Map(new Func1<String, String>() {
            //$ @Override
            //$ public String call(String s) {
            //$ return name;
            //$ }
            //$ }));
            //$ }
            //$ return Observable.MergeDelayError(items);
            //$ }

            return null;
        }
    }
}