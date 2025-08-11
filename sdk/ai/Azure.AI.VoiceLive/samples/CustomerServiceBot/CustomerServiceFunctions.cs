// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using static Azure.AI.VoiceLive.Samples.FunctionModels;
using static Azure.AI.VoiceLive.Samples.SampleData;

namespace Azure.AI.VoiceLive.Samples;

/// <summary>
/// Interface for customer service function execution.
/// </summary>
public interface ICustomerServiceFunctions
{
    /// <summary>
    /// Executes a function by name with JSON arguments.
    /// </summary>
    /// <param name="functionName"></param>
    /// <param name="argumentsJson"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<object> ExecuteFunctionAsync(string functionName, string argumentsJson, CancellationToken cancellationToken = default);
}

/// <summary>
/// Implementation of customer service functions with mock data for demonstration.
/// In a real implementation, these would connect to actual databases and services.
/// </summary>
public class CustomerServiceFunctions : ICustomerServiceFunctions
{
    private readonly ILogger<CustomerServiceFunctions> _logger;
    private readonly Dictionary<string, Order> _orders;
    private readonly Dictionary<string, Customer> _customers;
    private readonly List<SupportTicket> _supportTickets;

    /// <summary>
    /// Constructor for CustomerServiceFunctions.
    /// </summary>
    /// <param name="logger"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public CustomerServiceFunctions(ILogger<CustomerServiceFunctions> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        // Initialize sample data
        _orders = InitializeSampleOrders();
        _customers = InitializeSampleCustomers();
        _supportTickets = new List<SupportTicket>();
    }

    /// <summary>
    /// Execute a function by name with JSON arguments.
    /// </summary>
    public async Task<object> ExecuteFunctionAsync(string functionName, string argumentsJson, CancellationToken cancellationToken = default)
    {
        try
        {
            _logger.LogInformation("Executing function: {FunctionName} with arguments: {Arguments}", functionName, argumentsJson);

            return functionName switch
            {
                "check_order_status" => await CheckOrderStatusAsync(argumentsJson, cancellationToken).ConfigureAwait(false),
                "get_customer_info" => await GetCustomerInfoAsync(argumentsJson, cancellationToken).ConfigureAwait(false),
                "schedule_support_call" => await ScheduleSupportCallAsync(argumentsJson, cancellationToken).ConfigureAwait(false),
                "initiate_return_process" => await InitiateReturnProcessAsync(argumentsJson, cancellationToken).ConfigureAwait(false),
                "update_shipping_address" => await UpdateShippingAddressAsync(argumentsJson, cancellationToken).ConfigureAwait(false),
                _ => new { success = false, error = $"Unknown function: {functionName}" }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing function {FunctionName}", functionName);
            return new { success = false, error = "Internal error occurred while processing your request." };
        }
    }

    private async Task<object> CheckOrderStatusAsync(string argumentsJson, CancellationToken cancellationToken)
    {
        var args = JsonSerializer.Deserialize<CheckOrderStatusArgs>(argumentsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (args == null)
        {
            return new { success = false, message = "Invalid arguments provided." };
        }

        // Simulate async database lookup
        await Task.Delay(100, cancellationToken).ConfigureAwait(false);

        if (!_orders.TryGetValue(args.order_number, out var order))
        {
            return new
            {
                success = false,
                message = "Order not found. Please verify the order number and try again."
            };
        }

        return new
        {
            success = true,
            order = new
            {
                number = order.OrderNumber,
                status = order.Status,
                total = order.TotalAmount,
                items = order.Items.Select(item => new
                {
                    name = item.ProductName,
                    quantity = item.Quantity,
                    status = item.Status,
                    price = item.Price
                }),
                estimated_delivery = order.EstimatedDelivery?.ToString("yyyy-MM-dd"),
                tracking = order.TrackingNumber,
                order_date = order.CreatedAt.ToString("yyyy-MM-dd")
            }
        };
    }

    private async Task<object> GetCustomerInfoAsync(string argumentsJson, CancellationToken cancellationToken)
    {
        var args = JsonSerializer.Deserialize<GetCustomerInfoArgs>(argumentsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (args == null)
        {
            return new { success = false, message = "Invalid arguments provided." };
        }

        // Simulate async database lookup
        await Task.Delay(150, cancellationToken).ConfigureAwait(false);

        var customer = _customers.Values.FirstOrDefault(c =>
            c.CustomerId == args.customer_id ||
            c.Email.Equals(args.customer_id, StringComparison.OrdinalIgnoreCase));

        if (customer == null)
        {
            return new
            {
                success = false,
                message = "Customer account not found. Please verify the customer ID or email address."
            };
        }

        var result = new
        {
            success = true,
            customer = new
            {
                id = customer.CustomerId,
                name = customer.Name,
                email = customer.Email,
                phone = customer.Phone,
                tier = customer.Tier,
                joined_date = customer.CreatedAt.ToString("yyyy-MM-dd")
            }
        };

        if (args.include_history)
        {
            var customerOrders = _orders.Values
                .Where(o => o.CustomerId == customer.CustomerId)
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .Select(order => new
                {
                    number = order.OrderNumber,
                    date = order.CreatedAt.ToString("yyyy-MM-dd"),
                    total = order.TotalAmount,
                    status = order.Status
                });

            return new
            {
                result.success,
                customer = new
                {
                    result.customer.id,
                    result.customer.name,
                    result.customer.email,
                    result.customer.phone,
                    result.customer.tier,
                    result.customer.joined_date,
                    recent_orders = customerOrders
                }
            };
        }

        return result;
    }

    private async Task<object> ScheduleSupportCallAsync(string argumentsJson, CancellationToken cancellationToken)
    {
        var args = JsonSerializer.Deserialize<ScheduleSupportCallArgs>(argumentsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (args == null)
        {
            return new { success = false, message = "Invalid arguments provided." };
        }

        // Validate customer exists
        var customer = _customers.Values.FirstOrDefault(c =>
            c.CustomerId == args.customer_id ||
            c.Email.Equals(args.customer_id, StringComparison.OrdinalIgnoreCase));

        if (customer == null)
        {
            return new
            {
                success = false,
                message = "Customer not found. Please verify the customer ID."
            };
        }

        // Simulate async scheduling system
        await Task.Delay(200, cancellationToken).ConfigureAwait(false);

        // Parse preferred time or use default
        DateTime scheduledTime;
        if (!string.IsNullOrEmpty(args.preferred_time) && DateTime.TryParse(args.preferred_time, out scheduledTime))
        {
            // Use provided time
        }
        else
        {
            // Default to next business day at 10 AM
            scheduledTime = DateTime.Today.AddDays(1);
            if (scheduledTime.DayOfWeek == DayOfWeek.Saturday)
                scheduledTime = scheduledTime.AddDays(2);
            if (scheduledTime.DayOfWeek == DayOfWeek.Sunday)
                scheduledTime = scheduledTime.AddDays(1);
            scheduledTime = scheduledTime.AddHours(10);
        }

        var ticket = new SupportTicket
        {
            TicketId = $"TICKET-{DateTime.Now:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}",
            CustomerId = customer.CustomerId,
            Category = args.issue_category,
            Urgency = args.urgency,
            Description = args.description,
            ScheduledTime = scheduledTime,
            Status = "Scheduled"
        };

        _supportTickets.Add(ticket);

        return new
        {
            success = true,
            ticket = new
            {
                ticket_id = ticket.TicketId,
                customer_name = customer.Name,
                scheduled_time = ticket.ScheduledTime.ToString("yyyy-MM-dd HH:mm"),
                category = ticket.Category,
                urgency = ticket.Urgency,
                description = ticket.Description,
                status = ticket.Status
            },
            message = $"Support call scheduled for {ticket.ScheduledTime:yyyy-MM-dd HH:mm}. You will receive a confirmation email shortly."
        };
    }

    private async Task<object> InitiateReturnProcessAsync(string argumentsJson, CancellationToken cancellationToken)
    {
        var args = JsonSerializer.Deserialize<InitiateReturnProcessArgs>(argumentsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (args == null)
        {
            return new { success = false, message = "Invalid arguments provided." };
        }

        // Simulate async database lookup
        await Task.Delay(150, cancellationToken).ConfigureAwait(false);

        if (!_orders.TryGetValue(args.order_number, out var order))
        {
            return new
            {
                success = false,
                message = "Order not found. Please verify the order number."
            };
        }

        var item = order.Items.FirstOrDefault(i => i.ProductId == args.product_id);
        if (item == null)
        {
            return new
            {
                success = false,
                message = "Product not found in this order."
            };
        }

        // Check if return is eligible (within 30 days and not already returned)
        if (order.CreatedAt < DateTime.Now.AddDays(-30))
        {
            return new
            {
                success = false,
                message = "This order is outside the 30-day return window."
            };
        }

        if (item.Status == "Returned")
        {
            return new
            {
                success = false,
                message = "This item has already been returned."
            };
        }

        var returnId = $"RTN-{DateTime.Now:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";

        return new
        {
            success = true,
            return_info = new
            {
                return_id = returnId,
                order_number = order.OrderNumber,
                product_name = item.ProductName,
                return_type = args.return_type,
                reason = args.reason,
                refund_amount = args.return_type == "refund" ? item.Price : 0,
                estimated_processing = "3-5 business days",
                return_label_url = $"https://returns.techcorp.com/label/{returnId}"
            },
            message = "Return request initiated successfully. You will receive a return shipping label via email within 24 hours."
        };
    }

    private async Task<object> UpdateShippingAddressAsync(string argumentsJson, CancellationToken cancellationToken)
    {
        var args = JsonSerializer.Deserialize<UpdateShippingAddressArgs>(argumentsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (args == null)
        {
            return new { success = false, message = "Invalid arguments provided." };
        }

        // Simulate async database lookup
        await Task.Delay(100, cancellationToken).ConfigureAwait(false);

        if (!_orders.TryGetValue(args.order_number, out var order))
        {
            return new
            {
                success = false,
                message = "Order not found. Please verify the order number."
            };
        }

        // Check if order can be modified
        if (order.Status == "Delivered" || order.Status == "Shipped")
        {
            return new
            {
                success = false,
                message = $"Cannot update address for {order.Status.ToLower()} orders."
            };
        }

        return new
        {
            success = true,
            updated_order = new
            {
                order_number = order.OrderNumber,
                status = order.Status,
                new_shipping_address = new
                {
                    args.new_address.street,
                    args.new_address.city,
                    args.new_address.state,
                    args.new_address.zip_code,
                    args.new_address.country
                },
                estimated_delivery = order.EstimatedDelivery?.AddDays(1).ToString("yyyy-MM-dd") // Adjust delivery date
            },
            message = "Shipping address updated successfully. Your estimated delivery date may have changed."
        };
    }

    private Dictionary<string, Order> InitializeSampleOrders()
    {
        return new Dictionary<string, Order>
        {
            ["ORD-2024-001"] = new Order
            {
                OrderNumber = "ORD-2024-001",
                Status = "Processing",
                TotalAmount = 299.99m,
                CustomerId = "CUST-001",
                CreatedAt = DateTime.Now.AddDays(-2),
                EstimatedDelivery = DateTime.Now.AddDays(3),
                TrackingNumber = "1Z999AA1234567890",
                Items = new List<OrderItem>
                {
                    new() { ProductId = "LAPTOP-001", ProductName = "TechCorp Laptop Pro", Quantity = 1, Status = "Processing", Price = 299.99m }
                }
            },
            ["ORD-2024-002"] = new Order
            {
                OrderNumber = "ORD-2024-002",
                Status = "Shipped",
                TotalAmount = 159.98m,
                CustomerId = "CUST-002",
                CreatedAt = DateTime.Now.AddDays(-5),
                EstimatedDelivery = DateTime.Now.AddDays(1),
                TrackingNumber = "1Z999AA1234567891",
                Items = new List<OrderItem>
                {
                    new() { ProductId = "MOUSE-001", ProductName = "Wireless Gaming Mouse", Quantity = 1, Status = "Shipped", Price = 79.99m },
                    new() { ProductId = "PAD-001", ProductName = "Gaming Mouse Pad", Quantity = 1, Status = "Shipped", Price = 79.99m }
                }
            },
            ["ORD-2024-003"] = new Order
            {
                OrderNumber = "ORD-2024-003",
                Status = "Delivered",
                TotalAmount = 499.99m,
                CustomerId = "CUST-001",
                CreatedAt = DateTime.Now.AddDays(-10),
                EstimatedDelivery = DateTime.Now.AddDays(-3),
                TrackingNumber = "1Z999AA1234567892",
                Items = new List<OrderItem>
                {
                    new() { ProductId = "MONITOR-001", ProductName = "4K Gaming Monitor", Quantity = 1, Status = "Delivered", Price = 499.99m }
                }
            }
        };
    }

    private Dictionary<string, Customer> InitializeSampleCustomers()
    {
        return new Dictionary<string, Customer>
        {
            ["CUST-001"] = new Customer
            {
                CustomerId = "CUST-001",
                Name = "John Smith",
                Email = "john.smith@email.com",
                Phone = "+1-555-0123",
                Tier = "Gold",
                CreatedAt = DateTime.Now.AddMonths(-8)
            },
            ["CUST-002"] = new Customer
            {
                CustomerId = "CUST-002",
                Name = "Sarah Johnson",
                Email = "sarah.johnson@email.com",
                Phone = "+1-555-0124",
                Tier = "Silver",
                CreatedAt = DateTime.Now.AddMonths(-3)
            },
            ["CUST-003"] = new Customer
            {
                CustomerId = "CUST-003",
                Name = "Mike Davis",
                Email = "mike.davis@email.com",
                Phone = "+1-555-0125",
                Tier = "Standard",
                CreatedAt = DateTime.Now.AddMonths(-1)
            }
        };
    }
}
