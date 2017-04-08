// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Common.Authentication
{
    public interface IDataStore
    {
        void WriteFile(string path, string contents);

        void WriteFile(string path, string content, Encoding encoding);

        void WriteFile(string path, byte[] contents);

        string ReadFileAsText(string path);

        Stream ReadFileAsStream(string path);

        byte[] ReadFileAsBytes(string path);

        void RenameFile(string oldPath, string newPath);

        void CopyFile(string oldPath, string newPath);

        bool FileExists(string path);

        void DeleteFile(string path);

        void DeleteDirectory(string dir);

        void EmptyDirectory(string dirPath);

        bool DirectoryExists(string path);

        void CreateDirectory(string path);

        string[] GetDirectories(string sourceDirName);

        string[] GetDirectories(string startDirectory, string filePattern, SearchOption options);

        string[] GetFiles(string sourceDirName);

        string[] GetFiles(string startDirectory, string filePattern, SearchOption options);

        FileAttributes GetFileAttributes(string path);

        X509Certificate2 GetCertificate(string thumbprint);

        void AddCertificate(X509Certificate2 cert);

        void RemoveCertificate(string thumbprint);
    }
}
