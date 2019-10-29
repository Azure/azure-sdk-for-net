namespace Microsoft.Azure.Management.StorSimple1200Series.Models
{
    public partial class BackupScheduleGroup
    {
        public BackupScheduleGroup(
            StorSimpleManagementClient client,
            string resourceGroupName,
            string managerName,
            string name) : base(client, resourceGroupName, managerName, name)
        {
        }
    }
}