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
    
    public partial class DetailReservation
    {
        public int idDetail { get; set; }
        public int idReservation { get; set; }
        public int idService { get; set; }
        public int idCar { get; set; }
        public decimal priceService { get; set; }
        public decimal priceTypeCar { get; set; }
        public decimal fullPayment { get; set; }
        public string carRegistration { get; set; }
    
        public virtual Reservation Reservation { get; set; }
        public virtual Services Services { get; set; }
        public virtual TypeCars TypeCars { get; set; }
    }
}
