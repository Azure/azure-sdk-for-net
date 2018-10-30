// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

        public bool LogReplacement { get; set; }

        /// <summary>
        /// Gets or sets the optional output directory. If a OutputDir value is
        /// specified, the original file contents will not be overwritten.
        /// </summary>
        public string OutputDir { get; set; }

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

                    string outputFileName = fileName;
                    string message = null;
                    if (!string.IsNullOrEmpty(OutputDir))
                    {
                        string path = Path.GetFullPath(OutputDir);
                        outputFileName = Path.Combine(path, Path.GetFileName(fileName));
                        message = " saved as " + outputFileName;
                    }

                    File.WriteAllText(outputFileName, content, Encoding.UTF8);
                    File.SetAttributes(outputFileName, oldAttributes);

                    if (LogReplacement)
                    {
                        Log.LogMessage("Processed regular expression replacement in file {0}{1}", fileName, message);
                    }
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
