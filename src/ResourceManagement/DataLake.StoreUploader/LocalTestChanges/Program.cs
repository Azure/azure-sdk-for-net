using Microsoft.Azure.Management.DataLake.StoreUploader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTestChanges
{
    class Program
    {
        static void Main(string[] args)
        {

            var uploadParamsFlat = new UploadParameters(@"C:\temp\ManyFilesTest", "/begoldsm/testfolder", "testAccount");
            var uploadParamsRecursive = new UploadParameters(@"C:\temp\ManyFilesTest", "/begoldsm/testfolder", "testAccount", isRecursive: true);
            var watch = Stopwatch.StartNew();
            var folderDataRecursive = new UploadFolderMetadata(@"C:\temp\foldermetadata.xml", uploadParamsRecursive);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            watch.Reset();
            watch.Start();
            var folderDataFlat = new UploadFolderMetadata(@"C:\temp\foldermetadata.xml", uploadParamsFlat);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalSeconds);
            folderDataFlat.Save();
            folderDataRecursive.Save();
        }
    }
}
