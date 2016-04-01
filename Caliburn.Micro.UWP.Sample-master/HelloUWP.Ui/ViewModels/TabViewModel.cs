﻿using Windows.UI.Xaml.Controls;

namespace Caliburn.Micro.HelloUWP.Ui.ViewModels
{
    /// <summary>
    /// Class TabViewModel.
    /// </summary>
    public class TabViewModel : Screen
    {
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public TabViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }
    }
}