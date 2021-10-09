// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Newtonsoft.Json.Linq;
using Xunit;

namespace SignalRServiceExtension.Tests
{
    public class SignalROutputConverterTests
    {
        [Fact]
        public void OutputConverter_SignalRMessage_TypeReturnsValid()
        {
            var converter = new SignalROutputConverter();

            var input = new SignalRMessage()
            {
                Target = "newMessage",
                Arguments = new object[] { "arg1", "arg2" }
            };

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRMessage), converted.GetType());
        }

        [Fact]
        public void OutputConverter_SignalRMessage_JObjectReturnsValid()
        {
            var converter = new SignalROutputConverter();

            var input = JObject.Parse(@"{
              'userId': 'user1',
              'target': 'newMessage',
              'arguments': [
                {
                  'arg1': 'arg1',
                  'agr2': 'arg2'
                }
              ]
            }");

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRMessage), converted.GetType());
        }

        [Fact]
        public void OutputConverter_SignalRGroupAction_TypeReturnsValid()
        {
            var converter = new SignalROutputConverter();

            var input = new SignalRGroupAction()
            {
                UserId = "user1",
                GroupName = "group1",
                Action = GroupAction.Add
            };

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRGroupAction), converted.GetType());
        }

        [Fact]
        public void OutputConverter_SignalRGroupAction_JObjectReturnsValid()
        {
            var converter = new SignalROutputConverter();

            var input = JObject.Parse(@"{
              'userId': 'user1',
              'groupName': 'group1',
              'action': 'add'
            }");

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRGroupAction), converted.GetType());
        }

        [Fact]
        public void OutputConverter_SignalRGroupAction_EnumNotValid()
        {
            var converter = new SignalROutputConverter();

            var input = JObject.Parse(@"{
              'userId': 'user1',
              'groupName': 'group1',
              'action': 'delete'
            }");

            Assert.Throws<ArgumentException>(() => converter.ConvertToSignalROutput(input));
        }

        [Fact]
        public void OutputConverter_JObjectNotValid()
        {
            var converter = new SignalROutputConverter();

            var input = JObject.Parse(@"{
              'userId': 'user1',
              'arguments': [
                {
                  'arg1': 'arg1',
                  'agr2': 'arg2'
                }
              ]
            }");

            Assert.Throws<ArgumentException>(() => converter.ConvertToSignalROutput(input));
        }
    }
}