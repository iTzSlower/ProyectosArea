using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtility {
    public class DataManagement : MonoBehaviour {

        const string DATA_PATH = "D:/game3D.sav";

       public static void WriteDataToFile (object saveData) {
            using (FileStream fs = new FileStream(DATA_PATH, FileMode.Create)) {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, saveData);
            }
        }

        public static object ReadDataFromFile () {
            if (File.Exists(DATA_PATH)) {
                using (FileStream fs = new FileStream(DATA_PATH, FileMode.OpenOrCreate)){
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(fs);
                }
            }else {
                return null;
            }
        }
    }
}
