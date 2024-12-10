﻿#pragma checksum "..\..\..\Training.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D09B2E849E7526FA9F1E2BCCAAB85980DE4AFB73"
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
    /// Training
    /// </summary>
    public partial class Training : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ExerciseTextBlock;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox YourAnswerTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CorrectAnswerTextBlock;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Answer;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FinishTheTraining;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Training.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextTask;
        
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
            System.Uri resourceLocater = new System.Uri("/TestingAppInterface;component/training.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Training.xaml"
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
            this.ExerciseTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.YourAnswerTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Training.xaml"
            this.YourAnswerTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CorrectAnswerTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Answer = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Training.xaml"
            this.Answer.Click += new System.Windows.RoutedEventHandler(this.Answer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FinishTheTraining = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Training.xaml"
            this.FinishTheTraining.Click += new System.Windows.RoutedEventHandler(this.FinishTheTraining_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NextTask = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Training.xaml"
            this.NextTask.Click += new System.Windows.RoutedEventHandler(this.NextTask_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

