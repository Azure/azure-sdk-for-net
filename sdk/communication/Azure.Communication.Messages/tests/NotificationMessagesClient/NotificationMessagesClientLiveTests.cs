// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
        public const string VideoUrl = "https://sample-videos.com/video321/mp4/720/big_buck_bunny_720p_1mb.mp4";
        public const string DocumentUrl = "https://file-examples.com/storage/fe63e96e0365c0e1e99a842/2017/10/file-sample_150kB.pdf";

        [Test]
        public async Task SendTextMessage_ShouldSucceed()
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
        public async Task SendTextMessage_WithAzureKeyCredential_ShouldSucceed()
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
        public async Task SendShippingConfirmationTemplateMessage_ShouldSucceed()
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
        public async Task SendPurchaseFeedbackTemplateMessage_ShouldSucceed()
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
        public async Task SendIssueResolutionTemplateMessage_ShouldSucceed()
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
        public async Task SendHappyHourAnnocementTemplateMessage_ShouldSucceed()
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
        public async Task SendFlightConfirmationTemplateMessage_ShouldSucceed()
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
        public async Task SendMovieTicketConfirmationTemplateMessage_ShouldSucceed()
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
        public Task SendTextMessage_WithEmptyContent_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            TextNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId),
                new List<string> { TestEnvironment.RecipientIdentifier }, string.Empty);

            // Act and Assert
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.SendAsync(content));

            // Assert the expected error code and message
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("BadRequest", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("A non-empty \"Content\" is required when message type is Text."));

            return Task.CompletedTask;
        }

        [Test]
        public Task SendTemplateMessage_WithInvalidTemplate_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            Guid channelRegistrationId = new(TestEnvironment.SenderChannelRegistrationId);
            IList<string> recipients = new List<string> { TestEnvironment.RecipientIdentifier };

            // Invalid template without required values
            MessageTemplate template = new("invalid_template", "en_us");

            NotificationContent content = new TemplateNotificationContent(channelRegistrationId, recipients, template);

            // Act and Assert
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.SendAsync(content));

            // Assert the expected error code and message
            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual("TemplateNotFound", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("Template does not exist"));
            return Task.CompletedTask;
        }

        [Test]
        public Task SendTextNessage_WithInvalidRecipient_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            TextNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId),
                new List<string> { "InvalidRecipient" }, "LiveTest");

            // Act and Assert
            Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.SendAsync(content));
            return Task.CompletedTask;
        }

        [Test]
        public Task SendSuperLongTextMessage_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();

            // Create a super long text message
            string superLongText = new string('A', 1000000); // 1 million characters

            TextNotificationContent content = new TextNotificationContent(
                new Guid(TestEnvironment.SenderChannelRegistrationId),
                new List<string> { TestEnvironment.RecipientIdentifier },
                superLongText);

            // Act and Assert
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.SendAsync(content));

            // Assert the expected error code and message
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("BadRequest", ex.ErrorCode);
            Assert.IsTrue(ex.Message.Contains("InvalidParameter: (#100) Param text['body'] must be at most 4096 characters long."));

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
        public void DownloadMedia_NullOrEmptyMediaContentId_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await notificationMessagesClient.DownloadMediaAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await notificationMessagesClient.DownloadMediaAsync(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(async () => await notificationMessagesClient.DownloadMediaAsync(""));
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.DownloadMediaAsync("  "));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 400);
        }

        [Test]
        public void DownloadMedia_InvalidMediaContentId_ShouldFail()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act & Assert
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await notificationMessagesClient.DownloadMediaAsync("test"));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
            Assert.AreEqual(ex?.ErrorCode, "MediaNotFound");
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
