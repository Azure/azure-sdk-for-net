// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Core.Testing
{
    public partial class TestEnvironment
    {
        private TestRecording _recording;
        private bool _playback;
        private TokenCredential _credential;

        public void SetRecording(TestRecording recording, bool playback)
        {
            _credential = null;
            _recording = recording;
            _playback = playback;
        }

        partial void GetRecordedValue(string name, ref string value, ref bool isPlayback)
        {
            if (_recording == null)
            {
                return;
            }

            value =  _recording.GetVariable(name, null);
            isPlayback = _playback;
        }

        partial void SetRecordedValue(string name, string value)
        {
            _recording?.SetVariable(name, value);
        }

        public TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }

                if (_playback)
                {
                    _credential = new TestCredential();
                }
                else
                {
                    _credential = new ClientSecretCredential(
                        GetVariable("TENANT_ID"),
                        GetVariable("CLIENT_ID"),
                        GetVariable("CLIENT_SECRET")
                    );
                }

                return _credential;
            }
        }

        private class TestCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}