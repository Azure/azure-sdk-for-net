import json
import requests

url = "http://localhost:8088/responses"
stream = False


input = "What is 3 plus 5?"
payload = {
    "agent": {"name": "local_agent", "type": "agent_reference"},
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
except Exception as e:
    print(f"Error: {e}")

print("\n\n")

print(f"conversation_id: {conversation_id}")

if not conversation_id:
    print("Failed to parse conversation_id")
else:
    payload = {
        "agent": {"name": "local_agent", "type": "agent_reference"},
        "stream": stream,
        "input": "What is the previous answer you provided?",
        "conversation": {"id": conversation_id}
    }

    try:
        print("\n\n2nd input...")
        print(json.dumps(payload, indent=2))
        response = requests.post(url, json=payload)
        response.raise_for_status()  # Raise an error for HTTP errors
        print("\n\nagent response:")
        print(json.dumps(response.json(), indent=2))
    except Exception as e:
        print(f"Error: {e}")
