namespace Azure.CloudMachine
{
    public static partial class CloudMachineExtensions
    {
        public static void Map<T>(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder routeBuilder, T serviceImplementation) where T : class { }
        public static System.Threading.Tasks.Task UploadFormAsync(this Azure.CloudMachine.StorageServices storage, Microsoft.AspNetCore.Http.HttpRequest multiPartFormData) { throw null; }
    }
}
