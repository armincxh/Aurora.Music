﻿// Copyright (c) Aurora Studio. All rights reserved.
//
// Licensed under the MIT License. See LICENSE in the project root for license information.
using Aurora.Music.Core.Models;
using Aurora.Music.ViewModels;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Aurora.Music.Controls
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CompactOverlayPanel : Page
    {
        public CompactOverlayPanel()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is SongViewModel s)
            {
                Context.Init(s);
            }
            else
            {
                throw new Exception();
            }

            SystemNavigationManager.GetForCurrentView().BackRequested += CompactOverlayPanel_BackRequested;
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            Settings.Current.CompactHeight = e.Size.Height;
            Settings.Current.CompactWidth = e.Size.Width;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= CompactOverlayPanel_BackRequested;
        }

        private void CompactOverlayPanel_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            Context.ReturnNormal.Execute();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().BackRequested -= CompactOverlayPanel_BackRequested;
            Window.Current.SizeChanged -= Current_SizeChanged;
            Settings.Current.Save();
        }

        private void ArtworkBGBlur_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SetTitleBar(ArtworkBGBlur);
        }

        private void Page_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PointerIn.Begin();
        }

        private void Page_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PointerOut.Begin();
        }
    }
}
