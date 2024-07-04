using Calculator.Models;
using System.ComponentModel;

namespace Calculator.ViewModels
{
    public abstract class ViewModelBase<TModel>(TModel model) : IViewModel where TModel : IModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected TModel Model => model;
    }
}