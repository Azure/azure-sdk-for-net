// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Azure.AI.Projects.Agents;

internal class FileHelper
{
    internal static void SaveAndUnzipData(string directoryPath, BinaryData content)
    {
        using (MemoryStream stream = new())
        {
            stream.Write(content.ToArray(), 0, content.Length);
            stream.Position = 0;
            using (ZipArchive archive = new(stream, ZipArchiveMode.Read))
            {
                archive.ExtractToDirectory(directoryPath);
            }
        }
    }

    private static void DirWalk(ZipArchive archive, string directoryPath, string prefix)
    {
        foreach (string file in Directory.GetFiles(directoryPath))
        {
            archive.CreateEntryFromFile(file, file.Substring(prefix.Length));
        }
        foreach (string dir in Directory.GetDirectories(directoryPath))
        {
            archive.CreateEntry(dir);
            DirWalk(archive, dir, directoryPath);
        }
    }

    internal static BinaryData CreateAndReadZipFileFromDirectory(string directoryPath)
    {
        BinaryData zipContents;
        using (MemoryStream stream = new())
        {
            stream.Position = 0;
            using (ZipArchive archive = new(stream, ZipArchiveMode.Create))
            {
                DirWalk(archive, directoryPath, directoryPath);
            }
            stream.Position = 0;
            zipContents = new(stream.ToArray());
        }
        return zipContents;
    }

    internal static (BinaryData Data, string Sha256sum) CreateAndReadZipFile(string fileName)
    {
        BinaryData zipContents;
        using (MemoryStream stream = new())
        {
            using (ZipArchive tempZip = new(stream, ZipArchiveMode.Create))
            {
                tempZip.CreateEntryFromFile(fileName, Path.GetFileName(fileName));
            }
            stream.Position = 0;
            zipContents = new(stream.ToArray());
        }
        string strHash = default;
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] hash = sha256Hash.ComputeHash(zipContents.ToArray());
            StringBuilder sbString = new();
            foreach (byte b in hash)
            {
                sbString.Append(b.ToString("X2"));
            }
            strHash = sbString.ToString();
        }
        return (zipContents, strHash);
    }
}
