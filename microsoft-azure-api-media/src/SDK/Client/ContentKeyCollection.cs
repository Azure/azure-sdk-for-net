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
using System.Data.Services.Client;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Represents a collection of content keys.
    /// </summary>
    public class ContentKeyCollection : BaseContentKeyCollection
    {
        private readonly DataServiceContext _dataContext;
        internal const string ContentKeySet = "ContentKeys";

        internal ContentKeyCollection(DataServiceContext dataContext)
        {
            _dataContext = dataContext;

            if (dataContext != null)
            {
                ContentKeyQueryable = dataContext.CreateQuery<ContentKeyData>(ContentKeyCollection.ContentKeySet);
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Linq.IQueryable"/> interface to evaluate queries against 
        /// the collection of content keys.
        /// </summary>
        protected override IQueryable<IContentKey> Queryable
        {
            get { return ContentKeyQueryable; }
        }

        /// <summary>
        /// Creates a content key with the specified key identifier and value.
        /// </summary>
        /// <param name="keyId">The key identifier.</param>
        /// <param name="contentKey">The value of the content key.</param>
        /// <param name="name">A friendly name for the content key.</param>
        /// <returns>A <see cref="IContentKey"/> that can be associated with an <see cref="IAsset"/>.</returns>
        public override IContentKey Create(Guid keyId, byte[] contentKey, string name)
        {
            IContentKey contentKeyToReturn = null;

            if (keyId == Guid.Empty)
            {
                throw new ArgumentException(StringTable.ErrorCreateKey_EmptyGuidNotAllowed, "keyId");
            }

            if (contentKey == null)
            {
                throw new ArgumentNullException("contentKey");
            }

            if (contentKey.Length != EncryptionUtils.KeySizeInBytesForAes128)
            {
                throw new ArgumentException(StringTable.ErrorCommonEncryptionKeySize, "contentKey");
            }

            if (_dataContext != null)
            {
                X509Certificate2 certToUse = BaseContentKeyCollection.GetCertificateToEncryptContentKey(_dataContext, ContentKeyType.CommonEncryption);
                ContentKeyData contentKeyData = CreateCommonContentKey(keyId, contentKey, name, certToUse);

                _dataContext.AddObject(ContentKeyCollection.ContentKeySet, contentKeyData);

                _dataContext.SaveChanges();
                contentKeyToReturn = ContentKeyQueryable.Where(c => c.Id == contentKeyData.Id).First();
            }

            return contentKeyToReturn;
        }

        /// <summary>
        /// Deletes a content key from the content key collection.
        /// </summary>
        /// <param name="contentKey">The content key to be deleted.</param>
        public override void Delete(IContentKey contentKey)
        {
            MarkContentKeyForDeletion(contentKey);
            _dataContext.SaveChanges();
        }

        private void MarkContentKeyForDeletion(IContentKey contentKey)
        {
            if (contentKey == null)
            {
                throw new ArgumentNullException("contentKey");
            }
            VerifyContentKey(contentKey);

            bool contentKeyAlreadyAttached = false;
            foreach (EntityDescriptor entityDesc in _dataContext.Entities)
            {
                IContentKey key = entityDesc.Entity as IContentKey;
                if (key != null)
                {
                    if (key.Id == contentKey.Id)
                    {
                        contentKey = key;
                        contentKeyAlreadyAttached = true;
                        break;
                    }
                }
            }

            if (!contentKeyAlreadyAttached)
            {
                _dataContext.AttachTo(ContentKeySet, contentKey);
            }

            _dataContext.DeleteObject(contentKey);
        }

    }
}
