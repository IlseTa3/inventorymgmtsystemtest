using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TestInventoryMgmtSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string ProductNr { get; set; }

        [DataType(DataType.Currency)]
        [Range(0.01, 10000.00, ErrorMessage = "Price must be between 0.01 and 10,000.00")]
        public decimal Price { get; set; }

        // Foreign Key with Supplier
        public int SupplierId { get; set; }

        [ValidateNever]
        public virtual Supplier Supplier { get; set; }

        // 1 product can be stocked in different other Stock-locations

        [ValidateNever]
        public virtual ICollection<ProductLocationStock> ProductLocationStocks { get; set; }


    }
}
