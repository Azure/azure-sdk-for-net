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
        File.WriteAllBytes(temporaryFile, content.ToArray());
        ZipFile.ExtractToDirectory(temporaryFile, directoryPath);
    }

    internal static BinaryData CreateAndReadZipFileFromDirectory(string directoryPath)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        ZipFile.CreateFromDirectory(directoryPath, temporaryFile);
        return new(File.ReadAllBytes(temporaryFile));
    }

    internal static (BinaryData Data, string Sha256sum) CreateAndReadZipFile(string fileName)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        using (ZipArchive tempZip = ZipFile.Open(temporaryFile, ZipArchiveMode.Create))
        {
            tempZip.CreateEntryFromFile(fileName, fileName);
        }
        BinaryData zipContents = new(File.ReadAllBytes(temporaryFile));
        string strHash = default;
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] hash = sha256Hash.ComputeHash(zipContents.ToArray());
            strHash = System.Text.Encoding.Default.GetString(hash);
        }
        return (zipContents, strHash);
    }
}
