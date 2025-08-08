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
        public string order_number { get; set; } = string.Empty;
        public string? email { get; set; }
    }

    /// <summary>
    /// Parameters for getting customer information.
    /// </summary>
    public class GetCustomerInfoArgs
    {
        public string customer_id { get; set; } = string.Empty;
        public bool include_history { get; set; } = false;
    }

    /// <summary>
    /// Parameters for scheduling support calls.
    /// </summary>
    public class ScheduleSupportCallArgs
    {
        public string customer_id { get; set; } = string.Empty;
        public string? preferred_time { get; set; }
        public string issue_category { get; set; } = string.Empty;
        public string urgency { get; set; } = "medium";
        public string description { get; set; } = string.Empty;
    }

    /// <summary>
    /// Parameters for initiating return process.
    /// </summary>
    public class InitiateReturnProcessArgs
    {
        public string order_number { get; set; } = string.Empty;
        public string product_id { get; set; } = string.Empty;
        public string reason { get; set; } = string.Empty;
        public string return_type { get; set; } = string.Empty;
    }

    /// <summary>
    /// Address information for shipping updates.
    /// </summary>
    public class Address
    {
        public string street { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string state { get; set; } = string.Empty;
        public string zip_code { get; set; } = string.Empty;
        public string country { get; set; } = "US";
    }

    /// <summary>
    /// Parameters for updating shipping address.
    /// </summary>
    public class UpdateShippingAddressArgs
    {
        public string order_number { get; set; } = string.Empty;
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
        public string OrderNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public DateTime? EstimatedDelivery { get; set; }
        public string? TrackingNumber { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Sample order item information.
    /// </summary>
    public class OrderItem
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Sample customer information.
    /// </summary>
    public class Customer
    {
        public string CustomerId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Tier { get; set; } = "Standard";
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Sample support ticket information.
    /// </summary>
    public class SupportTicket
    {
        public string TicketId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ScheduledTime { get; set; }
        public string Status { get; set; } = "Scheduled";
    }
}