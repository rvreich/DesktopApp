﻿using System;
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
using System.Windows.Shapes;

namespace RV_UnderTheSeaApp.Departments.AttractionDepartment
{
    /// <summary>
    /// Interaction logic for FeeForm.xaml
    /// </summary>
    public partial class FeeForm : Window
    {
        public FeeForm(int amount)
        {
            InitializeComponent();
            amount_label.Content = amount.ToString() + " Ticket(s)";
            //int total = (amount * 60000);
            total_price_label.Content = "Rp. " + (amount * 60000).ToString();
        }
    }
}