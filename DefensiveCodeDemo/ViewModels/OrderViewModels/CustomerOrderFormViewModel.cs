using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefensiveCodeDemo.Models.OrderViewModel
{
    public class CustomerOrderFormViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = "Test";

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = "Test";

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = "test@example.com";

        public List<OrderInventory> OrderInventory { get; set; }

        public IEnumerable<Inventory> InventoryList { get; set; } = new List<Inventory>();

        public string Error { get; set; }

        public Customer CreateCustomerObject()
        {
            var customer = new Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };

            return customer;
        }
    }
}
