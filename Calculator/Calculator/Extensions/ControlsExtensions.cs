using System.Linq.Expressions;
using System.Windows.Input;

namespace Calculator.Extensions;

public static class ControlsExtensions
{
    public static void Bind<T, U>(Expression<Func<T>> item1, Expression<Func<U>> item2)
    {
        static Tuple<object, string> ResolveLambda<V>(Expression<Func<V>> expression)
        {
            if (expression is not LambdaExpression lambda) throw new ArgumentException();
            if (lambda.Body is not MemberExpression property) throw new ArgumentException();
            var parent = property.Expression;
            return new Tuple<object, string>(Expression.Lambda(parent).Compile().DynamicInvoke(), property.Member.Name);
        }
        var tuple1 = ResolveLambda(item1);
        var tuple2 = ResolveLambda(item2);
        if (tuple1.Item1 is not Control control) throw new ArgumentException();
        control.DataBindings.Add(new Binding(tuple1.Item2, tuple2.Item1, tuple2.Item2));
    }

    public static void Bind<T>(this Label label, Expression<Func<T>> expression)
        => Bind(() => label.Text, expression);

    public static void Bind<T>(this TextBox textBox, Expression<Func<T>> expression)
        => Bind(() => textBox.Text, expression);

    public static void Bind(this Button button, ICommand command, object tag = null)
    {
        button.Tag = tag;
        command.CanExecuteChanged += (sender, args) => button.Enabled = command.CanExecute(tag);
        button.Enabled = command.CanExecute(tag);
        button.Click += (sender, args) => command.Execute(tag);
    }
}