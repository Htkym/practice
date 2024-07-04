using Calculator.View;
using Calculator.ViewModels;

namespace Calculator.Presenters
{
    public abstract class PresenterBase<TView, TViewModel>(TView view, TViewModel viewModel) : IPresenter<TView, TViewModel>
        where TView : Control, IView, new()
        where TViewModel : class, IViewModel
    {
        public TView View { get; } = view;

        public TViewModel ViewModel { get; } = viewModel;
    }
}