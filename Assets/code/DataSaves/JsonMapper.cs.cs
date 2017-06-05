using System;
using UnityEngine;
using System.Collections;
 
public class JsonMapper
{
    static JsonMapper()
    {
        LitJson.JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));
        LitJson.JsonMapper.RegisterExporter<decimal>((obj, writer) => writer.Write(Convert.ToString(obj)));
        LitJson.JsonMapper.RegisterImporter<double, float>(input => Convert.ToSingle(input));
        LitJson.JsonMapper.RegisterImporter<int, long>(input => Convert.ToInt64(input));
        LitJson.JsonMapper.RegisterImporter<string, decimal>(input => Convert.ToDecimal(input));
        //      Debug.Log ("Mappingします");
    }
 
    public static T ToObject<T>( string json )
    {
 
        return LitJson.JsonMapper.ToObject<T>( json );
    }
 
    public static string ToJson( object obj )
    {
        return LitJson.JsonMapper.ToJson ( obj );
    }
}