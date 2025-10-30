// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;
//using Azure.AI.Agents.Models;

//namespace Azure.AI.Agents;

//public partial class Responses
//{
//    /// <summary> Creates a model response. </summary>
//    /// <param name="metadata">
//    /// Set of 16 key-value pairs that can be attached to an object. This can be
//    /// useful for storing additional information about the object in a structured
//    /// format, and querying for objects via API or the dashboard.
//    ///
//    /// Keys are strings with a maximum length of 64 characters. Values are strings
//    /// with a maximum length of 512 characters.
//    /// </param>
//    /// <param name="temperature">
//    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
//    /// We generally recommend altering this or `top_p` but not both.
//    /// </param>
//    /// <param name="topP">
//    /// An alternative to sampling with temperature, called nucleus sampling,
//    /// where the model considers the results of the tokens with top_p probability
//    /// mass. So 0.1 means only the tokens comprising the top 10% probability mass
//    /// are considered.
//    ///
//    /// We generally recommend altering this or `temperature` but not both.
//    /// </param>
//    /// <param name="user"> A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices#end-user-ids). </param>
//    /// <param name="topLogprobs"> An integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability. </param>
//    /// <param name="previousResponseId">
//    /// The unique ID of the previous response to the model. Use this to
//    /// create multi-turn conversations. Learn more about
//    /// [conversation state](/docs/guides/conversation-state).
//    /// </param>
//    /// <param name="reasoning"></param>
//    /// <param name="background">
//    /// Whether to run the model response in the background.
//    /// [Learn more](/docs/guides/background).
//    /// </param>
//    /// <param name="maxOutputTokens"> An upper bound for the number of tokens that can be generated for a response, including visible output tokens and [reasoning tokens](/docs/guides/reasoning). </param>
//    /// <param name="maxToolCalls"> The maximum number of total calls to built-in tools that can be processed in a response. This maximum number applies across all built-in tool calls, not per individual tool. Any further attempts to call a tool by the model will be ignored. </param>
//    /// <param name="text">
//    /// Configuration options for a text response from the model. Can be plain
//    /// text or structured JSON data. Learn more:
//    /// - [Text inputs and outputs](/docs/guides/text)
//    /// - [Structured Outputs](/docs/guides/structured-outputs)
//    /// </param>
//    /// <param name="toolChoice">
//    /// How the model should select which tool (or tools) to use when generating
//    /// a response. See the `tools` parameter to see how to specify which tools
//    /// the model can call.
//    /// </param>
//    /// <param name="prompt"></param>
//    /// <param name="truncation">
//    /// The truncation strategy to use for the model response.
//    /// - `auto`: If the context of this response and previous ones exceeds
//    ///   the model's context window size, the model will truncate the
//    ///   response to fit the context window by dropping input items in the
//    ///   middle of the conversation.
//    /// - `disabled` (default): If a model response will exceed the context window
//    ///   size for a model, the request will fail with a 400 error.
//    /// </param>
//    /// <param name="include">
//    /// Specify additional output data to include in the model response. Currently
//    /// supported values are:
//    /// - `code_interpreter_call.outputs`: Includes the outputs of python code execution
//    ///   in code interpreter tool call items.
//    /// - `computer_call_output.output.image_url`: Include image urls from the computer call output.
//    /// - `file_search_call.results`: Include the search results of
//    ///   the file search tool call.
//    /// - `message.input_image.image_url`: Include image urls from the input message.
//    /// - `message.output_text.logprobs`: Include logprobs with assistant messages.
//    /// - `reasoning.encrypted_content`: Includes an encrypted version of reasoning
//    ///   tokens in reasoning item outputs. This enables reasoning items to be used in
//    ///   multi-turn conversations when using the Responses API statelessly (like
//    ///   when the `store` parameter is set to `false`, or when an organization is
//    ///   enrolled in the zero data retention program).
//    /// </param>
//    /// <param name="parallelToolCalls"> Whether to allow the model to run tool calls in parallel. </param>
//    /// <param name="store">
//    /// Whether to store the generated model response for later retrieval via
//    /// API.
//    /// </param>
//    /// <param name="instructions">
//    /// A system (or developer) message inserted into the model's context.
//    ///
//    /// When using along with `previous_response_id`, the instructions from a previous
//    /// response will not be carried over to the next response. This makes it simple
//    /// to swap out system (or developer) messages in new responses.
//    /// </param>
//    /// <param name="stream">
//    /// If set to true, the model response data will be streamed to the client
//    /// as it is generated using [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format).
//    /// See the [Streaming section below](/docs/api-reference/responses-streaming)
//    /// for more information.
//    /// </param>
//    /// <param name="conversation"></param>
//    /// <param name="model"> The model deployment to use for the creation of this response. </param>
//    /// <param name="agent"> The agent to use for generating the response. </param>
//    /// <param name="input"></param>
//    /// <param name="tools"></param>
//    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
//    /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//    internal virtual Response<AgentResponse> CreateResponse(IDictionary<string, string> metadata = default, float? temperature = default, float? topP = default, string user = default, int? topLogprobs = default, string previousResponseId = default, Reasoning reasoning = default, bool? background = default, int? maxOutputTokens = default, int? maxToolCalls = default, CreateResponseRequestText text = default, BinaryData toolChoice = default, Prompt prompt = default, CreateResponseRequestTruncation? truncation = default, IEnumerable<Includable> include = default, bool? parallelToolCalls = default, bool? store = default, string instructions = default, bool? stream = default, BinaryData conversation = default, string model = default, AgentReference agent = default, BinaryData input = default, IEnumerable<AgentTool> tools = default, CancellationToken cancellationToken = default)
//    {
//        CreateResponseRequest spreadModel = new CreateResponseRequest(
//            ((IReadOnlyDictionary<string, string>)metadata) ?? new Dictionary<string, string>(),
//            temperature,
//            null,
//            user,
//            null,
//            null,
//            reasoning,
//            background,
//            null,
//            null,
//            text,
//            null,
//            prompt,
//            truncation,
//            include?.ToList() as IList<Includable> ?? new ChangeTrackingList<Includable>(),
//            null,
//            store,
//            instructions,
//            stream,
//            conversation,
//            model,
//            agent,
//            input,
//            tools?.ToList() as IList<AgentTool> ?? new ChangeTrackingList<AgentTool>(),
//            null);
//        Response result = CreateResponse(spreadModel, cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null);
//        return Response.FromValue((AgentResponse)result, result);
//    }

//    /// <summary> Creates a model response. </summary>
//    /// <param name="metadata">
//    /// Set of 16 key-value pairs that can be attached to an object. This can be
//    /// useful for storing additional information about the object in a structured
//    /// format, and querying for objects via API or the dashboard.
//    ///
//    /// Keys are strings with a maximum length of 64 characters. Values are strings
//    /// with a maximum length of 512 characters.
//    /// </param>
//    /// <param name="temperature">
//    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
//    /// We generally recommend altering this or `top_p` but not both.
//    /// </param>
//    /// <param name="topP">
//    /// An alternative to sampling with temperature, called nucleus sampling,
//    /// where the model considers the results of the tokens with top_p probability
//    /// mass. So 0.1 means only the tokens comprising the top 10% probability mass
//    /// are considered.
//    ///
//    /// We generally recommend altering this or `temperature` but not both.
//    /// </param>
//    /// <param name="user"> A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices#end-user-ids). </param>
//    /// <param name="topLogprobs"> An integer between 0 and 20 specifying the number of most likely tokens to return at each token position, each with an associated log probability. </param>
//    /// <param name="previousResponseId">
//    /// The unique ID of the previous response to the model. Use this to
//    /// create multi-turn conversations. Learn more about
//    /// [conversation state](/docs/guides/conversation-state).
//    /// </param>
//    /// <param name="reasoning"></param>
//    /// <param name="background">
//    /// Whether to run the model response in the background.
//    /// [Learn more](/docs/guides/background).
//    /// </param>
//    /// <param name="maxOutputTokens"> An upper bound for the number of tokens that can be generated for a response, including visible output tokens and [reasoning tokens](/docs/guides/reasoning). </param>
//    /// <param name="maxToolCalls"> The maximum number of total calls to built-in tools that can be processed in a response. This maximum number applies across all built-in tool calls, not per individual tool. Any further attempts to call a tool by the model will be ignored. </param>
//    /// <param name="text">
//    /// Configuration options for a text response from the model. Can be plain
//    /// text or structured JSON data. Learn more:
//    /// - [Text inputs and outputs](/docs/guides/text)
//    /// - [Structured Outputs](/docs/guides/structured-outputs)
//    /// </param>
//    /// <param name="toolChoice">
//    /// How the model should select which tool (or tools) to use when generating
//    /// a response. See the `tools` parameter to see how to specify which tools
//    /// the model can call.
//    /// </param>
//    /// <param name="prompt"></param>
//    /// <param name="truncation">
//    /// The truncation strategy to use for the model response.
//    /// - `auto`: If the context of this response and previous ones exceeds
//    ///   the model's context window size, the model will truncate the
//    ///   response to fit the context window by dropping input items in the
//    ///   middle of the conversation.
//    /// - `disabled` (default): If a model response will exceed the context window
//    ///   size for a model, the request will fail with a 400 error.
//    /// </param>
//    /// <param name="include">
//    /// Specify additional output data to include in the model response. Currently
//    /// supported values are:
//    /// - `code_interpreter_call.outputs`: Includes the outputs of python code execution
//    ///   in code interpreter tool call items.
//    /// - `computer_call_output.output.image_url`: Include image urls from the computer call output.
//    /// - `file_search_call.results`: Include the search results of
//    ///   the file search tool call.
//    /// - `message.input_image.image_url`: Include image urls from the input message.
//    /// - `message.output_text.logprobs`: Include logprobs with assistant messages.
//    /// - `reasoning.encrypted_content`: Includes an encrypted version of reasoning
//    ///   tokens in reasoning item outputs. This enables reasoning items to be used in
//    ///   multi-turn conversations when using the Responses API statelessly (like
//    ///   when the `store` parameter is set to `false`, or when an organization is
//    ///   enrolled in the zero data retention program).
//    /// </param>
//    /// <param name="parallelToolCalls"> Whether to allow the model to run tool calls in parallel. </param>
//    /// <param name="store">
//    /// Whether to store the generated model response for later retrieval via
//    /// API.
//    /// </param>
//    /// <param name="instructions">
//    /// A system (or developer) message inserted into the model's context.
//    ///
//    /// When using along with `previous_response_id`, the instructions from a previous
//    /// response will not be carried over to the next response. This makes it simple
//    /// to swap out system (or developer) messages in new responses.
//    /// </param>
//    /// <param name="stream">
//    /// If set to true, the model response data will be streamed to the client
//    /// as it is generated using [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format).
//    /// See the [Streaming section below](/docs/api-reference/responses-streaming)
//    /// for more information.
//    /// </param>
//    /// <param name="conversation"></param>
//    /// <param name="model"> The model deployment to use for the creation of this response. </param>
//    /// <param name="agent"> The agent to use for generating the response. </param>
//    /// <param name="input"></param>
//    /// <param name="tools"></param>
//    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
//    /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
//    public virtual async Task<Response<AgentResponse>> CreateResponseAsync(IDictionary<string, string> metadata = default, float? temperature = default, float? topP = default, string user = default, int? topLogprobs = default, string previousResponseId = default, Reasoning reasoning = default, bool? background = default, int? maxOutputTokens = default, int? maxToolCalls = default, CreateResponseRequestText text = default, BinaryData toolChoice = default, Prompt prompt = default, CreateResponseRequestTruncation? truncation = default, IEnumerable<Includable> include = default, bool? parallelToolCalls = default, bool? store = default, string instructions = default, bool? stream = default, BinaryData conversation = default, string model = default, AgentReference agent = default, BinaryData input = default, IEnumerable<AgentTool> tools = default, CancellationToken cancellationToken = default)
//    {
//        CreateResponseRequest spreadModel = new CreateResponseRequest(
//            ((IReadOnlyDictionary<string, string>)metadata) ?? new Dictionary<string, string>(),
//            temperature,
//            null,
//            user,
//            null,
//            null,
//            reasoning,
//            background,
//            null,
//            null,
//            text,
//            null,
//            prompt,
//            truncation,
//            include?.ToList() as IList<Includable> ?? new ChangeTrackingList<Includable>(),
//            null,
//            store,
//            instructions,
//            stream,
//            conversation,
//            model,
//            agent,
//            input,
//            tools?.ToList() as IList<AgentTool> ?? new ChangeTrackingList<AgentTool>(),
//            null);
//        Response result = await CreateResponseAsync(spreadModel, cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
//        return Response.FromValue((AgentResponse)result, result);
//    }
//}
