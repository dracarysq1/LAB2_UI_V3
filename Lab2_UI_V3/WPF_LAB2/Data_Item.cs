using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using DataLibrary;

namespace WPF_LAB2
{
    class Data_Item :IDataErrorInfo,INotifyPropertyChanged
    {
        public float x=0, y=0;
        public double cle=0;
        public V3DataCollection v3datacollection;

        public event PropertyChangedEventHandler PropertyChanged;



        public void NotifyPropertyChanged(string propertyname = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        public float X
        {
            get { return x; }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
                NotifyPropertyChanged("Y");
            }
        }

        public float Y
        {
            get { return y; }
            set
            {
                y = value;
                NotifyPropertyChanged("X");
                NotifyPropertyChanged("Y");
            }
        }
        public  double Cle
        {
            get { return cle; }
            set
            {
                cle = value;
                NotifyPropertyChanged("Cle");
            }
        }

        public string Error { get { return "Error  Data"; } }

        public string this[string columnName]
        {
            get
            {
                string msg = null;
                switch (columnName)
                {
                    case "X":
                        {
                            foreach (DataItem item in v3datacollection.list)

                                if (item.vec.X == X)
                                    msg = "Match field points";
                            break;
                        }
                        break;

                    case "Y":
                        {
                            foreach (DataItem item in v3datacollection.list)

                                if ( item.vec.Y == Y)
                                    msg = "Match field points";
                            break;
                        }
                        break;
                    case "Cle":
                        {
                           if (cle < 0)
                                msg = "value < 0";
                                    break;
                        }
                    default:
                        break;                                        
                }
                return msg;
            }
        }
    public Data_Item( V3DataCollection dataItems)
        {
            v3datacollection = dataItems;
        }
        //public Data_Item(ref V3DataCollection dataItems,float x = 2,float y = 3,double cle =4.0)
        //    {
        //        v3datacollection = dataItems;
        //        X = x;
        //        Y = y;
        //        Cle = cle;
        //    }

        /* public void Add(float x,float y,double cle)
         {

             X = x;
             Y = y;
             Cle = cle;
             v3datacollection.list.Add(new DataItem(cle, new System.Numerics.Vector2(X, y)));

         }*/
        public void Add()
        {
            System.Numerics.Vector2 vec = new System.Numerics.Vector2(x, y);
            DataItem dataItem = new DataItem(Cle, vec);
            v3datacollection.Add(dataItem);
            NotifyPropertyChanged("X");
            NotifyPropertyChanged("Y");
            NotifyPropertyChanged("Cle");
        }
        //public static void Add(Data_Item data)
        //{
        //    System.Numerics.Vector2 vec = new System.Numerics.Vector2(data.X, data.Y);
        //    DataItem dataItem = new DataItem(data.Cle, vec);
        //    data.v3datacollection.Add(dataItem);
        //}
    }

}
