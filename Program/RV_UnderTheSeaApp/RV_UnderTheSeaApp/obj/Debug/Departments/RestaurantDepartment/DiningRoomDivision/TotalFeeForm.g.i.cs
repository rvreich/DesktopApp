﻿#pragma checksum "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2817F91F9BD690C1133227302D3E53782E20788A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RV_UnderTheSeaApp.Departments.RestaurantDepartment.DiningRoomDivision;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.DiningRoomDivision {
    
    
    /// <summary>
    /// TotalFeeForm
    /// </summary>
    public partial class TotalFeeForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label tableLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label totalLabel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox feedback_box;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RV_UnderTheSeaApp;component/departments/restaurantdepartment/diningroomdivision/" +
                    "totalfeeform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.tableLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.totalLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.feedback_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.sendButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\Departments\RestaurantDepartment\DiningRoomDivision\TotalFeeForm.xaml"
            this.sendButton.Click += new System.Windows.RoutedEventHandler(this.SendButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

