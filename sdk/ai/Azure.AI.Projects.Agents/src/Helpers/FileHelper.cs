// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Azure.AI.Projects.Agents;

internal class FileHelper
{
    internal static void SaveAndUnzipData(string directoryPath, BinaryData content)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        try
        {
            File.WriteAllBytes(temporaryFile, content.ToArray());
            ZipFile.ExtractToDirectory(temporaryFile, directoryPath);
        }
        finally
        {
            File.Delete(temporaryFile);
        }
    }

    internal static BinaryData CreateAndReadZipFileFromDirectory(string directoryPath)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        try
        {
            ZipFile.CreateFromDirectory(directoryPath, temporaryFile);
            return new(File.ReadAllBytes(temporaryFile));
        }
        finally
        {
            File.Delete(temporaryFile);
        }
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
            strHash = System.Text.Encoding.Default.GetString(hash);
        }
        return (zipContents, strHash);
    }
}
