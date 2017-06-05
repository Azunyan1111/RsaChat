using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class GameData : SingletonMonoBehaviour<GameData>{
 
    //セーブしたいデータを定義するクラス
    //コンストラクタで値を初期化
    class SaveData: SavableSingleton<SaveData>{
        public UserData UserData;
        public float VolumeSE;
        public float VolumeBGM;
 
        public SaveData(){
            UserData = new UserData();
            VolumeSE=0.5f;
            VolumeBGM=0.5f;
        }
    }
    public static void Save(){
        SaveData.Save ();
    }
    public static void Reset(){
        SaveData.Reset ();
    }
 
    public static float VolumeSE{
        get{return SaveData.Instance.VolumeSE;}
        set{SaveData.Instance.VolumeSE = value; }
    }
    public static float VolumeBGM{
        get{return SaveData.Instance.VolumeBGM;}
        set{SaveData.Instance.VolumeBGM = value; }
    }
 
    public static UserData UserData{
        get{return SaveData.Instance.UserData;}
        set{ SaveData.Instance.UserData = value; }
    }
 
 
    public void Awake()
    {
        if(this != Instance)
        {
            Destroy(this);
            return;
        }
 
        DontDestroyOnLoad(this.gameObject);
    }    
 
 
    void Start(){
    }
 
}