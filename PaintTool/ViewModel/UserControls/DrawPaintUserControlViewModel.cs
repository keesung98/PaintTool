using PaintTool.Model;
using PaintTool.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaintTool.ViewModel.UserControl
{
    internal class DrawPaintUserControlViewModel
    {
        public ObservableCollection<PolylineViewModel> Lines { get; set; } = new ObservableCollection<PolylineViewModel>();

        public ObservableCollection<string> AvailableColors { get; } = new ObservableCollection<string> { "Black", "Red", "Blue", "Green" };

        private string selectedColor = "Black";
        public string SelectedColor
        {
            get => selectedColor;
            set { selectedColor = value; OnPropertyChanged(); }
        }

        private double lineThickness = 2;
        public double LineThickness
        {
            get => lineThickness;
            set { lineThickness = value; OnPropertyChanged(); }
        }

        public ICommand ClearCommand { get; }

        public DrawPaintUserControlViewModel()
        {
            ClearCommand = new RelayCommandUtil(_ => Lines.Clear());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
