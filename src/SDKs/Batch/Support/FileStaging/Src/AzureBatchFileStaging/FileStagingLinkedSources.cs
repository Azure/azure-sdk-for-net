// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Security;
using System.Runtime.InteropServices;

namespace Microsoft.Azure.Batch.FileStaging
{
    internal sealed class FileStagingLinkedSources
    {

        private static string MakeDefaultNamePlusNamingFragment(string namingFragment)
        {
            StringBuilder newNameBuilder = new StringBuilder();
            
            newNameBuilder.Append(Batch.Constants.DefaultConveniencePrefix);

            if (!string.IsNullOrWhiteSpace(namingFragment))
            {
                newNameBuilder.Append(namingFragment);
                newNameBuilder.Append("-");
            }

            string newName = newNameBuilder.ToString();

            return newName;
        }

        // lock used to ensure only one name is created at a time.
        private static object _lockForContainerNaming = new object();

        internal static string ConstructDefaultName(string namingFragment)
        {
            lock (_lockForContainerNaming)
            {
                Thread.Sleep(30);  // make sure no two names are identical

                string uniqueLetsHope = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-fff");
                string defContainerName = MakeDefaultNamePlusNamingFragment(namingFragment) + uniqueLetsHope;

                return defContainerName;
            }
        }
    }
}
