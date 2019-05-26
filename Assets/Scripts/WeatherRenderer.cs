using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherRenderer : MonoBehaviour
{
    public float latitude;
    public float longitude;
    public WeatherLoader Loader;
    public Text CityNameText;
    public Text WeatherText;
    public Text TemperatureText;
    public Text WindForceText;

    void Start() {
        StartCoroutine(Loader.Load(latitude, longitude, weatherEntity => {
            Render(weatherEntity);
        }));
    }

    // UIのTextを更新する
    void Render(WeatherEntity weatherEntity) {
        CityNameText.text = string.Format("都市名: {0}", weatherEntity.name);
        WeatherText.text = string.Format("天気: {0}", weatherEntity.weather[0].main);
        TemperatureText.text = string.Format("気温: {0}", weatherEntity.main.temp - 273); // 気温（ケルビン）を摂氏に変換するため273.15を引いている
        WindForceText.text = string.Format("風速: {0}m/s", weatherEntity.wind.speed);
    }
}
