using Caliburn.Micro;
using Mqtt_MonitoringApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mqtt_MonitoringApp.ViewModels
{
    public class CustomPopupViewModel : Conductor<object>
    {
        #region 속성영역
        string brokerIP;
        public string BrokerIP
        {
            get => brokerIP;
            set
            {
                brokerIP = value;
                NotifyOfPropertyChange(() => BrokerIP);
            }
        }

        string topic;
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }
        #endregion

        public CustomPopupViewModel(string title)
        {
            this.DisplayName = title;
            BrokerIP = "localhost";
            Topic = "home/device/data/";

        }

        public void AcceptClose()
        {
            Commons.BROKERHOST = BrokerIP;
            Commons.PUB_TOPIC = Topic;
            TryClose(true);
        }
    }
}
