using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Request: BaseEntity
    {
      
        public int MobileNumber { get; private set; }
        public DateTime RequestDate { get; private set; }
        public Request(int mobileNumber, DateTime requestDate)
        {
            MobileNumber = mobileNumber;
            RequestDate = requestDate;
        }

    }
}