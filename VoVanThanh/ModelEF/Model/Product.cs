namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int IDProduct { get; set; }

        
        [StringLength(50, ErrorMessage = "Kí tự tối đa là 50")]
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Bạn chưa nhập tên danh mục.")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá tiền")]
        public decimal UnitCost { get; set; }

        [DisplayName("Số lượng")]
        [Range (0, Int32.MaxValue, ErrorMessage ="Bạn phải nhập số.")]
        public int Quantity { get; set; }

        [DisplayName("Ảnh")]
        public string Image { get; set; }

        
        [DisplayName("Miêu tả")]
        public string Description { get; set; }

      
        [DisplayName("Trạng thái")]
        public string Status { get; set; }

        [DisplayName("Mã danh mục")]
        public int IDCategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
