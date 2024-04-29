namespace webbanxe.Models
{
    public class ModelViewBike
    {
        private IQueryable<TypeBike> listType;
        private IQueryable<Bike> listCar;

        public ModelViewBike()
        {
        }

        public TypeBike TypeBike { get; set; }
        public Bike Bike { get; set; }

        public ModelViewBike(TypeBike typeBike, Bike bike)
        {
            TypeBike = typeBike;
            Bike = bike;
        }

        public ModelViewBike(IQueryable<TypeBike> listType, IQueryable<Bike> listCar)
        {
            this.listType = listType;
            this.listCar = listCar;
        }
    }
}
