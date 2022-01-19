// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
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
