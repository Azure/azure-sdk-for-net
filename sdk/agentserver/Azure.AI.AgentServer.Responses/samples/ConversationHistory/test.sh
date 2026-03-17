#!/usr/bin/env bash
# Test script for the ConversationHistory sample.
# Multi-turn conversation using previous_response_id:
#   Turn 1: Initial message — no history
#   Turn 2: Chains via previous_response_id — sees Turn 1 output
#   Turn 3: Chains again — sees Turn 1 + Turn 2 output
#   Turn 4: Streaming mode with chained history
SAMPLE_NAME="ConversationHistory"
SAMPLE_PORT=5103
source "$(dirname "$0")/../test-helpers.sh"

start_sample_server

echo "--- Turn 1: Initial message (no history) ---"
http POST /responses '{
    "model": "test",
    "input": "Hello, I am Alice."
  }'

RESPONSE_1_ID=$(echo "$HTTP_BODY" | jq -r '.id')
echo "Response 1 ID: $RESPONSE_1_ID"
echo ""

echo "--- Turn 2: Chain via previous_response_id (sees Turn 1 history) ---"
http POST /responses "{
    \"model\": \"test\",
    \"input\": \"What is 2 + 2?\",
    \"previous_response_id\": \"$RESPONSE_1_ID\"
  }"

RESPONSE_2_ID=$(echo "$HTTP_BODY" | jq -r '.id')
echo "Response 2 ID: $RESPONSE_2_ID"
echo ""

echo "--- Turn 3: Chain again (sees Turn 1 + Turn 2 history) ---"
http POST /responses "{
    \"model\": \"test\",
    \"input\": \"Thanks for the help!\",
    \"previous_response_id\": \"$RESPONSE_2_ID\"
  }"

RESPONSE_3_ID=$(echo "$HTTP_BODY" | jq -r '.id')
echo "Response 3 ID: $RESPONSE_3_ID"
echo ""

echo "--- Turn 4: Streaming with chained history ---"
http_stream POST /responses "{
    \"model\": \"test\",
    \"stream\": true,
    \"input\": \"One more thing.\",
    \"previous_response_id\": \"$RESPONSE_3_ID\"
  }"

pass
