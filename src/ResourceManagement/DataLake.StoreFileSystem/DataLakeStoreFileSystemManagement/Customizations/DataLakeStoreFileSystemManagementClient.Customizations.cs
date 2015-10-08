// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Linq;
using System.Net.Http;

namespace Microsoft.Azure.Management.DataLake.StoreFileSystem
{
    public partial class DataLakeStoreFileSystemManagementClient
    {
        private static object clientInitializationLock = new object();
        private HttpClient autoRedirectOffClient;
        private HttpClient defaultClient;
        private HttpClientHandler defaultHandler;
        private HttpClientHandler autoRedirectOffHandler;
        private bool currentRedirectSetting = true;

        public void SetAutoRedirectSwitch(bool setEnabled)
        {
            // initialize the clients if they are not already initialized
            this.InitializeCustomClientAndHandler();
            
            // setting it to true is the default behavior
            if (setEnabled && !currentRedirectSetting)
            {
                lock (clientInitializationLock)
                {
                    this.HttpClient = defaultClient;
                    currentRedirectSetting = true;
                }
                
            }
            else if(!setEnabled && currentRedirectSetting)
            {
                lock (clientInitializationLock)
                {
                    this.HttpClient = autoRedirectOffClient;
                    currentRedirectSetting = false;
                }
            }
        }

        private void InitializeCustomClientAndHandler()
        {
            if (autoRedirectOffClient == null || autoRedirectOffHandler == null
                || defaultClient == null || defaultHandler == null)
            {
                lock (clientInitializationLock)
                {
                    if (defaultHandler == null)
                    {
                        defaultHandler = (HttpClientHandler)this.GetHttpPipeline().First(h => h is HttpClientHandler);
                    }

                    if (defaultClient == null)
                    {
                        defaultClient = this.HttpClient;
                    }

                    if (autoRedirectOffHandler == null)
                    {
                        autoRedirectOffHandler = new HttpClientHandler
                        {
                            AllowAutoRedirect = false,
                            AutomaticDecompression = defaultHandler.AutomaticDecompression,
                            ClientCertificateOptions = defaultHandler.ClientCertificateOptions,
                            CookieContainer = defaultHandler.CookieContainer,
                            Credentials = defaultHandler.Credentials,
                            MaxAutomaticRedirections = defaultHandler.MaxAutomaticRedirections,
                            MaxRequestContentBufferSize = defaultHandler.MaxRequestContentBufferSize,
                            PreAuthenticate = defaultHandler.PreAuthenticate,
                            Proxy = defaultHandler.Proxy,
                            UseCookies = defaultHandler.UseCookies,
                            UseDefaultCredentials = defaultHandler.UseDefaultCredentials,
                            UseProxy = defaultHandler.UseProxy
                        };
                    }
                    
                    if (autoRedirectOffClient == null)
                    {
                        autoRedirectOffClient = new HttpClient(autoRedirectOffHandler)
                        {
                            BaseAddress = defaultClient.BaseAddress,
                            MaxResponseContentBufferSize = defaultClient.MaxResponseContentBufferSize,
                            Timeout = defaultClient.Timeout
                        };
                    }
                }
            }
        }
    }
}
