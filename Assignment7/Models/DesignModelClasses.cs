using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Models
{
    public class Smartphone
    {
        public Smartphone()
        {
            DateReleased = DateTime.Now.AddMonths(-1);
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Manufacturer { get; set; }

        [Required, StringLength(100)]
        public string Model { get; set; }

        public DateTime DateReleased { get; set; }

        public double ScreenSize { get; set; }

        public int MSRP { get; set; }
    }
}