namespace Microsoft.WindowsAzure.Management.ExpressRoute.Testing
{
    using Azure.Test;

    [UndoHandlerFactory]
    public static class UndoContextDiscoveryExtensions
    {
        public static OperationUndoHandler CreateDedicatedCircuitUndoHandler()
        {
            return new DedicatedCircuitUndoHandler();
        }

        public static OperationUndoHandler CreateBorderGatewayProtocolPeeringUndoHandler()
        {
            return new BorderGatewayProtocolPeeringUndoHandler();
        }

        public static OperationUndoHandler CreateDedicatedCircuitLinkUndoHandler()
        {
            return new DedicatedCircuitLinkUndoHandler();
        }

        public static OperationUndoHandler CreateCrossConnectionUndoHandler()
        {
            return new CrossConnectionUndoHandler();
        }

        public static OperationUndoHandler CreateDedicatedCircuitLinkAuthorizationMicrosoftIdUndoHandler()
        {
            return new DedicatedCircuitLinkAuthorizationMicrosoftIdUndoHandler();
        }

        public static OperationUndoHandler CreateDedicatedCircuitLinkAuthorizationUndoHandler()
        {
            return new DedicatedCircuitLinkAuthorizationUndoHandler();
        }
    }
}
