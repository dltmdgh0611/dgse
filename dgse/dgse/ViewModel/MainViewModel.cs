using dgse.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected Window mainViewModel;

    public Meal meal;

    public Thread meal_thread;

    public  void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public MainViewModel()
    { }

    public MainViewModel(Window mainViewModel)
    {

        mainViewModel = mainViewModel;

        meal = new Meal();
        meal_thread = new Thread(new ThreadStart(Meal_Get));
        meal_thread.Start();
    }

    public void Move()
    {
        mainViewModel.DragMove();
    }

    public void Close()
    {
        mainViewModel.Close();
    }


    public ICommand Bt_Close
    {
        get
        {
            return new DelegateCommand(Close);
        }
    }

    public ICommand Bar_Move
    {
        get
        {
            return new DelegateCommand(Move);
        }
    }

    public string morning
    {
        get
        {
            Debug.WriteLine("call");
            return meal.Meal_Get(0);
        }
    }

    public string lunch
    {
        get
        {
            return meal.Meal_Get(1);
        }
    }

    public string dinner
    {
        get
        {
            return meal.Meal_Get(2);
        }
    }

    public void Meal_Get()
    {
        meal.Get_Meal_Json();
        meal.Parse_Meal(meal.meal_arr);
        for (int i = 0; i < 3; i++)
        {
            meal.meal[i] = string.Join("\n", meal.meal_arr[i]);
        }
        OnPropertyChanged("morning");
    }

}

#region DelegateCommand Class
public class DelegateCommand : ICommand
{

    private readonly Func<bool> canExecute;
    private readonly Action execute;

    /// <summary>
    /// Initializes a new instance of the DelegateCommand class.
    /// </summary>
    /// <param name="execute">indicate an execute function</param>
    public DelegateCommand(Action execute) : this(execute, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the DelegateCommand class.
    /// </summary>
    /// <param name="execute">execute function </param>
    /// <param name="canExecute">can execute function</param>
    public DelegateCommand(Action execute, Func<bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }
    /// <summary>
    /// can executes event handler
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// implement of icommand can execute method
    /// </summary>
    /// <param name="o">parameter by default of icomand interface</param>
    /// <returns>can execute or not</returns>
    public bool CanExecute(object o)
    {
        if (this.canExecute == null)
        {
            return true;
        }
        return this.canExecute();
    }

    /// <summary>
    /// implement of icommand interface execute method
    /// </summary>
    /// <param name="o">parameter by default of icomand interface</param>
    public void Execute(object o)
    {
        this.execute();
    }

    /// <summary>
    /// raise ca excute changed when property changed
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        if (this.CanExecuteChanged != null)
        {
            this.CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
#endregion

