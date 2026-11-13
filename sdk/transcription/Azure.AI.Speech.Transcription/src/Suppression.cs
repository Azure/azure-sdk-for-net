// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// AZC0007: TranscriptionClient constructors use System.ClientModel credential types (ApiKeyCredential,
// AuthenticationTokenProvider) and TranscriptionClientOptions (derives from ClientPipelineOptions, not
// ClientOptions) because this SDK is built on System.ClientModel rather than Azure.Core.
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Uses System.ClientModel ApiKeyCredential instead of Azure.Core AzureKeyCredential.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.#ctor(System.Uri,System.ClientModel.ApiKeyCredential)")]
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Uses System.ClientModel AuthenticationTokenProvider instead of Azure.Core TokenCredential.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.#ctor(System.Uri,System.ClientModel.AuthenticationTokenProvider)")]
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Uses System.ClientModel ApiKeyCredential and TranscriptionClientOptions (ClientPipelineOptions) instead of Azure.Core types.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.#ctor(System.Uri,System.ClientModel.ApiKeyCredential,Azure.AI.Speech.Transcription.TranscriptionClientOptions)")]
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Uses System.ClientModel AuthenticationTokenProvider and TranscriptionClientOptions (ClientPipelineOptions) instead of Azure.Core types.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.#ctor(System.Uri,System.ClientModel.AuthenticationTokenProvider,Azure.AI.Speech.Transcription.TranscriptionClientOptions)")]

// AZC0015: TranscribeAsync/Transcribe return ClientResult<T> (System.ClientModel) instead of
// Response<T>/Task<Response<T>> (Azure.Core) because this SDK is built on System.ClientModel.
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<T>> from System.ClientModel rather than Task<Response<T>> from Azure.Core.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.TranscribeAsync(Azure.AI.Speech.Transcription.TranscriptionOptions,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.ClientModel.ClientResult{Azure.AI.Speech.Transcription.TranscriptionResult}}")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<T> from System.ClientModel rather than Response<T> from Azure.Core.", Scope = "member", Target = "~M:Azure.AI.Speech.Transcription.TranscriptionClient.Transcribe(Azure.AI.Speech.Transcription.TranscriptionOptions,System.Threading.CancellationToken)~System.ClientModel.ClientResult{Azure.AI.Speech.Transcription.TranscriptionResult}")]
