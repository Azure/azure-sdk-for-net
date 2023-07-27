// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.SignalR;
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
                ],
                'endpoints': [
                    {
                        'endpointType': 'primary',
                        'name': 'endpoint1',
                        'endpoint': 'https://endpoint1',
                        'online': 'true'
                    },
                    {
                        'endpointType': 'primary',
                        'name': 'endpoint2',
                        'endpoint': 'https://endpoint2',
                        'online': 'true'
                    }
                ]
            }");

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRMessage), converted.GetType());
            var message = (SignalRMessage)converted;
            Assert.Equal("newMessage", message.Target);
            Assert.Equal("user1", message.UserId);
            Assert.Equal(2, message.Endpoints.Length);
            Assert.Equal(new ServiceEndpoint("Endpoint=https://endpoint1;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;", name: "endpoint1"), message.Endpoints[0]);
            Assert.Equal(new ServiceEndpoint("Endpoint=https://endpoint2;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789;Version=1.0;", name: "endpoint2"), message.Endpoints[1]);
        }

        [Fact]
        public void OutputConverter_SignalRMessage_ArgumentsNotRequired()
        {
            var converter = new SignalROutputConverter();

            var input = JObject.Parse(@"{
              'userId': 'user1',
              'target': 'newMessage',
            }");

            var converted = converter.ConvertToSignalROutput(input);
            Assert.Equal(typeof(SignalRMessage), converted.GetType());
            var message = (SignalRMessage)converted;
            Assert.Equal("newMessage", message.Target);
            Assert.Equal("user1", message.UserId);
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