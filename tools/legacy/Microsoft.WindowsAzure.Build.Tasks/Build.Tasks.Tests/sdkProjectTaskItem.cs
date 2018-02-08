// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Build.Tasks.Tests
{

    class sdkProjectTaskItem : ITaskItem
    {
        string _itemSpec;

        public sdkProjectTaskItem(string taskItemPath)
        {
            if(File.Exists(taskItemPath))
            {
                _itemSpec = taskItemPath;
            }
        }
        public string ItemSpec
        { get => _itemSpec; set => _itemSpec = value; }

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
