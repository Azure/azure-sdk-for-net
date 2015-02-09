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

using Microsoft.Azure.Common.Authentication.Properties;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Microsoft.Azure.Common.Authentication.Models
{
    public class DiskDataStore : IDataStore
    {
        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void WriteFile(string path, string contents, Encoding encoding)
        {
            File.WriteAllText(path, contents, encoding);
        }

        public void WriteFile(string path, byte[] contents)
        {
            File.WriteAllBytes(path, contents);
        }

        public string ReadFileAsText(string path)
        {
            return File.ReadAllText(path);
        }

        public byte[] ReadFileAsBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public Stream ReadFileAsStream(string path)
        {
            return File.Open(path, FileMode.Open, FileAccess.Read);
        }

        public void RenameFile(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }

        public void CopyFile(string oldPath, string newPath)
        {
            File.Copy(oldPath, newPath, true);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void DeleteDirectory(string dir)
        {
            Directory.Delete(dir, true);
        }

        public void EmptyDirectory(string dirPath)
        {
            foreach (var filePath in Directory.GetFiles(dirPath))
            {
                File.Delete(filePath);
            }
        }

        public string[] GetFiles(string sourceDirName)
        {
            return Directory.GetFiles(sourceDirName);
        }

        public string[] GetFiles(string startDirectory, string filePattern, SearchOption options)
        {
            return Directory.GetFiles(startDirectory, filePattern, options);
        }

        public FileAttributes GetFileAttributes(string path)
        {
            return File.GetAttributes(path);
        }

        public X509Certificate2 GetCertificate(string thumbprint)
        {
            if (thumbprint == null)
            {
                return null;
            }
            else
            {
                Validate.ValidateStringIsNullOrEmpty(thumbprint, "certificate thumbprint");
                X509Certificate2Collection certificates;
                if (TryFindCertificatesInStore(thumbprint, StoreLocation.CurrentUser, out certificates) ||
                    TryFindCertificatesInStore(thumbprint, StoreLocation.LocalMachine, out certificates))
                {
                    return certificates[0];
                }
                else
                {
                    throw new ArgumentException(string.Format(Resources.CertificateNotFoundInStore, thumbprint));
                }
            }
        }

        private static bool TryFindCertificatesInStore(string thumbprint,
            StoreLocation location, out X509Certificate2Collection certificates)
        {
            X509Store store = new X509Store(StoreName.My, location);
            store.Open(OpenFlags.ReadOnly);
            certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
            store.Close();

            return certificates.Count > 0;
        }

        public void AddCertificate(X509Certificate2 certificate)
        {
            Validate.ValidateNullArgument(certificate, Resources.InvalidCertificate);
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();
        }

        public void RemoveCertificate(string thumbprint)
        {
            if (thumbprint != null)
            {
                var certificate = GetCertificate(thumbprint);
                if (certificate != null)
                {
                    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.ReadWrite);
                    store.Remove(certificate);
                    store.Close();
                }
            }
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public string[] GetDirectories(string sourceDirName)
        {
            return Directory.GetDirectories(sourceDirName);
        }

        public string[] GetDirectories(string startDirectory, string filePattern, SearchOption options)
        {
            return Directory.GetDirectories(startDirectory, filePattern, options);
        }
    }
}
