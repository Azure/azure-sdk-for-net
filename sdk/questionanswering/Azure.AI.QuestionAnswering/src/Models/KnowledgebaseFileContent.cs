// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.QuestionAnswering.Models
{
    public partial class KnowledgebaseFileContent
    {
        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <remarks>
        /// Supported file types are:
        /// <list type="bullet">
        ///   <item>
        ///     <description>.docx</description>
        ///   </item>
        ///   <item>
        ///     <description>.pdf</description>
        ///   </item>
        ///   <item>
        ///     <description>.tsv</description>
        ///   </item>
        ///   <item>
        ///     <description>.txt</description>
        ///   </item>
        ///   <item>
        ///     <description>.xlsx</description>
        ///   </item>
        /// </list>
        /// </remarks>
        [CodeGenMember("FileName")]
        public string Name { get; }

        /// <summary>
        /// Gets the public <see cref="Uri"/> to the file.</summary>
        [CodeGenMember("FileUri")]
        public Uri Uri { get; }
    }
}
