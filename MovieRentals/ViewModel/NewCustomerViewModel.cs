using MovieRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentals.ViewModel
{
    public class NewCustomerViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customers { get; set; }
        public String Title
        {
            get
            {
                if (Customers != null && Customers.Id != 0)
                    return "Edit Customer";

                return "New Customer";



            }
        }
    }
}