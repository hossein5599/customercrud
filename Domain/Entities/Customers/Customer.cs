using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Customers
{
   public class Customer : BaseEntity
    {
        //آیدی را از بیس انتیتی میگیرد

     


        public string FirstName { get; set; }

        public string LastName { get; set; }


        public DateTime? DateOfBirth { get; set; }

       
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BankAccountNumber { get; set; }


    }
}
