// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    public class FileReader
    {
        private readonly string folder;
        private readonly string pattern;

        public FileReader(string folder, string pattern)
        {
            this.folder = folder;
            this.pattern = pattern;
        }

        public Model ReadTypes()
        {
            var files = Directory.GetFiles(folder, pattern);
            var inputs = files.Select(f => File.ReadAllText(f));

            var input = "{ \"Types\": [\r\n" + string.Join(",\r\n", inputs) + " ] }";

            Model m = JsonConvert.DeserializeObject<Model>(input);

            return m;
        }
    }
}
