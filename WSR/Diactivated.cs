using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WSR
{
    public partial class Diactivated: MainWindow
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public bool finish = false;
        public void Window_Deactivated(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            finish = true;
            timer.Stop();
            this.Show();
        }
    }
}
