using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpmuTypes;

namespace NpmuApartment_V2.ViewModels
{
    interface IViewModel
    {
        event Func<Type, ECommand, object, object> CommandEvent;

        object OnCommandEvent(ECommand pCmd, object pData);

        void Start(object pParam = null);

        void OnNextExecute(object pData);

        void ClearInstance();
    }

    
    public class ViewModelBase<T> : System.Windows.DependencyObject, IViewModel, System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string pPropertyName = "")
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(pPropertyName));
        }

        private Type _viewType;
        public Type ViewType
        {
            get => this._viewType;
            set
            {
                this._viewType = value;
                this.ViewTypeName = value.Name;
                this.NotifyPropertyChanged();
            }
        }
        public string ViewTypeName { get; set; }
        public string Title { get; set; }

        public event Func<Type, ECommand, object, object> CommandEvent;

        public ViewModelBase(string pTitle = null)
        {
            this.ViewType = typeof(T);
            this.Title = pTitle;
        }

        public virtual void Start(object pParam = null)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNextExecute(object pData)
        {
            throw new NotImplementedException();
        }

        public virtual void ClearInstance()
        {
            throw new NotImplementedException();
        }

        public virtual object OnCommandEvent(ECommand pCmd, object pData)
        {
            object ret = null;

            if (this.CommandEvent != null)
                ret = this.CommandEvent(this.ViewType, pCmd, pData);

            return ret;
        }
    }
}
