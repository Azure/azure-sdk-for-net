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
    /// <typeparam name="InnerModel">Azure inner resource class type.</typeparam>
    /// <typeparam name="FluentModelImpl">The implementation type of the fluent model type.</typeparam>
    public abstract class IndependentChildResourceImpl<IFluentResourceT, FluentParentModelT, InnerModelT, FluentResourceT, IDefinitionT, IUpdatableT>  :
        IndependentChildImpl<IFluentResourceT,FluentParentModelT,InnerModelT, FluentResourceT, IDefinitionT, IUpdatableT>,
        IIndependentChildResource
        where InnerModelT : Fluent.Resource
        where FluentResourceT : IndependentChildResourceImpl<IFluentResourceT, FluentParentModelT, InnerModelT, FluentResourceT, IDefinitionT, IUpdatableT>, IFluentResourceT
        where FluentParentModelT : class, IGroupableResource
        where IDefinitionT : class
        where IUpdatableT : class
        where IFluentResourceT : class, IDefinitionT
    {
        /// <summary>
        /// Removes a tag from the resource.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the resource definition/update.</return>
        public  FluentResourceT WithoutTag(string key)
        {
            this.Inner.Tags.Remove(key);
            return this as FluentResourceT;
        }

        /// <summary>
        /// Creates a new instance of CreatableUpdatableImpl.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="innerObject">The inner object.</param>
        protected  IndependentChildResourceImpl(string name, InnerModelT innerObject) : base(name, innerObject)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Getters.
        /// </summary>
        public string RegionName
        {
            get
            {
                return this.Inner.Location;
            }
        }

        public string Type
        {
            get
            {
                return this.Inner.Type;
            }
        }

        public IDictionary<string, string> Tags
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
        public FluentResourceT WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this as FluentResourceT;
        }

        public string Name
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

        public Region Region
        {
            get
            {
                return Region.Create(this.RegionName);
            }
        }

        public override string Id
        {
            get
            {
                if (this.Inner != null)
                {
                    return this.Inner.Id;
                }

                return null;
            }
        }

        public override ResourceActions.ICreatable<IFluentResourceT> WithExistingParentResource(FluentParentModelT existingParentResource)
        {
            Inner.Location = existingParentResource.RegionName;
            return base.WithExistingParentResource(existingParentResource);
        }
    }
}