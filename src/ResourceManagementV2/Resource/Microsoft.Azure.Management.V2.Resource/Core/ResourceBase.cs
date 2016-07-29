using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    /// This class uses Reflection, it will be removed once we have a "Resource" from which all resource inherits
    /// </summary>
    /// <typeparam name="IFluentResourceT">The fluent wrapper interface for the resource</typeparam>
    /// <typeparam name="InnerResourceT">The autorest generated resource</typeparam>
    /// <typeparam name="InnerResourceBaseT">The autorest generated base class from which <InnerResourceT @ref="InnerResourceT" /> inherits</typeparam>
    /// <typeparam name="FluentResourceT">The implementation for fluent wrapper interface</typeparam>
    public abstract class ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT, IDefintionAfterRegion> : 
        CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT>,
        IResource
        where FluentResourceT : ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT, IDefintionAfterRegion>, IFluentResourceT
        where IFluentResourceT : class, IResource
        where InnerResourceBaseT : class
        where InnerResourceT : class, InnerResourceBaseT
        where IDefintionAfterRegion: class
    {

        private TypeInfo resourceTypeInfo;

        protected ResourceBase(string key, InnerResourceT innerObject) : base(key, innerObject)
        {
            EnsureResource(innerObject);
            if (GetValue("Tags") == null)
            {
                SetValue("Tags", new Dictionary<string, string>());
            }
        }

        #region Getters

        public string Id
        {
            get
            {
                return GetStringValue("Id");

            }
        }

        public string Name
        {
            get
            {
                return GetStringValue("Name");
            }
        }

        public string RegionName
        {
            get
            {
                return GetStringValue("Location");
            }
        }

        public string Type
        {
            get
            {
                return GetStringValue("Type");
            }
        }

        public IReadOnlyDictionary<string, string> Tags
        {
            get
            {
                Dictionary<string, string> tags = (Dictionary < string, string>)GetValue("Tags");
                return tags;
            }
        }

        #endregion

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
                throw new NotImplementedException();
            }
        }

        IDictionary<string, string> IResource.Tags
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #region The fluent setters

        public IDefintionAfterRegion WithRegion(string regionName)
        {
            SetValue("Location", regionName);
            return this as IDefintionAfterRegion;
        }

        public FluentResourceT WithTags(IDictionary<string, string> tags)
        {
            SetValue("Tags", tags);
            return this as FluentResourceT;
        }
        
        public FluentResourceT WithTag(string key, string value)
        {
            var tags = GetValue("Tags") as IDictionary<string, string>;
            if (!tags.ContainsKey(key))
            {
                tags.Add(key, value);
            }
            return this as FluentResourceT;
        }

        public FluentResourceT WithoutTag(string key)
        {
            var tags = GetValue("Tags") as IDictionary<string, string>;
            if (tags.ContainsKey(key))
            {
                tags.Remove(key);
                SetValue("Tags", tags);
            }
            return this as FluentResourceT;
        }

        #endregion

        private void EnsureResource(InnerResourceT innerObject)
        {
            var baseTypeName = typeof(InnerResourceBaseT).FullName;
            TypeInfo typeInfo = innerObject.GetType().GetTypeInfo();
            while (typeInfo != null && !typeInfo.FullName.Equals(baseTypeName))
            {
                Type baseType = typeInfo.BaseType;
                if (baseType == null)
                {
                    break;
                }
                typeInfo = baseType.GetTypeInfo();
            }

            if (typeInfo == null)
            {
                throw new ArgumentException(innerObject.GetType().FullName + " is not " + baseTypeName);
            }

            if (typeInfo.GetDeclaredProperty("Id") == null)
            {
                throw new ArgumentException(typeInfo.FullName + " is not a Resource [Missing Id property]");
            }

            if (typeInfo.GetDeclaredProperty("Location") == null)
            {
                throw new ArgumentException(typeInfo.FullName + " is not a Resource [Missing Location property]");
            }

            if (typeInfo.GetDeclaredProperty("Name") == null)
            {
                throw new ArgumentException(typeInfo.FullName + " is not a Resource [Missing Name property]");
            }

            if (typeInfo.GetDeclaredProperty("Tags") == null)
            {
                throw new ArgumentException(typeInfo.FullName + " is not a Resource [Missing Tags property]");
            }

            if (typeInfo.GetDeclaredProperty("Type") == null)
            {
                throw new ArgumentException(typeInfo.FullName + " is not a Resource [Missing Type property]");
            }

            resourceTypeInfo = typeInfo;
        }

        private string GetStringValue(string propertyName)
        {
            return (string) GetValue(propertyName);
        }

        private object GetValue(string propertyName)
        {
            PropertyInfo propInfo = resourceTypeInfo.GetDeclaredProperty(propertyName);
            return propInfo.GetValue(Inner);
        }

        private void SetValue(string propertyName, object val)
        {
            PropertyInfo propInfo = resourceTypeInfo.GetDeclaredProperty(propertyName);
            propInfo.SetValue(Inner, val);
        }
    }
}
