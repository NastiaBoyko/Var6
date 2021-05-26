using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseList
{
    class Expense : INotifyPropertyChanged
    {
        private string shopName;

        public string ShopName
        {
            get { return shopName; }
            set 
            {
                shopName = value;
                OnPropertyChanged();
            }
        }

        private DateTime purchaseTime;

        public DateTime PurchaseTime
        {
            get { return purchaseTime; }
            set
            {
                purchaseTime = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PurchaseTimeStr));
                OnPropertyChanged(nameof(PurchaseDateStr));
            }
        }

        private string ticketNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set
            {
                ticketNumber = value;
                OnPropertyChanged();
            }
        }

        private string purchaseName;    

        public string PurchaseName
        {
            get { return purchaseName; }
            set
            {
                purchaseName = value;
                OnPropertyChanged();
            }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public string PurchaseTimeStr => PurchaseTime.ToString("HH:mm:ss");
        public string PurchaseDateStr => PurchaseTime.ToString("dd.MM.yyyy");

        public Expense()
        {

        }

        public Expense(string shopName, DateTime purchaseDate, string ticketNumber, string purchaseName, float price)
        {
            ShopName = shopName;
            PurchaseTime = purchaseDate;
            TicketNumber = ticketNumber;
            PurchaseName = purchaseName;
            Price = price;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
