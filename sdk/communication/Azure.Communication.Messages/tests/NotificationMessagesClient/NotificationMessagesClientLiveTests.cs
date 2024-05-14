// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.Messages.Tests
{
    public class NotificationMessagesClientLiveTests : MessagesLiveTestBase
    {
        public NotificationMessagesClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        public const string ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/30/Building92microsoft.jpg";
        public const string VideoUrl = "https://sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4";
        public const string DocumentUrl = "https://go.microsoft.com/fwlink/?linkid=2131549";

        [Test]
        public async Task SendMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            var options = new SendMessageOptions(TestEnvironment.SenderChannelRegistrationId, new List<string> { TestEnvironment.RecipientIdentifier }, "LiveTest");

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendMessageWithAzureKeyCredentialShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClientWithAzureKeyCredential();
            var options = new SendMessageOptions(TestEnvironment.SenderChannelRegistrationId, new List<string> { TestEnvironment.RecipientIdentifier }, "LiveTest");

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendShippingConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var ThreeDays = new MessageTemplateText("threeDays", "3");
            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { ThreeDays };

            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                body: new[] { ThreeDays.Name }
            );

            MessageTemplate template = new MessageTemplate("sample_shipping_confirmation", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendPurchaseFeedbackTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var image = new MessageTemplateImage("image", new Uri(ImageUrl));
            var product = new MessageTemplateText("product", "Microsoft Office");

            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { image, product };
            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                header: new[] { image.Name },
                body: new[] { product.Name }
            );
            MessageTemplate template = new MessageTemplate("sample_purchase_feedback", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendIssueResolutionTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var name = new MessageTemplateText("name", "Gloria");
            var yes = new MessageTemplateQuickAction("yes", null, "Yay!");
            var no = new MessageTemplateQuickAction("no", null, "Nay!");

            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { name, yes, no };
            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                body: new[] { name.Name },
                button: new[] {
                    new KeyValuePair<string, MessageTemplateValueWhatsAppSubType>(yes.Name, MessageTemplateValueWhatsAppSubType.QuickReply),
                    new KeyValuePair<string, MessageTemplateValueWhatsAppSubType>(no.Name, MessageTemplateValueWhatsAppSubType.QuickReply),
                }
            );
            MessageTemplate template = new MessageTemplate("sample_issue_resolution", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendHappyHourAnnocementTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var venue = new MessageTemplateText("venue", "Starbucks");
            var time = new MessageTemplateText("time", "Today 2-4PM");
            var video = new MessageTemplateVideo("video", new Uri(VideoUrl));

            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { venue, time, video };
            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                header: new[] { video.Name },
                body: new[] { venue.Name, time.Name }
            );
            MessageTemplate template = new MessageTemplate("sample_happy_hour_announcement", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendFlightConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var document = new MessageTemplateDocument("document", new Uri(DocumentUrl));
            var firstName = new MessageTemplateText("firstName", "Gloria");
            var lastName = new MessageTemplateText("lastName", "Li");
            var date = new MessageTemplateText("date", "July 1st, 2023");

            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { document, firstName, lastName, date };
            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                header: new[] { document.Name },
                body: new[] { firstName.Name, lastName.Name, date.Name }
            );
            MessageTemplate template = new MessageTemplate("sample_flight_confirmation", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendMovieTicketConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string channelRegistrationId = TestEnvironment.SenderChannelRegistrationId;
            IEnumerable<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var image = new MessageTemplateImage("image", new Uri(ImageUrl));
            var title = new MessageTemplateText("title", "Avengers");
            var time = new MessageTemplateText("time", "July 1st, 2023 12:30PM");
            var venue = new MessageTemplateText("venue", "Cineplex");
            var seats = new MessageTemplateText("seats", "Seat 1A");
            IEnumerable<MessageTemplateValue> values = new List<MessageTemplateValue> { image, title, time, venue, seats };
            MessageTemplateWhatsAppBindings bindings = new MessageTemplateWhatsAppBindings(
                header: new[] { image.Name },
                body: new[] { title.Name, time.Name, venue.Name, seats.Name }
            );
            MessageTemplate template = new MessageTemplate("sample_movie_ticket_confirmation", "en_us", values, bindings);
            SendMessageOptions options = new SendMessageOptions(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendMessageAsync(options);

            // Assert
            validateResponse(response);
        }

        private void validateResponse(Response<SendMessageResult> response)
        {
            Assert.AreEqual(202, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value.Receipts[0].MessageId);
            Assert.IsNotNull(response.Value.Receipts[0].To);
            Assert.AreEqual(TestEnvironment.RecipientIdentifier, response.Value.Receipts[0].To);
        }
    }
}
