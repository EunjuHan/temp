using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment7.Models;
using AutoMapper;

namespace Assignment7.Controllers
{
    public class Manager
    {
        private ApplicationDbContext ds = new ApplicationDbContext();

        public Manager()
        {
            ds.Configuration.ProxyCreationEnabled = false;

            ds.Configuration.LazyLoadingEnabled = false;
        }

        public IEnumerable<SmartphoneBase> SmartphoneGetAll()
        {
            var c = ds.Smartphones.OrderBy(s => s.Model).Take(50);

            return Mapper.Map<IEnumerable<SmartphoneBase>>(c);
        }

        public SmartphoneBase SmartphoneGetById(int id)
        {
            var o = ds.Smartphones.SingleOrDefault(s => s.Id == id);

            return (o == null) ? null : Mapper.Map<SmartphoneBase>(o);
        }

        public SmartphoneBase SmartphoneAdd(SmartphoneAdd newItem)
        {
            var addedItem = ds.Smartphones.Add(Mapper.Map<Smartphone>(newItem));
            ds.SaveChanges();

            return (addedItem == null) ? null : Mapper.Map<SmartphoneBase>(addedItem);
        }



    }
}