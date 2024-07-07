# practice
## Calculator
### Architecture
* WindowsForm
* C#/.Net Core 8
* log4Net
* MVPVM
    * object "Model(domain model)"
    * object "View"
    * object "Presenter"
    * object "ViewModel(application model)"
    * View <-> ViewModel : Data Bind / Command
    * View <-- Presenter : Navigation
    * ViewModel <-- Presenter : Navigation
    * ViewModel <-> Model : Synchronization
    * Presenter -> Model : Get Or Update Data