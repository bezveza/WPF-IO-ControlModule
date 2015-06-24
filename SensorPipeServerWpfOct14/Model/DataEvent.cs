using System;
using System.Windows;
using System.Windows.Controls;

namespace SensorPipeServerWpfOct14.Model
{
    public class DataInfoEventArgs : EventArgs
    {
        public DataInfoEventArgs(string data)
        {
            this.Data = data;
        }
        public string Data { get; private set; }
    }
    
    //using events instead of databinding for mainwindow debug panel textbox display, need to simplify this in the future
    public class Data
    {
        public static bool initFlag { get; set; }

        public static Data Source = new Data(); //Send a warning that event is not register

        public event EventHandler<DataInfoEventArgs> NewInfo;

        public static void eventAlert()
        {
            MessageBox.Show("Warning!  Event not registered.\nSource could be null.");
        }

        public void Msg(string data)
        {
            if (initFlag == false)
                eventAlert();
            if (Source != null)
                RaiseNewInfo(data);
        }

        protected virtual void RaiseNewInfo(string data)
        {
            EventHandler<DataInfoEventArgs> newInfo = NewInfo;
            if (newInfo != null)
            {
                newInfo(this, new DataInfoEventArgs(data));
            }
        }
    }

    public class EventUser
    {
        private TextBox textbox;

        public EventUser(TextBox textbox)
        {
            this.textbox = textbox;
            initEvent(); //initialize Source event and register a ready to use handler
        }

        private void initEvent()
        {
            if (Data.Source == null)
            {
                Data.Source = new Data();
                Data.initFlag = true;
            }

            else
            {
                Data.Source = new Data();
                Data.initFlag = true;
            }

            Data.Source.NewInfo += NewDataHandler;
        }

        private void NewDataHandler(object sender, DataInfoEventArgs e)
        {
            textbox.AppendText(e.Data);
        }
    }
}
