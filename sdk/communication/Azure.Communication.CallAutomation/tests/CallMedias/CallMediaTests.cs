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

        private static readonly PlayToAllOptions _filePlayToAllOptions = new PlayToAllOptions(_fileSource )
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
                VoiceGender = GenderType.Female,
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
                VoiceGender = GenderType.Female,
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
                VoiceGender = GenderType.Female,
                VoiceName = "LULU"
            },
            SpeechLanguage= "en-US",
            SpeechModelEndpointId = "customModelEndpointId"
        };

        private static readonly CallMediaRecognizeOptions _emptyRecognizeOptions = new CallMediaRecognizeDtmfOptions(new CommunicationUserIdentifier("targetUserId"), maxTonesToCollect: 1);

        private static CallMedia? _callMedia;

        [SetUp]
        public void Setup()
        {
            _fileSource.PlaySourceCacheId = "PlaySourceCacheId";
        }

        private CallMedia GetCallMedia(int responseCode)
        {
            CallAutomationClient callAutomationClient = CreateMockCallAutomationClient(responseCode);
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

        [TestCaseSource(nameof(TestData_PlayOperations))]
        public void MediaOperations_Return202Accepted(Func<CallMedia, Response<PlayResult>> operation)
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
                }
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
                   callMedia => callMedia.StartRecognizing(_emptyRecognizeOptions)
                }
            };
        }
    }
}
