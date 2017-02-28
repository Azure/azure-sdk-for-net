// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for the child resource which can be CRUDed independently from the parent resource.
    /// (internal use only).
    /// </summary>
    /// <typeparam name="FluentModel">The fluent model type.</typeparam>
    /// <typeparam name="FluentParentModel">The fluent model for parent resource.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnJlc291cmNlcy5mbHVlbnRjb3JlLmFybS5tb2RlbHMuaW1wbGVtZW50YXRpb24uSW5kZXBlbmRlbnRDaGlsZFJlc291cmNlSW1wbA==
    /// <typeparam name="InnerModel">Azure inner resource class type.</typeparam>
    /// <typeparam name="FluentModelImpl">The implementation type of the fluent model type.</typeparam>

    public abstract class IndependentChildResourceImpl<
            IFluentResourceT,
            FluentParentModelT,
            InnerModelT,
            FluentResourceT,
            IDefinitionT,
            IUpdatableT,
            ManagerT> :
        IndependentChildImpl<
            IFluentResourceT,
            FluentParentModelT,
            InnerModelT,
            FluentResourceT,
            IDefinitionT,
            IUpdatableT,
            ManagerT>,
        IIndependentChildResource<ManagerT, InnerModelT>
        where InnerModelT : Fluent.Resource
        where FluentResourceT : IndependentChildResourceImpl<IFluentResourceT, FluentParentModelT, InnerModelT, FluentResourceT, IDefinitionT, IUpdatableT, ManagerT>, IFluentResourceT
        where FluentParentModelT : class, IResource, IHasResourceGroup
        where IDefinitionT : class
        where IUpdatableT : class
        where IFluentResourceT : class, IDefinitionT
    {
        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource definition/update.</return>

        ///GENMHASH:2345D3E100BA4B78504A2CC57A361F1E:F09D7F392261B6225D607D71947E5D4D
        public  FluentResourceT WithoutTag(string key)
        {
            Inner.Tags.Remove(key);
            return this as FluentResourceT;
        }

        /// <summary>
        /// Creates a new instance of CreatableUpdatableImpl.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="innerObject">The inner object.</param>
        ///GENMHASH:E0523E7DBA50D933E82FB55AEF0FEEE3:2572719AB7F9FA6EF015164D8E50629B
        protected  IndependentChildResourceImpl(string name, InnerModelT innerObject, ManagerT manager) : base(name, innerObject, manager)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName
        {
            get
            {
                return Inner.Location;
            }
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type
        {
            get
            {
                return Inner.Type;
            }
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:497CEBB37227D75C20D80EC55C7C4F14
        public IReadOnlyDictionary<string, string> Tags
        {
            get
            {
                return (Dictionary<string, string>)Inner.Tags;
            }
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the resource definition/update.</return>

        ///GENMHASH:FF80DD5A8C82E021759350836BD2FAD1:3F40906A9FA52509037F6BFCDD20BF33
        public FluentResourceT WithTag(string key, string value)
        {
            if (!Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Add(key, value);
            }
            return this as FluentResourceT;
        }

        /// <summary>
        /// Specifies tags for the resource as a Map.
        /// </summary>
        /// <param name="tags">A Map of tags.</param>
        /// <return>The next stage of the resource definition/update.</return>

        ///GENMHASH:32E35A609CF1108D0FC5FAAF9277C1AA:44AB506D9A8E5CFFF51BB0ADBE880CDD
        public FluentResourceT WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this as FluentResourceT;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:C796465774D2BDD23B4B677CF847B445
        new public string Name
        {
            get
            {
                if (Inner.Name == null)
                {
                    return base.Name;
                }
                else
                {
                    return Inner.Name;
                }
            }
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:4208AEB8137598AB1A39881825F4406A
        public Region Region
        {
            get
            {
                return Region.Create(this.RegionName);
            }
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:B4BB65C5F3DFF22971E61FCC898DE88C
        public override string Id
        {
            get
            {
                if (Inner != null)
                {
                    return Inner.Id;
                }

                return null;
            }
        }

        ///GENMHASH:FFF0419E47F38B054FDA7E0468915FAD:B52A2582A7E3A9B1FCCB77137A50E921
        public override ResourceActions.ICreatable<IFluentResourceT> WithExistingParentResource(FluentParentModelT existingParentResource)
        {
            Inner.Location = existingParentResource.RegionName;
            return base.WithExistingParentResource(existingParentResource);
        }
    }
}
