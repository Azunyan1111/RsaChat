using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
 
abstract public class SavableSingleton<T> where T : SavableSingleton<T>, new()
    {
        private static T instance;
 
    public static string folderPath = Application.persistentDataPath + "/Database/" ;
    public static string filePath = folderPath+ typeof(T).FullName + ".json";
        public static T Instance
        {
            get
            {
                if (null == instance)
                {
                    Load ();
                }
                return instance;
            }
        }
 
    public static void Save (){
        Instance._Save ();
    }
    public void _Save()
        {
        string json = JsonMapper.ToJson(Instance);
            json += "[END]"; // 復号化の際にPaddingされたデータを除去するためのデリミタの追記
        //      Debug.Log (json);
            string crypted = Crypt.Encrypt(json);
             
        //  Debug.Log ("保存先フォルダ" + folderPath);
            // フォルダーがない場合は作成する
        if (!Directory.Exists(folderPath))
            {
            Directory.CreateDirectory(folderPath);
            }
        FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fileStream);
            writer.Write(crypted);
            writer.Close();
        }
 
    public static void Load()
    {
        T ret = null;
        Debug.Log (typeof(T).Name + "Load Start");
        string json = "";
 
 
        //      Debug.Log (File.Exists (filePath).ToString ());
        if (File.Exists (filePath)) {
            //          Debug.Log ("Fileは存在します。" + filePath);
 
            FileStream fileStream = new FileStream (filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader (fileStream);
            if (reader != null) {
                string str = reader.ReadString ();
                string decrypted = Crypt.Decrypt (str);
                 
                decrypted = System.Text.RegularExpressions.Regex.Replace (decrypted, @"¥[END¥].*$", "");
                 
                json = decrypted;
                instance = JsonMapper.ToObject<T> (json);
                reader.Close ();
 
            }
 
        } else {
            Debug.Log ("Fileが存在しません。");
            instance = new T ();
        }
    }
 
    private void writeFile(string filePath)
        {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonMapper.ToJson(Instance));
                }
            }
        }
 
 
    public static void Reset(){
        Debug.Log (typeof(T).ToString() + "Fileを消去します。");
        if(File.Exists(filePath)){
            Debug.Log(filePath + "が存在しましたので、消去します。");
            File.Delete(filePath);
            if (!File.Exists (filePath)) {
                Debug.Log (filePath + "を消去しました。");
            }
        }
    }
 
 
    }