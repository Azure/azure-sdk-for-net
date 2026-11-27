import json

import azure.functions as func

app = func.FunctionApp()


@app.queue_trigger(arg_name="msg", queue_name="%STORAGE_INPUT_QUEUE_NAME%", connection="STORAGE_CONNECTION")
@app.queue_output(arg_name="output_queue", queue_name="%STORAGE_OUTPUT_QUEUE_NAME%", connection="STORAGE_CONNECTION")
def queue_trigger(msg: func.QueueMessage, output_queue: func.Out[str]) -> None:
    payload = json.loads(msg.get_body().decode("utf-8"))
    location = payload["function_args"]["location"]
    output_queue.set(
        json.dumps(
            {
                "Value": f"Weather is {len(location)} degrees and sunny in {location}",
                "CorrelationId": payload["CorrelationId"],
            }
        )
    )
