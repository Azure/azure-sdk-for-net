// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// Base class for independent child resource collection class.
    /// (Internal use only).
    /// </summary>
    /// <typeparam name="">The individual resource type returned.</typeparam>
    /// <typeparam name="Impl">The individual resource implementation.</typeparam>
    /// <typeparam name="Inner">The wrapper inner type.</typeparam>
    /// <typeparam name="InnerCollection">The inner type of the collection object.</typeparam>
    /// <typeparam name="Manager">The manager type for this resource provider type.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlc291cmNlcy5mbHVlbnRjb3JlLmFybS5jb2xsZWN0aW9uLmltcGxlbWVudGF0aW9uLkluZGVwZW5kZW50Q2hpbGRSZXNvdXJjZXNJbXBs
    public abstract partial class IndependentChildResourcesImpl<T, ImplT, InnerT, InnerCollectionT, ManagerT> :
        IndependentChildrenImpl<T,ImplT,InnerT, InnerCollectionT, ManagerT>
        where T : class, IHasId
        where ImplT : T
    {
        public IndependentChildResourcesImpl(InnerCollectionT innerCollection, ManagerT manager) : base(innerCollection, manager)
        {
        }
    }
}
