namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class StorageAccountCredential
    {
        public StorageAccountCredential(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName, string name) : base(client, resourceGroupName, managerName, name)
        {
        }
    }
}