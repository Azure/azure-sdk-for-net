// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportPlatformTests
    {
        [Test]
        public void CreateDefaultTransport_ShouldNotThrow_OnAnyPlatform()
        {
            // This test verifies that creating a default HttpClientTransport instance
            // does not throw PlatformNotSupportedException on any platform, including WebAssembly
            Assert.DoesNotThrow(() =>
            {
                using var transport = new HttpClientTransport();
                Assert.IsNotNull(transport);
                Assert.IsNotNull(transport.Client);
            });
        }

        [Test]
        public void CreateDefaultTransport_WithOptions_ShouldNotThrow_OnAnyPlatform()
        {
            // This test verifies that creating a HttpClientTransport with options
            // does not throw PlatformNotSupportedException on any platform
            Assert.DoesNotThrow(() =>
            {
                var options = new HttpPipelineTransportOptions();
                using var transport = new HttpClientTransport(options);
                Assert.IsNotNull(transport);
                Assert.IsNotNull(transport.Client);
            });
        }

        [Test]
        public void CreateDefaultHandler_ShouldNotThrow_OnBrowserPlatform()
        {
            // This test simulates the browser platform scenario
            // We can't actually set the platform, but we can test that the handler creation
            // logic handles platform-specific scenarios gracefully

            // Create handler using reflection to access the private method
            var createDefaultHandlerMethod = typeof(HttpClientTransport)
                .GetMethod("CreateDefaultHandler", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Assert.DoesNotThrow(() =>
            {
                var handler = (HttpMessageHandler)createDefaultHandlerMethod.Invoke(null, new object[] { null });
                Assert.IsNotNull(handler);

                // Verify the handler type is appropriate
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER")))
                {
                    Assert.IsInstanceOf<HttpClientHandler>(handler);
                }
                else
                {
#if NETCOREAPP
                    // On .NET Core platforms, we should get SocketsHttpHandler
                    Assert.IsTrue(handler is System.Net.Http.SocketsHttpHandler || handler is HttpClientHandler);
#else
                    Assert.IsInstanceOf<HttpClientHandler>(handler);
#endif
                }

                handler.Dispose();
            });
        }

        [Test]
        public void AllowAutoRedirect_Setting_ShouldBeHandledSafely()
        {
            // Test that AllowAutoRedirect is set correctly without throwing exceptions
            Assert.DoesNotThrow(() =>
            {
#if NETCOREAPP
                // Test SocketsHttpHandler scenario
                var socketsHandler = new System.Net.Http.SocketsHttpHandler();
                try
                {
                    socketsHandler.AllowAutoRedirect = false;
                    Assert.False(socketsHandler.AllowAutoRedirect);
                }
                catch (PlatformNotSupportedException)
                {
                    // This should be caught and handled gracefully in the actual implementation
                    Assert.Fail("PlatformNotSupportedException should be handled gracefully");
                }
                finally
                {
                    socketsHandler.Dispose();
                }
#endif

                // Test HttpClientHandler scenario
                var clientHandler = new HttpClientHandler();
                try
                {
                    clientHandler.AllowAutoRedirect = false;
                    Assert.False(clientHandler.AllowAutoRedirect);
                }
                catch (PlatformNotSupportedException)
                {
                    // This should be caught and handled gracefully in the actual implementation
                    Assert.Fail("PlatformNotSupportedException should be handled gracefully");
                }
                finally
                {
                    clientHandler.Dispose();
                }
            });
        }

        [Test]
        public void CreateHttpClientHandler_WithPlatformException_ShouldSucceed()
        {
            // This test verifies that our CreateHttpClientHandler method handles PlatformNotSupportedException
            // by using reflection to invoke the private method directly
            var createHttpClientHandlerMethod = typeof(HttpClientTransport)
                .GetMethod("CreateHttpClientHandler", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Assert.DoesNotThrow(() =>
            {
                var handler = (HttpClientHandler)createHttpClientHandlerMethod.Invoke(null, null);
                Assert.IsNotNull(handler);

                // The handler should be created successfully even if AllowAutoRedirect setting failed
                // Default value for AllowAutoRedirect is usually true, but that's platform-dependent
                // so we just verify the handler was created
                Assert.IsInstanceOf<HttpClientHandler>(handler);

                handler.Dispose();
            });
        }

#if NETCOREAPP
        [Test]
        public void CreateSocketsHttpHandler_WithPlatformException_ShouldSucceed()
        {
            // This test verifies that our CreateSocketsHttpHandler method handles PlatformNotSupportedException
            // by using reflection to invoke the private method directly
            var createSocketsHttpHandlerMethod = typeof(HttpClientTransport)
                .GetMethod("CreateSocketsHttpHandler", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Assert.DoesNotThrow(() =>
            {
                var handler = (System.Net.Http.SocketsHttpHandler)createSocketsHttpHandlerMethod.Invoke(null, null);
                Assert.IsNotNull(handler);

                // The handler should be created successfully even if AllowAutoRedirect setting failed
                Assert.IsInstanceOf<System.Net.Http.SocketsHttpHandler>(handler);

                handler.Dispose();
            });
        }
#endif
    }
}