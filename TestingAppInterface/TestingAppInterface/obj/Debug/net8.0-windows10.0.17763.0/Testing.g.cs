﻿#pragma checksum "..\..\..\Testing.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C3E73424777CE730A82A6931C79C5A5D457B0E17"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using TestingAppInterface;


namespace TestingAppInterface {
    
    
    /// <summary>
    /// Testing
    /// </summary>
    public partial class Testing : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ExerciseTestTextBlock;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YourAnswerTestTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextTaskTest;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LastTaskTest;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FinishTest;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Testing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TaskCounterTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestingAppInterface;component/testing.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Testing.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ExerciseTestTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.YourAnswerTestTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Testing.xaml"
            this.YourAnswerTestTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NextTaskTest = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Testing.xaml"
            this.NextTaskTest.Click += new System.Windows.RoutedEventHandler(this.Next_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LastTaskTest = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Testing.xaml"
            this.LastTaskTest.Click += new System.Windows.RoutedEventHandler(this.LastTaskTest_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FinishTest = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Testing.xaml"
            this.FinishTest.Click += new System.Windows.RoutedEventHandler(this.FinishTest_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TaskCounterTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

