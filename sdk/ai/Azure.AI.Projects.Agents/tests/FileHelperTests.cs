// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;

public class FileHelperTests
{
    [Test]
    public void CreateAndReadZipFileFromDirectoryUsesForwardSlashes()
    {
        string root = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        string skills = Path.Combine(root, "Prompts", "Skills");
        Directory.CreateDirectory(skills);
        File.WriteAllText(Path.Combine(skills, "SKILL.md"), "skill");
        try
        {
            BinaryData zip = FileHelper.CreateAndReadZipFileFromDirectory(root);

            using ZipArchive archive = new(zip.ToStream(), ZipArchiveMode.Read);
            string[] entries = archive.Entries.Select(e => e.FullName).OrderBy(n => n, StringComparer.Ordinal).ToArray();
            Assert.That(entries, Is.EqualTo(new[] { "Prompts/", "Prompts/Skills/", "Prompts/Skills/SKILL.md" }));
        }
        finally
        {
            Directory.Delete(root, recursive: true);
        }
    }
}
