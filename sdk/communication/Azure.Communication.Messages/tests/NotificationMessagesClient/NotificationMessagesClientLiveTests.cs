// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Communication.Messages.Models.Channels;
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
            TextNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, "LiveTest");

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendMessageWithAzureKeyCredentialShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClientWithAzureKeyCredential();
            TextNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, "LiveTest");

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendShippingConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var ThreeDays = new MessageTemplateText("threeDays", "3");
            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Body.Add(new(ThreeDays.Name));

            MessageTemplate template = new("sample_shipping_confirmation", "en_us")
            {
                Bindings = bindings
            };
            template.Values.Add(ThreeDays);

            NotificationContent content = new TemplateNotificationContent(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendPurchaseFeedbackTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var image = new MessageTemplateImage("image", new Uri(ImageUrl));
            var product = new MessageTemplateText("product", "Microsoft Office");

            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Header.Add(new(image.Name));
            bindings.Body.Add(new(product.Name));

            MessageTemplate template = new("sample_purchase_feedback", "en_us");
            template.Values.Add(image);
            template.Values.Add(product);
            template.Bindings = bindings;
            var content = new TemplateNotificationContent(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendIssueResolutionTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var name = new MessageTemplateText("name", "Gloria");
            var yes = new MessageTemplateQuickAction("yes") { Payload = "Yay!" };
            var no = new MessageTemplateQuickAction("no") { Payload = "Nay!" };

            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Body.Add(new(name.Name));
            bindings.Buttons.Add(new(WhatsAppMessageButtonSubType.QuickReply.ToString(), yes.Name));
            bindings.Buttons.Add(new(WhatsAppMessageButtonSubType.QuickReply.ToString(), no.Name));

            MessageTemplate template = new("sample_issue_resolution", "en_us")
            {
                Bindings = bindings
            };
            template.Values.Add(name);
            template.Values.Add(yes);
            template.Values.Add(no);

            TemplateNotificationContent content = new(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendHappyHourAnnocementTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var venue = new MessageTemplateText("venue", "Starbucks");
            var time = new MessageTemplateText("time", "Today 2-4PM");
            var video = new MessageTemplateVideo("video", new Uri(VideoUrl));

            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Header.Add(new(video.Name));
            bindings.Body.Add(new(venue.Name));
            bindings.Body.Add(new(time.Name));

            MessageTemplate template = new("sample_happy_hour_announcement", "en_us");
            template.Values.Add(venue);
            template.Values.Add(time);
            template.Values.Add(video);
            template.Bindings = bindings;

            TemplateNotificationContent content = new(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendFlightConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var document = new MessageTemplateDocument("document", new Uri(DocumentUrl));
            var firstName = new MessageTemplateText("firstName", "Gloria");
            var lastName = new MessageTemplateText("lastName", "Li");
            var date = new MessageTemplateText("date", "July 1st, 2023");

            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Header.Add(new(document.Name));
            bindings.Body.Add(new(firstName.Name));
            bindings.Body.Add(new(lastName.Name));
            bindings.Body.Add(new(date.Name));

            MessageTemplate template = new("sample_flight_confirmation", "en_us");
            template.Values.Add(document);
            template.Values.Add(firstName);
            template.Values.Add(lastName);
            template.Values.Add(date);
            template.Bindings = bindings;

            TemplateNotificationContent content = new(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendMovieTicketConfirmationTemplateMessageShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            var image = new MessageTemplateImage("image", new Uri(ImageUrl));
            var title = new MessageTemplateText("title", "Avengers");
            var time = new MessageTemplateText("time", "July 1st, 2023 12:30PM");
            var venue = new MessageTemplateText("venue", "Cineplex");
            var seats = new MessageTemplateText("seats", "Seat 1A");

            WhatsAppMessageTemplateBindings bindings = new();
            bindings.Header.Add(new(image.Name));
            bindings.Body.Add(new(title.Name));
            bindings.Body.Add(new(time.Name));
            bindings.Body.Add(new(venue.Name));
            bindings.Body.Add(new(seats.Name));

            MessageTemplate template = new("sample_movie_ticket_confirmation", "en_us");
            template.Values.Add(image);
            template.Values.Add(title);
            template.Values.Add(time);
            template.Values.Add(venue);
            template.Values.Add(seats);
            template.Bindings = bindings;

            TemplateNotificationContent content = new(channelRegistrationId, recipients, template);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public Task SendMessageWithEmptyContentShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            TextNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId),
                new List<string> { TestEnvironment.RecipientIdentifier }, string.Empty);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await notificationMessagesClient.SendAsync(content));
            return Task.CompletedTask;
        }

        [Test]
        public Task SendTemplateMessageWithInvalidTemplateShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            // Invalid template without required values
            MessageTemplate template = new("invalid_template", "en_us");

            NotificationContent content = new TemplateNotificationContent(channelRegistrationId, recipients, template);

            // Act and Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await notificationMessagesClient.SendAsync(content));
            return Task.CompletedTask;
        }

        [Test]
        public async Task DownloadMedia_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string mediaContentId = TestEnvironment.MediaContentId;

            // Act
            Stream mediaStream = await notificationMessagesClient.DownloadMediaAsync(mediaContentId);

            // Assert
            mediaStream.Position = 0; // Reset stream position for reading
            Assert.IsTrue(mediaStream.Length > 0);
        }

        [Test]
        public async Task DownloadMediaToStream_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string mediaContentId = TestEnvironment.MediaContentId;
            Stream destinationStream = new MemoryStream();

            // Act
            Response downloadResponse = await notificationMessagesClient.DownloadMediaToAsync(mediaContentId, destinationStream);

            // Assert
            Assert.AreEqual(200, downloadResponse.Status);
            destinationStream.Position = 0; // Reset stream position for reading
            Assert.IsTrue(destinationStream.Length > 0);
        }

        [Test]
        public async Task DownloadMediaToFilePath_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            string mediaContentId = TestEnvironment.MediaContentId;
            string destinationPath = TestEnvironment.DownloadDestinationLocalPath;

            // Act
            Response downloadResponse = await notificationMessagesClient.DownloadMediaToAsync(mediaContentId, destinationPath);

            // Assert
            Assert.AreEqual(200, downloadResponse.Status);
            Assert.IsTrue(File.Exists(destinationPath));
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
