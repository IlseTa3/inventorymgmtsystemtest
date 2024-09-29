using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TestInventoryMgmtSystem.Models
{
    public class ProductLocationStock
    {
        public int Id { get; set; }

        //foreign key product
        public int ProductId { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; }


        //foreign key locationstock
        public int LocationStockId { get; set; }
        [ValidateNever]
        public virtual LocationStock LocationStock { get; set; }

        public int TotalInStock { get; set; }
    }
}
