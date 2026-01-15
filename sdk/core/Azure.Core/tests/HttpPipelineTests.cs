// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineTests
    {
        [Test]
        public async Task CanBuildPipelineAndSendMessage()
        {
            var mockTransport = new MockTransport(
                new MockResponse(500),
                new MockResponse(1));

            var pipeline = new HttpPipeline(mockTransport, new HttpPipelinePolicy[] {
                new RetryPolicy(5)
            }, responseClassifier: new CustomResponseClassifier());

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.That(response.Status, Is.EqualTo(1));
        }

        [Test]
        public async Task DoesntDisposeRequestInSendRequestAsync()
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions()
            {
                Transport = new MockTransport(new MockResponse(200))
            });

            using MockRequest request = (MockRequest)httpPipeline.CreateRequest();

            MockResponse response = (MockResponse)await httpPipeline.SendRequestAsync(request, default);

            Assert.That(request.IsDisposed, Is.False);
            Assert.That(response.IsDisposed, Is.False);
        }

        [Test]
        public async Task CanAddPolicy_PerCall()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };
            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.That(request.Headers.TryGetValues("PerCallHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(1));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
        }

        [Test]
        public async Task CanAddPolicy_PerRetry()
        {
            var retryResponse = new MockResponse(408); // Request Timeout
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "Value"), HttpPipelinePosition.PerRetry);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];
            Assert.That(request.Headers.TryGetValues("PerRetryHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(3));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(1), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(2), Is.EqualTo("Value"));
        }

        [Test]
        public async Task CanAddPolicy_BeforeTransport()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "Value"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.That(request.Headers.TryGetValues("BeforeTransportHeader", out var values), Is.True);
            Assert.That(values.Count(), Is.EqualTo(3));
            Assert.That(values.ElementAt(0), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(1), Is.EqualTo("Value"));
            Assert.That(values.ElementAt(2), Is.EqualTo("Value"));
        }

        [Test]
        public async Task CanAddRequestPolicies_AllPositions()
        {
            var retryResponse = new MockResponse(408); // Request Timeout

            // retry twice -- this will add the header three times.
            var mockTransport = new MockTransport(retryResponse, retryResponse, new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var pipeline = HttpPipelineBuilder.Build(options);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader1", "PerCall1"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader2", "PerCall2"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("PerRetryHeader", "PerRetry"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransportHeader", "BeforeTransport"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.That(request.Headers.TryGetValues("PerCallHeader1", out var perCall1Values), Is.True);
            Assert.That(perCall1Values.Count(), Is.EqualTo(1));
            Assert.That(perCall1Values.ElementAt(0), Is.EqualTo("PerCall1"));

            Assert.That(request.Headers.TryGetValues("PerCallHeader2", out var perCall2Values), Is.True);
            Assert.That(perCall2Values.Count(), Is.EqualTo(1));
            Assert.That(perCall2Values.ElementAt(0), Is.EqualTo("PerCall2"));

            Assert.That(request.Headers.TryGetValues("PerRetryHeader", out var perRetryValues), Is.True);
            Assert.That(perRetryValues.ElementAt(0), Is.EqualTo("PerRetry"));
            Assert.That(perRetryValues.ElementAt(1), Is.EqualTo("PerRetry"));
            Assert.That(perRetryValues.ElementAt(2), Is.EqualTo("PerRetry"));

            Assert.That(request.Headers.TryGetValues("BeforeTransportHeader", out var beforeTransportValues), Is.True);
            Assert.That(beforeTransportValues.ElementAt(0), Is.EqualTo("BeforeTransport"));
            Assert.That(beforeTransportValues.ElementAt(1), Is.EqualTo("BeforeTransport"));
            Assert.That(beforeTransportValues.ElementAt(2), Is.EqualTo("BeforeTransport"));
        }

        [Test]
        public async Task CanAddPolicies_ThreeWays()
        {
            var mockTransport = new MockTransport(new MockResponse(200));
            var options = new TestOptions()
            {
                Transport = mockTransport,
            };

            var perCallPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerCall", "Builder") };
            var perRetryPolicies = new HttpPipelinePolicy[] { new AddHeaderPolicy("PerRetry", "Builder") };

            options.AddPolicy(new AddHeaderPolicy("BeforeTransport", "ClientOptions"), HttpPipelinePosition.BeforeTransport);
            options.AddPolicy(new AddHeaderPolicy("PerRetry", "ClientOptions"), HttpPipelinePosition.PerRetry);
            options.AddPolicy(new AddHeaderPolicy("PerCall", "ClientOptions"), HttpPipelinePosition.PerCall);

            var pipeline = HttpPipelineBuilder.Build(options, perCallPolicies, perRetryPolicies, null);

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerRetry", "RequestContext"), HttpPipelinePosition.PerRetry);
            context.AddPolicy(new AddHeaderPolicy("PerCall", "RequestContext"), HttpPipelinePosition.PerCall);
            context.AddPolicy(new AddHeaderPolicy("BeforeTransport", "RequestContext"), HttpPipelinePosition.BeforeTransport);

            var message = pipeline.CreateMessage(context);
            await pipeline.SendAsync(message, message.CancellationToken);

            Request request = mockTransport.Requests[0];

            Assert.That(request.Headers.TryGetValues("PerCall", out var perCallValues), Is.True);
            Assert.That(perCallValues.Count(), Is.EqualTo(3));
            Assert.That(perCallValues.ElementAt(0), Is.EqualTo("Builder"));
            Assert.That(perCallValues.ElementAt(1), Is.EqualTo("ClientOptions"));
            Assert.That(perCallValues.ElementAt(2), Is.EqualTo("RequestContext"));

            Assert.That(request.Headers.TryGetValues("PerRetry", out var perRetryValues), Is.True);
            Assert.That(perRetryValues.Count(), Is.EqualTo(3));
            Assert.That(perRetryValues.ElementAt(0), Is.EqualTo("Builder"));
            Assert.That(perRetryValues.ElementAt(1), Is.EqualTo("ClientOptions"));
            Assert.That(perRetryValues.ElementAt(2), Is.EqualTo("RequestContext"));

            Assert.That(request.Headers.TryGetValues("BeforeTransport", out var beforeTransportValues), Is.True);
            Assert.That(beforeTransportValues.Count(), Is.EqualTo(2));
            Assert.That(beforeTransportValues.ElementAt(0), Is.EqualTo("ClientOptions"));
            Assert.That(beforeTransportValues.ElementAt(1), Is.EqualTo("RequestContext"));
        }

        [Test]
        public void ThrowsIfUsePipelineConstructor()
        {
            HttpPipeline pipeline = new HttpPipeline(new MockTransport());

            var context = new RequestContext();
            context.AddPolicy(new AddHeaderPolicy("PerCallHeader", "Value"), HttpPipelinePosition.PerCall);

            var message = pipeline.CreateMessage(context);
            Assert.CatchAsync<InvalidOperationException>(async () => await pipeline.SendAsync(message, context.CancellationToken));
        }

        [Test]
        public void CreateMessage_AllowsNullContext()
        {
            var pipeline = new HttpPipeline(new MockTransport());
            Assert.DoesNotThrow(() => pipeline.CreateMessage(null));
        }

        [Test]
        public async Task PipelineSetsResponseIsErrorTrue()
        {
            var mockTransport = new MockTransport(
                new MockResponse(500));

            var pipeline = new HttpPipeline(mockTransport);

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.That(response.IsError, Is.True);
        }

        [Test]
        public async Task PipelineSetsResponseIsErrorFalse()
        {
            var mockTransport = new MockTransport(
                new MockResponse(200));

            var pipeline = new HttpPipeline(mockTransport);

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.That(response.IsError, Is.False);
        }

        [Test]
        public async Task PipelineClassifierSetsResponseIsError()
        {
            var mockTransport = new MockTransport(
                new MockResponse(404));

            var pipeline = new HttpPipeline(mockTransport, responseClassifier: new CustomResponseClassifier());

            Request request = pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));
            Response response = await pipeline.SendRequestAsync(request, CancellationToken.None);

            Assert.That(response.IsError, Is.False);
        }

        [Test]
        public async Task RequestContextClassifierSetsResponseIsError()
        {
            var mockTransport = new MockTransport(
                new MockResponse(404));

            var pipeline = new HttpPipeline(mockTransport, default);

            var context = new RequestContext();
            context.AddClassifier(404, isError: false);

            HttpMessage message = pipeline.CreateMessage(context, ResponseClassifier200204304);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));

            await pipeline.SendAsync(message, CancellationToken.None);
            Response response = message.Response;

            Assert.That(response.IsError, Is.False);
        }

        [Test]
        [TestCase(100, true)]
        [TestCase(200, false)]
        [TestCase(201, true)]
        [TestCase(202, true)]
        [TestCase(204, false)]
        [TestCase(300, true)]
        [TestCase(304, false)]
        [TestCase(400, true)]
        [TestCase(404, true)]
        [TestCase(500, true)]
        [TestCase(504, true)]
        public async Task RequestContextDefault_IsErrorIsSet(int code, bool isError)
        {
            var mockTransport = new MockTransport(
                new MockResponse(code));

            var pipeline = new HttpPipeline(mockTransport, default);

            HttpMessage message = pipeline.CreateMessage(context: default, ResponseClassifier200204304);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            request.Uri.Reset(new Uri("https://contoso.a.io"));

            await pipeline.SendAsync(message, CancellationToken.None);
            Response response = message.Response;

            Assert.That(response.IsError, Is.EqualTo(isError));
        }

        [Test]
        public void TransportIsUpdatedWhenPolicyFiresTransportUpdatedEvent()
        {
            var policy = new TransportUpdatingPolicy();
            var options = new HttpPipelineTransportOptions();
            var certificate = GetTestCertificate();
            options.ClientCertificates.Add(certificate);

            var mockTransport = new MockTransport(
                new MockResponse(1));

            var _ = new HttpPipeline(mockTransport, [
                policy
            ], responseClassifier: new CustomResponseClassifier());

            Assert.That(mockTransport.TransportUpdates, Is.Empty);

            policy.UpdateTransport(options);

            Assert.That(options.ClientCertificates[0], Is.EqualTo(certificate));
        }

        #region Helpers
        public class AddHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            private string _headerName;
            private string _headerVaue;

            public AddHeaderPolicy(string headerName, string headerValue) : base()
            {
                _headerName = headerName;
                _headerVaue = headerValue;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add(_headerName, _headerVaue);
            }
        }

        private class TestOptions : ClientOptions
        {
        }

        private class CustomResponseClassifier : ResponseClassifier
        {
            public override bool IsRetriableResponse(HttpMessage message)
            {
                return message.Response.Status == 500;
            }

            public override bool IsRetriableException(Exception exception)
            {
                return false;
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                return IsRetriableResponse(message);
            }
        }

        // How classifiers will be generated in DPG.
        private static ResponseClassifier _responseClassifier200204304;
        private static ResponseClassifier ResponseClassifier200204304 => _responseClassifier200204304 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 204, 304 });

        public class TransportUpdatingPolicy : HttpPipelinePolicy, ISupportsTransportUpdate
        {
            public event Action<HttpPipelineTransportOptions> TransportOptionsChanged;

            public void UpdateTransport(HttpPipelineTransportOptions options)
            {
                TransportOptionsChanged?.Invoke(options);
            }

            public TransportUpdatingPolicy()
            {
            }

            public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessNext(message, pipeline);
            }
        }

        private X509Certificate2 GetTestCertificate()
        {
            byte[] cer = Convert.FromBase64String(Pfx);

#if NET9_0_OR_GREATER
            return X509CertificateLoader.LoadPkcs12(cer, null);
#else
            return new X509Certificate2(cer);
#endif
        }

        private const string Pfx = @"
MIIQzwIBAzCCEIUGCSqGSIb3DQEHAaCCEHYEghByMIIQbjCCBloGCSqGSIb3DQEHBqCCBkswggZHAgEAMIIGQAYJKoZIhvcNAQcBMF8GCSqGSIb3DQEFDTBSMDEGCSqGSIb3DQEFDDAkBBC7yCMtx6oDATpCaQVf5XC5AgIIADAMBggqhkiG9w0CCQUAMB0GCWCGSAFlAwQBKgQQa2eU6J3q3Uso5/ADdc5jpICCBdDtAYxjkhyCrCI7iKVUDTsu9qY/ZBkAZtndloT18lYUjOiV/eP5Mg6x+bxzWaN6z32ZZ/GIlqihemVuhwSBsp28tA4dkeK7md2xbCrr1WaAdX0VgUG0/3CpYmI8023o37rD3mq8I2vpB8svnkrFeu1vbDyGbTNmdym3UUIvyawLAXxzEjTKjRlYKyD+TwEzqWqYS1xEFDtG9g7OVdsbc7nqJiH84I2JqpYHwGaWKrli0R0YIOhbiMXo8MNPLP5DjH0JzJ0OkL059qQSYACWLrfNggSu7VMo/AXIorx3gWSfeUolBW1HMU4UwoOHy4VuNBv9yF108plAYAlrfYbeY+ZuBP5IWjvQh2svms7M7Eutol+O4moibN1HeKVPTob3qHX+GMW8rhr55Ii6t2JzQbR447ZCw+5FfLLN9QjWGbVuz2e1Kq/zgMvKCnMjjNJuJPWgTRTo9h02JTt/af2YwB/005p4O4q3Se3HfB1hTQv2dBWvAnUbaqMt0aplQjklWgbczhZMgj5X/t93+/jACbZSEhVgnK8iaTHGndSJnIwVSAG6eMvF+wdFNZjGghaglzfP+72PBXHndsSWYdGwzQZtFlW3b9eA9UxmMbV7VipXTC2V8/jmeAt5dY8X/mG8wZFsTaxAs2Z5cTJFP3KvoSAYegXUOHLWzA5CDug9mARzkLACFLsOo4STINsUI1BDItBJ3dbDuZ/5++zIwcr4ediG2GKeyFaw1gAOgWXi5/Qc3p9MHCB5EGTPaXPjq6qMZJJAyF2K7zlOxRjYTXLdWeK3fe6N6EvQfORGtDlEmrd0gLgOoAMfoZFNtHgpwAe7IChx6Cz+DUzIzi7dZT0OOhXK2eB92FZ4EkJjwH/Njv+AZwypqC1txrdRzI+gEnIeGEkh3OAfWu/WUMeNLUrJk87tIkGgHqPqp6/86/nZe362O8DmbX4BTiYUz2nDiIxfq95uvzLKz20cj3kp6nCUq04utvpYATN+ZogIQjHmxaZqKp7MvCx3L91id+P7gxDZxd22kEjpJnKjgDoZU6eO8MvE/Wb5cr7fGurRRhpzmZ23/JGJ2caMEaLSyV0yxiEB5jS+ikvMAvupcUHnirDGA+76GV6GuL2/2fS/ottGqtp3O2jL69onCGx3UMA5jjIRPVZseCSmERdjrSnetJTGc61VTw39xbvSewsOuYJlL+ruddL8UJzRmu5/NcIw9xq/4waX6g2QJvnfO9xZHJdAat5XG4ie5ePmYNtok+xONV8ZhWKAv3UmuLmnzcHuqN0mxBniiLsFJBSfay4/UbPhL+vXeE4Al/gyk70I07w2fIVhxG7h5MTo+juWv8OqmbnQ1p96Aq6QY5DcV9Tg9FW2coivzkX7aA5nHUGGt/GowgEDePdJjBgaXOq1XXDZpgJotYWyFqKYHvI+hvFaHrqSIlbyariG+LTInjhmJa1/WcJGoEB1ngFhX9up0tqBQdxaocxB/2jprNww9ioqbIwE9vTEBfM/WFfprHjx+beVEKJW3KCWDkyQMItD7V/ps8KvrAhm7cR9yOXfl3KOya1qCPo77TkFR3WrWFXtufCzYMW1ewj2MxNxMmkb8+/TA+FxW/NkOmlPFekfzsegjTyT4m2DJo0t3MrSJLsEsL4MOtO+8dRM7rP8HFMZmkpiiy1IYZ69n1jKl6De1Y6R5h1vhdGtMpgmwF9GGpFCeX7ErbF8duH8oiHwobtvv3GL0XBN73sFpYIaDFvsGmXGh/UZ1LKCznenteWg5UN+hgQ5jW8f/hKd92E2kyl30jXwOnJLbryN/BfP8db3+Opz55A17zxPMMKYKBHiSGp9ncbFJ/zg65bNiUXuJam/P5/6VjEii+gLqnzMLY4D94y/kEVvU/hoT1X7+tNYF42xxPcDOQs4ew5pe4caGpo9oW2yLdsXUhWWNBrxg+13/w6hXC2924YoeyeHCA6BEQSmlD3uLC7vBmHuea3eTCOwrP6MrVOm3HIwggoMBgkqhkiG9w0BBwGgggn9BIIJ+TCCCfUwggnxBgsqhkiG9w0BDAoBAqCCCbkwggm1MF8GCSqGSIb3DQEFDTBSMDEGCSqGSIb3DQEFDDAkBBC7i0BgvYExXtovt+QPCERsAgIIADAMBggqhkiG9w0CCQUAMB0GCWCGSAFlAwQBKgQQ0lWlUzm/ZafkFQD8G75nGQSCCVCfn5F3SRe4xqHuY93dD4dzbmRUpToVa6MC6jbJwP4jcDEth1BCZnIcdDxNOrwlXBeoFudsDOjfa2mVaSi96hxJTxLCqCIauXXKyg2JPYiHQaMvT3BGDpFOe6b9MgN0nVwi8LnvN3GWTCR1bYDZnitIxkmwIfSayPSYuG0qdn9lVRrEA8qevMyPZvxxU6OZadhFTurd9+GwaqF29t9k90m15Sj0ZgR+Ox956k9xdaJ/WakbF/5YE806qfibU7mn1+5EGY2rTp8tEvE30eaUrM1sIg2L6pOx9oh4Rdm2tTN/DkamBaCPWLhPOJ8LiIRtWAOTvJ3slG+A12Xnot698R0BtixkQCE6UiCsDMU6uTb7wAUn5m/VPYDQo2y+sftOiBSve9s+1Sui+M72HXJMFVXXZAivUGapUOr19sNS06IP44OzeHNwXQL2cUfFqU0JKK6sqEFlTdQYkwu7Fr7s5XxiGIykj7C6Z592POL4hj4gFQC4Tn5vatYWaRr6oNmTnP8a1AFl6LhQBCgbiiYw4fczsG4sqi3Z+6B9024L9kwIUeQCnXyZRb8AFukTgR1o9brBR0mcpANb2w0mESysTti7cwvC+PCrfY6SyBsJLtFX5SkQLK9SBhMczlvwhfVOSsUiN4K+BEAZjCnjoXuV5xjoUHF5//q8fQkLxQsAIvwgVydkekhXoEiGJ7BQ8NbW5R86ibvgXRW5V+cAEsQZcMXMGEBvWAVGHAOCu5zpDkTFSyED9SjmWbMNW9PNrJZFFTLI4HNtwwdhOaABEvcYlP9vhZj79rfbdPu+cDoDzo+KtzpSzq10uNupUo6ODojmuq3onCiB2bFl/e29MhD9+8E0yx+Tkd4RaJSXnQqDEhpJiuBT12lAWKAjyDIGs0Cr9uD5AQR4vpIJf1/MROIr2vmSS5b5kLkkA8T9L0VJQ9FaL2ZTG+D+e0JnhO7U8JnngRktZsu3XQkbIwYP0dsRpSOcuvmAO92mmPtBQgrrPAKoMhvwl+CX1EBTNybQ5BCXF0dgO/1htyg7TtdnokBx+gCexsMASs4dcOVCUtNK9D2s8OvZGIAGvGB4mQc61gp5qpzGwsPGaImvqhdT0dMJB4V1XIxwM4wED9kfRW01Unhk8XAktL9wwM+pRHCy7+RnFVNH8+b6/6Q+ryYm0wyLmjL3nEPTggkrOHdh+NkNfgQRj9l9PWNo+BJ5uRpPNmE5z0IQkmhJVcLCdgsmlSZZmmBA3VnVUim03pImV6t978plH/HfH58pK762TN09tdb1fCUCePgg8HFqR9zWtPHrmHhax5hEFYxlYt4RBUyxcDYXTYUnbOBb6hPrsmJcQs+IMP2vhjsKdZz267srqegB5GVdBkSyn35NE2w7iDzuyFvb8UsYjqBg9WCVy7pmLJ5mv/3SerrumRda0ILiL2hwrQIrKgYEZJY8giiCvWjru2NJW3q5PbIwyM27DTCkQXPp6NN09FBXwLhi+qXeNMmzQuREE9QnTQcTGbIBfiRc7Avn0y4jz4etLqTTqJLPLX9lU0JwN1LJ5grjNdNWFNHc3NpxfOEesmIkyPkmVkSgYL4ldEicDM7ur05Fr8kH0Lzpnj0ZmeRdX4Ggrx4OKuyKJ5EWTVQSrroJqIrLxWvzq70ANI6uO3nk8hdTEkL6F9pX79mjyJuSj5cNRGtgLvliZTm4wSk/qNBEUySj1fhtWHcLb8ggurnVcmBCvM8IZCVVjW+hi20mPt3jp+Es7pyKq6DI5h/gn9gIXZAN1RWVtEakK6w4p1DqRFM4twc4VY77hUKRb03P0XPsewON1tCGIwScZ2+fo/1f5kvhlXf2Mw03O5kAIzCd11QOnLs/3NOWoV7xEQP8+pp8HkwAiiy2KUS1JDVH2Wo1pfw9wUDkdu5Si+7XzALy6aIFlHiYGs5gEWZZiSVRbetSeCeD2PJlRuaosfozxJa2eNgdERC9eOoAEKbn0iwFGcNswMsaZoSLBvHMByxoYYF++uSRJIR60hOAPxT4Qi4UVU/wkDztEM1tLve0ByIGLQAkyv7xfHzPuRhWT0MZCsLMoJW9iCZwa2DSB9Jkkotf1jHO84UCt0OBDLYMNht6+FIHw/BEmRTn22kdKpskrD+VCdrxYL5UNEt5d57vz3M++hcFE4dNEYzv0TfYl7GNRRvw6qLz3j1JIgCXoxhQ8a/DxHe91hJk3NcM8inQ1v6a0f+BxL/xFx4wNvdoDZsp6u++MRsDj+dwG51x/ysFwtDIKuhOzG0chJcLWxmqglfjpL6A6OyBu0o9O/ZmdUgfEBMkxCHuVR7Xk2ASmMoBgAVHKsd2UuPhVIX6T4ONLfhFICSTTnHLiGkeoO4BHdaGRd09caNQEc0GBIUfwEP7L7hifqZOTAK9gmJZcfCzu2qiqY7kOferQpw76GwfVW/kOV0FmXD4IQR6myXt/AkqsJgim6dswWI66iKQ2ec30ApVv855D+0i40RfsUGSbGvcwxxdG78Tc4hafBwA3F9fKYOrrDGRCMrnktGG1caJRpSWmNEv4+q15ceSLF05NEO9bqtc52g1t5mtdlDDrMu91kmvCs4X9nLao3y+klwZwIK4ttQRNWD8bWN7EUns/iM8P7E3IrXZgBIAdxCalOD3PnU65He8CeMCh/ZnmPIz5eBwRFRKj5N2S4U8XCBzme3oG5jBH74r5hCsOOZt93ulejV8hJosLW5Rq9fHZfPi6IvcKSQbHg+muNOlSRb9aSihDSy9FitPoOdX4mLXmPKC0OlcXOMVcG6RvoEtOs6yKnD+uPdOmnZkmEWnxQ/EmgDreRIieFgLfNkO52aIaWgg2nTU530O9uTWBSk3QSCKF4n/NWCWmjZiWg5O3CmUcxoKI4eRmZ58oYvAl+wdI4k+89rV1jUmmts8O3eftAHWeUiXWils2MdzWbFk0iwdsutavh8prEbGZfAM6nnRhR0L4ppN5dvSRWtjI5eyxfuODnGUskGcSAXD0zdqfJTMqg1ey/qF51vYDKwyk9uq8jSESdgA9Rc1oCBMqRfFgDHmPnlfdmIMO2bp8VrZKWNTPBTzCIf00jUlUpNNtwnMb0dpZwk3rPHfgIdMLQ8SNxkts+VqTTEmIIb2dmC1353s5AMNydrtyNAXYHSSp9hxwP8oESZdQRlUjivFusGPpIS/spcEt6JBu7aiMmSfKTElMCMGCSqGSIb3DQEJFTEWBBQLglDeakGMXukKkw1Ak5ac4o4cLzBBMDEwDQYJYIZIAWUDBAIBBQAEIJUPNvPN11c4V/Bq+3kIUB9hj37CScdpGtoQMf3htjMqBAhX75eHkXy8wgICCAA=";
        #endregion

    }
}
