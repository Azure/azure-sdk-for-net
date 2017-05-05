using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using Xunit;
using BuildTasks.Core;

namespace Build.Tasks.Tests
{
    public class GetMetaDataTests
    {
        //[Fact]
        public void GetTargetFramework()
        {
            string projFile = Path.GetFullPath("SampleSdk.csproj");


            SampleItem si = new SampleItem(projFile);

            SDKCategorizeProjects cproj = new SDKCategorizeProjects();
            //cproj.SDKProjectsToBuild = new ITaskItem[] { si };

            Dictionary<string, string> fxList = cproj.GetMetaData(si);

        }
    }

    internal class SampleItem : ITaskItem
    {
        string _itemSpec;
        internal SampleItem(string itemPath)
        {
            if(File.Exists(itemPath))
            {
                _itemSpec = itemPath;
            }
        }
        public string ItemSpec
        {
            get => _itemSpec;
            set => _itemSpec = value;
        }

        public ICollection MetadataNames => throw new NotImplementedException();

        public int MetadataCount => throw new NotImplementedException();

        public IDictionary CloneCustomMetadata()
        {
            throw new NotImplementedException();
        }

        public void CopyMetadataTo(ITaskItem destinationItem)
        {
            throw new NotImplementedException();
        }

        public string GetMetadata(string metadataName)
        {
            throw new NotImplementedException();
        }

        public void RemoveMetadata(string metadataName)
        {
            throw new NotImplementedException();
        }

        public void SetMetadata(string metadataName, string metadataValue)
        {
            throw new NotImplementedException();
        }
    }
}
