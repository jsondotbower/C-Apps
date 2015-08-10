using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DateChanger
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        [StructLayout(LayoutKind.Sequential)]
        static extern bool SetSystemTime([In] ref SYSTEMTIME st);
        
        public Form1()
        {
            InitializeComponent();
        }
        public struct SYSTEMTIME
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
            public void FromDateTime(DateTime time)
            {
                Year = (ushort)time.Year;
                Month = (ushort)time.Month;
                DayOfWeek = (ushort)time.DayOfWeek;
                Day = (ushort)time.Day;
                Hour = (ushort)time.Hour;
                Minute = (ushort)time.Minute;
                Second = (ushort)time.Second;
                Milliseconds = (ushort)time.Millisecond;
            }
            public DateTime ToDateTime()
            {
                return new DateTime(Year, Month, Day, Hour, Minute, Second, Milliseconds);
            }
            public static DateTime ToDateTime(SYSTEMTIME time)
            {
                return time.ToDateTime();
            }
        }

        private void BtnChangeDate_Click(object sender, EventArgs e)
        {
            ChangeDateUp(0);
        }

        private void BtnPreviousDay_Click(object sender, EventArgs e)
        {
            ChangeDateDown(0);
        }
        private void ChangeDateUp(int numDays)
        {
            DateTime t = DateTime.Now.AddDays(1);
            DateTime h = DateTime.Now.AddHours(0);
            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(t);
            st.FromDateTime(h);
            SetSystemTime(ref st);
        }

        private void ChangeDateDown(int numDays)
        {
            DateTime t = DateTime.Now.AddDays(-1);
            DateTime h = DateTime.Now.AddHours(0);
            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(t);
            SetSystemTime(ref st);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
