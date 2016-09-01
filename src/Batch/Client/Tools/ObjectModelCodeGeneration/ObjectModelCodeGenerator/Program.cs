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

namespace ObjectModelCodeGenerator
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CodeGenerationLibrary;
    using ProxyLayerParser;

    public class Program
    {
        public static void Main(string[] args)
        {
            GenerateModelFiles();

            GenerateSomeRoslynFiles();
        }

        private static void GenerateModelFiles()
        {
            var inputFile = @"BatchProperties.json";
            var model = new FileReader(inputFile).ReadTypes();

            var seen = new HashSet<string>();

            foreach (var type in model.Types)
            {
                if (seen.Contains(type.Name))
                {
                    System.Console.WriteLine($"Duplicate type in {inputFile}: {type.Name}");
                }
                seen.Add(type.Name);

                string outputDirectory = "../../../../../src/Generated";
                string outputFilePath = Path.Combine(outputDirectory, type.Name + ".cs");

                string innerClassString;
                if (!type.IsStaticallyReadOnly || type.IsTopLevelObject)
                {
                    ModifiableClassTemplate modifiableClass = new ModifiableClassTemplate(type);
                    innerClassString = modifiableClass.TransformText();
                }
                else
                {
                    //If any property is complex throw an exception because it will look read only and yet
                    //will not be.
                    if (type.Properties.Select(kvp => kvp.Key).Any(prop => CodeGenerationUtilities.IsTypeComplex(prop.Type)))
                    {
                        //TODO: Can't enforce this right now because of some get-only types which we autogenerate
                        //throw new InvalidOperationException(string.Format("Statically readonly type {0} cannot have complex properties",
                        //    type.Name));
                    }
                    StaticReadOnlyClassTemplate staticReadOnlyClass = new StaticReadOnlyClassTemplate(type);
                    innerClassString = staticReadOnlyClass.TransformText();
                }
                ModelClassTemplate batchModel = new ModelClassTemplate(type, innerClassString);


                File.WriteAllText(outputFilePath, batchModel.TransformText());
            }
        }

        private static void GenerateSomeRoslynFiles()
        {
            var projectFile = @"..\..\..\..\..\src\Batch.csproj";
            IEnumerable<BatchRequestGroup> batchRequests = BatchRequestTemplateBuilder.GetBatchRequestTemplatesAsync(projectFile).Result;

            NamedBatchRequests generator = new NamedBatchRequests(batchRequests);
            string resultDirectory = CreateResultDirectoryIfNotExist("GeneratedNamedBatchRequests");
            string outputFilePath = Path.Combine(resultDirectory, "NamedBatchRequests.cs");
            File.WriteAllText(outputFilePath, generator.TransformText());
        }

        private static string CreateResultDirectoryIfNotExist(string directoryName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string generatedCodeDirectory = Path.Combine(currentDirectory, directoryName);
            Directory.CreateDirectory(generatedCodeDirectory);

            return generatedCodeDirectory;
        }
    }
}
