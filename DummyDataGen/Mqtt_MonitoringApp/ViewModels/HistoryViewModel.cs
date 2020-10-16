using Caliburn.Micro;
using Mqtt_MonitoringApp.Helpers;
using Mqtt_MonitoringApp.Models;
using MySql.Data.MySqlClient;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mqtt_MonitoringApp.ViewModels
{
    public class HistoryViewModel : Conductor<object>
    {
        #region 속성영역
        private BindableCollection<DivisionModel> divisions;
        
        public BindableCollection<DivisionModel> Divisions
        {
            get => divisions;
            set
            {
                divisions = value;
                NotifyOfPropertyChange(() => Divisions);
            }
        }

        private DivisionModel selectedDivision;
        public DivisionModel SelectedDivision
        {
            get => selectedDivision;
            set
            {
                selectedDivision = value;
                NotifyOfPropertyChange(() => SelectedDivision);
            }

        }

        private string startDate;
        public string StartDate
        {
            get => startDate;
            set
            {
                startDate = DateTime.Parse(value).ToString("yyyy-MM-dd");
                endDate = DateTime.Parse(startDate).AddDays(1).ToString("yyyy-MM-dd");
                NotifyOfPropertyChange(() => StartDate);
                NotifyOfPropertyChange(() => EndDate);
            }
        }

        private string endDate;
        public string EndDate
        {
            get => endDate;
            set
            {
                endDate = DateTime.Parse(value).ToString("yyyy-MM-dd");
                NotifyOfPropertyChange(() => EndDate);
            }
        }

        List<DataPoint> tempValues;
        public List<DataPoint> TempValues
        {
            get => tempValues;
            set
            {
                tempValues = value;
                NotifyOfPropertyChange(() => TempValues);
            }
        }

        List<DataPoint> humidValues;
        public List<DataPoint> HumidValues
        {
            get => humidValues;
            set
            {
                humidValues = value;
                NotifyOfPropertyChange(() => HumidValues);
            }
        }

        List<DataPoint> pressValues;
        public List<DataPoint> PressValues
        {
            get => pressValues;
            set
            {
                pressValues = value;
                NotifyOfPropertyChange(() => PressValues);
            }
        }

        private int totalCount;
        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                NotifyOfPropertyChange(() => TotalCount);
            }
        }


        
        #endregion

        public HistoryViewModel()
        {
            InitControls();
            InitDataFromDB();
        }

        private void InitControls()
        {
            Divisions = new BindableCollection<DivisionModel>
            {
                new DivisionModel {KeyVal=0,DivisionVal="Select"},
                new DivisionModel {KeyVal=1,DivisionVal="DiningRoom"},
                new DivisionModel {KeyVal=2,DivisionVal="LivingRoom"},
                new DivisionModel {KeyVal=3,DivisionVal="BedRoom"},
                new DivisionModel {KeyVal=4,DivisionVal="BathRoom"},
                new DivisionModel {KeyVal=5,DivisionVal="GuestRoom"},
            };
            SelectedDivision = Divisions.Where(v => v.DivisionVal.Contains("Select")).FirstOrDefault();
        }

        private void InitDataFromDB()
        {
            Commons.CONNSTRING = "Server=localhost;Port=3306;Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
            using(var conn = new MySqlConnection(Commons.CONNSTRING))
            {
                string strInsQuery = "SELECT date_format(Curr_Time,'%Y-%m-%d') AS StartDte " +
                                     "  FROM smarthometbl " +
                                     "  WHERE Id = 1";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strInsQuery, conn);
                    //DateTime result = DateTime.Parse(cmd.ExecuteScalar().ToString());
                    string result = cmd.ExecuteScalar().ToString();

                    StartDate = result;
                    //EndDate = result.AddDays(1);
                    EndDate = DateTime.Parse(result).AddDays(1).ToString("yyyy-MM-dd");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public void Search()
        {
            if(SelectedDivision.KeyVal == 0)
            {
                var wManager = new WindowManager();
                wManager.ShowDialog(new ErrorPopuoViewModel("Error|Division을 선택하세요"));
                return;
            }



            TempValues = HumidValues = PressValues = new List<DataPoint>();
            List<DataPoint> listTemps = new List<DataPoint>();
            List<DataPoint> listHumids = new List<DataPoint>();
            List<DataPoint> listPresses = new List<DataPoint>();

            using (var conn = new MySqlConnection(Commons.CONNSTRING))
            {
                string strInsQuery = " SELECT Temp,Humid,Press " +
                                     "   FROM smarthometbl " +
                                     " WHERE Dev_Id = @Dev_Id " +
                                     "   AND Curr_Time BETWEEN @StartDate AND @EndDate " +
                                     " ORDER BY Id";

                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strInsQuery, conn);

                    MySqlParameter paramDevid = new MySqlParameter("@Dev_Id", MySqlDbType.VarChar) ;
                    paramDevid.Value = SelectedDivision.DivisionVal;
                    cmd.Parameters.Add(paramDevid);
                    MySqlParameter paramStartDate = new MySqlParameter("@StartDate", MySqlDbType.VarChar);
                    paramStartDate.Value = StartDate;
                    cmd.Parameters.Add(paramStartDate);
                    MySqlParameter paramEndDate = new MySqlParameter("@EndDate", MySqlDbType.VarChar);
                    paramEndDate.Value = EndDate;
                    cmd.Parameters.Add(paramEndDate);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    var i = 0;
                    while(reader.Read())
                    {
                        listTemps.Add(new DataPoint(i, Convert.ToDouble(reader["Temp"])));
                        listHumids.Add(new DataPoint(i, Convert.ToDouble(reader["Humid"])));
                        listPresses.Add(new DataPoint(i, Convert.ToDouble(reader["Press"])));
                        i++;
                    }
                    if (i == 0)
                    {
                        var wManager = new WindowManager();
                        wManager.ShowDialog(new ErrorPopuoViewModel("Error|데이터가 없습니다."));
                        return;
                    }
                    TotalCount = i;
                }
                catch (Exception ex)
                {
                    var wManager = new WindowManager();
                    wManager.ShowDialog(new ErrorPopuoViewModel($"Error|{ex.Message}"));
                }
                TempValues = listTemps;
                HumidValues = listHumids;
                PressValues = listPresses;
            }
        }
    }
}
