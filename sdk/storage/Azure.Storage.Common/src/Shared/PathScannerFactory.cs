// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD:sdk/storage/Azure.Storage.Common/src/Shared/PathScannerFactory.cs
namespace Azure.Storage
=======
namespace Azure.Storage.DataMovement
>>>>>>> upstream/feature/storage/data-movement:sdk/storage/Azure.Storage.DataMovement/src/PathScannerFactory.cs
{
    internal class PathScannerFactory
    {
        private string _path;

        public PathScannerFactory(string path)
        {
            _path = path;
        }

        public PathScanner BuildPathScanner()
        {
            return new PathScanner(_path);
        }
    }
}
