// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Core.Tests.ModelSerializationTests.Models
{
    [DeserializationProxy(typeof(ModelX))]
    public class ModelXDeserializationProxy
    {
    }
}
