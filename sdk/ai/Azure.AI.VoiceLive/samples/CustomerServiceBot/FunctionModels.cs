// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Request models for customer service functions.
/// </summary>
public static class FunctionModels
{
    /// <summary>
    /// Parameters for checking order status.
    /// </summary>
    public class CheckOrderStatusArgs
    {
        /// <summary>
        /// The order number to check status for.
        /// </summary>
        public string order_number { get; set; } = string.Empty;
        /// <summary>
        /// Customer email.
        /// </summary>
        public string? email { get; set; }
    }

    /// <summary>
    /// Parameters for getting customer information.
    /// </summary>
    public class GetCustomerInfoArgs
    {
        /// <summary>
        /// Customer ID to retrieve information for.
        /// </summary>
        public string customer_id { get; set; } = string.Empty;
        /// <summary>
        /// Whether to include order history in the response.
        /// </summary>
        public bool include_history { get; set; } = false;
    }

    /// <summary>
    /// Parameters for scheduling support calls.
    /// </summary>
    public class ScheduleSupportCallArgs
    {
        /// <summary>
        /// The customer ID to schedule the call for.
        /// </summary>
        public string customer_id { get; set; } = string.Empty;
        /// <summary>
        /// The preferred time for the support call.
        /// </summary>
        public string? preferred_time { get; set; }
        /// <summary>
        /// The category of the support issue.
        /// </summary>
        public string issue_category { get; set; } = string.Empty;
        /// <summary>
        /// The urgency level of the support issue.
        /// </summary>
        public string urgency { get; set; } = "medium";
        /// <summary>
        /// A brief description of the issue.
        /// </summary>
        public string description { get; set; } = string.Empty;
    }

    /// <summary>
    /// Parameters for initiating return process.
    /// </summary>
    public class InitiateReturnProcessArgs
    {
        /// <summary>
        /// The order number for which the return is requested.
        /// </summary>
        public string order_number { get; set; } = string.Empty;
        /// <summary>
        /// The product ID to be returned.
        /// </summary>
        public string product_id { get; set; } = string.Empty;
        /// <summary>
        /// The reason for the return.
        /// </summary>
        public string reason { get; set; } = string.Empty;
        /// <summary>
        /// The return method preferred by the customer.
        /// </summary>
        public string return_type { get; set; } = string.Empty;
    }

    /// <summary>
    /// Address information for shipping updates.
    /// </summary>
    public class Address
    {
        /// <summary>
        ///  Street address for shipping.
        /// </summary>
        public string street { get; set; } = string.Empty;
        /// <summary>
        ///  City for shipping address.
        /// </summary>
        public string city { get; set; } = string.Empty;
        /// <summary>
        /// state for shipping address.
        /// </summary>
        public string state { get; set; } = string.Empty;
        /// <summary>
        /// zip code for shipping address.
        /// </summary>
        public string zip_code { get; set; } = string.Empty;
        /// <summary>
        /// Country for shipping address.
        /// </summary>
        public string country { get; set; } = "US";
    }

    /// <summary>
    /// Parameters for updating shipping address.
    /// </summary>
    public class UpdateShippingAddressArgs
    {
        /// <summary>
        /// Order number for which the address needs to be updated.
        /// </summary>
        public string order_number { get; set; } = string.Empty;
        /// <summary>
        /// New shipping address.
        /// </summary>
        public Address new_address { get; set; } = new();
    }
}

/// <summary>
/// Sample data models for demonstration purposes.
/// </summary>
public static class SampleData
{
    /// <summary>
    /// Sample order information.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The unique identifier for the order.
        /// </summary>
        public string OrderNumber { get; set; } = string.Empty;
        /// <summary>
        /// Status of the order.
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Total amount for the order.
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// The items included in the order.
        /// </summary>
        public List<OrderItem> Items { get; set; } = new();
        /// <summary>
        /// Estimated delivery date for the order.
        /// </summary>
        public DateTime? EstimatedDelivery { get; set; }
        /// <summary>
        /// Shipping tracking number, if available.
        /// </summary>
        public string? TrackingNumber { get; set; }
        /// <summary>
        /// Theustomer ID associated with the order.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;
        /// <summary>
        /// When the order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Sample order item information.
    /// </summary>
    public class OrderItem
    {
        /// <summary>
        /// The unique identifier for the product.
        /// </summary>
        public string ProductId { get; set; } = string.Empty;
        /// <summary>
        /// Name of the product.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;
        /// <summary>
        /// quantity of the product ordered.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// status of the order item.
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// price of the product.
        /// </summary>
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Sample customer information.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// customer ID.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;
        /// <summary>
        /// preferred name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// customer's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// phone number of the customer.
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// customer's pricing tier.
        /// </summary>
        public string Tier { get; set; } = "Standard";
        /// <summary>
        /// When the customer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Sample support ticket information.
    /// </summary>
    public class SupportTicket
    {
        /// <summary>
        /// ID of the support ticket.
        /// </summary>
        public string TicketId { get; set; } = string.Empty;
        /// <summary>
        /// customer ID associated with the ticket.
        /// </summary>
        public string CustomerId { get; set; } = string.Empty;
        /// <summary>
        /// category of the support issue.
        /// </summary>
        public string Category { get; set; } = string.Empty;
        /// <summary>
        /// urgency level of the support issue.
        /// </summary>
        public string Urgency { get; set; } = string.Empty;
        /// <summary>
        /// brief description of the issue.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// time when the ticket was created.
        /// </summary>
        public DateTime ScheduledTime { get; set; }
        /// <summary>
        /// current status of the support ticket.
        /// </summary>
        public string Status { get; set; } = "Scheduled";
    }
}
