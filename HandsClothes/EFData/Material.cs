//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HandsClothes.EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.MaterialQtyChangeHistory = new HashSet<MaterialQtyChangeHistory>();
            this.Suplier = new HashSet<Suplier>();
        }
    
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int MaterialTypeId { get; set; }
        public string PhotoPath { get; set; }
        public decimal Price { get; set; }
        public int QtyInStock { get; set; }
        public int MinimalAmount { get; set; }
        public int InPackAmount { get; set; }
        public int UnitId { get; set; }
        public string Description { get; set; }
    
        public virtual MaterialType MaterialType { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialQtyChangeHistory> MaterialQtyChangeHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suplier> Suplier { get; set; }
    }
}
