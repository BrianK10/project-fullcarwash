//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wcf_fullcarwash
{
    using System;
    using System.Collections.Generic;
    
    public partial class Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Services()
        {
            this.DetailReservation = new HashSet<DetailReservation>();
        }
    
        public int idService { get; set; }
        public Nullable<int> idLocal { get; set; }
        public string nameService { get; set; }
        public string typeService { get; set; }
        public int idCar { get; set; }
        public decimal price { get; set; }
    
        public virtual Local Local { get; set; }
        public virtual TypeCars TypeCars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailReservation> DetailReservation { get; set; }
    }
}
