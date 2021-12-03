// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

#if FullNetFx || NETCOREAPP2_0_OR_GREATER
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.Unit.Tests
{
    public class AzureServiceTokenProviderExceptionTests
    {
        [Fact]
        public void SerializableTest()
        {
            var exception = new AzureServiceTokenProviderException("connectionString", "resource", "authority", "message");

            // serialize
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, exception);

            // deserialize
            stream.Seek(0, SeekOrigin.Begin);
            var exceptionDeserialized = (AzureServiceTokenProviderException)formatter.Deserialize(stream);

            // simple comparison
            Assert.Equal(exception.Message, exceptionDeserialized.Message);
        }
    }
}
#endif
