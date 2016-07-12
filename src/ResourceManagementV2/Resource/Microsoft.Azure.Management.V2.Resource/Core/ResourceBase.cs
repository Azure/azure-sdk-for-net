using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.Azure.Management.V2.Resource.Core
{
    /// <summary>
    ///  TODO: This class uses Reflection, it will be removed once we have a Resource that is shared across all services.
    /// </summary>
    /// <typeparam name="IFluentResourceT"></typeparam>
    /// <typeparam name="InnerResourceT"></typeparam>
    /// <typeparam name="FluentResourceT"></typeparam>
    public abstract class ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT> : 
        CreatableUpdatable<IFluentResourceT, InnerResourceT, FluentResourceT>,
        IResource
        where IFluentResourceT : class, IResource
        where InnerResourceT : class     // TODO: This constraint will change to "where InnerResourceT : Resource" once we shared "Resource"
        where InnerResourceBaseT: class
        where FluentResourceT : ResourceBase<IFluentResourceT, InnerResourceT, InnerResourceBaseT, FluentResourceT>, IFluentResourceT
    {

        private TypeInfo resourceTypeInfo;

        protected ResourceBase(string key, InnerResourceT innerObject) : base(key, innerObject)
        {
            EnsureResource(innerObject);
            if (getValue("Tags") == null)
            {
                setValue("Tags", new Dictionary<string, string>());
            }

        }

        public string Id
        {
            get
            {
                return getStringValue("Id");

            }
        }

        public string Name
        {
            get
            {
                return getStringValue("Name");
            }
        }

        public string RegionName
        {
            get
            {
                return getStringValue("Location");
            }
        }

        public string Type
        {
            get
            {
                return getStringValue("Type");
            }
        }

        public IReadOnlyDictionary<string, string> Tags
        {
            get
            {
                Dictionary<string, string> tags = (Dictionary < string, string>)getValue("Tags");
                return tags;
            }
        }

        //


        protected bool IsInCreateMode
        {
            get
            {
                return Id == null;
            }
        }

        //

        public FluentResourceT WithRegion(string regionName)
        {
            setValue("Location", regionName);
            return this as FluentResourceT;
        }

        public FluentResourceT WithTags(IDictionary<string, string> tags)
        {
            setValue("Tags", tags);
            return this as FluentResourceT;
        }
        
        public FluentResourceT WithTag(string key, string value)
        {
            var tags = getValue("Tags") as IDictionary<string, string>;
            if (!tags.ContainsKey(key))
            {
                tags.Add(key, value);
            }
            return this as FluentResourceT;
        }

        public FluentResourceT WithoutTag(string key)
        {
            var tags = getValue("Tags") as IDictionary<string, string>;
            if (tags.ContainsKey(key))
            {
                tags.Remove(key);
                setValue("Tags", tags);
            }
            return this as FluentResourceT;
        }


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

        private string getStringValue(string propertyName)
        {
            return (string) getValue(propertyName);
        }

        private object getValue(string propertyName)
        {
            PropertyInfo propInfo = resourceTypeInfo.GetDeclaredProperty(propertyName);
            var l = propInfo.GetValue(Inner);
            return propInfo.GetValue(Inner);
        }

        private void setValue(string propertyName, object val)
        {
            PropertyInfo propInfo = resourceTypeInfo.GetDeclaredProperty(propertyName);
            propInfo.SetValue(Inner, val);
        }
    }
}
