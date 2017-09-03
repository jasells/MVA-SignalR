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

            //handle update from model

            //set initial xy
            SetXY(Item.X, item.Y);
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        string xy = "(0,0)";
        public string XY
        {
            get { return xy; }
            set
            {
                SetProperty(ref xy, value);
            }
        }

        void SetXY(int X, int Y)
        {
            XY = string.Concat("(", X, ",", Y, ")");
        }
    }
}