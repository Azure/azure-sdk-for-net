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
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.MediaServices.Client;

namespace Microsoft.WindowsAzure.MediaServices.Client.BulkIngest
{
    internal class BulkIngestContentKeyCollection : BaseContentKeyCollection
    {
        private readonly List<IContentKey> _contentKeyTracking;
        private readonly string[] _protectionKeyIds;

        internal BulkIngestContentKeyCollection(string[] protectionKeyIds, List<IContentKey> contentKeyTracking)
        {
            _contentKeyTracking = contentKeyTracking;
            _protectionKeyIds = protectionKeyIds;
        }

        public override IContentKey Create(Guid keyId, byte[] contentKey, string name)
        {
            if (keyId == Guid.Empty)
            {
                throw new ArgumentException(StringTable.ErrorCreateKey_EmptyGuidNotAllowed);
            }

            if (contentKey == null)
            {
                throw new ArgumentNullException("contentKey");
            }

            if (contentKey.Length != EncryptionUtils.KeySizeInBytesForAes128)
            {
                throw new ArgumentException(StringTable.ErrorCreateKey_KeyMustBe128Bits);
            }

            int protectionKeyIndex = Convert.ToInt32(ContentKeyType.CommonEncryption, CultureInfo.InvariantCulture);
            if ((_protectionKeyIds == null) || string.IsNullOrEmpty(_protectionKeyIds[protectionKeyIndex]))
            {
                throw new ArgumentException("Unknown ProtectionKeyId for ContentKeyType.CommonEncryption");
            }
            X509Certificate2 cert = BaseContentKeyCollection.GetCertificateForProtectionKeyId(null, _protectionKeyIds[protectionKeyIndex]);

            ContentKeyData contentKeyData = CreateCommonContentKey(keyId, contentKey, name, cert);

            return contentKeyData;
        }

        public override void Delete(IContentKey contentKey)
        {
            _contentKeyTracking.Remove(contentKey);
        }

        protected override IQueryable<IContentKey> Queryable
        {
            get { return _contentKeyTracking.AsQueryable(); }
        }
    }
}
