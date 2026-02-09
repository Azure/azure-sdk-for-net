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

        public static readonly Uri ImageUrl = new Uri("https://aka.ms/acsicon1");
        public static readonly Uri DocumentUrl = new Uri("https://filesamples.com/samples/document/pdf/sample2.pdf");
        public static readonly Uri VideoUrl = new Uri("https://filesamples.com/samples/video/3gp/sample_640x360.3gp");
        public static readonly Uri AudioUrl = new Uri("https://filesamples.com/samples/audio/mp3/sample3.mp3");
        public static readonly Uri StickUrl = new Uri("https://img-06.stickers.cloud/packs/5df297e3-a7f0-44e0-a6d1-43bdb09b793c/webp/8709a42d-0579-4314-b659-9c2cdb979305.webp");

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
        public async Task SendImageMessage_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            ImageNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, ImageUrl);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendAudioMessage_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            AudioNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, AudioUrl);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendVideoMessage_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            VideoNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, VideoUrl);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendDocumentMessage_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            DocumentNotificationContent content = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, DocumentUrl);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendStickerMessage_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var content = new StickerNotificationContent(new Guid(TestEnvironment.SenderChannelRegistrationId), recipients, StickUrl);

            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendReactionMessage_ShouldSucceed()
        {
            // Arrange
            NotificationMessagesClient notificationMessagesClient = CreateInstrumentedNotificationMessagesClient();
            TextNotificationContent textContent = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, "LiveTest");
            Response<SendMessageResult> textResponse = await notificationMessagesClient.SendAsync(textContent);
            var messageId = textResponse.Value.Receipts[0].MessageId;
            ReactionNotificationContent reactionContent = new(new Guid(TestEnvironment.SenderChannelRegistrationId), new List<string> { TestEnvironment.RecipientIdentifier }, "\uD83D\uDE00", messageId);

            // Act
            Response<SendMessageResult> response = await notificationMessagesClient.SendAsync(reactionContent);

            // Assert
            validateResponse(textResponse);
        }

        [Test]
        public async Task SendInteractiveMessageWithButtonAction_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var buttonActions = new List<ButtonContent>
            {
                new ButtonContent("no", "No"),
                new ButtonContent("yes", "Yes")
            };
            var buttonSet = new ButtonSetContent(buttonActions);
            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Do you want to proceed?"),
                new WhatsAppButtonActionBindings(buttonSet));

            var content = new InteractiveNotificationContent(new Guid(TestEnvironment.SenderChannelRegistrationId), recipients, interactiveMessage);
            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendInteractiveMessageWithImageHeader_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var buttonActions = new List<ButtonContent>
            {
                new ButtonContent("no", "No"),
                new ButtonContent("yes", "Yes")
            };
            var buttonSet = new ButtonSetContent(buttonActions);
            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Do you want to proceed?"),
                new WhatsAppButtonActionBindings(buttonSet));
            interactiveMessage.Header = new ImageMessageContent(ImageUrl);

            var content = new InteractiveNotificationContent(new Guid(TestEnvironment.SenderChannelRegistrationId), recipients, interactiveMessage);
            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendInteractiveMessageWithDocumentHeader_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var buttonActions = new List<ButtonContent>
            {
                new ButtonContent("no", "No"),
                new ButtonContent("yes", "Yes")
            };
            var buttonSet = new ButtonSetContent(buttonActions);
            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Do you want to proceed?"),
                new WhatsAppButtonActionBindings(buttonSet));
            interactiveMessage.Header = new DocumentMessageContent(DocumentUrl);

            var content = new InteractiveNotificationContent(new Guid(TestEnvironment.SenderChannelRegistrationId), recipients, interactiveMessage);
            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendInteractiveMessageWithVideoHeader_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var buttonActions = new List<ButtonContent>
            {
                new ButtonContent("no", "No"),
                new ButtonContent("yes", "Yes")
            };
            var buttonSet = new ButtonSetContent(buttonActions);
            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Do you like it?"),
                new WhatsAppButtonActionBindings(buttonSet));
            interactiveMessage.Header = new VideoMessageContent(VideoUrl);

            var content = new InteractiveNotificationContent(new Guid(TestEnvironment.SenderChannelRegistrationId), recipients, interactiveMessage);
            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(content);

            // Assert
            validateResponse(response);
        }

        [Test]

        public async Task SendInteractiveListMessage_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var channelRegistrationId = new Guid(TestEnvironment.SenderChannelRegistrationId);

            var actionItemsList1 = new List<ActionGroupItem>
            {
                new ActionGroupItem("priority_express", "Priority Mail Express", "Next Day to 2 Days"),
                new ActionGroupItem("priority_mail", "Priority Mail", "1–3 Days")
            };

            var actionItemsList2 = new List<ActionGroupItem>
            {
                new ActionGroupItem("usps_ground_advantage", "USPS Ground Advantage", "2-5 Days"),
                new ActionGroupItem("media_mail", "Media Mail", "2-8 Days")
            };

            var groups = new List<ActionGroup>
            {
                new ActionGroup("I want it ASAP!", actionItemsList1),
                new ActionGroup("I can wait a bit", actionItemsList2)
            };

            var actionGroupContent = new ActionGroupContent("Shipping Options", groups);

            var interactionMessage = new InteractiveMessage(
                new TextMessageContent("Test Body"),
                new WhatsAppListActionBindings(actionGroupContent)
            );
            interactionMessage.Header = new TextMessageContent("Test Header");
            interactionMessage.Footer = new TextMessageContent("Test Footer");

            var interactiveMessageContent = new InteractiveNotificationContent(
                channelRegistrationId,
                recipients,
                interactionMessage
            );

            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(interactiveMessageContent);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendInteractiveReplyButtonMessage_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var channelRegistrationId = new Guid(TestEnvironment.SenderChannelRegistrationId);

            var replyButtonActionList = new List<ButtonContent>
            {
                new ButtonContent("cancel", "Cancel"),
                new ButtonContent("agree", "Agree")
            };

            var buttonSet = new ButtonSetContent(replyButtonActionList);

            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Test Body"),
                new WhatsAppButtonActionBindings(buttonSet)
            );
            interactiveMessage.Header = new TextMessageContent("Test Header");
            interactiveMessage.Footer = new TextMessageContent("Test Footer");

            var interactiveMessageContent = new InteractiveNotificationContent(
                channelRegistrationId,
                recipients,
                interactiveMessage
            );

            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(interactiveMessageContent);

            // Assert
            validateResponse(response);
        }

        [Test]
        public async Task SendInteractiveClickToActionMessage_ShouldSucceed()
        {
            // Arrange
            var recipients = new List<string> { TestEnvironment.RecipientIdentifier };
            var channelRegistrationId = new Guid(TestEnvironment.SenderChannelRegistrationId);

            var urlAction = new LinkContent("Test Url", AudioUrl);

            var interactiveMessage = new InteractiveMessage(
                new TextMessageContent("Test Body"),
                new WhatsAppUrlActionBindings(urlAction)
            );
            interactiveMessage.Header = new TextMessageContent("Test Header");
            interactiveMessage.Footer = new TextMessageContent("Test Footer");

            var interactiveMessageContent = new InteractiveNotificationContent(channelRegistrationId, recipients, interactiveMessage);

            NotificationMessagesClient messagesClient = CreateInstrumentedNotificationMessagesClient();

            // Act
            var response = await messagesClient.SendAsync(interactiveMessageContent);

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

            var image = new MessageTemplateImage("image", ImageUrl);
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
            var video = new MessageTemplateVideo("video", VideoUrl);

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

            var document = new MessageTemplateDocument("document", DocumentUrl);
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

            var image = new MessageTemplateImage("image", ImageUrl);
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
        [Ignore("Disabling this test as for failing Email build.")]
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
