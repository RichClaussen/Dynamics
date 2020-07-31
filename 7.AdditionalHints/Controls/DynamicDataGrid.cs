using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Dynamics.Controls
{
    public class DynamicDataGrid : DataGrid
    {
        static DynamicDataGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicDataGrid), new FrameworkPropertyMetadata(typeof(DataGrid)));
        }

        public DynamicDataGrid()
        {
            this.AutoGeneratingColumn += this.OnGeneratingColumns;
        }

        void OnGeneratingColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var descriptor = e.PropertyDescriptor as PropertyDescriptor;
            e.Column.Header = descriptor.DisplayName;
        }
    }
}
