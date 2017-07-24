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
using System.Text;

namespace Microsoft.Azure.Batch.FileStaging
{
    internal static class FileStagingNamingHelpers
    {
        public const int MaxContainerNameLength = 63;

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

        internal static string ConstructDefaultName(string namingFragment)
        {
            string timeString = DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss");
            string containerName = MakeDefaultNamePlusNamingFragment(namingFragment) + timeString + Guid.NewGuid().ToString("D");

            containerName = containerName.Length > MaxContainerNameLength ? containerName.Substring(0, MaxContainerNameLength) : containerName;

            return containerName;
        }
    }
}
