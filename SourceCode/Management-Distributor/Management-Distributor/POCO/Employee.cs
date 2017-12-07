﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Distributor.POCO
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string EmpName { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string EmpAddress { get; set; }

        // temporary skip avatar image 
        [Required(ErrorMessage = "Phone number is required!")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email is not valid")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MaxLength(20, ErrorMessage = "Username maximum is 20 character"), MinLength(5, ErrorMessage = "Username could not less than 5 character")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string EncryptedPassword { get; set; }

        [Required(ErrorMessage = "Salf is required")]
        public string Salt { get; set; }

        [DefaultValue(typeof(DateTime))]
        public DateTime LastLogged { get; set; }

        [DefaultValue(0)]
        public int NumOfLoginAttemp { get; set; }
        public DateTime LastAttemp { get; set; }

        public string Role { get; set; }

        // Foreign Key
        [Required(ErrorMessage = "Department is required")]

        [ForeignKey("DeparmentId")]

        // One to one with Department
        public virtual Department Department { get; set; }

        // Zero->Many with Order, Invoice, Payment, Report and Statistic
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
        //public virtual ICollection<Contract> Contracts { get; set; }
    }
}