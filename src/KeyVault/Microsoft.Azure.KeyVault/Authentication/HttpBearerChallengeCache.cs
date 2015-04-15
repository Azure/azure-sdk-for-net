//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.KeyVault
{
    public sealed class HttpBearerChallengeCache
    {
        private static HttpBearerChallengeCache _instance = new HttpBearerChallengeCache();

        public static HttpBearerChallengeCache GetInstance()
        {
            return _instance;
        }

        private Dictionary<string, HttpBearerChallenge> _cache = null;
        private object _cacheLock = null;

        private HttpBearerChallengeCache()
        {
            _cache = new Dictionary<string, HttpBearerChallenge>();
            _cacheLock = new object();
        }

#if WINDOWS_PHONE

        public HttpBearerChallenge this[Uri url]
        {
            get
            {
                if ( url == null )
                    throw new ArgumentNullException( "url" );

                HttpBearerChallenge value = null;

                lock ( _cacheLock )
                {
                    _cache.TryGetValue( url.FullAuthority(), out value );
                }

                return value;
            }
            set
            {
                if ( url == null )
                    throw new ArgumentNullException( "url" );

                if ( value != null && string.Compare( url.FullAuthority(), value.SourceAuthority, StringComparison.OrdinalIgnoreCase ) != 0 )
                    throw new ArgumentException( "Source URL and Challenge URL do not match" );

                lock ( _cacheLock )
                {
                    if ( value == null )
                        _cache.Remove( url.FullAuthority() );
                    else
                        _cache[url.FullAuthority()] = value;
                }
            }
        }

#else

        public HttpBearerChallenge GetChallengeForURL(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            HttpBearerChallenge value = null;

            lock (_cacheLock)
            {
                _cache.TryGetValue(url.FullAuthority(), out value);
            }

            return value;
        }

        public void RemoveChallengeForURL(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            lock (_cacheLock)
            {
                _cache.Remove(url.FullAuthority());
            }
        }

        public void SetChallengeForURL(Uri url, HttpBearerChallenge value)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (value == null)
                throw new ArgumentNullException("value");

            if (string.Compare(url.FullAuthority(), value.SourceAuthority, StringComparison.OrdinalIgnoreCase) != 0)
                throw new ArgumentException("Source URL and Challenge URL do not match");

            lock (_cacheLock)
            {
                _cache[url.FullAuthority()] = value;
            }
        }
#endif

        public void Clear()
        {
            lock (_cacheLock)
            {
                _cache.Clear();
            }
        }
    }
}
