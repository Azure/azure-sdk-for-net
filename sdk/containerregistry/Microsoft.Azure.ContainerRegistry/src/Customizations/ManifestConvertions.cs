using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Microsoft.Azure.ContainerRegistry.Models
{
    public partial class V2Manifest : Manifest
    {
        /// <summary>
        /// Initializes a new instance of the V2Manifest class.
        /// </summary>
        public static explicit operator V2Manifest(ManifestWrapper v)
        {
            var manifest = new V2Manifest();
            Converter.MapProp(v, manifest);
            return manifest;
        }
    }

    public partial class V1Manifest : Manifest
    {
        /// <summary>
        /// Initializes a new instance of the V2Manifest class.
        /// </summary>
        public static explicit operator V1Manifest(ManifestWrapper v)
        {
            var manifest = new V1Manifest();
            Converter.MapProp(v, manifest);
            return manifest;
        }
    }

    public partial class ManifestList : Manifest
    {
        /// <summary>
        /// Initializes a new instance of the V2Manifest class.
        /// </summary>
        public static explicit operator ManifestList(ManifestWrapper v)
        {
            var manifest = new ManifestList();
            Converter.MapProp(v, manifest);
            return manifest;
        }
    }

    public partial class OCIIndex : Manifest
    {
        /// <summary>
        /// Initializes a new instance of the V2Manifest class.
        /// </summary>
        public static explicit operator OCIIndex(ManifestWrapper v)
        {
            var manifest = new OCIIndex();
            Converter.MapProp(v, manifest);
            return manifest;
        }
    }

    public partial class OCIManifest : Manifest
    {
        /// <summary>
        /// Initializes a new instance of the V2Manifest class.
        /// </summary>
        public static explicit operator OCIManifest(ManifestWrapper v)
        {
            var manifest = new OCIManifest();
            Converter.MapProp(v, manifest);
            return manifest;
        }
    }


    public class Converter {
        /// <summary>
        /// Map all common properties
        /// </summary>
        /// <param name="sourceObj"></param>
        /// <param name="targetObj"></param>
        public static void MapProp(Manifest sourceObj, Manifest targetObj)
        {
            var sourceProperties = sourceObj.GetType().GetTypeInfo().DeclaredProperties;
            var targetProperties = targetObj.GetType().GetTypeInfo().DeclaredProperties;
            List<PropertyInfo> targetPropertyList = targetProperties.ToList();

            foreach (PropertyInfo srcProp in sourceProperties)
            {
                var ps = new PropertySearch(srcProp);
                int index = targetPropertyList.FindIndex(ps.EqualName);
                if (index >= 0)
                {
                    PropertyInfo targetProp = targetPropertyList[index];
                    targetProp.SetValue(targetObj, srcProp.GetValue(sourceObj, null));
                }
            }
            //Common fields (DeclaredProperties does not include properties from parent)
            targetObj.SchemaVersion = sourceObj.SchemaVersion;
        }
        private class PropertySearch
        {
            PropertyInfo _inner;

            public PropertySearch(PropertyInfo inner)
            {
                _inner = inner;
            }
            public bool EqualName(PropertyInfo comparable)
            {
                return comparable.Name.Equals(_inner.Name);
            }
        }

    }
}
