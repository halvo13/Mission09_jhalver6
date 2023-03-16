using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_jhalver6.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage ="Please enter a name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter your city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your zipcode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
    }
}
