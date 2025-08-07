// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class InterceptorMockTransport : MockTransport
    {
        private string _firstRequestBody;

        public InterceptorMockTransport(params MockResponse[] responses) : base(responses)
        {
        }

        public string FirstRequestBody => _firstRequestBody;

        public override void Process(HttpMessage message)
        {
            if (_firstRequestBody == null)
            {
                using var stream = new MemoryStream();

                message.Request.Content.WriteTo(stream, CancellationToken.None);
                _firstRequestBody = Encoding.UTF8.GetString(stream.ToArray());
            }

            base.Process(message);
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            if (_firstRequestBody == null)
            {
                using var stream = new MemoryStream();

                await message.Request.Content.WriteToAsync(stream, CancellationToken.None);
                _firstRequestBody = Encoding.UTF8.GetString(stream.ToArray());
            }

            await base.ProcessAsync(message);
        }
    }
}
