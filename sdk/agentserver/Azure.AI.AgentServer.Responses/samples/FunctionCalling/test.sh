#!/usr/bin/env bash
# Test script for the FunctionCalling sample.
# Two-turn conversation using conversation_id:
#   Turn 1: server returns a get_weather function call
#   Turn 2: client submits function output, server returns weather text
SAMPLE_NAME="FunctionCalling"
SAMPLE_PORT=5101
source "$(dirname "$0")/../test-helpers.sh"

start_sample_server

CONV_ID="conv_a1b2c3d4e5f6789800WeatherConvSampleDemoRequest0001"

echo "--- Turn 1: Request function call ---"
http POST /responses "{
    \"model\": \"test\",
    \"conversation\": \"$CONV_ID\",
    \"input\": \"What is the weather in Seattle?\"
  }"

# Extract the call_id from the function call output
CALL_ID=$(echo "$HTTP_BODY" | jq -r '.output[0].call_id')
echo "Extracted call_id: $CALL_ID"
echo ""

TURN2_BODY=$(cat <<EOF
{
  "model": "test",
  "conversation": "$CONV_ID",
  "input": [{
    "type": "function_call_output",
    "call_id": "$CALL_ID",
    "output": "{\"temperature\": 72, \"condition\": \"sunny\"}"
  }]
}
EOF
)

TURN2_STREAM_BODY=$(cat <<EOF
{
  "model": "test",
  "stream": true,
  "conversation": "$CONV_ID",
  "input": [{
    "type": "function_call_output",
    "call_id": "$CALL_ID",
    "output": "{\"temperature\": 72, \"condition\": \"sunny\"}"
  }]
}
EOF
)

echo "--- Turn 2: Submit function output, get weather response ---"
http POST /responses "$TURN2_BODY"

echo "--- Turn 2 (streaming) ---"
http_stream POST /responses "$TURN2_STREAM_BODY"

pass
