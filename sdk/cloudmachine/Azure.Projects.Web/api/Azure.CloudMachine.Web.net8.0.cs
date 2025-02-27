namespace Azure.Projects
{
    public static partial class AzureProjectsExtensions
    {
        public static void MapAzureProjectsApplication<T>(this Microsoft.AspNetCore.Builder.WebApplication application) where T : class { }
        public static void Map<T>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder routeBuilder, T serviceImplementation) where T : class { }
        public static System.Threading.Tasks.Task UploadFormAsync(this Azure.Projects.StorageServices storage, Microsoft.AspNetCore.Http.HttpRequest multiPartFormData) { throw null; }
    }
}
