namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class BaseModel
    {
        public StorSimpleManagementClient Client;
        public string ResourceGroupName;
        public string ManagerName;

        public BaseModel(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName)
        {
            this.Client = client;
            this.ResourceGroupName = resourceGroupName;
            this.ManagerName = managerName;
        }
        
        public BaseModel(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName, 
            string name)
        {
            this.Client = client;
            this.ResourceGroupName = resourceGroupName;
            this.ManagerName = managerName;
            this.Name = name;
        }
    }
}