using Caliburn.Micro;
using Mqtt_MonitoringApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mqtt_MonitoringApp.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        public MainViewModel()
        {
            DisplayName = "MQTT Monitoring App - v0.9";
        }

        protected override void OnDeactivate(bool close)
        {
            if(Commons.BROKERCLIENT.IsConnected)
            {
                Commons.BROKERCLIENT.Disconnect();
                Commons.BROKERCLIENT = null;
            }

            base.OnDeactivate(close);
        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }

        public void BtnExitProgram()
        {
            ExitProgram();
        }

        public void LoadDataBaseView()
        {
            if (Commons.BROKERCLIENT != null)
            {
                ActivateItem(new DataBaseViewModel());
            }
            else
            {
                var wManager = new WindowManager();
                wManager.ShowDialog(new ErrorPopuoViewModel("Error|MQTT가 실행되지 않았습니다."));
            }
        }

        public void LoadRealTimeView()
        {
            ActivateItem(new RealTimeViewModel());
        }

        public void LoadHistoryView()
        {
            ActivateItem(new HistoryViewModel());
        }

         public void PopInfoDialog()
        {
            TaskStart();
        }

        private void TaskStart()
        {
            var wManager = new WindowManager();
            var result = wManager.ShowDialog(new CustomPopupViewModel("New Broker"));

            if(result==true)
            {
                ActivateItem(new DataBaseViewModel());
            }
        }

        public void ToolBarStart()
        {
            TaskStart();
        }
    }
}
