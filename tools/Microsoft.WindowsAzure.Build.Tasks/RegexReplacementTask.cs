//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.WindowsAzure.Build.Tasks
{
    public class RegexReplacementTask : Task
    {
        [Required]
        public ITaskItem[] Files { get; set; }

        [Required]
        public string Find { get; set; }

        [Required]
        public string Replace { get; set; }

        public override bool Execute()
        {
            try
            {
                foreach (string fileName in Files.Select(f => f.GetMetadata("FullPath")))
                {
                    FileAttributes oldAttributes = File.GetAttributes(fileName);
                    File.SetAttributes(fileName, oldAttributes & ~FileAttributes.ReadOnly);

                    string content = Regex.Replace(
                        File.ReadAllText(fileName), 
                        Find, 
                        Replace);

                    File.WriteAllText(fileName, content, Encoding.UTF8);
                    File.SetAttributes(fileName, oldAttributes);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                return false;
            }
        }
    }
}
