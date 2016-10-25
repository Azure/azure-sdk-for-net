// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.ClientRuntime.Tests.Fakes;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests
{
    public class ValidationExceptionTests
    {
        [Fact]
        public void VerifyNotNull()
        {
            var validationException = new ValidationException(ValidationRules.CannotBeNull, "Id");

            Assert.Equal(ValidationRules.CannotBeNull, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' cannot be null.", validationException.ToString());
        }

        [Fact]
        public void VerifyMaximum()
        {
            var validationException = new ValidationException(ValidationRules.InclusiveMaximum, "Id", 20);

            Assert.Equal(ValidationRules.InclusiveMaximum, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' exceeds maximum value of '20'.", validationException.ToString());
        }

        [Fact]
        public void VerifyExclusiveMaximum()
        {
            var validationException = new ValidationException(ValidationRules.ExclusiveMaximum, "Id", 30);

            Assert.Equal(ValidationRules.ExclusiveMaximum, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' is equal or exceeds maximum value of '30'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMinimum()
        {
            var validationException = new ValidationException(ValidationRules.InclusiveMinimum, "Id", 3);

            Assert.Equal(ValidationRules.InclusiveMinimum, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' is less than minimum value of '3'.", validationException.ToString());
        }

        [Fact]
        public void VerifyExclusiveMinimum()
        {
            var validationException = new ValidationException(ValidationRules.ExclusiveMinimum, "Id", -1);

            Assert.Equal(ValidationRules.ExclusiveMinimum, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' is less than or equal minimum value of '-1'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMaxLenth()
        {
            var validationException = new ValidationException(ValidationRules.MaxLength, "Id", 100);

            Assert.Equal(ValidationRules.MaxLength, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' exceeds maximum length of '100'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMinLenth()
        {
            var validationException = new ValidationException(ValidationRules.MinLength, "Id", 12);

            Assert.Equal(ValidationRules.MinLength, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' is less than minimum length of '12'.", validationException.ToString());
        }
        
        [Fact]
        public void VerifyPattern()
        {
            var validationException = new ValidationException(ValidationRules.Pattern, "Id", "\\w+");

            Assert.Equal(ValidationRules.Pattern, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("\\w+", validationException.Details);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' does not match expected pattern '\\w+'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMaxItems()
        {
            var validationException = new ValidationException(ValidationRules.MaxItems, "Id", 2);

            Assert.Equal(ValidationRules.MaxItems, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' exceeds maximum item count of '2'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMinItems()
        {
            var validationException = new ValidationException(ValidationRules.MinItems, "Id", 1);

            Assert.Equal(ValidationRules.MinItems, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' contains less items than '1'.", validationException.ToString());
        }

        [Fact]
        public void VerifyUniqueItems()
        {
            var validationException = new ValidationException(ValidationRules.UniqueItems, "Id");

            Assert.Equal(ValidationRules.UniqueItems, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' collection contains duplicate items.", validationException.ToString());
        }

        [Fact]
        public void VerifyEnum()
        {
            var validationException = new ValidationException(ValidationRules.Enum, "Id", "red, green, blue");

            Assert.Equal(ValidationRules.Enum, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' cannot have value other than 'red, green, blue'.", validationException.ToString());
        }

        [Fact]
        public void VerifyMultipleOf()
        {
            var validationException = new ValidationException(ValidationRules.MultipleOf, "Id", 5);

            Assert.Equal(ValidationRules.MultipleOf, validationException.Rule);
            Assert.Equal("Id", validationException.Target);
            Assert.Equal(5, validationException.Details);
            Assert.Equal("Microsoft.Rest.ValidationException: 'Id' has to be multiple of '5'.", validationException.ToString());
        }
    }
}
