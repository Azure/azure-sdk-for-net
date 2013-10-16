//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public static class PlatformConfigurationHelper
    {       
        public static X509Certificate2 GetCertificate(IDictionary<string, object> parameters, string name, bool isRequired = true)
        {
            object value = ConfigurationHelper.GetParameter(parameters, name, isRequired);

            X509Certificate2 certificate = value as X509Certificate2;
            if (certificate == null)
            {
                // Try to load the value as a serialized certificate
                byte[] bytes = value as byte[];
                string text = value as string;
                if (bytes == null && text != null)
                {
                    bytes = Convert.FromBase64String(text);
                }
                if (bytes != null)
                {
                    certificate = GetCertificate(bytes);
                }

                // Try to load the value as a thumbprint from the store
                if (certificate == null && !string.IsNullOrEmpty(text))
                {
                    certificate =
                        GetCertificateFromStore(text, StoreLocation.CurrentUser) ??
                        GetCertificateFromStore(text, StoreLocation.LocalMachine);
                }
            }

            if (isRequired && certificate == null)
            {
                throw ConfigurationHelper.CreateCouldNotConvertException<X509Certificate2>(name, value);
            }

            return certificate;
        }

        private static X509Certificate2 GetCertificate(byte[] bytes)
        {
            try
            {
                return new X509Certificate2(bytes);
            }
            catch
            {
            }
            return null;
        }

        private static X509Certificate2 GetCertificateFromStore(string thumbprint, StoreLocation location)
        {
            if (thumbprint != null)
            {
                X509Store store = null;
                try
                {
                    store = new X509Store(StoreName.My, location);
                    store.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                    if (certificates.Count > 0)
                    {
                        return certificates[0];
                    }
                }
                catch
                {
                }
                finally
                {
                    if (store != null)
                    {
                        store.Close();
                    }
                }
            }
            return null;
        }
    }
}
