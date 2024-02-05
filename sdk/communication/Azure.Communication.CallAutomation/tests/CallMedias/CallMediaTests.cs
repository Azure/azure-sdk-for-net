// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallMedias
{
    public class CallMediaTests : CallAutomationTestBase
    {
        private static readonly IEnumerable<CommunicationIdentifier> _target = new CommunicationIdentifier[]
        {
            new CommunicationUserIdentifier("id")
        };
        private static readonly FileSource _fileSource = new FileSource(new System.Uri("file://path/to/file"));
        private static readonly TextSource _textSource = new TextSource("PlayTTS test text.", "en-US-ElizabethNeural")
        {
            CustomVoiceEndpointId = "customVoiceEndpointId"
        };
        private static readonly SsmlSource _ssmlSource = new SsmlSource("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><voice name=\"en-US-JennyNeural\">Recognize Choice Completed, played through SSML source.</voice></speak>")
        {
            CustomVoiceEndpointId = "customVoiceEndpointId"
        };

        private static readonly PlayOptions _fileOptions = new PlayOptions(_fileSource, _target)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static readonly PlayOptions _textOptions = new PlayOptions(_textSource, _target)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static readonly PlayOptions _ssmlOptions = new PlayOptions(_ssmlSource, _target)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static readonly PlayToAllOptions _filePlayToAllOptions = new PlayToAllOptions(_fileSource)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static readonly PlayToAllOptions _textPlayToAllOptions = new PlayToAllOptions(_textSource)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static readonly PlayToAllOptions _ssmlPlayToAllOptions = new PlayToAllOptions(_ssmlSource)
        {
            Loop = false,
            OperationContext = "context"
        };

        private static List<string> s_strings = new List<string>()
        {
            "The first test string to be recognized by cognition service.",
            "The second test string to be recognized by cognition service",
            "The third test string to be recognized by cognition service"
        };

        private static RecognitionChoice _recognizeChoice1 = new RecognitionChoice("testLabel1", s_strings);
        private static RecognitionChoice _recognizeChoice2 = new RecognitionChoice("testLabel2", s_strings);

        private static readonly List<RecognitionChoice> s_recognizeChoices = new List<RecognitionChoice>()
        {
            _recognizeChoice1,
            _recognizeChoice2
        };

        private static readonly CallMediaRecognizeOptions _dmtfRecognizeOptions = new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier("targetUserId"), maxTonesToCollect: 5)
        {
            InterruptCallMediaOperation = true,
            InterToneTimeout = TimeSpan.FromSeconds(10),
            StopTones = new DtmfTone[] { DtmfTone.Pound },
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new FileSource(new Uri("https://localhost"))
        };

        private static CallMediaRecognizeOptions _choiceRecognizeOptions = new CallMediaRecognizeChoiceOptions(new CommunicationUserIdentifier("targetUserId"), s_recognizeChoices)
        {
            InterruptCallMediaOperation = true,
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new TextSource("PlayTTS test text.")
            {
                SourceLocale = "en-US",
                VoiceKind = VoiceKind.Female,
                VoiceName = "LULU"
            },
            SpeechLanguage = "en-US",
            SpeechModelEndpointId = "customModelEndpointId"
        };

        private static CallMediaRecognizeSpeechOptions _speechRecognizeOptions = new CallMediaRecognizeSpeechOptions(new CommunicationUserIdentifier("targetUserId"))
        {
            InterruptCallMediaOperation = true,
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            EndSilenceTimeout = TimeSpan.FromMilliseconds(500),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new TextSource("PlayTTS test text.")
            {
                SourceLocale = "en-US",
                VoiceKind = VoiceKind.Female,
                VoiceName = "LULU"
            },
            SpeechLanguage = "en-US",
            SpeechModelEndpointId = "customModelEndpointId"
        };

        private static CallMediaRecognizeSpeechOrDtmfOptions _speechOrDtmfRecognizeOptions = new CallMediaRecognizeSpeechOrDtmfOptions(new CommunicationUserIdentifier("targetUserId"), 10)
        {
            InterruptCallMediaOperation = true,
            InitialSilenceTimeout = TimeSpan.FromSeconds(5),
            EndSilenceTimeout = TimeSpan.FromMilliseconds(500),
            InterruptPrompt = true,
            OperationContext = "operationContext",
            Prompt = new TextSource("PlayTTS test text.")
            {
                SourceLocale = "en-US",
                VoiceKind = VoiceKind.Female,
                VoiceName = "LULU"
            },
            SpeechLanguage= "en-US",
            SpeechModelEndpointId = "customModelEndpointId"
        };

        private static readonly CallMediaRecognizeOptions _emptyRecognizeOptions = new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier("targetUserId"), maxTonesToCollect: 1);

        private static readonly StartHoldMusicOptions _startHoldMusicOptions = new StartHoldMusicOptions(new CommunicationUserIdentifier("targetUserId"), _textSource)
        {
            OperationContext = "operationContext"
        };

        private static readonly StopHoldMusicOptions _stopHoldMusicOptions = new StopHoldMusicOptions(new CommunicationUserIdentifier("targetUserId"))
        {
            OperationContext = "operationContext"
        };

        private static CallMedia? _callMedia;

        [SetUp]
        public void Setup()
        {
            _fileSource.PlaySourceCacheId = "playSourceId";
        }

        private CallMedia GetCallMedia(int responseCode, object? responseContent = null)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(responseCode, responseContent);
            return callAutomationClient.GetCallConnection("callConnectionId").GetCallMedia();
        }

        [TestCaseSource(nameof(TestData_PlayOperationsAsync))]
        public async Task PlayOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<PlayResult>>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_CancelOperationsAsync))]
        public async Task CancelOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperationsAsync))]
        public async Task RecognizeOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_SendDtmfOperationsAsync))]
        public async Task SendDtmfOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response<SendDtmfTonesResult>>> operation)
        {
            _callMedia = GetCallMedia(202, "{ \"operationContext\": \"operationContext\" }");
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_StartContinuousRecognitionOperationsAsync))]
        public async Task StartContinuousRecognitionOperationssAsync_Return200Accepted(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_StopContinuousRecognitionOperationsAsync))]
        public async Task StopContinuousRecognitionOperationssAsync_Return200Accepted(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_StartTranscriptionOperationsAsync))]
        public async Task StartTranscriptionOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_StopTranscriptionOperationsAsync))]
        public async Task StopTranscriptionOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateTranscriptionOperationsAsync))]
        public async Task UpdateTranscriptionOperationsAsync_Return202Accepted(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_PlayOperations))]
        public void MediaOperations_Return202Accepted(Func<CallMedia, Response<PlayResult>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_PlayOperations_WithBargeIn))]
        public void MediaOperationsWithBargeIn_Return202Accepted(Func<CallMedia, Response<PlayResult>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_CancelOperations))]
        public void CancelOperations_Return202Accepted(Func<CallMedia, Response<CancelAllMediaOperationsResult>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperations))]
        public void RecognizeOperations_Return202Accepted(Func<CallMedia, Response<StartRecognizingCallMediaResult>> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_SendDtmfOperations))]
        public void SendDtmfOperations_Return202Accepted(Func<CallMedia, Response<SendDtmfTonesResult>> operation)
        {
            _callMedia = GetCallMedia(202, "{ \"operationContext\": \"operationContext\" }");
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.GetRawResponse().Status);
        }

        [TestCaseSource(nameof(TestData_StartContinuousRecognitionOperations))]
        public void StartContinuousRecognitionOperations_Return200OK(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_StopContinuousRecognitionOperations))]
        public void StopContinuousRecognizeOperations_Return200OK(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_StartTranscriptionOperations))]
        public void StartTranscriptionOperations_Return202Accepted(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_StopTranscriptionOperations))]
        public void StopTranscriptionOperations_Return202Accepted(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_UpdateTranscriptionOperations))]
        public void UpdateTranscriptionOperations_Return202Accepted(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(202);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.Accepted, result.Status);
        }

        [TestCaseSource(nameof(TestData_PlayOperationsAsync))]
        public void PlayOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<PlayResult>>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelOperationsAsync))]
        public void CancelOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperationsAsync))]
        public void RecognizeOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_SendDtmfOperationsAsync))]
        public void SendDtmfOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response<SendDtmfTonesResult>>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartContinuousRecognitionOperationsAsync))]
        public void StartContinuousRecognitionOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopContinuousRecognitionOperationsAsync))]
        public void StopContinuousRecognitionOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartTranscriptionOperationsAsync))]
        public void StartTranscriptionOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_UpdateTranscriptionOperationsAsync))]
        public void UpdateTranscriptionOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopTranscriptionOperationsAsync))]
        public void StopTranscriptionOperationsAsync_Return404NotFound(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_PlayOperations))]
        public void PlayOperations_Return404NotFound(Func<CallMedia, Response<PlayResult>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperations))]
        public void RecognizeOperations_Return404NotFound(Func<CallMedia, Response<StartRecognizingCallMediaResult>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_SendDtmfOperations))]
        public void SendDtmfOperations_Return404NotFound(Func<CallMedia, Response<SendDtmfTonesResult>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_CancelOperations))]
        public void CancelOperations_Return404NotFound(Func<CallMedia, Response<CancelAllMediaOperationsResult>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_RecognizeOperations))]
        public void MediaOperations_Return404NotFound(Func<CallMedia, Response<StartRecognizingCallMediaResult>> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartContinuousRecognitionOperations))]
        public void StartContinuousRecognitionOperations_Return404NotFound(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopContinuousRecognitionOperations))]
        public void StopContinuousRecognizeOperations_Return404NotFound(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StartTranscriptionOperations))]
        public void StartTranscriptionOperations_Return404NotFound(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_StopTranscriptionOperations))]
        public void StopTranscriptionOperations_Return404NotFound(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_UpdateTranscriptionOperations))]
        public void UpdateTranscriptionOperations_Return404NotFound(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(
                () => operation(_callMedia));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_HoldOperationsAsync))]
        public async Task HoldMusicAsyncOperations_Return200Ok(Func<CallMedia, Task<Response>> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = await operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [TestCaseSource(nameof(TestData_HoldOperations))]
        public void HoldMusicOperations_Return200Ok(Func<CallMedia, Response> operation)
        {
            _callMedia = GetCallMedia(200);
            var result = operation(_callMedia);
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        private static IEnumerable<object?[]> TestData_PlayOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayAsync(_fileOptions)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayToAllAsync(_filePlayToAllOptions)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayAsync(_textOptions)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayToAllAsync(_textPlayToAllOptions)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayAsync(_ssmlOptions)
                },
                new Func<CallMedia, Task<Response<PlayResult>>>?[]
                {
                   callMedia => callMedia.PlayToAllAsync(_ssmlPlayToAllOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayOperations_WithBargeIn()
        {
            return new[]
            {
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => {
                       _filePlayToAllOptions.InterruptCallMediaOperation = true;
                       return callMedia.PlayToAll(_filePlayToAllOptions);
                    }
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => {
                       _textPlayToAllOptions.InterruptCallMediaOperation = true;
                       return callMedia.PlayToAll(_textPlayToAllOptions);
                    }
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => {
                       _ssmlPlayToAllOptions.InterruptCallMediaOperation = true;
                       return callMedia.PlayToAll(_ssmlPlayToAllOptions);
                    }
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CancelOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<CancelAllMediaOperationsResult>>>?[]
                {
                   callMedia => callMedia.CancelAllMediaOperationsAsync()
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RecognizeOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_dmtfRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_choiceRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_speechRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_speechOrDtmfRecognizeOptions)
                },
                new Func<CallMedia, Task<Response<StartRecognizingCallMediaResult>>>?[]
                {
                   callMedia => callMedia.StartRecognizingAsync(_emptyRecognizeOptions)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_PlayOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.Play(_fileOptions)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.PlayToAll(_filePlayToAllOptions)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.Play(_textOptions)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.PlayToAll(_textPlayToAllOptions)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.Play(_ssmlOptions)
                },
                new Func<CallMedia, Response<PlayResult>>?[]
                {
                   callMedia => callMedia.PlayToAll(_ssmlPlayToAllOptions)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_CancelOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<CancelAllMediaOperationsResult>>?[]
                {
                   callMedia => callMedia.CancelAllMediaOperations()
                },
            };
        }

        private static IEnumerable<object?[]> TestData_RecognizeOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<StartRecognizingCallMediaResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_dmtfRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingCallMediaResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_choiceRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingCallMediaResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_speechRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingCallMediaResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_speechOrDtmfRecognizeOptions)
                },
                new Func<CallMedia, Response<StartRecognizingCallMediaResult>>?[]
                {
                   callMedia => callMedia.StartRecognizing(_emptyRecognizeOptions)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_SendDtmfOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response<SendDtmfTonesResult>>?[]
                {
                   callMedia => callMedia.SendDtmfTones(
                       new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound },
                       new CommunicationUserIdentifier("targetUserId")
                       )
                }
            };
        }

        private static IEnumerable<object?[]> TestData_SendDtmfOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response<SendDtmfTonesResult>>>?[]
                {
                   callMedia => callMedia.SendDtmfTonesAsync(
                       new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound },
                       new CommunicationUserIdentifier("targetUserId")
                       )
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StartContinuousRecognitionOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StartContinuousDtmfRecognition(new CommunicationUserIdentifier("targetUserId"))
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StartContinuousRecognitionOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StartContinuousDtmfRecognitionAsync(new CommunicationUserIdentifier("targetUserId"))
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StopContinuousRecognitionOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StopContinuousDtmfRecognition(new CommunicationUserIdentifier("targetUserId"))
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StopContinuousRecognitionOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StopContinuousDtmfRecognitionAsync(new CommunicationUserIdentifier("targetUserId"))
                }
            };
        }

        private static IEnumerable<object?[]> TestData_HoldOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StartHoldMusicAsync(_startHoldMusicOptions)
                },
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StopHoldMusicAsync(_stopHoldMusicOptions)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_HoldOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StartHoldMusic(_startHoldMusicOptions)
                },
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StopHoldMusic(_stopHoldMusicOptions)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StartTranscriptionOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StartTranscription()
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StartTranscriptionOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StartTranscriptionAsync(new StartTranscriptionOptions(){OperationContext = "OperationContext"})
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StopTranscriptionOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.StopTranscription(new StopTranscriptionOptions(){OperationContext = "OperationContext"})
                }
            };
        }

        private static IEnumerable<object?[]> TestData_StopTranscriptionOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.StopTranscriptionAsync(new StopTranscriptionOptions(){OperationContext = "OperationContext"})
                }
            };
        }

        private static IEnumerable<object?[]> TestData_UpdateTranscriptionOperations()
        {
            return new[]
            {
                new Func<CallMedia, Response>?[]
                {
                   callMedia => callMedia.UpdateTranscription("locale")
                }
            };
        }

        private static IEnumerable<object?[]> TestData_UpdateTranscriptionOperationsAsync()
        {
            return new[]
            {
                new Func<CallMedia, Task<Response>>?[]
                {
                   callMedia => callMedia.UpdateTranscriptionAsync("locale")
                }
            };
        }
    }
}
