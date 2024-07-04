using Calculator.View;
using Calculator.ViewModels;

namespace Calculator.Presenters
{
    internal interface IPresenter<TView, TViewModel>
        where TView : IView
        where TViewModel : IViewModel
    {
        TView View { get; }

        TViewModel ViewModel { get; }
    }
}