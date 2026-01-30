// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TestProjects.Spector.Tests
{
    [AttributeUsage(AttributeTargets.Assembly)]
    internal sealed class BuildPropertiesAttribute : Attribute
    {
        public string RepoRoot { get; }
        public string ArtifactsDirectory { get; }

        public BuildPropertiesAttribute(string repoRoot, string artifactsDirectory)
        {
            RepoRoot = repoRoot;
            ArtifactsDirectory = artifactsDirectory;
        }
    }
}
