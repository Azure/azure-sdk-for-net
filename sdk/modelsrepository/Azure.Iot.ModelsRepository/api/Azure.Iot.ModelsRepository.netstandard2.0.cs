namespace Azure.Iot.ModelsRepository
{
    public enum DependencyResolutionOption
    {
        Disabled = 0,
        Enabled = 1,
        TryFromExpanded = 2,
    }
    public partial class ModelsRepositoryClient
    {
        public ModelsRepositoryClient() { }
        public ModelsRepositoryClient(Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions options) { }
        public ModelsRepositoryClient(System.Uri repositoryUri, Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions options = null) { }
        public static System.Uri DefaultModelsRepository { get { throw null; } }
        public System.Uri RepositoryUri { get { throw null; } }
        public virtual System.Collections.Generic.IDictionary<string, string> GetModels(System.Collections.Generic.IEnumerable<string> dtmis, Azure.Iot.ModelsRepository.DependencyResolutionOption? resolutionOption = default(Azure.Iot.ModelsRepository.DependencyResolutionOption?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IDictionary<string, string> GetModels(string dtmi, Azure.Iot.ModelsRepository.DependencyResolutionOption? resolutionOption = default(Azure.Iot.ModelsRepository.DependencyResolutionOption?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, string>> GetModelsAsync(System.Collections.Generic.IEnumerable<string> dtmis, Azure.Iot.ModelsRepository.DependencyResolutionOption? resolutionOption = default(Azure.Iot.ModelsRepository.DependencyResolutionOption?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, string>> GetModelsAsync(string dtmi, Azure.Iot.ModelsRepository.DependencyResolutionOption? resolutionOption = default(Azure.Iot.ModelsRepository.DependencyResolutionOption?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelsRepositoryClientOptions : Azure.Core.ClientOptions
    {
        public ModelsRepositoryClientOptions(Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion version = Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion.V2021_02_11, Azure.Iot.ModelsRepository.DependencyResolutionOption resolutionOption = Azure.Iot.ModelsRepository.DependencyResolutionOption.Enabled) { }
        public Azure.Iot.ModelsRepository.DependencyResolutionOption DependencyResolution { get { throw null; } }
        public Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2021_02_11 = 1,
        }
    }
}
