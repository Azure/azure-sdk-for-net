// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class ResponseSamples
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ResponseTHelloWorld()
        {
            #region Snippet:ResponseTHelloWorld
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            // call a service method, which returns Response<T>
            Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

            // Response<T> has two main accessors.
            // Value property for accessing the deserialized result of the call
            KeyVaultSecret secret = response.Value;

            // .. and GetRawResponse method for accessing all the details of the HTTP response
            Response http = response.GetRawResponse();

            // for example, you can access HTTP status
            int status = http.Status;

            // or the headers
            foreach (HttpHeader header in http.Headers)
            {
                Console.WriteLine($"{header.Name} {header.Value}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ResponseTContent()
        {
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:ResponseTContent
            // call a service method, which returns Response<T>
            Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

            Response http = response.GetRawResponse();

            Stream contentStream = http.ContentStream;

            // Rewind the stream
            contentStream.Position = 0;

            using (StreamReader reader = new StreamReader(contentStream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ResponseHeaders()
        {
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:ResponseHeaders
            // call a service method, which returns Response<T>
            Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

            Response http = response.GetRawResponse();

            Console.WriteLine("ETag " + http.Headers.ETag);
            Console.WriteLine("Content-Length " + http.Headers.ContentLength);
            Console.WriteLine("Content-Type " + http.Headers.ContentType);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AsyncPageable()
        {
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:AsyncPageable
            // call a service method, which returns AsyncPageable<T>
            AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

            await foreach (SecretProperties secretProperties in allSecretProperties)
            {
                Console.WriteLine(secretProperties.Name);
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task AsyncPageableLoop()
        {
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:AsyncPageableLoop
            // call a service method, which returns AsyncPageable<T>
            AsyncPageable<SecretProperties> allSecretProperties = client.GetPropertiesOfSecretsAsync();

            IAsyncEnumerator<SecretProperties> enumerator = allSecretProperties.GetAsyncEnumerator();
            try
            {
                while (await enumerator.MoveNextAsync())
                {
                    SecretProperties secretProperties = enumerator.Current;
                    Console.WriteLine(secretProperties.Name);
                }
            }
            finally
            {
                await enumerator.DisposeAsync();
            }
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RequestFailedException()
        {
            // create a client
            var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

            #region Snippet:RequestFailedException
            try
            {
                KeyVaultSecret secret = client.GetSecret("NonexistentSecret");
            }
            // handle exception with status code 404
            catch (RequestFailedException e) when (e.Status == 404)
            {
                // handle not found error
                Console.WriteLine("ErrorCode " + e.ErrorCode);
            }
            #endregion
        }
    }
}
