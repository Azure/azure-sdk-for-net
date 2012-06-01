// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    internal partial class ContentKeyData : IContentKey, ICloudMediaContextInit
    {
        
        private CloudMediaContext _cloudMediaContext;

        static private ContentKeyType GetExposedContentKeyType(int contentKeyType)
        {
            return (ContentKeyType)contentKeyType;
        }
        static private ProtectionKeyType GetExposedProtectionKeyType(int protectionKeyType)
        {
            return (ProtectionKeyType)protectionKeyType;        
        }

        public void InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        public byte[] GetClearKeyValue()
        {
            byte[] returnValue = null;
            if (_cloudMediaContext != null)
            {
                Uri uriRebindContentKey = new Uri(string.Format(CultureInfo.InvariantCulture, "/RebindContentKey?id='{0}'&x509Certificate=''", this.Id), UriKind.Relative);
                IEnumerable<string> results = _cloudMediaContext.DataContext.Execute<string>(uriRebindContentKey);
                string reboundContentKey = results.Single();

                returnValue = Convert.FromBase64String(reboundContentKey);
            }

            return returnValue;
        }

        public byte[] GetEncryptedKeyValue(X509Certificate2 certToEncryptTo)
        {
            byte[] returnValue = null;
            if (certToEncryptTo == null)
            {
                throw new ArgumentNullException("certToEncryptTo");
            }

            if (_cloudMediaContext != null)
            {
                string certToSend = Convert.ToBase64String(certToEncryptTo.Export(X509ContentType.Cert));
                certToSend = HttpUtility.UrlEncode(certToSend);

                Uri uriRebindContentKey = new Uri(string.Format(CultureInfo.InvariantCulture, "/RebindContentKey?id='{0}'&x509Certificate='{1}'", this.Id, certToSend), UriKind.Relative);
                IEnumerable<string> results = _cloudMediaContext.DataContext.Execute<string>(uriRebindContentKey);
                string reboundContentKey = results.Single();

                returnValue = Convert.FromBase64String(reboundContentKey);
            }

            return returnValue;
        }
    }
}
