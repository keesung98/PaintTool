using PaintTool.Model;
using PaintTool.ViewModel.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintTool.Views.UserControls
{
    public partial class DrawPaintUserControl: UserControl
    {
        private bool isDrawing = false;
        private PolylineViewModel? currentLine;

        public DrawPaintUserControl()
        {
            InitializeComponent();
            this.DataContext = new DrawPaintUserControlViewModel();
        }
        private DrawPaintUserControlViewModel VM => (DrawPaintUserControlViewModel)DataContext;

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            currentLine = new PolylineViewModel
            {
                Color = (Brush)new BrushConverter().ConvertFromString(VM.SelectedColor),
                Thickness = VM.LineThickness
            };
            currentLine.Points.Add(e.GetPosition(DrawCanvas));
            VM.Lines.Add(currentLine);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentLine != null)
            {
                var point = e.GetPosition(DrawCanvas);
                currentLine.Points.Add(point);

                // 새로 할당해서 UI 갱신 유도
                currentLine.Points = new PointCollection(currentLine.Points);
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }
    }
}
