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
        }

        public ICommand Bt_Close
        {
            get
            {
                return bt_close = new DelegateCommand(close);
            }
        }

        public override void close()
        {
            mainViewModel.Close();
        }

        private ICommand bar_move;

        public ICommand Bar_Move
        {
            get
            {
                return bar_move = new DelegateCommand(move);
            }
        }

        public void move()
        {
            base.mainViewModel.DragMove();
        }

    }

}
