using dgse.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace dgse.ViewModel
{
    class MainViewModel : ViewModel
    {

        public MainViewModel(Window mainViewModel)
        {
            base.mainViewModel = mainViewModel;
            meal = new Meal();
            meal.Get_Meal_Date(new DateTime());
        }

        public override void Move()
        {
            base.mainViewModel.DragMove();
        }

        public override void Close()
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
                return meal.breakfast;
            }
        }

    }

}
