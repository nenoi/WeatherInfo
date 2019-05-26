using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WeatherLoader : MonoBehaviour
{
    public string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";
    public string ApiKey = "a25aaf97996c55765f0c97c5c581eda9";
    public int TimeOutSeconds = 10;

    public IEnumerator Load(double latitude, double longitude, UnityAction<WeatherEntity> callback) {
        var url = string.Format("{0}?lat={1}&lon={2}&appid={3}", BaseUrl, latitude.ToString(), longitude.ToString(), ApiKey);
        var request = UnityWebRequest.Get(url);
        var progress = request.SendWebRequest();

        int waitSeconds = 0;
        while (!progress.isDone) {
            yield return new WaitForSeconds(1.0f);
            waitSeconds++;
            if (waitSeconds >= TimeOutSeconds) {
                Debug.Log("timeout:" + url);
                yield break;
            }
        }

        if (request.isNetworkError) {
            Debug.Log("error:" + url);
        }
        else {
            string jsonText = request.downloadHandler.text;
            Debug.Log("Weatherloader download jsonText:" + jsonText);
            callback(JsonUtility.FromJson<WeatherEntity>(jsonText));
            yield break;
        }
    }
}
