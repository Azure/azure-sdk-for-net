// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using ServiceBusNamespace.Definition;
    using Microsoft.Rest;

    /// <summary>
    /// Implementation for ServiceBusNamespaces.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU2VydmljZUJ1c05hbWVzcGFjZXNJbXBs
    internal partial class ServiceBusNamespacesImpl  :
        TopLevelModifiableResourcesImpl<Microsoft.Azure.Management.Servicebus.Fluent.IServiceBusNamespace,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespaceImpl,Microsoft.Azure.Management.Servicebus.Fluent.NamespaceInner,Microsoft.Azure.Management.Servicebus.Fluent.NamespacesInner,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager>,
        IServiceBusNamespaces
    {
        ///GENMHASH:42E0B61F5AA4A1130D7B90CCBAAE3A5D:9F33885F608914F714E6FA1E746CFA88
        public async Task<Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Inner.CheckNameAvailabilityMethodAsync(name).Map(new Func1<CheckNameAvailabilityResultInner, CheckNameAvailabilityResult>() {
            //$ @Override
            //$ public CheckNameAvailabilityResult call(CheckNameAvailabilityResultInner checkNameAvailabilityResultInner) {
            //$ return new CheckNameAvailabilityResultImpl(checkNameAvailabilityResultInner);
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:BB8532CEF83EF6BC19358A25F357F6D2:61D8AC186ED2249584115AB3DFDC674B
        public async ServiceFuture<Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, IServiceCallback<Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult> callback, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return ServiceFuture.FromBody(this.CheckNameAvailabilityAsync(name), callback);

            return null;
        }

        ///GENMHASH:C4C74C5CA23BE3B4CAFEFD0EF23149A0:B6DE3F3ADD30CF80937F7E47989E73C7
        public ICheckNameAvailabilityResult CheckNameAvailability(string name)
        {
            //$ return this.CheckNameAvailabilityAsync(name).ToBlocking().Last();

            return null;
        }

        ///GENMHASH:03B58DF1706F0F92F7D99C96D11EBD56:0FCD47CBCD9128C3D4A03458C5796741
        internal  ServiceBusNamespacesImpl(NamespacesInner innerCollection, ServiceBusManager manager)
        {
            //$ super(innerCollection, manager);
            //$ }

        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public IBlank Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:62E3350A9FAF32A0172D3FF0EECDFAD5
        protected ServiceBusNamespaceImpl WrapModel(string name)
        {
            //$ return new ServiceBusNamespaceImpl(name,
            //$ new NamespaceInner(),
            //$ this.Manager());

            return null;
        }

        ///GENMHASH:586C665ACF635E212AB1A09D9563543A:7B03AAAEC3D40D56B6C75B57727A67CF
        protected ServiceBusNamespaceImpl WrapModel(NamespaceInner inner)
        {
            //$ return new ServiceBusNamespaceImpl(inner.Name(),
            //$ inner,
            //$ this.Manager());

            return null;
        }
    }
}