using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }

        [Required(ErrorMessage ="A Name must be entered")]
        public string Name { get; set; }

        [Display(Name="Main Description")]
        [Required(ErrorMessage ="The main description is required.")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Detail Description")]
        [Required(ErrorMessage = "The detail description is required.")]
        [DataType(DataType.MultilineText)]
        public string MainDescription { get; set; }

        [Display(Name="Date Recieved")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime DateRecieved { get; set; }

        [Range(0,50)]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public string PicturePath { get; set; }
    }
}