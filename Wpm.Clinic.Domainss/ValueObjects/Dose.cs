using Wpm.Clinic.Domain.Entities;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public  class Dose 
    {
        public decimal Quantity { get; set; }
        public UnitOfMeasure Unit { get; set; }
        public Dose(decimal quantity, UnitOfMeasure unit)
        {
            Quantity = quantity;
            Unit = unit;
        }



    }
}
