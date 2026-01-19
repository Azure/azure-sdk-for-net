// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Shared;

namespace Azure.Storage.Test.Shared
{
    internal class ObserveStructuredMessagePolicy : HttpPipelineSynchronousPolicy
    {
        private readonly HashSet<CheckMessageScope> _requestScopes = new();

        private readonly HashSet<CheckMessageScope> _responseScopes = new();

        public ObserveStructuredMessagePolicy()
        {
        }

        public override void OnSendingRequest(HttpMessage message)
        {
            if (_requestScopes.Count > 0)
            {
                byte[] encodedContent;
                byte[] underlyingContent;
                StructuredMessageDecodingStream.RawDecodedData decodedData;
                using (MemoryStream ms = new())
                {
                    message.Request.Content.WriteTo(ms, default);
                    encodedContent = ms.ToArray();
                    using (MemoryStream ms2 = new())
                    {
                        (Stream s, decodedData) = StructuredMessageDecodingStream.WrapStream(new MemoryStream(encodedContent));
                        s.CopyTo(ms2);
                        underlyingContent = ms2.ToArray();
                    }
                }
            }
        }

        public override void OnReceivedResponse(HttpMessage message)
        {
        }

        public IDisposable CheckRequestScope() => CheckMessageScope.CheckRequestScope(this);

        public IDisposable CheckResponseScope() => CheckMessageScope.CheckResponseScope(this);

        private class CheckMessageScope : IDisposable
        {
            private bool _isRequestScope;
            private ObserveStructuredMessagePolicy _policy;

            public static CheckMessageScope CheckRequestScope(ObserveStructuredMessagePolicy policy)
            {
                CheckMessageScope result = new()
                {
                    _isRequestScope = true,
                    _policy = policy
                };
                result._policy._requestScopes.Add(result);
                return result;
            }

            public static CheckMessageScope CheckResponseScope(ObserveStructuredMessagePolicy policy)
            {
                CheckMessageScope result = new()
                {
                    _isRequestScope = false,
                    _policy = policy
                };
                result._policy._responseScopes.Add(result);
                return result;
            }

            public void Dispose()
            {
                (_isRequestScope ? _policy._requestScopes : _policy._responseScopes).Remove(this);
            }
        }
    }
}
