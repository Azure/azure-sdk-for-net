namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class Manager
    {
        public Manager(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName) : base(client, resourceGroupName, managerName)
        {
        }
    }
}