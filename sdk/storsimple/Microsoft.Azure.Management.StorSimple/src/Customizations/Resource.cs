namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class Resource
    {
        public StorSimpleManagementClient Client;
        public string ResourceGroupName;
        public string ManagerName;

        public Resource(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            Client = client;
            ResourceGroupName = resourceGroupName;
            ManagerName = managerName;
            Name = managerName;
        }
    }
}