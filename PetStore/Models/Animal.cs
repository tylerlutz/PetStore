using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string MainDescription { get; set; }
        public DateTime DateRecieved { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte[] Picture { get; set; }
        public string PicturePath { get; set; }
    }
}