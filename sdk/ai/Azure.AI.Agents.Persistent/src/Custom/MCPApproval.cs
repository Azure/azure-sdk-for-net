// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Agents.Persistent
{
    public class MCPApproval
    {
        private static readonly string ALWAYS = "always";
        private static readonly string NEVER = "never";
        private static readonly ModelReaderWriterOptions s_options = new("W");

        private readonly string _forAllToolsApproval = default;
        /// <summary>
        /// Create an instance of an MCPApproval with custom trust levels for different tools.
        /// </summary>
        /// <param name="perToolApproval">The object, describing, which tools never require approvals and which tools always require approvals.</param>
        public MCPApproval(MCPApprovalPerTool perToolApproval)
        {
            if (perToolApproval == null)
            {
                _forAllToolsApproval = ALWAYS;
            }
            else
            {
                // Correct for 500 error, if the MCPList contains an empty array.
                // Server may return 500 if we send the empty array of always requiring approval tools
                // and non empty array of never requiring approval tools.
                if (perToolApproval.Always is not null && perToolApproval.Always.ToolNames.Count == 0)
                {
                    perToolApproval.Always = null;
                }
                if (perToolApproval.Never is not null && perToolApproval.Never.ToolNames.Count == 0)
                {
                    perToolApproval.Never = null;
                }
                if (perToolApproval.Always == null && perToolApproval.Never == null)
                {
                    _forAllToolsApproval = ALWAYS;
                }
                else
                {
                    PerToolApproval = perToolApproval;
                }
            }
        }

        /// <summary>
        /// Create an instance of an MCPApproval with trust level, equal for all tools.
        /// </summary>
        /// <param name="trust">The trust level, can be "always" or "never"</param>
        public MCPApproval(string trust)
        {
            if (!string.Equals(trust, ALWAYS) && !string.Equals(trust, NEVER))
                throw new ArgumentException($"The parameter \"trust\" may be only \"{ALWAYS}\" or \"{NEVER}\".");
            _forAllToolsApproval = trust;
        }
        /// <summary>
        /// Return true if we do not trust all tools and always need to ask for approval before sending data to server.
        /// </summary>
        public bool AlwaysRequireApproval{get => string.Equals(_forAllToolsApproval, ALWAYS);}
        /// <summary>
        /// Return true if we trust all tools and do not need to ask for approval before sending data to server.
        /// </summary>
        public bool NeverRequireApproval { get => string.Equals(_forAllToolsApproval, NEVER); }

        /// <summary>
        /// Return the object, describing, which tools always require approval and which do not need it.
        /// </summary>
        public MCPApprovalPerTool PerToolApproval { get; } = null;

        internal BinaryData ToBinaryData()
        {
            if (AlwaysRequireApproval || NeverRequireApproval)
            {
                return BinaryData.FromString(
                    JsonSerializer.Serialize(
                        _forAllToolsApproval,
                        StringSerializerContext.Default.String
                    )
                );
            }
            return ((IPersistableModel<MCPApprovalPerTool>)PerToolApproval).Write(s_options);
        }

        internal static MCPApproval FromBinaryData(BinaryData data)
        {
            if (data is null)
            {
                return null;
            }
            string dataString = data.ToString().Trim('"');
            if (string.Equals(dataString, ALWAYS) || string.Equals(dataString, NEVER))
            {
                return new MCPApproval(dataString);
            }
            return new MCPApproval(
                ((IPersistableModel<MCPApprovalPerTool>)new MCPApprovalPerTool()).Create(data, s_options)
            );
        }
    }
}
