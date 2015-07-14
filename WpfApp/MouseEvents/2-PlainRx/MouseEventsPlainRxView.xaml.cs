﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseEventsPlainRxView.xaml.cs" author="Marko Marković">
//   Copyright (c) 2015
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//   http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming

namespace WpfApp.MouseEvents
{
    using System;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class MouseEventsPlainRxView : UserControl
    {
        private readonly IDisposable mouseMoveSubscription;

        public MouseEventsPlainRxView()
        {
            this.InitializeComponent();
            this.DataContext = new MouseEventsClassicViewModel();

            this.mouseMoveSubscription = Observable
                .FromEventPattern<MouseEventArgs>(this, "MouseMove")
                .Select(x => x.EventArgs.GetPosition(this.PlayGround))
                .Subscribe(
                    position =>
                    {
                        var viewModel = (MouseEventsClassicViewModel)this.DataContext;

                        viewModel.X = position.X;
                        viewModel.Y = position.Y;
                    });
        }

        private void MouseEventsPlainRxView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.mouseMoveSubscription.Dispose();
        }
    }
}