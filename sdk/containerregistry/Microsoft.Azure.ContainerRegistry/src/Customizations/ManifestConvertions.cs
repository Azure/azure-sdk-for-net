
namespace Microsoft.Azure.ContainerRegistry.Models
{
    public partial class V2Manifest : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to V2Manifest
        /// </summary>
        public static explicit operator V2Manifest(ManifestWrapper v)
        {
            var manifest = new V2Manifest();
            manifest.Layers = v.Layers;
            manifest.SchemaVersion = v.SchemaVersion;
            manifest.Config = v.Config;
            manifest.MediaType = v.MediaType;
            return manifest;
        }
    }

    public partial class V1Manifest : Manifest
    {
        /// <summary>
        /// Provides a method to convert ManifestWrapper to V21Manifest
        /// </summary>
        public static explicit operator V1Manifest(ManifestWrapper v)
        {
            var manifest = new V1Manifest();
            manifest.Architecture = v.Architecture;
            manifest.FsLayers = manifest.FsLayers;
            manifest.History = v.History;
            manifest.Name = v.Name;
            manifest.Signatures = v.Signatures;
            manifest.Tag = v.Tag;
            manifest.SchemaVersion = v.SchemaVersion;
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
            var manifest = new ManifestList();
            manifest.Manifests = v.Manifests;
            manifest.SchemaVersion = v.SchemaVersion;
            manifest.MediaType = v.MediaType;
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
            var manifest = new OCIIndex();
            manifest.Manifests = v.Manifests;
            manifest.SchemaVersion = v.SchemaVersion;
            manifest.Annotations = v.Annotations;
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
            var manifest = new OCIManifest();
            manifest.Layers = v.Layers;
            manifest.SchemaVersion = v.SchemaVersion;
            manifest.Config = v.Config;
            manifest.Annotations = v.Annotations;
            return manifest;
        }
    }
}
