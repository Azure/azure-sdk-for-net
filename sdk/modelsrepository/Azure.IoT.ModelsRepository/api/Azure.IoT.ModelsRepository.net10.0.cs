namespace Azure.IoT.ModelsRepository
{
    public static partial class DtmiConventions
    {
        public static System.Uri GetModelUri(string dtmi, System.Uri repositoryUri, bool expanded = false) { throw null; }
        public static bool IsValidDtmi(string dtmi) { throw null; }
    }
    public enum ModelDependencyResolution
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ModelResult
    {
        internal ModelResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Content { get { throw null; } }
    }
    public partial class ModelsRepositoryClient
    {
        public ModelsRepositoryClient() { }
        public ModelsRepositoryClient(Azure.IoT.ModelsRepository.ModelsRepositoryClientOptions options) { }
        public ModelsRepositoryClient(System.Uri repositoryUri, Azure.IoT.ModelsRepository.ModelsRepositoryClientOptions options = null) { }
        public System.Uri RepositoryUri { get { throw null; } }
        public virtual Azure.IoT.ModelsRepository.ModelResult GetModel(string dtmi, Azure.IoT.ModelsRepository.ModelDependencyResolution dependencyResolution = Azure.IoT.ModelsRepository.ModelDependencyResolution.Enabled, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.IoT.ModelsRepository.ModelResult> GetModelAsync(string dtmi, Azure.IoT.ModelsRepository.ModelDependencyResolution dependencyResolution = Azure.IoT.ModelsRepository.ModelDependencyResolution.Enabled, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelsRepositoryClientMetadataOptions
    {
        public ModelsRepositoryClientMetadataOptions() { }
        public bool IsMetadataProcessingEnabled { get { throw null; } set { } }
    }
    public partial class ModelsRepositoryClientOptions : Azure.Core.ClientOptions
    {
        public ModelsRepositoryClientOptions(Azure.IoT.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion version = Azure.IoT.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion.V2021_02_11) { }
        public Azure.IoT.ModelsRepository.ModelsRepositoryClientMetadataOptions RepositoryMetadata { get { throw null; } }
        public Azure.IoT.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2021_02_11 = 1,
        }
    }
}
