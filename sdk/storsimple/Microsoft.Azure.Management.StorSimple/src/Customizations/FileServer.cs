namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class FileServer
    {
        public FileServer(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string name) : base(client, resourceGroupName, managerName, name)
        {
        }
    }
}