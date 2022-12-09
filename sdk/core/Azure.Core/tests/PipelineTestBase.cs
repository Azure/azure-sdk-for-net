// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public class PipelineTestBase
    {
        private readonly bool _isAsync;

        public PipelineTestBase(bool isAsync)
        {
            _isAsync = isAsync;
        }

        protected async Task ProcessAsync(HttpMessage message, HttpPipelineTransport transport, CancellationToken cancellationToken = default)
        {
            message.CancellationToken = cancellationToken;
            if (_isAsync)
            {
                await transport.ProcessAsync(message);
            }
            else
            {
                transport.Process(message);
            }
        }

        protected async Task<Response> ExecuteRequest(Request request, HttpPipelineTransport transport, CancellationToken cancellationToken = default)
        {
            var message = new HttpMessage(request, ResponseClassifier.Shared);
            message.CancellationToken = cancellationToken;
            if (_isAsync)
            {
                await transport.ProcessAsync(message);
            }
            else
            {
                transport.Process(message);
            }
            return message.Response;
        }

        protected async Task<Response> ExecuteRequest(Request request, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            var message = new HttpMessage(request, ResponseClassifier.Shared);
            return await ExecuteRequest(message, pipeline, cancellationToken);
        }

        protected async Task<Response> ExecuteRequest(HttpMessage message, HttpPipeline pipeline, CancellationToken cancellationToken = default)
        {
            if (_isAsync)
            {
                await pipeline.SendAsync(message, cancellationToken);
            }
            else
            {
                pipeline.Send(message, cancellationToken);
            }
            return message.Response;
        }

        protected const string Pfx = @"
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
10dutJHzmsRcVFCBZvojiMDovF2Ge98xh3A2AGvN/nEQBayKPqSTL4JggC+K+TpizW82MDMqcp/n
fEtWJ5v0TDBlWqapKwi12hN2JIwmfWgowKfQar2FMBB1B5agHCTHXmVY8lRBqW2dSC+lUUPakHSr
IMEfjBTm8VD+GYvnlD/1wxmsooVsxDEOvxFsLgcXlY2/5SqsLSmSEmqIjGtwcOOn6brhXBBx8V/T
VsdRw00ounu+gApAFsCSGM4/O2IRRoNpLkZrSG8v9SFj5ieZqo53mb6USyhDlgL670P/oO7C+Ta0
icNR55z/h8Yu8NBPtQ6Ahsou8/wXDnbkxqjx8LwLlGsZuHmzPecBQicn0wgRa4c2z98ycyPoLcvF
o0R6D5prvHXY3ej3wtzytXiBAcJk3Yh1BQbVUBWftRqm2TcBa5TIkvdDoNP+UWDPHoxEP008gkJp
gX0aU+xI9doprq9xM/QFClPnnHyFN6lqHUFEOT8fNAKS3bQZtZPn7Iqn0rtmtWv06wCNfdlh7MGg
fIcx1Eks2bA4nMCnA7PJaG5PDaCQsxW4yiyQhC6cNz81ZpuSqmzBdToDjwTIaOiDVfAAPhzO8284
LPp2FuLEUgVyRGJ0hCgHDIqEMp7C7sgK2uWcUUGBiHXusFuA6C3WDqLsjriCtvWkIcL4v4ByKxqh
16nPBt09mhRXXzO9gKtVJ0cvTfLyKgyIHTjQnLJLuHpKiJ/9SqrWHOv6CwTUk2OV51VedYe3emr7
Fa9dt6EPvzLTbLdB/CnEOPzh7aInR/iaiWMSNxOE7AJ8hACU8/C3QEDsjnUK6LoTzC71jWAdCPcZ
1uze0fhHYwZ67rWneQOShhHEfX2Vxlm1R8L4sbPppFHrIygR9KCPjUUj8OTNvwQUumdqE0C8iNyQ
T4E0NzGB3zATBgkqhkiG9w0BCRUxBgQEAQAAADBbBgkqhkiG9w0BCRQxTh5MAHsARQBDADkAMwBC
ADcANQA1AC0AQwA5ADYAMwAtADQANgBBADAALQA5AEIARQBDAC0ANAAzADQANgBDADkARQA4AEYA
MwBBADkAfTBrBgkrBgEEAYI3EQExXh5cAE0AaQBjAHIAbwBzAG8AZgB0ACAARQBuAGgAYQBuAGMA
ZQBkACAAQwByAHkAcAB0AG8AZwByAGEAcABoAGkAYwAgAFAAcgBvAHYAaQBkAGUAcgAgAHYAMQAu
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
AAAAAAAA";
    }
}
