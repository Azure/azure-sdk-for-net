namespace Azure.Iot.ModelsRepository
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
        TryFromExpanded = 2,
    }
    public partial class ModelsRepositoryClient
    {
        public ModelsRepositoryClient() { }
        public ModelsRepositoryClient(Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions options) { }
        public ModelsRepositoryClient(System.Uri repositoryUri, Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions options = null) { }
        public System.Uri RepositoryUri { get { throw null; } }
        public virtual System.Collections.Generic.IDictionary<string, string> GetModels(System.Collections.Generic.IEnumerable<string> dtmis, Azure.Iot.ModelsRepository.ModelDependencyResolution? dependencyResolution = default(Azure.Iot.ModelsRepository.ModelDependencyResolution?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IDictionary<string, string> GetModels(string dtmi, Azure.Iot.ModelsRepository.ModelDependencyResolution? dependencyResolution = default(Azure.Iot.ModelsRepository.ModelDependencyResolution?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, string>> GetModelsAsync(System.Collections.Generic.IEnumerable<string> dtmis, Azure.Iot.ModelsRepository.ModelDependencyResolution? dependencyResolution = default(Azure.Iot.ModelsRepository.ModelDependencyResolution?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IDictionary<string, string>> GetModelsAsync(string dtmi, Azure.Iot.ModelsRepository.ModelDependencyResolution? dependencyResolution = default(Azure.Iot.ModelsRepository.ModelDependencyResolution?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelsRepositoryClientOptions : Azure.Core.ClientOptions
    {
        public ModelsRepositoryClientOptions(Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion version = Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion.V2021_02_11, Azure.Iot.ModelsRepository.ModelDependencyResolution dependencyResolution = Azure.Iot.ModelsRepository.ModelDependencyResolution.Enabled) { }
        public Azure.Iot.ModelsRepository.ModelDependencyResolution DependencyResolution { get { throw null; } }
        public Azure.Iot.ModelsRepository.ModelsRepositoryClientOptions.ServiceVersion Version { get { throw null; } }
        public enum ServiceVersion
        {
            V2021_02_11 = 1,
        }
    }
}
