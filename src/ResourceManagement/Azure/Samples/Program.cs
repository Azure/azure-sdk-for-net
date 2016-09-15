using System;

namespace Samples
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Test Manage resource groups");
            ManageResourceGroup.TestManageResourceGroup();

            Console.WriteLine("Test list virtual machine images");
            ListVirtualMachineImages.TestListVirtualMachineImages();

            Console.WriteLine("Testing storage accounts now");
            ManageStorageAccount.TestStorageAccount();

            Console.WriteLine("Availability sets");
            ManageAvailabilitySet.TestAvailabilitySet();

            Console.WriteLine("Virtual machine tests");
            ManageVirtualMachine.TestVirtualMachine();

            Console.WriteLine("Resource group deployment");
            DeployUsingArmTemplate.Deploy();

            Console.WriteLine("Manage resources");
            ManageResource.TestManageResource();
        }
    }
}