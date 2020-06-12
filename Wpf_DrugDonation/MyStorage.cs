using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Wpf_DrugDonation
{
    internal class MyStorage
    {
        internal static T ReadXml<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    return (T)ser.Deserialize(sr);
                }
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message, "Error");
                return default(T);
            }
        }

        internal static void WriteXml<T>(T data, string file)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(file, FileMode.Create);

            ser.Serialize(fs, data);
            fs.Close();
        }
    }
}