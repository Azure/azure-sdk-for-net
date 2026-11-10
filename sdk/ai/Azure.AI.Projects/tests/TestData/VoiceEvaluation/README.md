# Synthetic voice-evaluation fixture

`conversation.wav` is synthetic speech generated locally with Windows Speech
Synthesizer (Microsoft David Desktop), PCM 16 kHz, 16-bit, mono. It contains no
customer data:

- User: “When do you close?”
- Assistant: “We close at nine PM.”

The live sample uploads this file and builds a matching JSONL row. The fixture
is copied to the test output directory; standalone callers should place it at
`TestData/VoiceEvaluation/conversation.wav` below their application's base
directory. It demonstrates setup, not evaluator quality or a passing threshold.
