// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Resource.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Resource.Fluent.Core
{
    /// <summary>
    /// This class uses Reflection, it will be removed once we have a "Resource" from which all resource inherits
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent wrapper interface for the resource</typeparam>
    /// <typeparam name="InnerResourceT">The autorest generated resource</typeparam>
    /// <typeparam name="FluentResourceT">The implementation for fluent wrapper interface</typeparam>
    public abstract class ResourceBase<IFluentResourceT, InnerResourceT, FluentResourceT, IDefinitionAfterRegion, DefTypeWithTags, UTypeWithTags> : 
        CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT, IHasId, UTypeWithTags>,
        IResource, IDefinitionWithTags<DefTypeWithTags>, IUpdateWithTags<UTypeWithTags>
        where FluentResourceT : ResourceBase<IFluentResourceT, InnerResourceT, FluentResourceT, IDefinitionAfterRegion, DefTypeWithTags, UTypeWithTags>, IFluentResourceT
        where IFluentResourceT : class, IResource
        where InnerResourceT : Microsoft.Azure.Management.Resource.Fluent.Resource
        where IDefinitionAfterRegion: class
        where DefTypeWithTags : class
        where UTypeWithTags : class
    {
        protected ResourceBase(string key, InnerResourceT innerObject) : base(key, innerObject)
        {
            if (Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
        }

        #region Getters

        public string Id
        {
            get
            {
                return Inner.Id;

            }
        }

        public new string Name
        {
            get
            {
                string name = Inner.Name;
                if (name != null)
                {
                    return name;
                }
                return base.Name;
            }
        }

        public string RegionName
        {
            get
            {
                return Inner.Location;
            }
        }

        public string Type
        {
            get
            {
                return Inner.Type;
            }
        }

        public IReadOnlyDictionary<string, string> Tags
        {
            get
            {
                return (Dictionary<string, string>)Inner.Tags;
            }
        }

        #endregion

        protected IList<InnerT> InnersFromWrappers<InnerT, IWrapperT>(
            ICollection<IWrapperT> wrappers,
            IList<InnerT> inners) where IWrapperT : IWrapper<InnerT>
            {
                if (wrappers != null && wrappers.Count > 0)
            {
                inners = inners ?? new List<InnerT>();
                foreach (var wrapper in wrappers)
                {
                    inners.Add(wrapper.Inner);
                }
            }

            return inners;
        }

        protected IList<InnerT> InnersFromWrappers<InnerT, IWrapperT>(
            ICollection<IWrapperT> wrappers) where IWrapperT : IWrapper<InnerT>
        {
            return InnersFromWrappers<InnerT, IWrapperT>(wrappers, null);
        }

        protected bool IsInCreateMode
        {
            get
            {
                return Id == null;
            }
        }

        public Region Region
        {
            get
            {
                return Region.Create(this.RegionName);
            }
        }

        IReadOnlyDictionary<string, string> IResource.Tags
        {
            get
            {
                return (Dictionary<string, string>)Inner.Tags;
            }
        }

        #region The fluent setters

        public IDefinitionAfterRegion WithRegion(string regionName)
        {
            Inner.Location = regionName;
            return this as IDefinitionAfterRegion;
        }

        public IDefinitionAfterRegion WithRegion(Region region)
        {
            return this.WithRegion(Region.Name);
        }

        public FluentResourceT WithTags(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this as FluentResourceT;
        }
        
        public FluentResourceT WithTag(string key, string value)
        {
            if (!Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Add(key, value);
            }
            return this as FluentResourceT;
        }

        public FluentResourceT WithoutTag(string key)
        {
            if (Inner.Tags.ContainsKey(key))
            {
                Inner.Tags.Remove(key);
            }
            return this as FluentResourceT;
        }

        DefTypeWithTags IDefinitionWithTags<DefTypeWithTags>.WithTag(string key, string value)
        {
            this.WithTag(key, value);
            return this as DefTypeWithTags;
        }

        DefTypeWithTags IDefinitionWithTags<DefTypeWithTags>.WithTags(IDictionary<string, string> tags)
        {
            this.WithTags(tags);
            return this as DefTypeWithTags;
        }


        UTypeWithTags IUpdateWithTags<UTypeWithTags>.WithTag(string key, string value)
        {
            this.WithTag(key, value);
            return this as UTypeWithTags;
        }

        UTypeWithTags IUpdateWithTags<UTypeWithTags>.WithTags(IDictionary<string, string> tags)
        {
            this.WithTags(tags);
            return this as UTypeWithTags;
        }

        UTypeWithTags IUpdateWithTags<UTypeWithTags>.WithoutTag(string key)
        {
            this.WithoutTag(key);
            return this as UTypeWithTags;
        }

        #endregion
    }
}
