# Copyright (c) Microsoft Corporation.
# Licensed under the MIT license.
"""Sample 01 — Getting Started (echo handler).

Simplest possible handler: reads the user's input text and echoes it back
as a single non-streaming message using ``TextResponse``.

``TextResponse`` handles the full SSE lifecycle automatically:
``response.created`` → ``response.in_progress`` → message/content events
→ ``response.completed``.

Usage::

    # Start the server
    python sample_01_getting_started.py

    # Send a request
    curl -X POST http://localhost:8088/responses \
        -H "Content-Type: application/json" \
        -d '{"model": "echo", "input": "Hello, world!"}'
    # -> {"id": "...", "status": "completed", "output": [{"type": "message",
    #     "content": [{"type": "output_text", "text": "Echo: Hello, world!"}]}]}

    # Stream the response
    curl -N -X POST http://localhost:8088/responses \
        -H "Content-Type: application/json" \
        -d '{"model": "echo", "input": "Hello, world!", "stream": true}'
    # -> event: response.created            data: {"response": {"status": "in_progress", ...}}
    # -> event: response.in_progress        data: {"response": {"status": "in_progress", ...}}
    # -> event: response.output_item.added  data: {"item": {"type": "message", ...}}
    # -> event: response.content_part.added data: {"part": {"type": "output_text", ...}}
    # -> event: response.output_text.delta  data: {"delta": "Echo: Hello, world!"}
    # -> event: response.output_text.done   data: {"text": "Echo: Hello, world!"}
    # -> event: response.content_part.done  data: {"part": {"type": "output_text", ...}}
    # -> event: response.output_item.done   data: {"item": {"type": "message", ...}}
    # -> event: response.completed          data: {"response": {"status": "completed", ...}}
"""

import asyncio

from azure.ai.agentserver.responses import (
    CreateResponse,
    ResponseContext,
    ResponsesAgentServerHost,
    TextResponse,
)

app = ResponsesAgentServerHost()


@app.response_handler
async def handler(request: CreateResponse, context: ResponseContext, cancellation_signal: asyncio.Event):
    """Echo the user's input back as a single message."""
    input_text = await context.get_input_text()
    return TextResponse(context, request, text=f"Echo: {input_text}")


def main() -> None:
    app.run()


if __name__ == "__main__":
    main()
