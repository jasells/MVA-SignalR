using XamarinMoveShape.Models;

namespace XamarinMoveShape.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;

            loc = item.Location.ToString();
            //handle update from model
            Item.PropertyChanged += Item_PropertyChanged;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("Location"))
            {
                Location = Item.Location.ToString();
            }
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        string loc;
        public string Location
        {
            get { return loc; }
            set { SetProperty<string>(ref loc, value); }
        }
    }
}