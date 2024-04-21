//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiShowroom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Booking
    {
     
        public int BookingID { get; set; }
       
        public Nullable<int> CarID { get; set; }
        
        public Nullable<int> CustomerID { get; set; }
     
        public string CarName { get; set; }
       
        public string SchemeName { get; set; }
      
        public Nullable<System.DateTime> BookingDate { get; set; }
       
        public Nullable<decimal> BookingAmount { get; set; }
       
        public string UPI_ID { get; set; }
   

        public virtual CarDetail CarDetail { get; set; }
       
        public virtual CustomerDetail CustomerDetail { get; set; }
    }
}
