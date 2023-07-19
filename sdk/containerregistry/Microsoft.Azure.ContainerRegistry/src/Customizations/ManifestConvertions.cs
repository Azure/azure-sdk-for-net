
namespace Microsoft.Azure.ContainerRegistry.Models
{
    public partial class V2Manifest : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to V2Manifest
        /// </summary>
        public static explicit operator V2Manifest(ManifestWrapper v)
        {
            var manifest = new V2Manifest
            {
                Layers = v.Layers,
                SchemaVersion = v.SchemaVersion,
                Config = v.Config,
                MediaType = v.MediaType
            };
            return manifest;
        }
    }

    public partial class V1Manifest : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to V1Manifest
        /// </summary>
        public static explicit operator V1Manifest(ManifestWrapper v)
        {
            var manifest = new V1Manifest
            {
                Architecture = v.Architecture,
                FsLayers = v.FsLayers,
                History = v.History,
                Name = v.Name,
                Signatures = v.Signatures,
                Tag = v.Tag,
                SchemaVersion = v.SchemaVersion,
                MediaType=v.MediaType             
            };
            return manifest;
        }
    }

    public partial class ManifestList : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to ManifestList
        /// </summary>
        public static explicit operator ManifestList(ManifestWrapper v)
        {
            var manifest = new ManifestList
            {
                Manifests = v.Manifests,
                SchemaVersion = v.SchemaVersion,
                MediaType = v.MediaType
            };
            return manifest;
        }
    }

    public partial class OCIIndex : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to OCIIndex
        /// </summary>
        public static explicit operator OCIIndex(ManifestWrapper v)
        {
            var manifest = new OCIIndex
            {
                Manifests = v.Manifests,
                SchemaVersion = v.SchemaVersion,
                Annotations = v.Annotations,
                MediaType=v.MediaType               
            };
            return manifest;
        }
    }

    public partial class OCIManifest : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to OCIManifest
        /// </summary>
        public static explicit operator OCIManifest(ManifestWrapper v)
        {
            var manifest = new OCIManifest
            {
                Layers = v.Layers,
                SchemaVersion = v.SchemaVersion,
                Config = v.Config,
                Annotations = v.Annotations,
                MediaType=v.MediaType
            };
            return manifest;
        }
    }
}
