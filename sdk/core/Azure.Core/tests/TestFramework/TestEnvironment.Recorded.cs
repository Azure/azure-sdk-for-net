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

        public void SetRecording(TestRecording recording, bool playback)
        {
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

        public TokenCredential Credential => _playback ? (TokenCredential)new TestCredential() : new ClientSecretCredential(
            GetVariable("TENANT_ID"),
            GetVariable("CLIENT_ID"),
            GetVariable("CLIENT_SECRET")
        );

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