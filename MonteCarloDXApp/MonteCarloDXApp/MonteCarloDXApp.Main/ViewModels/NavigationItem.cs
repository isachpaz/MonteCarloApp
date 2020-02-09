using DevExpress.Mvvm;
using MonteCarloDXApp.Common;
using System;

namespace MonteCarloDXApp.Main.ViewModels
{
    [Serializable]
    public class NavigationItem : INavigationItem, ISupportState<NavigationItem>
    {
        public string Caption { get; set; }
        public NavigationItem() { }
        public NavigationItem(string caption)
        {
            Caption = caption;
        }

        #region Serialization
        NavigationItem ISupportState<NavigationItem>.SaveState()
        {
            return this;
        }
        void ISupportState<NavigationItem>.RestoreState(NavigationItem state)
        {
            Caption = state.Caption;
        }
        #endregion
    }
}
