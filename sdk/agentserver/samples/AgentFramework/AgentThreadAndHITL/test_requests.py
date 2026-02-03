import json
import requests

url = "http://localhost:8088/responses"
stream = False


input = "What is the weather like in Vancouver?"
payload = {
    "agent": {"name": "local_agent", "type": "agent_reference"},
    "tools": [],
    "stream": stream,
    "input": input,
}

call_id = None
conversation_id = None

try:
    response = requests.post(url, json=payload)

    response.raise_for_status()  # Raise an error for HTTP errors
    response_detail = None

    print(json.dumps(response.json(), indent=2))
    response_detail = response.json()
    
    conversation_id = response_detail.get("conversation", {}).get("id")
    output = response_detail.get("output", [])
    for item in output:
        if item.get("type") == "function_call" and item.get("name") == "__hosted_agent_adapter_hitl__":
            call_id = item.get("call_id")
            request_detail = json.loads(item.get("arguments", "{}"))
except Exception as e:
    print(f"Error: {e}")

print("\n\n")

print(f"conversation_id: {conversation_id}")
print(f"call_id: {call_id}")

if not conversation_id or not call_id:
    print("Failed to parse hitl request info")
else:
    human_feedback = {
        "call_id": call_id,
        "output": "approve",
        "type": "function_call_output",
    }

    feedback_payload = {
        "agent": {"name": "local_agent", "type": "agent_reference"},
        "tools": [],
        "stream": stream,
        "input": [human_feedback],
        "conversation": {"id": conversation_id}
    }

    try:
        print("\n\nsending feedback...")
        print(json.dumps(feedback_payload, indent=2))
        response = requests.post(url, json=feedback_payload)
        response.raise_for_status()  # Raise an error for HTTP errors
        print("\n\nagent response:")
        print(json.dumps(response.json(), indent=2))
    except Exception as e:
        print(f"Error: {e}")
