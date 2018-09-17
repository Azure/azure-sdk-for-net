namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class FileShare
    {
        public FileShare(
            StorSimple1200SeriesManagementClient client,
            string resourceGroupName,
            string managerName) : base(client, resourceGroupName, managerName)
        {
        }
    }
}