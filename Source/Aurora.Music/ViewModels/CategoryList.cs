﻿// Copyright (c) Aurora Studio. All rights reserved.
//
// Licensed under the MIT License. See LICENSE in the project root for license information.
using Aurora.Shared.MVVM;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;

namespace Aurora.Music.ViewModels
{
    public class CategoryListItem : ViewModelBase
    {
        public string Title { get; set; }

        private bool isCurrent;
        public bool IsCurrent
        {
            get { return isCurrent; }
            set { SetProperty(ref isCurrent, value); }
        }

        public Type NavigatType { get; set; }

        public double GetHeight(bool b)
        {
            return b ? 240d : 96d;
        }

        public double GetVerticalShift(bool b)
        {
            return b ? 0d : -240d;
        }
        public IList<ImageSource> HeroImages { get; set; }
        public int ID { get; internal set; }

        public double BoolToOpacity(bool a)
        {
            return a ? 1.0 : 0.1;
        }

        public SolidColorBrush ChangeTextForeground(bool b)
        {
            return (SolidColorBrush)(b ? MainPage.Current.Resources["SystemControlForegroundBaseHighBrush"] : MainPage.Current.Resources["ButtonDisabledForegroundThemeBrush"]);
        }
    }
}
