/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Adding a new customer and then serve the customer
        // Expected Result: Error when trying to serve the customer
        Console.WriteLine("Test 1");

        var newCustSize = new CustomerService(0);
        newCustSize.AddNewCustomer();
        newCustSize.ServeCustomer();
        newCustSize.ServeCustomer();
        Console.WriteLine(newCustSize);


        // Defect(s) Found: In ServeCustomer, customer was being pulled before being served.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Trying to add too many customers than the queue size
        // Expected Result: Will get error message past the queue size
        Console.WriteLine("Test 2");

        var newCustSize2 = new CustomerService(3);
        
        for (int i = 0; i < 5; i++) {
            newCustSize2.AddNewCustomer();
        }

        Console.WriteLine(newCustSize2.ToString());

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) { 
            // Does this actually catch when there are more customers than the max count?
            // Updated this to check that max size has not been reached prior to adding a new customer.
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count() == 0) {
            Console.WriteLine("There are no more customers in the queue. Good Job!");
            return;
        } // Added error message for no customers in queue - FIXED

        // Removing the customer before accessing the information - FIXED
        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0); 
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}