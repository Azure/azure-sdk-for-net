
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The controller power state change request.
    /// </summary>
    [JsonTransformation]
    public partial class ControllerPowerStateChangeRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the ControllerPowerStateChangeRequest
        /// class.
        /// </summary>
        public ControllerPowerStateChangeRequest() { }

        /// <summary>
        /// Initializes a new instance of the ControllerPowerStateChangeRequest
        /// class.
        /// </summary>
        /// <param name="action">The power state that the request is expecting
        /// for the controller of the device. Possible values include: 'Start',
        /// 'Restart', 'Shutdown'</param>
        /// <param name="activeController">The active controller that the
        /// request is expecting on the device. Possible values include:
        /// 'Unknown', 'None', 'Controller0', 'Controller1'</param>
        /// <param name="controller0State">The controller 0's status that the
        /// request is expecting on the device. Possible values include:
        /// 'NotPresent', 'PoweredOff', 'Ok', 'Recovering', 'Warning',
        /// 'Failure'</param>
        /// <param name="controller1State">The controller 1's status that the
        /// request is expecting on the device. Possible values include:
        /// 'NotPresent', 'PoweredOff', 'Ok', 'Recovering', 'Warning',
        /// 'Failure'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public ControllerPowerStateChangeRequest(ControllerPowerStateAction action, ControllerId activeController, ControllerStatus controller0State, ControllerStatus controller1State, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
            : base(id, name, type, kind)
        {
            Action = action;
            ActiveController = activeController;
            Controller0State = controller0State;
            Controller1State = controller1State;
        }

        /// <summary>
        /// Gets or sets the power state that the request is expecting for the
        /// controller of the device. Possible values include: 'Start',
        /// 'Restart', 'Shutdown'
        /// </summary>
        [JsonProperty(PropertyName = "properties.action")]
        public ControllerPowerStateAction Action { get; set; }

        /// <summary>
        /// Gets or sets the active controller that the request is expecting on
        /// the device. Possible values include: 'Unknown', 'None',
        /// 'Controller0', 'Controller1'
        /// </summary>
        [JsonProperty(PropertyName = "properties.activeController")]
        public ControllerId ActiveController { get; set; }

        /// <summary>
        /// Gets or sets the controller 0's status that the request is
        /// expecting on the device. Possible values include: 'NotPresent',
        /// 'PoweredOff', 'Ok', 'Recovering', 'Warning', 'Failure'
        /// </summary>
        [JsonProperty(PropertyName = "properties.controller0State")]
        public ControllerStatus Controller0State { get; set; }

        /// <summary>
        /// Gets or sets the controller 1's status that the request is
        /// expecting on the device. Possible values include: 'NotPresent',
        /// 'PoweredOff', 'Ok', 'Recovering', 'Warning', 'Failure'
        /// </summary>
        [JsonProperty(PropertyName = "properties.controller1State")]
        public ControllerStatus Controller1State { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

