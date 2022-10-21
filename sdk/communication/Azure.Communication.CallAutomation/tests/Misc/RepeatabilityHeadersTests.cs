// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Misc
{
    public class RepeatabilityHeadersTests
    {
        [Test]
        public void RepeatablityHeaders_IsInvalid_False()
        {
            // arrange
            var headers = new RepeatabilityHeaders(Guid.NewGuid(), DateTime.UtcNow);

            // act & assert
            Assert.IsFalse(headers.IsInvalidRepeatabilityHeaders());
        }

        [Test]
        public void RepeatablityHeaders_IsInvalid_RepeatabilityRequestIdIsDefaultValue()
        {
            // arrange
            var headers = new RepeatabilityHeaders(Guid.Empty, DateTimeOffset.UtcNow);

            // act & assert
            Assert.IsTrue(headers.IsInvalidRepeatabilityHeaders());
        }

        [Test]
        public void RepeatablityHeaders_IsInvalid_RepeatabilityFirstSentIsDefaultValueMin()
        {
            // arrange
            var headers = new RepeatabilityHeaders(Guid.NewGuid(), new DateTimeOffset());

            // act & assert
            Assert.IsTrue(headers.IsInvalidRepeatabilityHeaders());
        }

        [Test]
        public void RepeatablityHeaders_IsInvalid_RepeatabilityFirstSentIsDefaultValueMax()
        {
            // arrange
            var headers = new RepeatabilityHeaders(Guid.NewGuid(), DateTimeOffset.MaxValue);

            // act & assert
            Assert.IsTrue(headers.IsInvalidRepeatabilityHeaders());
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_AnswerCallOptions()
        {
            // arrange
            var options = new AnswerCallOptions("context", new Uri("https://contoso.com/callback"));

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_RedirectCallOptions()
        {
            // arrange
            var options = new RedirectCallOptions("context", new CommunicationUserIdentifier("user1"));

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_RejectCallOptions()
        {
            // arrange
            var options = new RejectCallOptions("context");
            options.CallRejectReason = CallRejectReason.Busy;

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_CreateCallOptions()
        {
            // arrange
            var options = new CreateCallOptions(new CallSource(new CommunicationUserIdentifier("8:acs:blahblahblah")), new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:acs:lalala") }, new Uri("https://contoso.com/callback"));

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_HangUpOptions()
        {
            // arrange
            var options = new HangUpOptions(true);

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_TransferCallOptions()
        {
            // arrange
            var options = new TransferToParticipantOptions(new CommunicationUserIdentifier("8:acs:blahblahblah"));

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_AddParticipantsOptions()
        {
            // arrange
            var options = new AddParticipantsOptions(new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:acs:blahblahblah") });

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotSetByDefault_RemoveParticipantsOptions()
        {
            // arrange
            var options = new RemoveParticipantsOptions(new CommunicationIdentifier[] { new CommunicationUserIdentifier("8:acs:blahblahblah") });

            // act & assert
            Assert.IsNull(options.RepeatabilityHeaders);
        }

        [Test]
        public void RepeatablityHeaders_IsNotOverwrittenByDefaultIfSet()
        {
            // arrange
            var repeatablityRequestId = Guid.NewGuid();
            var repeatabilityFirstSent = DateTime.UtcNow;
            // arrange
            var options = new AnswerCallOptions("context", new Uri("https://contoso.com/callback"))
            {
                RepeatabilityHeaders = new RepeatabilityHeaders(repeatablityRequestId, repeatabilityFirstSent)
            };

            // act & assert
            Assert.IsFalse(options.RepeatabilityHeaders.IsInvalidRepeatabilityHeaders());
            Assert.AreEqual(repeatablityRequestId, options.RepeatabilityHeaders.RepeatabilityRequestId);
            Assert.AreEqual(repeatabilityFirstSent.ToString("R"), options.RepeatabilityHeaders.GetRepeatabilityFirstSentString());
        }
    }
}
