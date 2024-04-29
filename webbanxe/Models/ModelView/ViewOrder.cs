namespace webbanxe.Models.ModelView
{
    public class ViewOrder
    {
        public Order Order { get; set; }
        public Cart Cart { get; set; }
        public Bike Bike { get; set; }
        public User User { get; set; }

        public Accessary Accessary { get; set; }
    }
}
