// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

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
