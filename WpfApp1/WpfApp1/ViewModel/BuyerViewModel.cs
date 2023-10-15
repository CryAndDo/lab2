using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class BuyerViewModel: INotifyPropertyChanged
    {
        private Buyer selectedBuyer;
        public ObservableCollection<Buyer> Buyers { get; set; }
        public Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set
            {
                selectedBuyer = value;
                OnPropertyChanged("SelectedBuyer");
            }
        }
        public BuyerViewModel()
        {
            Buyers = new ObservableCollection<Buyer>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
