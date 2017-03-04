namespace Microsoft.Azure.Management.ApiManagement.SmapiModels
{
    public partial class BackendGetContract
    {
        private const string IdPrefix = "/backends/";

        public string Id
        {
            get
            {
                if (!string.IsNullOrEmpty(IdPath))
                {
                    return IdPath.Replace(IdPrefix, string.Empty);
                }

                return IdPath;
            }
        }
    }
}