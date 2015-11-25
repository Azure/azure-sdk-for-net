// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Xunit;

    public sealed class ValueTypePreservingContractResolverTests
    {
        private ValueTypePreservingContractResolver _resolver;

        public ValueTypePreservingContractResolverTests()
        {
            this._resolver = new ValueTypePreservingContractResolver(new DefaultContractResolver());
        }

        [Fact]
        public void NullablePropertiesHaveNoDefaultValueHandlingSet()
        {
            JsonObjectContract contract = Resolve<ModelWithNullableInt>();
            
            Assert.Equal(2, contract.Properties.Count);
            Assert.True(contract.Properties.All(p => !p.DefaultValueHandling.HasValue));
        }

        [Fact]
        public void NonNullablePropertiesSetToDefaultValueInclude()
        {
            JsonObjectContract contract = Resolve<ModelWithInt>();

            Assert.Equal(2, contract.Properties.Count);
            
            JsonProperty key = contract.Properties.GetProperty("Key", StringComparison.Ordinal);
            JsonProperty intValue = contract.Properties.GetProperty("IntValue", StringComparison.Ordinal);

            Assert.False(key.DefaultValueHandling.HasValue);
            Assert.True(intValue.DefaultValueHandling.HasValue);
            Assert.Equal(DefaultValueHandling.Include, intValue.DefaultValueHandling.Value);
        }

        private JsonObjectContract Resolve<T>()
        {
            JsonContract contract = this._resolver.ResolveContract(typeof(T));
            return Assert.IsType<JsonObjectContract>(contract);
        }
    }
}
