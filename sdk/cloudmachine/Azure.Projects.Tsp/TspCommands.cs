// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.TypeSpec;
using System.Collections.Generic;
using System.IO;

namespace Azure.Projects;

/// <summary>
/// This class is used to generate TSP files for the operation groups.
/// </summary>
public class TspCommands
{
    private static void GenerateTsp(IEnumerable<Type> operationGroups)
    {
        foreach (Type operationGroup in operationGroups)
        {
            string name = operationGroup.Name;
            if (name.StartsWith("I"))
                name = name.Substring(1);
            string directory = Path.Combine(".", "tsp");
            string tspFile = Path.Combine(directory, $"{name}.tsp");
            Directory.CreateDirectory(Path.GetDirectoryName(tspFile)!);
            if (File.Exists(tspFile))
                File.Delete(tspFile);
            using FileStream stream = File.OpenWrite(tspFile);
            TypeSpecWriter.WriteServer(stream, operationGroup);
        }
    }
}
