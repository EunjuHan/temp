using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment7.Controllers
{
    public class SmartphoneAdd
    {
        public SmartphoneAdd()
        {
            DateReleased = DateTime.Now.AddMonths(-1);
        }

        [Required, StringLength(100)]
        public string Manufacturer { get; set; }

        [Required, StringLength(100)]
        public string Model { get; set; }

        public DateTime DateReleased { get; set; }

        [Range(3.0, 10.0)]
        public double ScreenSize { get; set; }

        [Range(10, 10000)]
        public int MSRP { get; set; }
    }

    public class SmartphoneAddTemplate
    {
        public string Manufacturer { get { return "Manufacturer, string, up to 100 characters"; } }
             
        public string Model { get { return "Model, string, up to 100 characters"; } }

        public string DateReleased { get { return "Released date, date type, optional, if empty, will be set to an initial value"; } }
        
        public string ScreenSize { get { return "Screen Size, optional, if empty, will be set to an initial value"; } }
        
        public string MSRP { get { return "Retail price, optional, if empty, will be set to an initial value"; } }
    }

    public class SmartphoneBase : SmartphoneAdd
    {
        [Key]
        public int Id { get; set; }
    }

    public class SmartphoneWithLink : SmartphoneBase
    {
        public Link Link { get; set; }

        public int LinkId { get; set; }
    }

    public class SmartphoneLinked : LinkedItem<SmartphoneWithLink>
    {
        public SmartphoneLinked(SmartphoneWithLink item) : base(item) { }
    }

    public class SmartphonesLinked : LinkedCollection<SmartphoneWithLink>
    {
        public SmartphonesLinked(IEnumerable<SmartphoneWithLink> collection) : base(collection)
        {
            Template = new SmartphoneAddTemplate();
        }

        public SmartphoneAddTemplate Template { get; set; }
    }
}